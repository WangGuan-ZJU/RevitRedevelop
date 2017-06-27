using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            //m_Doc = uiApp.ActiveUIDocuenmt.Document;
            RibbonPanel ribbonpanel = null;
            List<RibbonPanel> listRobbonPanel = uiApp.GetRibbonPanels("砖+宝");
            foreach (RibbonPanel panel in listRobbonPanel)
            {
                 if (panel.Name == "个人信息管理")//RibbonPanel的Name
                 {
                     ribbonpanel = panel;
                     break;
                  }
            }
            PushButton pushbutton = null;
            IList<RibbonItem> listItem = ribbonpanel.GetItems();
            foreach (RibbonItem item in listItem)
            {
                 if (item.Name == "UserInfo")//Ribbon的Name属性
                 {
                     pushbutton = item as PushButton;
                 }
            }
            string m_mainPageGuid;
            if(pushbutton.ItemText == "登录")
            {
                UI.Login userLogin = new UI.Login();
                userLogin.Show();
            }
            else
            {
                UI.UserInfo userinfo = new UI.UserInfo();
                userinfo.Show();
            }
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
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            //m_Doc = uiApp.ActiveUIDocuenmt.Document;
            RibbonPanel ribbonpanel = null;
            List<RibbonPanel> listRobbonPanel = uiApp.GetRibbonPanels("砖+宝");
            foreach (RibbonPanel panel in listRobbonPanel)
            {
                if (panel.Name == "个人信息管理")//RibbonPanel的Name
                {
                    ribbonpanel = panel;
                    break;
                }
            }
            PushButton pushbutton = null;
            IList<RibbonItem> listItem = ribbonpanel.GetItems();
            foreach (RibbonItem item in listItem)
            {
                if (item.Name == "PackagePurchase")//Ribbon的Name属性
                {
                    pushbutton = item as PushButton;
                }
            }
            if (pushbutton.ItemText == "注册")
            {
                UI.Register userRegister = new UI.Register();
                userRegister.Show();
            }
            else
            {
                UI.PackagePurchase packagepurchase = new UI.PackagePurchase();
                packagepurchase.Show();
            }
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class LogOut : IExternalCommand
    {
        
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            UIApplication uiApp;
            uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要退出吗?", "退出系统", messButton);
            if(dr==DialogResult.OK)
             UIEntityApp.InitUI();
               
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
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            m_Doc = uiApp.ActiveUIDocument.Document;

            string m_mainPageGuid = ConstGuid.DrawFloorPlanGuid;

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
    public class ChooseSize : IExternalCommand
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
            string m_mainPageGuid = ConstGuid.ChooseSizeGuid;

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
    public class DrawWall : IExternalCommand
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
            UIDocument uidocument = uiApp.ActiveUIDocument;
            Document RevitDoc = uidocument.Document;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.ArchitecturalWall));

            //Transaction trans = new Transaction(RevitDoc, "ExComm");
            //trans.Start();
            //FilteredElementCollector filteredelements = new FilteredElementCollector(RevitDoc);
            //ElementClassFilter classfilter = new ElementClassFilter(typeof(Wall));
            //filteredelements = filteredelements.WherePasses(classfilter);

            //foreach (Wall wall in filteredelements)
            //{

            //    Parameter parameter1 = wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM);

            //    CompoundStructure cs = wall.WallType.GetCompoundStructure();

            //    IList<CompoundStructureLayer> listLayer = cs.GetLayers();
            //    int iIdx = 0;
            //    foreach (CompoundStructureLayer cLayer in listLayer)
            //    {
            //        if (MaterialFunctionAssignment.Structure == cLayer.Function)
            //            break;
            //        iIdx++;
            //    }
            //    cs.SetLayerWidth(iIdx, 1000.0*PaintData.DrawFloorPlanData.wallThickness / 304.8);
            //    wall.WallType.SetCompoundStructure(cs);
            //    bool success = parameter1.Set(PaintData.DrawFloorPlanData.wallHeight * 1000.0 / 304.8);
            //}
            //trans.Commit();
            return Result.Succeeded;
        }
    }    

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class GenerateWall : IExternalCommand
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
            UIDocument uidocument = uiApp.ActiveUIDocument;
            Document RevitDoc = uidocument.Document;
            Transaction trans = new Transaction(RevitDoc, "ExComm");
            trans.Start();
            FilteredElementCollector filteredelements = new FilteredElementCollector(RevitDoc);
            ElementClassFilter classfilter = new ElementClassFilter(typeof(Wall));
            filteredelements = filteredelements.WherePasses(classfilter);

            foreach (Wall wall in filteredelements)
            {

                Parameter parameter1 = wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM);

                CompoundStructure cs = wall.WallType.GetCompoundStructure();

                IList<CompoundStructureLayer> listLayer = cs.GetLayers();
                int iIdx = 0;
                foreach (CompoundStructureLayer cLayer in listLayer)
                {
                    if (MaterialFunctionAssignment.Structure == cLayer.Function)
                        break;
                    iIdx++;
                }
                cs.SetLayerWidth(iIdx, 1000.0 * PaintData.DrawFloorPlanData.wallThickness / 304.8);
                wall.WallType.SetCompoundStructure(cs);
                bool success = parameter1.Set(PaintData.DrawFloorPlanData.wallHeight * 1000.0 / 304.8);
            }
            trans.Commit();
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class DrawDoor : IExternalCommand
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
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.Door));
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class DrawWindow : IExternalCommand
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
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.Window));
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class DrawColumn : IExternalCommand
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
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.ArchitecturalColumn));
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class DrawFurniture : IExternalCommand
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
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.PlaceAComponent));
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class ThreeDPreview : IExternalCommand
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
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.PlaceAComponent));
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class ImportCAD : IExternalCommand
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
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.ImportCAD));
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Pave : IExternalCommand
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
            m_Doc = uiApp.ActiveUIDocument.Document;

            string m_mainPageGuid = ConstGuid.PaveGuid;

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
    public class ResultExport : IExternalCommand
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
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            m_Doc = uiApp.ActiveUIDocument.Document;

            UI.ResultExport resultexport = new UI.ResultExport();
            resultexport.Show();
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class FloorPlanManage : IExternalCommand
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
            UI.FloorPlanManage floorplanmanage = new UI.FloorPlanManage();
            floorplanmanage.Show();
            return Result.Succeeded;
        }
    } 
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class PaveModelManage : IExternalCommand
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
            UI.PaveModelManage pavemodelmanage = new UI.PaveModelManage();
            pavemodelmanage.Show();
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class TileProductManage : IExternalCommand
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
            UI.TileProductManage tileproductmanage = new UI.TileProductManage();
            tileproductmanage.Show();
            return Result.Succeeded;
        }
    }
}
