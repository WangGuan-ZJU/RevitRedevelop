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
    /// DrawFloorPlan.xaml 的交互逻辑
    /// </summary>
    ///     
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public partial class DrawFloorPlan : Page, Autodesk.Revit.UI.IDockablePaneProvider
    {
         private Autodesk.Revit.UI.UIApplication app;
         public DrawFloorPlan()
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

        private void CreateWall(object sender, RoutedEventArgs e)
        {
            //UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            //Autodesk.Revit.Creation.Application creApp = uiDoc.Document.Application.Create;
            //Autodesk.Revit.Creation.Document creDoc = uiDoc.Document.Create;
            //List<Curve> curves = new List<Curve>();
            ////create rectangular curve: wall length: 60 , wall width: 40
            //Line line1 = Line.CreateBound(new Autodesk.Revit.DB.XYZ(0, 0, 0),
            //   new Autodesk.Revit.DB.XYZ(0, 60, 0));
            //Line line2 = Line.CreateBound(new Autodesk.Revit.DB.XYZ(0, 60, 0),
            //   new Autodesk.Revit.DB.XYZ(0, 60, 40));
            //Line line3 = Line.CreateBound(new Autodesk.Revit.DB.XYZ(0, 60, 40),
            //   new Autodesk.Revit.DB.XYZ(0, 0, 40));
            //Line line4 = Line.CreateBound(new Autodesk.Revit.DB.XYZ(0, 0, 40),
            //   new Autodesk.Revit.DB.XYZ(0, 0, 0));
            //curves.Add(line1);
            //curves.Add(line2);
            //curves.Add(line3);
            //curves.Add(line4);
            ////create wall
            //Wall.Create(uiDoc.Document, curves, false);
           // app = UIEntityApp.myApp;
          //  PackagePurchaseDockablePane test = new PackagePurchaseDockablePane();
           // test.Execute(UIEntityApp.commandData,"" , UIEntityApp.ElementSet);
            //string guid = "ef5b0ecc-5859-4642-bb27-769393383d02";
            //Guid retval = Guid.Empty;
            //try
            //{
            //    retval = new Guid(guid);
            //}
            //catch (Exception)
            //{

            //}

            //DockablePaneId sm_UserDockablePaneId = new DockablePaneId(retval);
            //DockablePane pane = app.GetDockablePane(sm_UserDockablePaneId);
            //pane.Hide();
          
          //  app.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.ArchitecturalWall));
            
        }
    }
}
