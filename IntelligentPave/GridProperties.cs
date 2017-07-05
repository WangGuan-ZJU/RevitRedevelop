using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitRedevelop.UI.Pave
{
    //此类需要修改
    public enum CurtainGridAlign
   {
      Beginning,
      Center,
      End
   }

    public class GridProperties
    {
        #region Fields
        private CurtainGridAlign m_verticalJustification;

        // stores the data of vertical angle
        private double m_verticalAngle;

        // stores the data of vertical offset
        private double m_verticalOffset;

        // stores how many vertical lines there are in the grid
        private int m_verticalLinesNumber;

        // stores the data of horizontal justification
        private CurtainGridAlign m_horizontalJustification;

        // stores the data of horizontal angle
        private double m_horizontalAngle;

        // stores the data of horizontal offset
        private double m_horizontalOffset;

        // stores how many horizontal lines there are in the grid
        private int m_horizontalLinesNumber;

        // stores how many panels there are in the grid
        private int m_panelNumber;

        // stores how many curtain cells there are in the grid
        private int m_cellNumber;

        // stores how many unlocked panels there are in the grid
        private int m_unlockedPanelsNumber;

        // stores how many mullions there are in the grid
        private int m_mullionsNumber;

        // stores how many unlocked mullions there are in the grid
        private int m_unlockedmullionsNumber;

        #endregion
    }
}
