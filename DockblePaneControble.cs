using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitRedevelop
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class UserInfoDockablePane : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            //Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            //m_Doc = uiApp.ActiveUIDocument.Document;

            //string m_mainPageGuid = "ef5b0ecc-5859-4642-bb27-769393383d00";

            //Guid retval = Guid.Empty;
            //try
            //{
            //    retval = new Guid(m_mainPageGuid);
            //}
            //catch (Exception)
            //{
            //}

            //DockablePaneId sm_UserDockablePaneId = new DockablePaneId(retval);
            //DockablePane pane = uiApp.GetDockablePane(sm_UserDockablePaneId);
            //pane.Show();
            //DrawFloorPlan test =new DrawFloorPlan()
            uiApp = commandData.Application;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.ArchitecturalWall));
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class PackagePurchaseDockablePane : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            m_Doc = uiApp.ActiveUIDocument.Document;

            string m_mainPageGuid = "ef5b0ecc-5859-4642-bb27-769393383d01";

            Guid retval = Guid.Empty;
            try
            {
                retval = new Guid(m_mainPageGuid);
            }
            catch (Exception)
            {
            }

            DockablePaneId sm_UserDockablePaneId = new DockablePaneId(retval);
            DockablePane pane = uiApp.GetDockablePane(sm_UserDockablePaneId);
            pane.Show();

            return Result.Succeeded;
        }
    }

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class DrawFloorPlanDockablePane : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            m_Doc = uiApp.ActiveUIDocument.Document;

            string m_mainPageGuid = "ef5b0ecc-5859-4642-bb27-769393383d02";

            Guid retval = Guid.Empty;
            try
            {
                retval = new Guid(m_mainPageGuid);
            }
            catch (Exception)
            {
            }

            DockablePaneId sm_UserDockablePaneId = new DockablePaneId(retval);
            DockablePane pane = uiApp.GetDockablePane(sm_UserDockablePaneId);
            pane.Show();

            return Result.Succeeded;
        }
    }
}
