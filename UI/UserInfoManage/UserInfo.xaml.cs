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
    /// UserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfo : Page, Autodesk.Revit.UI.IDockablePaneProvider
    {
        private Autodesk.Revit.UI.UIApplication app;
        public UserInfo()
        {
            InitializeComponent();
        }
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            
            data.FrameworkElement = this as FrameworkElement;
            DockablePaneProviderData d = new DockablePaneProviderData();

            data.InitialState = new Autodesk.Revit.UI.DockablePaneState();
         //   data.InitialState.SetFloatingRectangle(new Autodesk.Revit.UI.Rectangle(0,100,200,200));
            data.InitialState.DockPosition = Autodesk.Revit.UI.DockPosition.Tabbed;
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            string guid = "ef5b0ecc-5859-4642-bb27-769393383d00";
            Guid retval = Guid.Empty;
            try
            {
                retval = new Guid(guid);
            }
            catch (Exception)
            {
                                         
            }
            
            DockablePaneId sm_UserDockablePaneId = new DockablePaneId(retval);
            app = UIEntityApp.myApp;
            DockablePane pane = app.GetDockablePane(sm_UserDockablePaneId);
            pane.Hide();                                    
            //Console.WriteLine("close");
        }
    }
}
