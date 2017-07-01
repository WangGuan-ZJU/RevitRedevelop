using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Autodesk.Revit.UI;

namespace RevitRedevelop.UI
{
    /// <summary>
    /// ChooseDoorSize.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseDoorSize : Page,Autodesk.Revit.UI.IDockablePaneProvider
    {
        public ChooseDoorSize()
        {
            InitializeComponent();
        }
        public void SetupDockablePane(DockablePaneProviderData data)
        {

            data.FrameworkElement = this as FrameworkElement;
            DockablePaneProviderData d = new DockablePaneProviderData();

            data.InitialState = new Autodesk.Revit.UI.DockablePaneState();
            //data.InitialState.SetFloatingRectangle(new Autodesk.Revit.UI.Rectangle(0,100,200,200));
            data.InitialState.DockPosition = Autodesk.Revit.UI.DockPosition.Tabbed;
        }

        private void lossfocus(object sender, RoutedEventArgs e)
        {
            var temp1 = txt1.Text;
            var temp2 = txt2.Text;

            List<RibbonPanel> listRobbonPanel = UIEntityApp.myApp.GetRibbonPanels("砖+宝");
            RibbonPanel ribbonpanel = null;
            foreach (RibbonPanel panel in listRobbonPanel)
            {
                if (panel.Name == "户型图")//RibbonPanel的Name
                {
                    ribbonpanel = panel;
                    break;
                }
            }
            IList<RibbonItem> listItem = ribbonpanel.GetItems();
            Autodesk.Revit.UI.TextBox txt = null;
            foreach (RibbonItem item in listItem)
            {
                if (item.Name == "InfoShow1")//Ribbon的Name属性
                {
                    txt = item as Autodesk.Revit.UI.TextBox;
                    txt.Value = temp1;
                }
                if (item.Name == "InfoShow2")//Ribbon的Name属性
                {
                    txt = item as Autodesk.Revit.UI.TextBox;
                    txt.Value = temp2;
                }
            }
            PaintData.DrawFloorPlanData.wallHeight = Convert.ToDouble(temp2);
            PaintData.DrawFloorPlanData.wallThickness = Convert.ToDouble(temp1);

            DockablePane pane = UIEntityApp.myApp.GetDockablePane(new DockablePaneId(new Guid(ConstGuid.ChooseSizeGuid)));
            pane.Hide();
        }
    }
}
