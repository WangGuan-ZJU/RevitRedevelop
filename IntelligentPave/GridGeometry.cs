using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitRedevelop.UI.Pave
{
    public class GridGeometry
    {
        #region Fields
        //object which contains reference of Revit Application
        private PaveDocument m_paveDocument;

        private ExternalCommandData m_commandData;

        // the active document of Revit
        private Document m_activeDocument;

        // stores the curtain grid information of the created curtain wall
        private CurtainGrid m_activeGrid;

        private MullionType m_mullionType;

        private CurtainGridSet m_activeGridSet;

        // all the grid lines of U direction (in CurtainGridLine format)
        private List<CurtainGridLine> m_uGridLines;

        // all the grid lines of V direction (in CurtainGridLine format)
        private List<CurtainGridLine> m_vGridLines;

        // stores all the vertexes of the curtain grid (in Autodesk.Revit.DB.XYZ format)
        private List<Autodesk.Revit.DB.XYZ> m_GridVertexesXYZ;

        // store the grid line to be removed
        private CurtainGridLine m_lineToBeMoved = null;

        private bool is_Straight = false;

        private bool is_Slope = false;

        private double m_tileLength;
        private double m_tileWidth;

        // store the offset to be moved for the specified grid line
        private int m_moveOffset = 0;
        #endregion

        #region Properties
        public bool IsStraight
        {
            get
            {
                return is_Straight;
            }
            set
            {
                is_Straight = value;
            }
        }

        public bool IsSlope
        {
            get
            {
                return is_Slope;
            }
            set
            {
                is_Slope = value;
            }
        }
        public double TileLength
        {
            get
            {
                return m_tileLength;
            }
            set
            {
                m_tileLength = value;
            }
        }

        public double TileWidth
        {
            get
            {
                return m_tileWidth;
            }
            set
            {
                m_tileWidth = value;
            }
        }
        //返回一些私有属性
        public CurtainGrid ActiveGrid
        {
            get
            {
                return m_activeGrid;
            }
        }

        public List<CurtainGridLine> UGridLines
        {
            get
            {
                return m_uGridLines;
            }
        }

        public List<CurtainGridLine> VGridLines
        {
            get
            {
                return m_vGridLines;
            }
        }

        public List<Autodesk.Revit.DB.XYZ> GridVertexesXYZ
        {
            get
            {
                return m_GridVertexesXYZ;
            }
        }


        public CurtainGridLine LineToBeMoved
        {
            get
            {
                return m_lineToBeMoved;
            }
        }

        public int MoveOffset
        {
            get
            {
                return m_moveOffset;
            }
            set
            {
                m_moveOffset = value;
            }
        }

        public MullionType MullionType
        {
            get
            {
                return m_mullionType;
            }
            set
            {
                m_mullionType = value;
            }
        }

        #endregion

        #region Constructors

        public GridGeometry(PaveDocument m_paveDoc)
        {
            m_paveDocument = m_paveDoc;
            m_commandData = m_paveDoc.CommandData;
            m_activeDocument = m_paveDoc.Document;
            m_uGridLines = new List<CurtainGridLine>();
            m_vGridLines = new List<CurtainGridLine>();
            m_GridVertexesXYZ = new List<Autodesk.Revit.DB.XYZ>();
        }
        #endregion

        #region Public methods

        public void ReloadGridProperties()
        {
            if (null == m_activeGridSet)
            {
                if (true == m_paveDocument.RoofCreated)
                {
                    m_activeGridSet = m_paveDocument.SelectRoom.Roof.CurtainGrids;

                }
                else
                {
                    return;
                }

            }

        }

        public void ReloadGeometryData()
        {
            if (true == m_paveDocument.SelectRoom.HaveRoof)
            {
                m_activeGridSet = m_paveDocument.SelectRoom.Roof.CurtainGrids;
            }
            else
            {
                return;
            }
            Transaction act = new Transaction(m_activeDocument, Guid.NewGuid().GetHashCode().ToString());
            act.Start();

            IEnumerator enumerator = m_activeGridSet.GetEnumerator();
            while (enumerator.MoveNext())
            {
                m_activeGrid = (CurtainGrid)enumerator.Current;
            }

            ICollection<ElementId> mullions = m_activeGrid.GetMullionIds();

            act.Commit();

            if (0 == mullions.Count)
            {
                foreach (ElementId e in mullions)
                {
                    Mullion mullion = m_activeDocument.GetElement(e) as Mullion;

                    if (null != mullion)
                    {
                        m_mullionType = mullion.MullionType;
                        break;
                    }
                }
            }
            if (is_Straight)
            {
                StraightPave();
            }
            else if (is_Slope)
            {
                SlopePave();
            }


        }

        public void StraightPave()
        {
            CurtainGridLine newLine;
            double minX = m_paveDocument.RoofGeometry.RoomBoundBox.minX;
            double minY = m_paveDocument.RoofGeometry.RoomBoundBox.minY;
            double maxX = m_paveDocument.RoofGeometry.RoomBoundBox.maxX;
            double maxY = m_paveDocument.RoofGeometry.RoomBoundBox.maxY;
            double total_length = m_paveDocument.RoofGeometry.RoomBoundBox.length;
            double total_width = m_paveDocument.RoofGeometry.RoomBoundBox.width;
            double x, y;
            //转换
            FormatOptions formatOption = m_activeDocument.GetUnits().GetFormatOptions(UnitType.UT_Length);
            //把标识数据转化为内部数据
            double tile_length = UnitUtils.ConvertToInternalUnits(TileLength, formatOption.DisplayUnits);
            double tile_width = UnitUtils.ConvertToInternalUnits(TileWidth, formatOption.DisplayUnits);
            double row = total_length / tile_length;
            double col = total_width / tile_width;
            //从中间往两边铺贴
            //找到中心点
            //往两边铺贴
            double center_x = minX + ((maxX - minX) / 2);
            double center_y = minY + ((maxY - minY) / 2);
            Transaction stright_pave = new Transaction(m_activeDocument, Guid.NewGuid().GetHashCode().ToString());
            XYZ point1 = new XYZ(60, 20, 0);
            XYZ point2 = new XYZ(-20, 10, 0);
            Line axis = Line.CreateBound(point1, point2);

            stright_pave.Start();
            try
            {

                //横向的网格线
                newLine = ActiveGrid.AddGridLine(true, new Autodesk.Revit.DB.XYZ(center_x, center_y, 0.0), false);

                for (double hi = center_y + tile_length; hi < maxY; hi += tile_length)
                {
                    newLine = ActiveGrid.AddGridLine(true, new Autodesk.Revit.DB.XYZ(center_x, hi, 0.0), false);
                }
                for (double low = center_y - tile_length; low > minY; low -= tile_length)
                {
                    newLine = ActiveGrid.AddGridLine(true, new Autodesk.Revit.DB.XYZ(center_x, low, 0.0), false);
                }
                //    newLine.Location.Rotate(axis, Math.PI / 4.0);
                //    ElementTransformUtils.RotateElement(m_activeDocument,newLine.Id, axis, Math.PI / 3.0);

                //纵向的网格线
                newLine = ActiveGrid.AddGridLine(false, new Autodesk.Revit.DB.XYZ(center_x, center_y, 0.0), false);
                for (double hi = center_x + tile_width; hi < maxX; hi += tile_width)
                {
                    newLine = ActiveGrid.AddGridLine(false, new Autodesk.Revit.DB.XYZ(hi, center_y, 0.0), false);
                }
                for (double low = center_x - tile_width; low > minX; low -= tile_width)
                {
                    newLine = ActiveGrid.AddGridLine(false, new Autodesk.Revit.DB.XYZ(low, center_y, 0.0), false);
                }


                //把内部数据转化为标识数据
                //double grid_angle = UnitUtils.ConvertToInternalUnits(45, formatOption.DisplayUnits);

                //ActiveGrid.Grid2Angle = grid_angle;
            }

            catch (System.Exception e)
            {
                TaskDialog.Show("Exception", e.Message);
                // "add U line" failed, so return directly
                return;
            }
            stright_pave.Commit();
        }

        public void SlopePave()
        {

            CurtainGridLine newLine;
            double minX = m_paveDocument.RoofGeometry.RoomBoundBox.minX;
            double minY = m_paveDocument.RoofGeometry.RoomBoundBox.minY;
            double maxX = m_paveDocument.RoofGeometry.RoomBoundBox.maxX;
            double maxY = m_paveDocument.RoofGeometry.RoomBoundBox.maxY;
            double total_length = m_paveDocument.RoofGeometry.RoomBoundBox.length;
            double total_width = m_paveDocument.RoofGeometry.RoomBoundBox.width;
            double x, y;
            //转换
            FormatOptions formatOption = m_activeDocument.GetUnits().GetFormatOptions(UnitType.UT_Length);
            //把标识数据转化为内部数据
            double tile_length = UnitUtils.ConvertToInternalUnits(TileLength, formatOption.DisplayUnits);
            double tile_width = UnitUtils.ConvertToInternalUnits(TileWidth, formatOption.DisplayUnits);
            double row = total_length / tile_length;
            double col = total_width / tile_width;
            //从中间往两边铺贴
            //找到中心点
            //往两边铺贴
            double center_x = minX + ((maxX - minX) / 2);
            double center_y = minY + ((maxY - minY) / 2);
            Transaction slope_pave = new Transaction(m_activeDocument, Guid.NewGuid().GetHashCode().ToString());
            XYZ point1 = new XYZ(60, 20, 0);
            XYZ point2 = new XYZ(-20, 10, 0);
            Line axis = Line.CreateBound(point1, point2);

            slope_pave.Start();
            try
            {
                formatOption = m_activeDocument.GetUnits().GetFormatOptions(UnitType.UT_Angle);
                double grid_angle = UnitUtils.ConvertToInternalUnits(45, formatOption.DisplayUnits);
                ActiveGrid.Grid2Angle = grid_angle;
                ActiveGrid.Grid1Angle = grid_angle;
                //横向的网格线
                newLine = ActiveGrid.AddGridLine(true, new Autodesk.Revit.DB.XYZ(center_x, center_y, 0.0), false);

                for (double hi = center_y + tile_length; hi < maxY; hi += tile_length)
                {
                    newLine = ActiveGrid.AddGridLine(true, new Autodesk.Revit.DB.XYZ(center_x, hi, 0.0), false);
                }
                for (double low = center_y - tile_length; low > minY; low -= tile_length)
                {
                    newLine = ActiveGrid.AddGridLine(true, new Autodesk.Revit.DB.XYZ(center_x, low, 0.0), false);
                }
                //    newLine.Location.Rotate(axis, Math.PI / 4.0);
                //    ElementTransformUtils.RotateElement(m_activeDocument,newLine.Id, axis, Math.PI / 3.0);

                //纵向的网格线
                newLine = ActiveGrid.AddGridLine(false, new Autodesk.Revit.DB.XYZ(center_x, center_y, 0.0), false);
                for (double hi = center_x + tile_width; hi < maxX; hi += tile_width)
                {
                    newLine = ActiveGrid.AddGridLine(false, new Autodesk.Revit.DB.XYZ(hi, center_y, 0.0), false);
                }
                for (double low = center_x - tile_width; low > minX; low -= tile_width)
                {
                    newLine = ActiveGrid.AddGridLine(false, new Autodesk.Revit.DB.XYZ(low, center_y, 0.0), false);
                }


            }

            catch (System.Exception e)
            {
                TaskDialog.Show("Exception", e.Message);
                // "add U line" failed, so return directly
                return;
            }
            slope_pave.Commit();
        }

        #endregion

        #region Private methods

        private void GetULines()
        {
            m_uGridLines.Clear();
            Transaction act = new Transaction(m_activeDocument, Guid.NewGuid().GetHashCode().ToString());
            act.Start();
            //ElementSet uLines = m_activeGrid.UGridLines;
            ICollection<ElementId> uLines = m_activeGrid.GetUGridLineIds();
            act.Commit();
            if (0 == uLines.Count)
            {
                return;
            }

            foreach (ElementId e in uLines)
            {
                CurtainGridLine line = m_activeDocument.GetElement(e) as CurtainGridLine;

                m_uGridLines.Add(line);
            }
        }


        private void GetVLines()
        {
            m_vGridLines.Clear();
            Transaction act = new Transaction(m_activeDocument, Guid.NewGuid().GetHashCode().ToString());
            act.Start();
            //ElementSet vLines = m_activeGrid.VGridLines;
            ICollection<ElementId> vLines = m_activeGrid.GetVGridLineIds();
            act.Commit();
            if (0 == vLines.Count)
            {
                return;
            }

            foreach (ElementId e in vLines)
            {
                CurtainGridLine line = m_activeDocument.GetElement(e) as CurtainGridLine;

                m_vGridLines.Add(line);
            }
        }

        private bool GetCurtainGridVertexes()
        {
            // even in "ReloadGeometryData()" method, no need to reload the boundary information
            // (as the boundary of the curtain grid won't be changed in the sample)
            // just need to load it after the curtain wall been created
            if (null != m_GridVertexesXYZ && 0 < m_GridVertexesXYZ.Count)
            {
                return true;
            }

            // the curtain grid is from "Curtain Wall: Curtain Wall 1" (by default, the "Curtain Wall 1" has no U/V grid lines)
            if (m_uGridLines.Count <= 0 || m_vGridLines.Count <= 0)
            {
                // special handling for "Curtain Wall: Curtain Wall 1"
                // as the "Curtain Wall: Curtain Wall 1" has no U/V grid lines, so we can't compute the boundary from the grid lines
                // as that kind of curtain wall contains only one curtain cell
                // so we compute the boundary from the data of the curtain cell
                // Obtain the geometry information of the curtain wall
                // also works with some curtain grids with only U grid lines or only V grid lines
                Transaction act = new Transaction(m_activeDocument, Guid.NewGuid().GetHashCode().ToString());
                act.Start();
                ICollection<CurtainCell> cells = m_activeGrid.GetCurtainCells();
                act.Commit();
                Autodesk.Revit.DB.XYZ minXYZ = new Autodesk.Revit.DB.XYZ(Double.MaxValue, Double.MaxValue, Double.MaxValue);
                Autodesk.Revit.DB.XYZ maxXYZ = new Autodesk.Revit.DB.XYZ(Double.MinValue, Double.MinValue, Double.MinValue);
                GetVertexesByCells(cells, ref minXYZ, ref maxXYZ);

                // move the U & V lines to the boundary of the curtain grid, and get their end points as the vertexes of the curtain grid
                m_GridVertexesXYZ.Add(new Autodesk.Revit.DB.XYZ(minXYZ.X, minXYZ.Y, minXYZ.Z));
                m_GridVertexesXYZ.Add(new Autodesk.Revit.DB.XYZ(maxXYZ.X, maxXYZ.Y, minXYZ.Z));
                m_GridVertexesXYZ.Add(new Autodesk.Revit.DB.XYZ(maxXYZ.X, maxXYZ.Y, maxXYZ.Z));
                m_GridVertexesXYZ.Add(new Autodesk.Revit.DB.XYZ(minXYZ.X, minXYZ.Y, maxXYZ.Z));
                return true;
            }
            else
            {
                // handling for the other kinds of curtain walls (contains U&V grid lines by default)
                CurtainGridLine uLine = m_uGridLines[0];
                CurtainGridLine vLine = m_vGridLines[0];

                List<Autodesk.Revit.DB.XYZ> points = new List<Autodesk.Revit.DB.XYZ>();

                Autodesk.Revit.DB.XYZ uStartPoint = uLine.FullCurve.GetEndPoint(0);
                Autodesk.Revit.DB.XYZ uEndPoint = uLine.FullCurve.GetEndPoint(1);

                Autodesk.Revit.DB.XYZ vStartPoint = vLine.FullCurve.GetEndPoint(0);
                Autodesk.Revit.DB.XYZ vEndPoint = vLine.FullCurve.GetEndPoint(1);

                points.Add(uStartPoint);
                points.Add(uEndPoint);
                points.Add(vStartPoint);
                points.Add(vEndPoint);

                //move the U & V lines to the boundary of the curtain grid, and get their end points as the vertexes of the curtain grid
                m_GridVertexesXYZ.Add(new Autodesk.Revit.DB.XYZ(uStartPoint.X, uStartPoint.Y, vStartPoint.Z));
                m_GridVertexesXYZ.Add(new Autodesk.Revit.DB.XYZ(uEndPoint.X, uEndPoint.Y, vStartPoint.Z));
                m_GridVertexesXYZ.Add(new Autodesk.Revit.DB.XYZ(uEndPoint.X, uEndPoint.Y, vEndPoint.Z));
                m_GridVertexesXYZ.Add(new Autodesk.Revit.DB.XYZ(uStartPoint.X, uStartPoint.Y, vEndPoint.Z));

                return true;
            }
        }

        private void GetVertexesByCells(ICollection<CurtainCell> cells, ref Autodesk.Revit.DB.XYZ minXYZ, ref Autodesk.Revit.DB.XYZ maxXYZ)
        {
            if (null == cells || cells.Count == 0)
            {
                return;
            }

            List<Autodesk.Revit.DB.XYZ> points = GetPoints(cells);
            GetVertexesByPoints(points, ref minXYZ, ref maxXYZ);
        }

        private void GetVertexesByPoints(List<Autodesk.Revit.DB.XYZ> points, ref Autodesk.Revit.DB.XYZ minXYZ, ref Autodesk.Revit.DB.XYZ maxXYZ)
        {
            if (null == points || 0 == points.Count)
            {
                return;
            }

            double minX = minXYZ.X;
            double minY = minXYZ.Y;
            double minZ = minXYZ.Z;
            double maxX = maxXYZ.X;
            double maxY = maxXYZ.Y;
            double maxZ = maxXYZ.Z;

            foreach (Autodesk.Revit.DB.XYZ xyz in points)
            {
                // compare the values and update the min and max value
                if (xyz.X < minX)
                {
                    minX = xyz.X;
                    minY = xyz.Y;
                }
                if (xyz.X > maxX)
                {
                    maxX = xyz.X;
                    maxY = xyz.Y;
                }

                if (xyz.Z < minZ)
                {
                    minZ = xyz.Z;
                }
                if (xyz.Z > maxZ)
                {
                    maxZ = xyz.Z;
                }
            } // end of loop

            minXYZ = new Autodesk.Revit.DB.XYZ(minX, minY, minZ);
            maxXYZ = new Autodesk.Revit.DB.XYZ(maxX, maxY, maxZ);
        }

        private List<Autodesk.Revit.DB.XYZ> GetPoints(ICollection<CurtainCell> cells)
        {
            List<Autodesk.Revit.DB.XYZ> points = new List<Autodesk.Revit.DB.XYZ>();

            if (null == cells || cells.Count == 0)
            {
                return points;
            }

            foreach (CurtainCell cell in cells)
            {
                if (null == cell || 0 == cell.CurveLoops.Size)
                {
                    continue;
                }

                CurveArray curves = cell.CurveLoops.get_Item(0);

                foreach (Curve curve in curves)
                {
                    points.Add(curve.GetEndPoint(0));
                    points.Add(curve.GetEndPoint(1));
                }
            }

            return points;
        }
        #endregion
    }
}
