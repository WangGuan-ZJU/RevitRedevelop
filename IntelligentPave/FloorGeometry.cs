using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Architecture;
namespace RevitRedevelop.UI.Pave

{
    public class FloorGeometry
    {
        #region Fields
        private Document m_activeDocument;
        private Level m_level;
        PaveDocument m_paveDocument;

        CurveArray m_boundaryLines;
        #endregion

        #region Properties

        public PaveDocument PaveDocument
        {
            get
            {
                return m_paveDocument;
            }
        }
        public Document Document
        {
            get
            {
                return m_activeDocument;
            }
        }
        public CurveArray BoundaryLines
        {

            get
            {
                return m_boundaryLines;
            }
        }
        #endregion

        #region Construct

        public FloorGeometry(PaveDocument m_paveDoc)
        {
            m_paveDocument = m_paveDoc;
            m_activeDocument = m_paveDoc.Document;
            m_boundaryLines = new CurveArray();

        }

        #endregion

        #region Method
        /**
         * 
         * 根据房间的边界线生成楼板
         * 
         */
        public Floor CreateCurtainFloor()
        {
            m_boundaryLines = GetBoundaryLines(m_paveDocument.SelectRoom.Room);

            FloorType floorType = new FilteredElementCollector(m_activeDocument).OfClass(typeof(FloorType)).FirstElement() as FloorType;
            Transaction creat_floor = new Transaction(m_activeDocument, Guid.NewGuid().GetHashCode().ToString());
            creat_floor.Start();
            Floor floor = m_activeDocument.Create.NewFloor(m_boundaryLines, floorType, m_paveDocument.Level, false, XYZ.BasisZ);
            creat_floor.Commit();
            CompoundStructure com = floor.FloorType.GetCompoundStructure();
            if (null == com)
            {
                return null;
            }
            if (com.LayerCount > 0)
            {
                foreach (CompoundStructureLayer comlayer in com.GetLayers())
                {

                }
            }
            return floor;
        }

        private CurveArray GetBoundaryLines(Room room)
        {
            CurveArray BoundaryLines = new CurveArray();
            SpatialElementBoundaryOptions opt = new SpatialElementBoundaryOptions();
            opt.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
            IList<IList<Autodesk.Revit.DB.BoundarySegment>> loops = room.GetBoundarySegments(opt);
            foreach (IList<Autodesk.Revit.DB.BoundarySegment> loop in loops)
            {

                foreach (Autodesk.Revit.DB.BoundarySegment seg in loop)
                {
                    Wall wall = seg.Element as Wall;
                    Curve curve = seg.Curve;
                    //DetailCurve dc = doc.Create.NewDetailCurve(uidoc.ActiveView, curve);
                    BoundaryLines.Append(curve);
                }
            }
            return BoundaryLines;
        }

        #endregion
    }
}
