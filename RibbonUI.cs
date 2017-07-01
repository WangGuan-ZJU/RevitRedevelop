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

        static string AddInPath = typeof(Ribbon).Assembly.Location; //程序集路径

        #region 控件数据
        //面板
        RibbonPanel rp1;
        RibbonPanel rp2_1;
        RibbonPanel rp2_2;
        RibbonPanel rp2_3;
        RibbonPanel rp3;
        RibbonPanel rp4;
        //按钮
        PushButtonData pbd1;
        PushButton pb1;
        PushButtonData pbd2;
        PushButton pb2;
        PushButtonData pbd3;
        PushButton pb3;
        PushButtonData pbd4;
        PushButton pb4;
        PushButtonData pbd5_1;
        PushButton pb5_1;
        PushButtonData pbd5_2;
        PushButton pb5_2;
        PushButtonData pbd5_3;
        PushButton pb5_3;
        PushButtonData pbd5_4;
        PushButton pb5_4;
        PushButtonData pbd5_4_1;
        PushButton pb5_4_1;
        PushButtonData pbd5_4_2;
        PushButton pb5_4_2;
        PushButtonData pbd5_5;
        PushButton pb5_5;
        PushButtonData pbd5_5_1;
        PushButton pb5_5_1;
        PushButtonData pbd5_5_2;
        PushButton pb5_5_2;
        PushButtonData pbd5_6;
        PushButton pb5_6;
        PushButtonData pbd5_6_1;
        PushButton pb5_6_1;
        PushButtonData pbd5_6_2;
        PushButton pb5_6_2;
        PushButtonData pbd5_7;
        PushButton pb5_7;
        PushButtonData pbd5_7_1;
        PushButton pb5_7_1;
        PushButtonData pbd5_7_2;
        PushButton pb5_7_2;
        PushButtonData pbd5_8;
        PushButton pb5_8;
        PushButtonData pbd5_8_1;
        PushButton pb5_8_1;
        PushButtonData pbd5_8_2;
        PushButton pb5_8_2; 
        PushButtonData pbd5_9;
        PushButton pb5_9;
        PushButtonData pbd5_10;
        PushButton pb5_10;
        PushButtonData pbd5_11;
        PushButton pb5_11;
        PushButtonData pbd5_12;
        PushButton pb5_12;
        PushButtonData pbd5_13;
        PushButton pb5_13;    
        PushButtonData pbd6_1;
        PushButton pb6_1;
        PushButtonData pbd6_2;
        PushButton pb6_2;
        PushButtonData pbd6_3;
        PushButton pb6_3;
        PushButtonData pbd7;
        PushButton pb7;
        PushButtonData pbd8;
        PushButton pb8;
        PushButtonData pbd9;
        PushButton pb9;
        PushButtonData pbd10;
        PushButton pb10;
        PushButtonData pbd11;
        PushButton pb11;
        PushButtonData pbd12;
        PushButton pb12;
        #endregion
        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        {
            try
            {
                CreateRibbonSamplePanel(application);
                //InitializeRibbon();
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
            pbd1 = new PushButtonData("userInfoShow", userInfoShow, AddInPath, "userInfoShow");
            pb1 = rp1.AddItem(pbd1) as PushButton;
            pb1.Enabled = false;

            //pbd1.AvailabilityClassName = "RevitRedevelop.AvailabilityControll";

            pbd2 = new PushButtonData("UserInfo", "个人信息", AddInPath, "RevitRedevelop.UserInfoDockablePane");
            pb2 = rp1.AddItem(pbd2) as PushButton;
            pb2.ToolTip = "查看个人信息";
            pb2.LongDescription = "查看个人信息";
            pb2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd3 = new PushButtonData("PackagePurchase", "套餐购买", AddInPath, "RevitRedevelop.PackagePurchaseDockablePane");
            pb3 = rp1.AddItem(pbd3) as PushButton;
            pb3.ToolTip = "进行套餐的浏览和购买";
            pb3.LongDescription = "进行套餐的浏览和购买";
            pb3.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd4 = new PushButtonData("LogOut", "退出登录", AddInPath, "RevitRedevelop.LogOut");
            pb4 = rp1.AddItem(pbd4) as PushButton;
            pb4.ToolTip = "退出当前登录";
            pb4.LongDescription = "退出当前登录";
            pb4.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

          
            pbd5_1 = new PushButtonData("ChooseFloorPlan", "选择户型图", AddInPath, "RevitRedevelop.DrawFloorPlanDockablePane");
            pb5_1 = rp2_1.AddItem(pbd5_1) as PushButton;
            pb5_1.ToolTip = "进行户型图的选择";
            pb5_1.LongDescription = "进行户型图的选择";
            pb5_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
            pbd5_2 = new PushButtonData("EnsureFloorPlan", "确认户型图", AddInPath, "LogOut");
            pb5_2 = rp2_1.AddItem(pbd5_2) as PushButton;
            pb5_2.ToolTip = "确认选择的户型图";
            pb5_2.LongDescription = "进行户型图的选择";
            pb5_2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
           
            rp2_1.AddSeparator();

            pbd5_3= new PushButtonData("FloorPlan", "\n手动绘制\n户型图", AddInPath,"LogOut");
            pb5_3 = rp2_1.AddItem(pbd5_3) as PushButton;
            pb5_3.Enabled = false;
            //SplitButtonData spbd = new SplitButtonData("NewWallSplit", "创建墙");
            //SplitButton spb = rp2_1.AddItem(spbd) as SplitButton;

            PulldownButtonData pudbd = new PulldownButtonData("WallPull", "墙体");
            PulldownButton pudb = rp2_1.AddItem(pudbd) as PulldownButton;
            pudb.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_4_1 = new PushButtonData("Wall", "绘制墙的轮廓", AddInPath, "RevitRedevelop.DrawWall");
            pb5_4_1 = pudb.AddPushButton(pbd5_4_1);
            pb5_4_1.ToolTip = "绘制墙的轮廓";
            pb5_4_1.LongDescription = "绘制墙的轮廓";
            pb5_4_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_4 = new PushButtonData("ChooseSize", "选择墙的尺寸", AddInPath, "RevitRedevelop.ChooseSize");
            pb5_4 = pudb.AddPushButton(pbd5_4);
            pb5_4.ToolTip = "选择墙的尺寸";
            pb5_4.LongDescription = "选择墙的尺寸";
            pb5_4.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_4_2 = new PushButtonData("GenerateWall", "生成墙体", AddInPath, "RevitRedevelop.GenerateWall");
            pb5_4_2 = pudb.AddPushButton(pbd5_4_2);
            pb5_4_2.ToolTip = "生成墙体";
            pb5_4_2.LongDescription = "生成墙体";
            pb5_4_2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");


            PulldownButtonData pudbd2 = new PulldownButtonData("DoorPull", "门");
            PulldownButton pudb2 = rp2_1.AddItem(pudbd2) as PulldownButton;
            pudb2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_5 = new PushButtonData("Door", "绘制门位置", AddInPath, "RevitRedevelop.DrawDoor");
            pb5_5 = pudb2.AddPushButton(pbd5_5);
            pb5_5.ToolTip = "绘制门位置";
            pb5_5.LongDescription = "绘制门位置";
            pb5_5.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_5_1 = new PushButtonData("ChooseDoorSize", "选择门尺寸", AddInPath, "RevitRedevelop.ChooseDoorSize");
            pb5_5_1 = pudb2.AddPushButton(pbd5_5_1);
            pb5_5_1.ToolTip = "选择门尺寸";
            pb5_5_1.LongDescription = "选择门尺寸";
            pb5_5_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_5_2 = new PushButtonData("GenerateDoor", "生成门", AddInPath, "RevitRedevelop.GenerateDoor");
            pb5_5_2 = pudb2.AddPushButton(pbd5_5_2);
            pb5_5_2.ToolTip = "生成门";
            pb5_5_2.LongDescription = "生成门";
            pb5_5_2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PulldownButtonData pudbd3 = new PulldownButtonData("WindowPull", "窗");
            PulldownButton pudb3 = rp2_1.AddItem(pudbd3) as PulldownButton;
            pudb3.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_6 = new PushButtonData("DrawWindow", "窗", AddInPath, "RevitRedevelop.DrawWindow");
            pb5_6 = pudb3.AddPushButton(pbd5_6);
            pb5_6.ToolTip = "绘制窗";
            pb5_6.LongDescription = "绘制窗";
            pb5_6.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_6_1 = new PushButtonData("ChooseWindowSize", "选择窗户大小", AddInPath, "RevitRedevelop.ChooseWindowSize");
            pb5_6_1 = pudb3.AddPushButton(pbd5_6_1);
            pb5_6_1.ToolTip = "选择窗户大小";
            pb5_6_1.LongDescription = "选择窗户大小";
            pb5_6_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_6_2 = new PushButtonData("GenerateWindow", "生成窗户", AddInPath, "RevitRedevelop.GenerateWindow");
            pb5_6_2 = pudb3.AddPushButton(pbd5_6_2);
            pb5_6_2.ToolTip = "生成窗户";
            pb5_6_2.LongDescription = "生成窗户";
            pb5_6_2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PulldownButtonData pudbd4 = new PulldownButtonData("PillarPull", "柱子");
            PulldownButton pudb4 = rp2_1.AddItem(pudbd4) as PulldownButton;
            pudb4.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_7 = new PushButtonData("DrawPillar", "放置柱子", AddInPath, "RevitRedevelop.DrawColumn");
            pb5_7 = pudb4.AddPushButton(pbd5_7);
            pb5_7.ToolTip = "放置柱子";
            pb5_7.LongDescription = "放置柱子";
            pb5_7.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_7_1 = new PushButtonData("ChoosePillarSize", "选择柱子尺寸", AddInPath, "RevitRedevelop.ChoosePillarSize");
            pb5_7_1 = pudb4.AddPushButton(pbd5_7_1);
            pb5_7_1.ToolTip = "选择柱子尺寸";
            pb5_7_1.LongDescription = "选择柱子尺寸";
            pb5_7_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_7_2 = new PushButtonData("GeneratePillar", "生成柱子", AddInPath, "RevitRedevelop.GeneratePillar");
            pb5_7_2 = pudb4.AddPushButton(pbd5_7_2);
            pb5_7_2.ToolTip = "生成柱子";
            pb5_7_2.LongDescription = "生成柱子";
            pb5_7_2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PulldownButtonData pudbd5 = new PulldownButtonData("Furniture", "放置构件");
            PulldownButton pudb5 = rp2_1.AddItem(pudbd5) as PulldownButton;
            pudb5.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_8 = new PushButtonData("Furniture", "选择构件", AddInPath, "RevitRedevelop.ChooseFurniture");
            pb5_8 = pudb5.AddPushButton(pbd5_8);
            pb5_8.ToolTip = "选择构件";
            pb5_8.LongDescription = "选择构件";
            pb5_8.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd5_8_1 = new PushButtonData("FurnitureLocation", "选择构件位置", AddInPath, "RevitRedevelop.ChooseFurniture");
            pb5_8_1 = pudb5.AddPushButton(pbd5_8_1);
            pb5_8_1.ToolTip = "选择构件位置";
            pb5_8_1.LongDescription = "选择构件位置";
            pb5_8_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            rp2_1.AddSeparator();

            pbd5_11 = new PushButtonData("3DPreview", "三维图", AddInPath, "RevitRedevelop.ThreeDPreview");
            pbd5_13 = new PushButtonData("ImportDwg", "导入DWG图纸", AddInPath, "RevitRedevelop.ImportCAD");
            IList<RibbonItem> ribbonItems = rp2_1.AddStackedItems(pbd5_11, pbd5_13);
            pb5_11 = ribbonItems[0] as PushButton;          
            pb5_13 = ribbonItems[1] as PushButton;
            pb5_11.ToolTip = "三维图预览";
            pb5_11.LongDescription = "三维图预览";
            pb5_11.Image = GetBitmapImage("F:/StrcturalWall.png");
            pb5_13.ToolTip = "导入DWG图纸";
            pb5_13.LongDescription = "导入DWG图纸";
            pb5_13.Image = GetBitmapImage("F:/StrcturalWall.png");

            rp2_1.AddSlideOut();

            PushButtonData pbd5_14 = new PushButtonData("DrawInfo1", "  信息显示  \n高(m):\n宽(m):", AddInPath,"asdasd");
            PushButton pb5_14 = rp2_1.AddItem(pbd5_14) as PushButton;
            pb5_14.ToolTip = "墙体信息显示";
            pb5_14.LongDescription = "墙体信息显示";
           
            TextBoxData txd1 = new TextBoxData("InfoShow1");
            TextBoxData txd2 = new TextBoxData("InfoShow2");
            
            ribbonItems = rp2_1.AddStackedItems(txd1, txd2);
            TextBox txt1 = ribbonItems[0] as TextBox;
            TextBox txt2 = ribbonItems[1] as TextBox;
            txt1.Width = 100;
            txt2.Width = 100;
            PushButtonData pbd5_15 = new PushButtonData("DrawInfo2", "\n\n长度(m):", AddInPath, "asdasdads");
            PushButton pb5_15 = rp2_1.AddItem(pbd5_15) as PushButton;
            pb5_15.ToolTip = "墙体信息显示";
            pb5_15.LongDescription = "墙体信息显示";

            TextBoxData txd3 = new TextBoxData("InfoShow3");

            TextBox txt3 = rp2_1.AddItem(txd3) as TextBox;
            txt3.Width = 100;

            pbd6_1 = new PushButtonData("AreaSplit", "区域划分", AddInPath, "RevitRedevelop.Pave");
            pb6_1 = rp2_2.AddItem(pbd6_1) as PushButton;
            pb6_1.ToolTip = "区域划分";
            pb6_1.LongDescription = "区域划分";
            pb6_1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd6_2 = new PushButtonData("ChoosePaveModel", "模板选择", AddInPath, "Pave");
            pb6_2 = rp2_2.AddItem(pbd6_2) as PushButton;
            pb6_2.ToolTip = "模板选择";
            pb6_2.LongDescription = "模板选择";
            pb6_2.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd6_3 = new PushButtonData("AdaptPave", "适配铺贴", AddInPath, "Pave");
            pb6_3 = rp2_2.AddItem(pbd6_3) as PushButton;
            pb6_3.ToolTip = "适配铺贴";
            pb6_3.LongDescription = "适配铺贴";
            pb6_3.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd7 = new PushButtonData("ResultExport", "      出图    ", AddInPath, "RevitRedevelop.ResultExport");
            pb7 = rp2_3.AddItem(pbd7) as PushButton;
            pb7.ToolTip = "See Selected Element";
            pb7.LongDescription = "方案生成";
            pb7.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd8 = new PushButtonData("FloorPlanManage", "户型图管理", AddInPath, "RevitRedevelop.FloorPlanManage");
            pb8 = rp3.AddItem(pbd8) as PushButton;
            pb8.ToolTip = "See Selected Element";
            pb8.LongDescription = "户型图的管理";
            pb8.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd9 = new PushButtonData("PaveModelManage", " 模板管理", AddInPath, "RevitRedevelop.PaveModelManage");
            pb9 = rp3.AddItem(pbd9) as PushButton;
            pb9.ToolTip = "See Selected Element";
            pb9.LongDescription = "铺砖模板管理";
            pb9.LargeImage = new BitmapImage(new Uri("F:/StrcturalWall.png"));

            pbd10 = new PushButtonData("TileProductManage", " 单品管理", AddInPath, "RevitRedevelop.TileProductManage");
            pb10 = rp3.AddItem(pbd10) as PushButton;
            pb10.ToolTip = "See Selected Element";
            pb10.LongDescription = "铺砖模板管理";
            pb10.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd11 = new PushButtonData("OnlineLearning", "在线视频", AddInPath, "OnlineLearning");
            pb11 = rp4.AddItem(pbd11) as PushButton;
            pb11.ToolTip = "See Selected Element";
            pb11.LongDescription = "";
            pb11.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd12 = new PushButtonData("OnlineHelp", "在线帮助", AddInPath, "OnlineHelp");
            pb12 = rp4.AddItem(pbd12) as PushButton;
            pb12.ToolTip = "See Selected Element";
            pb12.LongDescription = "";
            pb12.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
        }
        //private void InitializeRibbon()
        //{   
        //    pb1.Enabled = true;
        //    pb1.ItemText = "\n您好！\n          请登录!         ";
        //    pb1.Enabled = false;
        //    pb2.Enabled = true;
        //    pb2.ItemText = "登录";
        //    pb3.Enabled = true;
        //    pb3.ItemText = "注册";
        //    pb4.Enabled = false;
        //    pb5_1.Enabled = false;
        //    pb5_2.Enabled = false;
        //    pb5_3.Enabled = false;
        //    pb5_4.Enabled = false;
        //    pb5_5.Enabled = false;
        //    pb5_6.Enabled = false;
        //    pb5_7.Enabled = false;
        //    pb5_8.Enabled = false;
        //    pb5_11.Enabled = false;
        //    pb5_12.Enabled = false;
        //    pb6_1.Enabled = false;
        //    pb6_2.Enabled = false;
        //    pb6_3.Enabled = false;
        //    pb7.Enabled = false;
        //    pb8.Enabled = false;
        //    pb9.Enabled = false;
        //    pb10.Enabled = false;
        //}
        public void RegisterDockableSamplePane(UIControlledApplication application)
        {
            Guid retval;
            DockablePane temp;

            //string Guid0 = ConstGuid.LoginGuid;
            //UI.Login userLogin = new UI.Login();
            //userLogin.Show();
          //  retval = Guid.Empty;
          //  retval = new Guid(Guid1);
          //  DockablePaneId userInfo_UserDockablePaneId = new DockablePaneId(retval);

           // application.RegisterDockablePane(userInfo_UserDockablePaneId, "个人信息", userInfo as IDockablePaneProvider);

            //个人信息
            //string Guid1 = ConstGuid.UserInfoGuid;
            //UI.UserInfo userInfo = new UI.UserInfo();

            //retval = Guid.Empty;
            //retval = new Guid(Guid1);
            //DockablePaneId userInfo_UserDockablePaneId = new DockablePaneId(retval);

            //application.RegisterDockablePane(userInfo_UserDockablePaneId, "个人信息", userInfo as IDockablePaneProvider);

            ////temp = application.GetDockablePane(userInfo_UserDockablePaneId);
            ////temp.Hide();

            ////套餐购买
            //string Guid2 = ConstGuid.PackagePurchaseGuid;
            //UI.PackagePurchase PackagePurchase = new UI.PackagePurchase();

            //retval = Guid.Empty;
            //retval = new Guid(Guid2);
            //DockablePaneId PackagePurchase_UserDockablePaneId = new DockablePaneId(retval);

            //application.RegisterDockablePane(PackagePurchase_UserDockablePaneId, "套餐购买", PackagePurchase as IDockablePaneProvider);

            ////temp = application.GetDockablePane(PackagePurchase_UserDockablePaneId);
            //temp.Hide();

            //绘制户型图
            string Guid3 = ConstGuid.DrawFloorPlanGuid;
            UI.DrawFloorPlan DrawFloorPlan = new UI.DrawFloorPlan();

            retval = Guid.Empty;
            retval = new Guid(Guid3);
            DockablePaneId DrawFloorPlan_UserDockablePaneId = new DockablePaneId(retval);

            application.RegisterDockablePane(DrawFloorPlan_UserDockablePaneId, "绘制户型图", DrawFloorPlan as IDockablePaneProvider);

            //temp = application.GetDockablePane(DrawFloorPlan_UserDockablePaneId);
            //temp.Hide();

            string Guid3_1 = ConstGuid.ChooseSizeGuid;
            UI.ChooseSize choosesize = new UI.ChooseSize();

            retval = Guid.Empty;
            retval = new Guid(Guid3_1);
            DockablePaneId choosesize_UserDockablePaneId = new DockablePaneId(retval);

            application.RegisterDockablePane(choosesize_UserDockablePaneId, "选择墙的尺寸", choosesize as IDockablePaneProvider);

            string Guid3_2 = ConstGuid.ChooseDoorSizeGuid;
            UI.ChooseDoorSize choosedoorsize = new UI.ChooseDoorSize();

            retval = Guid.Empty;
            retval = new Guid(Guid3_2);
            DockablePaneId choosedoorsize_UserDockablePaneId = new DockablePaneId(retval);

            application.RegisterDockablePane(choosedoorsize_UserDockablePaneId, "选择门的尺寸", choosesize as IDockablePaneProvider);

            string Guid4 = ConstGuid.PaveGuid;
            UI.Pave pave = new UI.Pave();

            retval = Guid.Empty;
            retval = new Guid(Guid4);
            DockablePaneId Pave_UserDockablePaneId = new DockablePaneId(retval);

            application.RegisterDockablePane(Pave_UserDockablePaneId, "铺砖", pave as IDockablePaneProvider);

            //temp = application.GetDockablePane(Pave_UserDockablePaneId);
            //temp.Hide();

            //string Guid5 = ConstGuid.ResultExportGuid;
            //UI.ResultExport resultExport = new UI.ResultExport();

            //retval = Guid.Empty;
            //retval = new Guid(Guid5);
            //DockablePaneId ResultExport_UserDockablePaneId = new DockablePaneId(retval);

            //application.RegisterDockablePane(ResultExport_UserDockablePaneId, "出图", resultExport as IDockablePaneProvider);

            //temp = application.GetDockablePane(ResultExport_UserDockablePaneId);
            //temp.Hide();

          

        }
        public BitmapImage GetBitmapImage(string imageName)
        {
            return new BitmapImage(new Uri(
             imageName));
        }
    }
}