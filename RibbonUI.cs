using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows;
//using System.Windows.Forms;
using System.Windows.Media.Imaging;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;

namespace RevitRedevelop
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
   // [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class UserInfoDockablePane : IExternalCommand
    {
        UIApplication uiApp;
        Document m_Doc;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            uiApp = commandData.Application;
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            m_Doc = uiApp.ActiveUIDocument.Document;

            string m_mainPageGuid = "ef5b0ecc-5859-4642-bb27-769393383d99";

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
        public UIApplication getUIApp()
        {
            return uiApp;
        }
    }
    public class Ribbon : IExternalApplication
    {
        // 程序集路径
        static string AddInPath = typeof(Ribbon).Assembly.Location;
        // 按钮图标目录
        static string ButtonIconsFolder = Path.GetDirectoryName(AddInPath);
        RibbonPanel rp1;
        RibbonPanel rp2;
        RibbonPanel rp3;
        RibbonPanel rp4;
        UIControlledApplication myApp;
        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        {
            try
            {
                CreateRibbonSamplePanel(application);
                RegisterDockableSamplePane(application);
                myApp = application;
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ribbon Sample");

                return Autodesk.Revit.UI.Result.Failed;
            }
        }
        public Autodesk.Revit.UI.Result OnShutdown(UIControlledApplication application)
        {
            return Autodesk.Revit.UI.Result.Succeeded;
        }
        BitmapSource convertFromBitmap(System.Drawing.Bitmap bitmap)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }
        private void CreateRibbonSamplePanel(UIControlledApplication application)
        {
            application.CreateRibbonTab("砖+宝");

            rp1 = application.CreateRibbonPanel("砖+宝", "个人信息管理");
            rp2 = application.CreateRibbonPanel("砖+宝", "智能铺贴");
            rp3 = application.CreateRibbonPanel("砖+宝", "基本信息管理");
            rp4 = application.CreateRibbonPanel("砖+宝", "快速入门");

            String userInfoShow = "\nAdministrator，您好！\n testtsetsetsetset!";
            PushButtonData pbd1 = new PushButtonData("userInfoShow", userInfoShow, AddInPath, "userInfoShow");
            rp1.AddItem(pbd1);

            PushButtonData pbd2 = new PushButtonData("UserInfo", "个人信息", AddInPath, "RevitRedevelop.UserInfoDockablePane");
            PushButton pb2 = rp1.AddItem(pbd2) as PushButton;
            pb2.ToolTip = "See Selected Element";
            pb2.LongDescription = "查看个人信息";
            pb2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd3 = new PushButtonData("PackagePurchase", "套餐购买", AddInPath, "PackagePurchase");
            PushButton pb3 = rp1.AddItem(pbd3) as PushButton;
            pb3.ToolTip = "See Selected Element";
            pb3.LongDescription = "进行套餐的浏览和购买";
            pb3.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd4 = new PushButtonData("LogOut", "退出登录", AddInPath, "LogOut");
            PushButton pb4 = rp1.AddItem(pbd4) as PushButton;
            pb4.ToolTip = "See Selected Element";
            pb4.LongDescription = "退出当前登录";
            pb4.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd5 = new PushButtonData("DrawFloorPlan", "绘制户型图", AddInPath, "DrawFloorPlan");
            PushButton pb5 = rp2.AddItem(pbd5) as PushButton;
            pb5.ToolTip = "See Selected Element";
            pb5.LongDescription = "进行户型图的选择";
            pb5.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd6 = new PushButtonData("Pave", "      铺贴      ", AddInPath, "Pave");
            PushButton pb6 = rp2.AddItem(pbd6) as PushButton;
            pb6.ToolTip = "See Selected Element";
            pb6.LongDescription = "进行铺贴模板的选择";
            pb6.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd7 = new PushButtonData("ResultExport", "      出图    ", AddInPath, "ResultExport");
            PushButton pb7 = rp2.AddItem(pbd7) as PushButton;
            pb7.ToolTip = "See Selected Element";
            pb7.LongDescription = "方案生成";
            pb7.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd8 = new PushButtonData("FloorPlanManage", "户型图管理", AddInPath, "FloorPlanManage");
            PushButton pb8 = rp3.AddItem(pbd8) as PushButton;
            pb8.ToolTip = "See Selected Element";
            pb8.LongDescription = "户型图的管理";
            pb8.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd9 = new PushButtonData("PaveModelManage", " 模板管理", AddInPath, "FloorPlanManage");
            PushButton pb9 = rp3.AddItem(pbd9) as PushButton;
            pb9.ToolTip = "See Selected Element";
            pb9.LongDescription = "铺砖模板管理";
            pb9.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd10 = new PushButtonData("TileProductManage", " 单品管理", AddInPath, "TileProductManage");
            PushButton pb10 = rp3.AddItem(pbd10) as PushButton;
            pb10.ToolTip = "See Selected Element";
            pb10.LongDescription = "铺砖模板管理";
            pb10.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd11 = new PushButtonData("OnlineLearning", "在线视频", AddInPath, "OnlineLearning");
            PushButton pb11 = rp4.AddItem(pbd11) as PushButton;
            pb11.ToolTip = "See Selected Element";
            pb11.LongDescription = "";
            pb11.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd12 = new PushButtonData("OnlineHelp", "在线帮助", AddInPath, "OnlineHelp");
            PushButton pb12 = rp4.AddItem(pbd12) as PushButton;
            pb12.ToolTip = "See Selected Element";
            pb12.LongDescription = "";
            pb12.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
        }
        public void RegisterDockableSamplePane(UIControlledApplication application)
        {
           // SetCarportNum.AvailabilityClassName = "RevitRedevelop.AvailabilityControll";

            // Guid temp = System.Guid.NewGuid.ToString('D');

            string temp = "ef5b0ecc-5859-4642-bb27-769393383d99";
            UI.UserInfo m_mainPage = new UI.UserInfo();

            Guid retval = Guid.Empty;
            retval = new Guid(temp);
            DockablePaneId sm_UserDockablePaneId = new DockablePaneId(retval);

            application.RegisterDockablePane(sm_UserDockablePaneId, "个人信息", m_mainPage as IDockablePaneProvider);
        }
        public BitmapImage GetBitmapImage(string imageName)
        {
            return new BitmapImage(new Uri(
             imageName));
        }
        public UIControlledApplication getUICTApp()
        {
            return myApp;
        }
    }
}