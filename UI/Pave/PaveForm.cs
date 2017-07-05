using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
namespace RevitRedevelop.UI.Pave
{

    public partial class PaveForm : System.Windows.Forms.Form
    {
        #region Fields

        PaveDocument m_paveDocument;

        #endregion

        #region Constructors
        public PaveForm(PaveDocument pDoc)
        {
            m_paveDocument = pDoc;
            if (null == m_paveDocument.UIDocument)
            {
                this.Close();
            }
            InitializeComponent();
            InitializeCustomComponent();

        }
        #endregion


        #region Private methods

        private void InitializeCustomComponent()
        {
            //遍历每个房间的名字加入到下拉框中
            foreach (RoomGeometry room in m_paveDocument.Apartment)
            {
                roomComboBox.Items.Add(room.Room.Name);
            }
            //添加铺贴方式
            paveTypeSelectBox.Items.Add(m_paveDocument.PaveTypes[0]);
            paveTypeSelectBox.Items.Add(m_paveDocument.PaveTypes[1]);
            tileSelectBox.Items.Add(m_paveDocument.TileTypes[0]);
            tileSelectBox.Items.Add(m_paveDocument.TileTypes[1]);

        }
        #endregion

        #region NoUse
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void pavaButton_Click(object sender, EventArgs e)
        {
            if (true == m_paveDocument.SelectRoom.HaveRoof)
            {
                Transaction delete_roof = new Transaction(m_paveDocument.Document, Guid.NewGuid().GetHashCode().ToString());
                delete_roof.Start();
                m_paveDocument.Document.Delete(m_paveDocument.SelectRoom.Roof.Id);
                m_paveDocument.SelectRoom.HaveRoof = false;
                delete_roof.Commit();
            }
            FootPrintRoof roof = m_paveDocument.RoofGeometry.CreateCurtainRoof();
            if (null == roof)
            {
                return;
            }
            m_paveDocument.SelectRoom.Roof = roof;
            m_paveDocument.SelectRoom.HaveRoof = true;

            m_paveDocument.GridGeometry.ReloadGeometryData();
        }

        private void roomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = roomComboBox.SelectedIndex;
            m_paveDocument.SelectRoom = (RoomGeometry)m_paveDocument.Apartment[indexSelected];
            //高亮显示选择的房间。
            IList<ElementId> list = new List<ElementId>();
            list.Add(m_paveDocument.SelectRoom.Room.Id);
            m_paveDocument.UIDocument.Selection.SetElementIds(list);
        }
        private void templetButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PaveForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.roomComboBox.SelectedIndex = 0;
                this.paveTypeSelectBox.SelectedIndex = 0;
                this.tileSelectBox.SelectedIndex = 0;
            }
            catch
            {
                TaskDialog.Show("提示", "请为房间标识类型");
            }


        }
        private void curtainRoofPictureBox_Paint(object sender, EventArgs e)
        {

        }

        private void paveTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = paveTypeSelectBox.SelectedIndex;
            if (indexSelected == 0)
            {
                m_paveDocument.GridGeometry.IsStraight = true;
                m_paveDocument.GridGeometry.IsSlope = false;
            }
            else if (indexSelected == 1)
            {
                m_paveDocument.GridGeometry.IsStraight = false;
                m_paveDocument.GridGeometry.IsSlope = true;
            }
            else
            {
                m_paveDocument.GridGeometry.IsStraight = false;
                m_paveDocument.GridGeometry.IsSlope = false;
            }


        }

        private void tileSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = tileSelectBox.SelectedIndex;
            if (indexSelected == 0)
            {
                m_paveDocument.GridGeometry.TileLength = 1600;
                m_paveDocument.GridGeometry.TileWidth = 1600;
            }
            else if (indexSelected == 1)
            {
                m_paveDocument.GridGeometry.TileLength = 800;
                m_paveDocument.GridGeometry.TileWidth = 800;
            }
            else
            {
                m_paveDocument.GridGeometry.TileLength = 0;
                m_paveDocument.GridGeometry.TileWidth = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Floor f = m_paveDocument.FloorGeometry.CreateCurtainFloor();

        }



    }
}
