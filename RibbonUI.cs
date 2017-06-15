/***
 * 
 * 
 * 控制Revit内置面板的UI
 * 
 * */

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
   
    public class Ribbon : IExternalApplication
    {
        // 程序集路径
        static string AddInPath = typeof(Ribbon).Assembly.Location;
        // 按钮图标目录
        static string ButtonIconsFolder = Path.GetDirectoryName(AddInPath);
        RibbonPanel rp1;
        RibbonPanel rp2_1;
        RibbonPanel rp2_2;
        RibbonPanel rp2_3;
        RibbonPanel rp3;
        RibbonPanel rp4;
        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        {
            try
            {
                CreateRibbonSamplePanel(application);
                RegisterDockableSamplePane(application);
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
            rp2_1 = application.CreateRibbonPanel("砖+宝", "户型图");
            rp2_2 = application.CreateRibbonPanel("砖+宝", "智能铺贴");
            rp2_3 = application.CreateRibbonPanel("砖+宝", "结果导出");
            rp3 = application.CreateRibbonPanel("砖+宝", "基本信息管理");
            rp4 = application.CreateRibbonPanel("砖+宝", "快速入门");

            String userInfoShow = "\nAdministrator，您好！\n testtsetsetsetset!";
            PushButtonData pbd1 = new PushButtonData("userInfoShow", userInfoShow, AddInPath, "userInfoShow");
            PushButton pd1 = rp1.AddItem(pbd1) as PushButton;
            pd1.Enabled = false;
            //pbd1.AvailabilityClassName = "RevitRedevelop.AvailabilityControll";
            //rp1.AddSlideOut();

            PushButtonData pbd2 = new PushButtonData("UserInfo", "个人信息", AddInPath, "RevitRedevelop.UserInfoDockablePane");
            PushButton pb2 = rp1.AddItem(pbd2) as PushButton;
            pb2.ToolTip = "查看个人信息";
            pb2.LongDescription = "查看个人信息";
            pb2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd3 = new PushButtonData("PackagePurchase", "套餐购买", AddInPath, "RevitRedevelop.PackagePurchaseDockablePane");
            PushButton pb3 = rp1.AddItem(pbd3) as PushButton;
            pb3.ToolTip = "进行套餐的浏览和购买";
            pb3.LongDescription = "进行套餐的浏览和购买";
            pb3.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd4 = new PushButtonData("LogOut", "退出登录", AddInPath, "LogOut");
            PushButton pb4 = rp1.AddItem(pbd4) as PushButton;
            pb4.ToolTip = "退出当前登录";
            pb4.LongDescription = "退出当前登录";
            pb4.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PulldownButtonData pubd5_1 = new PulldownButtonData("FloorPlanLib", "户型图库");
            PulldownButton pub5_1 = rp2_1.AddItem(pubd5_1) as PulldownButton;
            pub5_1.ToolTip = "进行户型图的选择";
            pub5_1.LongDescription = "进行户型图的选择";
            pub5_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
            PushButtonData pbd5_1 = new PushButtonData("ChooseFloorPlan", "选择户型图", AddInPath, "RevitRedevelop.DrawFloorPlanDockablePane");
            PushButton pb5_1 = pub5_1.AddPushButton(pbd5_1) as PushButton;
            pb5_1.ToolTip = "进行户型图的选择";
            pb5_1.LongDescription = "进行户型图的选择";
            pb5_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
            PushButtonData pbd5_2 = new PushButtonData("EnsureFloorPlan", "确认户型图", AddInPath, "LogOut");
            PushButton pb5_2 = pub5_1.AddPushButton(pbd5_2) as PushButton;
            pb5_2.ToolTip = "确认选择的户型图";
            pb5_2.LongDescription = "进行户型图的选择";
            pb5_2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
           
            rp2_1.AddSeparator();

            PushButtonData pbd5_3= new PushButtonData("FloorPlan", "\n手动绘制\n户型图", AddInPath,"LogOut");
            PushButton pb5_3 = rp2_1.AddItem(pbd5_3) as PushButton;
            pb5_3.Enabled = false;
         //   pb5_2.ToolTip = "手动绘制户型图";
         //   pb5_2.LongDescription = "手动绘制户型图";
         //   pb5_2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
            //rp2_1.AddSlideOut();
            PushButtonData pbd5_4 = new PushButtonData("Wall", "墙", AddInPath, "LogOut");
            PushButtonData pbd5_5 = new PushButtonData("Door", "门", AddInPath, "LogOut");
            PushButtonData pbd5_6 = new PushButtonData("Window", "窗", AddInPath, "LogOut");
            //IList<RibbonItem> ribbonItems =  rp2_1.AddStackedItems(pbd5_4, pbd5_5);
            PushButton pb5_4 = rp2_1.AddItem(pbd5_4) as PushButton;
            pb5_4.ToolTip = "绘制墙体";
            pb5_4.LongDescription = "绘制墙体";
            pb5_4.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
            PushButton pb5_5 = rp2_1.AddItem(pbd5_5) as PushButton;
            pb5_5.ToolTip = "绘制门";
            pb5_5.LongDescription = "绘制门";
            pb5_5.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
            PushButton pb5_6 = rp2_1.AddItem(pbd5_6) as PushButton;
            pb5_6.ToolTip = "绘制窗";
            pb5_6.LongDescription = "绘制窗";
            pb5_6.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd5_7 = new PushButtonData("Pillar", "柱子", AddInPath, "LogOut");
            PushButtonData pbd5_8 = new PushButtonData("Cupboard", "柜子", AddInPath, "LogOut");
            IList<RibbonItem> ribbonItems = rp2_1.AddStackedItems(pbd5_7, pbd5_8);
            PushButton pb5_7 = ribbonItems[0] as PushButton;
            PushButton pb5_8 = ribbonItems[1] as PushButton;
            pb5_7.ToolTip = "放置柱子";
            pb5_7.LongDescription = "放置柱子";
            pb5_7.Image = GetBitmapImage("F:/StrcturalWall.png");
            pb5_8.ToolTip = "放置柜子";
            pb5_8.LongDescription = "放置柜子";
            pb5_8.Image = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd5_9 = new PushButtonData("Background", "背景墙", AddInPath, "LogOut");
            PushButtonData pbd5_10 = new PushButtonData("OtherArea", "其他占位不铺贴", AddInPath, "LogOut");
            ribbonItems = rp2_1.AddStackedItems(pbd5_9, pbd5_10);
            PushButton pb5_9 = ribbonItems[0] as PushButton;
            PushButton pb5_10 = ribbonItems[1] as PushButton;
            pb5_9.ToolTip = "背景墙";
            pb5_9.LongDescription = "背景墙";
            pb5_9.Image = GetBitmapImage("F:/StrcturalWall.png");
            pb5_10.ToolTip = "其他占位不铺贴";
            pb5_10.LongDescription = "其他占位不铺贴";
            pb5_10.Image = GetBitmapImage("F:/StrcturalWall.png");

            rp2_1.AddSeparator();

            PushButtonData pbd5_11 = new PushButtonData("3-DPreview", "三维图预览", AddInPath, "LogOut");
            PushButtonData pbd5_12 = new PushButtonData("ImportDwg", "导入DWG图纸", AddInPath, "LogOut");
            ribbonItems = rp2_1.AddStackedItems(pbd5_11, pbd5_12);
            PushButton pb5_11 = ribbonItems[0] as PushButton;
            PushButton pb5_12 = ribbonItems[1] as PushButton;
            pb5_11.ToolTip = "三维图预览";
            pb5_11.LongDescription = "三维图预览";
            pb5_11.Image = GetBitmapImage("F:/StrcturalWall.png");
            pb5_12.ToolTip = "导入DWG图纸";
            pb5_12.LongDescription = "导入DWG图纸";
            pb5_12.Image = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd6_1 = new PushButtonData("AreaSplit", "区域划分", AddInPath, "Pave");
            PushButton pb6_1 = rp2_2.AddItem(pbd6_1) as PushButton;
            pb6_1.ToolTip = "区域划分";
            pb6_1.LongDescription = "区域划分";
            pb6_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd6_2 = new PushButtonData("ChoosePaveModel", "模板选择", AddInPath, "Pave");
            PushButton pb6_2 = rp2_2.AddItem(pbd6_2) as PushButton;
            pb6_2.ToolTip = "区域划分";
            pb6_2.LongDescription = "区域划分";
            pb6_2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd6_3 = new PushButtonData("AdaptPave", "适配铺贴", AddInPath, "Pave");
            PushButton pb6_3 = rp2_2.AddItem(pbd6_3) as PushButton;
            pb6_3.ToolTip = "区域划分";
            pb6_3.LongDescription = "区域划分";
            pb6_3.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbd7 = new PushButtonData("ResultExport", "      出图    ", AddInPath, "ResultExport");
            PushButton pb7 = rp2_3.AddItem(pbd7) as PushButton;
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
            pb9.LargeImage = new BitmapImage(new Uri("F:/StrcturalWall.png"));

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
            Guid retval;
            //个人信息
           // SetCarportNum.AvailabilityClassName = "RevitRedevelop.AvailabilityControll";
            string Guid1 = "ef5b0ecc-5859-4642-bb27-769393383d00";
            UI.UserInfo userInfo = new UI.UserInfo();

            retval = Guid.Empty;
            retval = new Guid(Guid1);
            DockablePaneId userInfo_UserDockablePaneId = new DockablePaneId(retval);

            application.RegisterDockablePane(userInfo_UserDockablePaneId, "个人信息", userInfo as IDockablePaneProvider);

            //套餐购买
            string Guid2 = "ef5b0ecc-5859-4642-bb27-769393383d01";
            UI.PackagePurchase PackagePurchase = new UI.PackagePurchase();

            retval = Guid.Empty;
            retval = new Guid(Guid2);
            DockablePaneId PackagePurchase_UserDockablePaneId = new DockablePaneId(retval);

            application.RegisterDockablePane(PackagePurchase_UserDockablePaneId, "套餐购买", PackagePurchase as IDockablePaneProvider);

            //绘制户型图
            string Guid3 = "ef5b0ecc-5859-4642-bb27-769393383d02";
            UI.DrawFloorPlan DrawFloorPlan = new UI.DrawFloorPlan();

            retval = Guid.Empty;
            retval = new Guid(Guid3);
            DockablePaneId DrawFloorPlan_UserDockablePaneId = new DockablePaneId(retval);

            application.RegisterDockablePane(DrawFloorPlan_UserDockablePaneId, "绘制户型图", DrawFloorPlan as IDockablePaneProvider);
        }
        public BitmapImage GetBitmapImage(string imageName)
        {
            return new BitmapImage(new Uri(
             imageName));
        }
    }
}