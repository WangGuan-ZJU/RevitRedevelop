using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Architecture;

namespace RevitRedevelop.UI.Pave
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Pave  : IExternalCommand
    {
        //需要拆分下这个类 把房间、屋顶等对象提取出来单独当做一个类
        //查看一下footcurtainroof中curtaingrid中存储的东西是什么
        #region Fields
        
        Document document;
        UIDocument uidoc;
        List<Room> m_rooms = new List<Room>();
        List<RoomTag> m_roomTags = new List<RoomTag>();
        List<RoofType> m_roofTypes;
        List<Autodesk.Revit.DB.View> m_views;
        private FootPrintRoof m_footPrintRoof;
        bool m_roofCreated;
        #endregion

        #region Properties
        public FootPrintRoof PrintRoof
        {
            get
            {
                return m_footPrintRoof;
            }
        }

        public bool RoofCreated
        {
            get
            {
                return m_roofCreated;
            }
            set
            {
                m_roofCreated = value;
            }
        }
        #endregion

        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
           ElementSet elements)
        {
            uidoc = commandData.Application.ActiveUIDocument;
            document = commandData.Application.ActiveUIDocument.Document;
            UIApplication app = commandData.Application;
            m_roofCreated = false;
            Transaction open_family = new Transaction(document, Guid.NewGuid().GetHashCode().ToString());
            open_family.Start();
            document.LoadFamily(@"C:\ProgramData\Autodesk\RVT 2015\Libraries\China\建筑\按填充图案划分的幕墙嵌板\矩形表面.rfa");
            open_family.Commit();
            PaveDocument pDoc = new PaveDocument(commandData);
            //using (PaveForm paveForm = new PaveForm(pDoc))
            //{
            //    if (null != paveForm && false == paveForm.IsDisposed)
            //    {
            //        paveForm.ShowDialog();
            //    }
            //}
            Transaction act = new Transaction(document, Guid.NewGuid().GetHashCode().ToString());
            act.Start();
            FamilySymbol familySymbol = null;
            FilteredElementCollector collector = new FilteredElementCollector(document);//过滤元素
            ICollection<Element> collection = collector.OfClass(typeof(FamilySymbol)).ToElements();
            foreach (Element e in collection)
            {
                familySymbol = e as FamilySymbol;
                if (null != familySymbol.Category)
                {

                    //遍历族符号的方法
                    FamilySymbolSetIterator symbolItor = familySymbol.Family.Symbols.ForwardIterator();
                    FamilySymbol fs = null;
                    while (symbolItor.MoveNext())
                    {
                        fs = symbolItor.Current as FamilySymbol;
                    }
                }
            }
            double length = 3.93700787401575;
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    XYZ point = new XYZ(-10 + y * length, 0 - i * length, 0);
                    FamilyInstance fi = document.Create.NewFamilyInstance(point, familySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);

                }
            }

            act.Commit();
            return Result.Succeeded;
        }

        
        //获取楼层信息
        private void Getinfo_Level()
        {
            StringBuilder levelInformation = new StringBuilder();
            int levelNumber = 0;
            FilteredElementCollector collector = new FilteredElementCollector(document);
            ICollection<Element> collection = collector.OfClass(typeof(Level)).ToElements();
            foreach (Element e in collection)
            {
                Level level = e as Level;

                if (null != level)
                {
                    // keep track of number of levels
                    levelNumber++;

                    //get the name of the level
                    levelInformation.Append("\nLevel Name: " + level.Name);

                    //get the elevation of the level
                    levelInformation.Append("\n\tElevation: " + level.Elevation);

                    // get the project elevation of the level
                    levelInformation.Append("\n\tProject Elevation: " + level.ProjectElevation);
                }
            }

            //number of total levels in current document
            levelInformation.Append("\n\n There are " + levelNumber + " levels in the document!");

            //show the level information in the messagebox
            TaskDialog.Show("Revit", levelInformation.ToString());
        }

        //获取所有的房间和标签
        private void GetAllRoomsAndTags()
        {
            //先清空当前的房间
            if(m_rooms.Count!=0||m_roomTags.Count!=0)
            {
                m_rooms.Clear();
                m_roomTags.Clear();
            }
            else
            {
                // get the active document
                RoomFilter roomFilter = new RoomFilter();
                RoomTagFilter roomTagFilter = new RoomTagFilter();
                LogicalOrFilter orFilter = new LogicalOrFilter(roomFilter, roomTagFilter);

                FilteredElementIterator elementIterator =
                    (new FilteredElementCollector(document)).WherePasses(orFilter).GetElementIterator();
                elementIterator.Reset();

                // try to find all the rooms and room tags in the project and add to the list
                while (elementIterator.MoveNext())
                {
                    object obj = elementIterator.Current;

                    // find the rooms, skip those rooms which don't locate at Level yet.
                    Room tmpRoom = obj as Room;
                    if (null != tmpRoom && null != document.GetElement(tmpRoom.LevelId))
                    {
                        m_rooms.Add(tmpRoom);
                        continue;
                    }

                    // find the room tags
                    RoomTag tmpTag = obj as RoomTag;
                    if (null != tmpTag)
                    {
                        
                        m_roomTags.Add(tmpTag);
                        continue;
                    }
                }
            }
            
        }

        //获取房间的几何信息
        private String getRoomGeometry(Room room)
        {

            CurveArray boundaryLines = new CurveArray();
            string message = "BoundarySegment";
            using (Transaction ts_curve = new Transaction(document))
            {
                ts_curve.Start("create Curve");
                SpatialElementBoundaryOptions opt = new SpatialElementBoundaryOptions();
                opt.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
                IList<IList<Autodesk.Revit.DB.BoundarySegment>> loops = room.GetBoundarySegments(opt);
                foreach (IList<Autodesk.Revit.DB.BoundarySegment> loop in loops)
                {
                    foreach (Autodesk.Revit.DB.BoundarySegment seg in loop)
                    {
                        message += "\nCurve start point: (" + seg.Curve.GetEndPoint(0).X + ","
                                + seg.Curve.GetEndPoint(0).Y + "," +
                               seg.Curve.GetEndPoint(0).Z + ")";

                        message += ";\nCurve end point: (" + seg.Curve.GetEndPoint(1).X + ","
                             + seg.Curve.GetEndPoint(1).Y + "," +
                             seg.Curve.GetEndPoint(1).Z + ")";
                        Curve curve = seg.Curve;
                        //DetailCurve dc = doc.Create.NewDetailCurve(uidoc.ActiveView, curve);
                        boundaryLines.Append(curve);
                    }
                }
                ts_curve.Commit();
            }
            //creatFloor(boundaryLines);
            return message;
        }

        //创建一个玻璃斜窗
        public void CreaterRoof()
        {

            FilteredElementCollector collector = new FilteredElementCollector(document);
            Level level = new FilteredElementCollector(document).OfClass(typeof(Level)).OrderBy(o => (o as Level).ProjectElevation).ElementAt(4) as Level;
            collector = new FilteredElementCollector(document);
            collector.OfClass(typeof(RoofType));
            RoofType roofType = collector.FirstOrDefault() as RoofType;
            TaskDialog.Show("aaaa", "\t"+roofType.Name+level.Name);
            // Get the handle of the application
            Autodesk.Revit.ApplicationServices.Application application = document.Application;

            // Define the footprint for the roof based on user selection
            CurveArray footprint = application.Create.NewCurveArray();
            UIDocument uidoc = new UIDocument(document);
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
            if (selectedIds.Count != 0)
            {
                foreach (ElementId id in selectedIds)
                {
                    Element element = document.GetElement(id);
                    Wall wall = element as Wall;
                    if (wall != null)
                    {
                        LocationCurve wallCurve = wall.Location as LocationCurve;
                        footprint.Append(wallCurve.Curve);
                        continue;
                    }

                    ModelCurve modelCurve = element as ModelCurve;
                    if (modelCurve != null)
                    {
                        footprint.Append(modelCurve.GeometryCurve);
                    }
                }
                //TaskDialog.Show("sssss", "\t\n" + selectedIds.Count);

            }
            //else
            //{
            //    throw new Exception("You should select a curve loop, or a wall loop, or loops combination \nof walls and curves to create a footprint roof.");
            //}

            ModelCurveArray footPrintToModelCurveMapping = new ModelCurveArray();
            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("creat printroof");
                m_footPrintRoof = document.Create.NewFootPrintRoof(footprint, level, roofType, out footPrintToModelCurveMapping);
                m_roofCreated = true;
                transaction.Commit();
            }
            ModelCurveArrayIterator iterator = footPrintToModelCurveMapping.ForwardIterator();
            //iterator.Reset();
            //while (iterator.MoveNext())
            //{
            //    ModelCurve modelCurve = iterator.Current as ModelCurve;
            //    footprintRoof.set_DefinesSlope(modelCurve, true);
            //    footprintRoof.set_SlopeAngle(modelCurve, 0.5);
            //}
           
        }

        public void CreateWallUsingCurve2()
        {
            List<WallType> m_wallTypes;
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document);
            filteredElementCollector.OfClass(typeof(WallType));
            // just get all the curtain wall type
            m_wallTypes = filteredElementCollector.Cast<WallType>().Where<WallType>(wallType => wallType.Kind == WallKind.Curtain).ToList<WallType>();
            Level level = new FilteredElementCollector(document).OfClass(typeof(Level)).OrderBy(o => (o as Level).ProjectElevation).ElementAt(4) as Level;
            
            // Build a location line for the wall creation
            XYZ start = new XYZ(0, 0, 0);
            XYZ end = new XYZ(10, 10, 0);
            Line geomLine = Line.CreateBound(start, end);
            // Determine the other parameters
            double height = 15;
            double offset = 3;
            using (Transaction ts = new Transaction(document))
            {
                ts.Start("creat wall");
                // Create a wall using the location line and wall type
                Wall.Create(document, geomLine, m_wallTypes[0].Id, level.Id, height, offset, true, true);
                ts.Commit();
            }
            
        }

    }
}
