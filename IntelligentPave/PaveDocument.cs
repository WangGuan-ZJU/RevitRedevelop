using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

using System.Linq;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace RevitRedevelop.UI.Pave
{
    public class PaveDocument
    {
        #region Fields
        ExternalCommandData m_commandData;
        Document m_document;
        List<Autodesk.Revit.DB.View> m_views;
        Level m_level;
        List<RoofType> m_roofTypes;
        List<RoomGeometry> m_apartment;
        UIDocument m_uiDocument;
        RoofGeometry m_roofGeometry;
        FloorGeometry m_floorGeometry;
        GridGeometry m_gridGeometry;

        RoomGeometry m_selectRoom;

        RoofType m_roofType;

        List<String> m_paveTypes;
        List<String> m_tileTypes;
        bool m_roofCreated;
        public ExternalCommandData CommandData
        {
            get
            {
                return m_commandData;
            }
        }
        public RoomGeometry SelectRoom
        {
            get
            {
                return m_selectRoom;
            }
            set
            {
                m_selectRoom = value;
            }
        }
        public FloorGeometry FloorGeometry
        {
            get
            {
                return m_floorGeometry;
            }
        }
        public Level Level
        {
            get
            {
                return m_level;
            }
        }

        public List<RoofType> RoofTypes
        {
            get
            {
                return m_roofTypes;
            }
        }

        public UIDocument UIDocument
        {
            get
            {
                return m_uiDocument;
            }
        }

        public Document Document
        {
            get
            {
                return m_document;
            }
        }

        public List<Autodesk.Revit.DB.View> Views
        {
            get
            {
                return m_views;
            }
        }

        public RoofGeometry RoofGeometry
        {
            get
            {
                return m_roofGeometry;
            }
        }

        public GridGeometry GridGeometry
        {
            get
            {
                return m_gridGeometry;
            }
        }

        public List<String> PaveTypes
        {
            get
            {
                return m_paveTypes;
            }
        }

        public RoofType RoofType
        {
            get
            {
                return m_roofType;
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

        public List<String> TileTypes
        {
            get
            {
                return m_tileTypes;
            }
        }

        public List<RoomGeometry> Apartment
        {
            get
            {
                return m_apartment;
            }
        }

        #endregion

        #region Construct

        public PaveDocument(ExternalCommandData commandData)
        {
            if (null != commandData.Application.ActiveUIDocument)
            {
                m_commandData = commandData;
                m_uiDocument = m_commandData.Application.ActiveUIDocument;
                m_document = m_uiDocument.Document;
                m_views = new List<Autodesk.Revit.DB.View>();
                m_roofGeometry = new RoofGeometry(this);
                m_floorGeometry = new FloorGeometry(this);
                m_roofCreated = false;
                m_gridGeometry = new GridGeometry(this);
                m_selectRoom = new RoomGeometry(this);
                m_paveTypes = new List<String>();
                m_tileTypes = new List<String>();
                m_apartment = new List<RoomGeometry>();
                InitializeData();
            }
        }

        private void InitializeData()
        {
            // get all the wall types
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(m_document);
            filteredElementCollector.OfClass(typeof(RoofType));
            // just get all the curtain wall type
            m_roofType = filteredElementCollector.FirstOrDefault() as RoofType;
            // get all the ViewPlans
            m_views = SkipTemplateViews(GetElements<Autodesk.Revit.DB.View>());

            m_level = new FilteredElementCollector(m_document).OfClass(typeof(Level)).OrderBy(o => (o as Level).ProjectElevation).ElementAt(4) as Level;

            // sort them alphabetically
            ViewComparer viewComp = new ViewComparer();
            m_views.Sort(viewComp);

            //get all room name
            RoomFilter roomFilter = new RoomFilter();
            RoomTagFilter roomTagFilter = new RoomTagFilter();
            LogicalOrFilter orFilter = new LogicalOrFilter(roomFilter, roomTagFilter);

            FilteredElementIterator elementIterator =
                (new FilteredElementCollector(m_document)).WherePasses(orFilter).GetElementIterator();
            elementIterator.Reset();
            while (elementIterator.MoveNext())
            {
                object obj = elementIterator.Current;

                // find the rooms, skip those rooms which don't locate at Level yet.
                Room tmpRoom = obj as Room;
                if (null != tmpRoom && null != m_document.GetElement(tmpRoom.LevelId))
                {
                    RoomGeometry rg = new RoomGeometry(this);
                    rg.Room = tmpRoom;
                    Apartment.Add(rg);
                    continue;
                }
            }
            m_paveTypes.Add("正铺");
            m_paveTypes.Add("斜铺");
            //如果是1600的砖块就载入1600大小的砖块
            m_tileTypes.Add("1600mm*1600mm");
            m_tileTypes.Add("800mm*800mm");

        }

        private List<T> SkipTemplateViews<T>(List<T> views) where T : Autodesk.Revit.DB.View
        {
            List<T> returns = new List<T>();
            foreach (Autodesk.Revit.DB.View curView in views)
            {
                if (null != curView && !curView.IsTemplate)
                    returns.Add(curView as T);
            }
            return returns;
        }

        protected List<T> GetElements<T>() where T : Element
        {
            List<T> returns = new List<T>();
            FilteredElementCollector collector = new FilteredElementCollector(m_document);
            ICollection<Element> founds = collector.OfClass(typeof(T)).ToElements();
            foreach (Element elem in founds)
            {
                returns.Add(elem as T);
            }
            return returns;
        }
        #endregion
    }
}
