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

    public class RoofGeometry
    {
        #region Fields
        public struct RoomBoundingBox
        {
            public double minX;
            public double minY;
            public double maxX;
            public double maxY;
            public double length;
            public double width;
        }
        private RoomBoundingBox m_roomBoundingBox;

        private Document m_activeDocument;

        PaveDocument m_paveDocument;

        CurveArray m_boundaryLines;

        private Autodesk.Revit.DB.ViewPlan m_selectedView;

        #endregion

        #region Properties
        public PaveDocument PaveDocument
        {
            get
            {
                return m_paveDocument;
            }
        }
        public RoomBoundingBox RoomBoundBox
        {

            get
            {
                return m_roomBoundingBox;
            }
        }
        public CurveArray BoundaryLines
        {

            get
            {
                return m_boundaryLines;
            }
        }

        public Document Document
        {
            get
            {
                return m_activeDocument;
            }
        }

        public Autodesk.Revit.DB.ViewPlan SelectedView
        {
            get
            {
                return m_selectedView;
            }
            set
            {
                m_selectedView = value;
            }
        }
        #endregion

        #region Construct

        public RoofGeometry(PaveDocument m_paveDoc)
        {
            m_paveDocument = m_paveDoc;
            m_activeDocument = m_paveDoc.Document;
            //初始化包围盒
            m_roomBoundingBox = new RoomBoundingBox();


        }
        #endregion

        #region public_method
        //记录下roof的包围盒信息
        public FootPrintRoof CreateCurtainRoof()
        {
            m_roomBoundingBox.maxX = -10000;
            m_roomBoundingBox.maxY = -10000;
            m_roomBoundingBox.minX = 10000;
            m_roomBoundingBox.minY = 10000;
            //获取房间的几何信息
            m_boundaryLines = new CurveArray();
            string message = "BoundarySegment";
            SpatialElementBoundaryOptions opt = new SpatialElementBoundaryOptions();
            opt.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
            IList<IList<Autodesk.Revit.DB.BoundarySegment>> loops = m_paveDocument.SelectRoom.Room.GetBoundarySegments(opt);
            foreach (IList<Autodesk.Revit.DB.BoundarySegment> loop in loops)
            {

                foreach (Autodesk.Revit.DB.BoundarySegment seg in loop)
                {
                    Wall wall = seg.Element as Wall;
                    m_roomBoundingBox.minX = Math.Min(seg.Curve.GetEndPoint(0).X, m_roomBoundingBox.minX);
                    m_roomBoundingBox.maxX = Math.Max(seg.Curve.GetEndPoint(0).X, m_roomBoundingBox.maxX);
                    m_roomBoundingBox.minY = Math.Min(seg.Curve.GetEndPoint(0).Y, m_roomBoundingBox.minY);
                    m_roomBoundingBox.maxY = Math.Max(seg.Curve.GetEndPoint(0).Y, m_roomBoundingBox.maxY);
                    message += "\nCurve start point: (" + seg.Curve.GetEndPoint(0).X + ","
                            + seg.Curve.GetEndPoint(0).Y + "," +
                           seg.Curve.GetEndPoint(0).Z + ")";

                    message += ";\nCurve end point: (" + seg.Curve.GetEndPoint(1).X + ","
                         + seg.Curve.GetEndPoint(1).Y + "," +
                         seg.Curve.GetEndPoint(1).Z + ")";
                    Curve curve = seg.Curve;
                    //DetailCurve dc = doc.Create.NewDetailCurve(uidoc.ActiveView, curve);
                    m_boundaryLines.Append(curve);
                }
            }

            m_roomBoundingBox.length = m_roomBoundingBox.maxY - m_roomBoundingBox.minY;
            m_roomBoundingBox.width = m_roomBoundingBox.maxX - m_roomBoundingBox.minX;
            Transaction creat_foot_roof = new Transaction(m_paveDocument.Document);
            ModelCurveArray footPrintToModelCurveMapping = new ModelCurveArray();
            creat_foot_roof.Start(Guid.NewGuid().GetHashCode().ToString());
            FootPrintRoof footPrintRoof = m_activeDocument.Create.NewFootPrintRoof(m_boundaryLines, m_paveDocument.Level, m_paveDocument.RoofType, out footPrintToModelCurveMapping);
            creat_foot_roof.Commit();
            Transaction show_roof = new Transaction(m_paveDocument.Document);
            show_roof.Start(Guid.NewGuid().GetHashCode().ToString());
            m_paveDocument.UIDocument.ShowElements(footPrintRoof);
            show_roof.Commit();

            return footPrintRoof;
        }
        #endregion
    }
}
