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
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            Document document = commandData.Application.ActiveUIDocument.Document;
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            m_Doc = uiApp.ActiveUIDocument.Document;
            UI.DrawFloorPlan drawfloorplan = new UI.DrawFloorPlan();
            drawfloorplan.Show();
            return Result.Succeeded;
        }
    }
    
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class ImportFloorPlan : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            m_Doc = uiApp.ActiveUIDocument.Document;
            uiApp.OpenAndActivateDocument("D:/项目1.rvt");
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Collect : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            UI.FloorPlanCollect collect = new UI.FloorPlanCollect();
            
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.ArchitecturalWall));
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            Transaction trans = new Transaction(UIEntityApp.document, "ExComm");
            trans.Start();
            FilteredElementCollector filteredelements = new FilteredElementCollector(UIEntityApp.document);
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.Door));
            return Result.Succeeded;
        }
    }

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class ChooseDoorSizeDoor : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            string m_mainPageGuid = ConstGuid.ChooseDoorSizeGuid;

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
    public class GenerateDoor : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            Transaction trans = new Transaction(UIEntityApp.document, "ExComm");
            trans.Start();

            FilteredElementCollector filteredelements = new FilteredElementCollector(UIEntityApp.document);
            ElementClassFilter classFilter = new ElementClassFilter(typeof(FamilyInstance));
            ElementCategoryFilter catFilter = new ElementCategoryFilter(BuiltInCategory.OST_Doors);            
            LogicalAndFilter logicalFilter = new LogicalAndFilter(classFilter, catFilter);
            filteredelements=filteredelements.WherePasses(logicalFilter);
            //IList<Element> list = filteredelements.ToElements();

            foreach (Element door in filteredelements)
            {
                Parameter parameter = door.get_Parameter(BuiltInParameter.DOOR_HEIGHT);
                if (parameter == null)
                {
                    MessageBox.Show("nodoor");
                }
            }
            trans.Commit();
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.PlaceAComponent));
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class ImportRevit : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.OpenRevitFile));
            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class TwoDPreview : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
         //   uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.));
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.ImportCAD));
            return Result.Succeeded;
        }
    }
    
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class AreaPartition : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
          ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.Room));

            return Result.Succeeded;
        }
    }
      [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class SplitLine : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
          ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.RoomSeparator));
            return Result.Succeeded;
        }
    }
    
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Pave : IExternalCommand
    {
        bool m_roofCreated;
      
        public bool RoofCreated
        {
            get
            {
                return m_roofCreated;
            }
            set
            {
                m_roofCreated = value;
            }
        }
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
           ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document document = commandData.Application.ActiveUIDocument.Document;
            UIApplication app = commandData.Application;
            m_roofCreated = false;
            UI.Pave.PaveDocument pDoc = new UI.Pave.PaveDocument(commandData);
            using (UI.Pave.PaveForm paveForm = new UI.Pave.PaveForm(pDoc))
            {
                if (null != paveForm && false == paveForm.IsDisposed)
                {
                    paveForm.ShowDialog();
                }
            }

            return Result.Succeeded;
        }
    }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Pave1 : IExternalCommand
    {
        bool m_roofCreated;

        public bool RoofCreated
        {
            get
            {
                return m_roofCreated;
            }
            set
            {
                m_roofCreated = value;
            }
        }
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
           ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document document = commandData.Application.ActiveUIDocument.Document;
            UIApplication app = commandData.Application;
            m_roofCreated = false;
            UI.Pave.PaveDocument pDoc = new UI.Pave.PaveDocument(commandData);
            //using (UI.Pave.PaveForm paveForm = new UI.Pave.PaveForm(pDoc))
            //{
            //    if (null != paveForm && false == paveForm.IsDisposed)
            //    {
            //        paveForm.ShowDialog();
            //    }
            //}
            Transaction open_family = new Transaction(document, Guid.NewGuid().GetHashCode().ToString());
            open_family.Start();
            document.LoadFamily(@"C:\ProgramData\Autodesk\RVT 2015\Libraries\China\建筑\按填充图案划分的幕墙嵌板\矩形表面.rfa");
            open_family.Commit();

            //using (PaveForm paveForm = new PaveForm(pDoc))
            //{
            //    if (null != paveForm && false == paveForm.IsDisposed)
            //    {
            //        paveForm.ShowDialog();
            //    }
            //}
            Transaction act = new Transaction(document, Guid.NewGuid().GetHashCode().ToString());
            act.Start();
            FamilySymbol familySymbol = null;
            FilteredElementCollector collector = new FilteredElementCollector(document);//过滤元素
            ICollection<Element> collection = collector.OfClass(typeof(FamilySymbol)).ToElements();
            foreach (Element e in collection)
            {
                familySymbol = e as FamilySymbol;
                if (null != familySymbol.Category)
                {

                    //遍历族符号的方法
                    FamilySymbolSetIterator symbolItor = familySymbol.Family.Symbols.ForwardIterator();
                    FamilySymbol fs = null;
                    while (symbolItor.MoveNext())
                    {
                        fs = symbolItor.Current as FamilySymbol;
                    }
                }
            }
            double length = 3.93700787401575;
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    XYZ point = new XYZ(-10 + y * length, 0 - i * length, 0);
                    FamilyInstance fi = document.Create.NewFamilyInstance(point, familySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);

                }
            }

            act.Commit();
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            uiApp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.Default3DView));
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
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
            UIApplication uiApp = commandData.Application;
            UIEntityApp.myApp = uiApp;
            UIEntityApp.ElementSet = elements;
            UIEntityApp.commandData = commandData;
            UIEntityApp.message = message;
            UIEntityApp.uidoc = commandData.Application.ActiveUIDocument;
            UIEntityApp.document = commandData.Application.ActiveUIDocument.Document;
            UI.TileProductManage tileproductmanage = new UI.TileProductManage();
            tileproductmanage.Show();
            return Result.Succeeded;
        }
    }
}
