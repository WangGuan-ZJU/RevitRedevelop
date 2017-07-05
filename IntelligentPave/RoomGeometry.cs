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

    public class RoomGeometry
    {
        #region Fields

        Room m_room;

        Room m_selectedRoom;

        FootPrintRoof m_roof;

        bool have_roof = false;

        CurveArray m_boundaryLines;

        PaveDocument m_paveDocument;

        private ExternalCommandData m_commandData;

        private Document m_activeDocument;

        #endregion

        #region Properties

        public PaveDocument PaveDocument
        {
            get
            {
                return m_paveDocument;
            }
        }
        public Room Room
        {
            get
            {
                return m_room;
            }
            set
            {
                m_room = value;
            }
        }

        public FootPrintRoof Roof
        {
            get
            {
                return m_roof;
            }
            set
            {
                m_roof = value;
            }
        }

        public Room SelectedRoom
        {
            get
            {
                return m_selectedRoom;
            }
            set
            {
                m_selectedRoom = value;
            }
        }

        public bool HaveRoof
        {
            get
            {
                return have_roof;
            }
            set
            {
                have_roof = value;
            }
        }

        #endregion

        #region Construct

        public RoomGeometry(PaveDocument pDoc)
        {

            m_paveDocument = pDoc;
            m_activeDocument = pDoc.Document;
            m_commandData = pDoc.CommandData;
            m_boundaryLines = new CurveArray();

        }

        #endregion




    }
}
