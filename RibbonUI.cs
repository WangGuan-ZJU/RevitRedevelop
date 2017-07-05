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
        PushButtonData pbdWelcome;
        PushButton pbWelcome;
        PushButtonData pbdLogin;
        PushButton pbLogin;
        PushButtonData pbdRegister;
        PushButton pbRegister;
        PushButtonData pbdLogout;
        PushButton pbLogout;
        PushButtonData pbdChooseFloorPlan;
        PushButton pbChooseFloorPlan;
        PushButtonData pbdEnsureFloorPlan;
        PushButton pbEnsureFloorPlan;
        PushButtonData pbdFloorPlan;
        PushButton pbFloorPlan;
        PushButtonData pbdChooseSize;
        PushButton pbChooseSize;
        PushButtonData pbdWall;
        PushButton pbWall;
        PushButtonData pbdGenerateWall;
        PushButton pbGenerateWall;
        PushButtonData pbdDoor;
        PushButton pbDoor;
        PushButtonData pbdChooseDoorSize;
        PushButton pbChooseDoorSize;
        PushButtonData pbdGenerateDoor;
        PushButton pbGenerateDoor;
        PushButtonData pbdDrawWindow;
        PushButton pbDrawWindow;
        PushButtonData pbdChooseWindowSize;
        PushButton pbChooseWindowSize;
        PushButtonData pbdGenerateWindow;
        PushButton pbGenerateWindow;
        PushButtonData pbdDrawPillar;
        PushButton pbDrawPillar;
        PushButtonData pbdChoosePillarSize;
        PushButton pbChoosePillarSize;
        PushButtonData pbdGeneratePillar;
        PushButton pbGeneratePillar;
        PushButtonData pbdChooseFurniture;
        PushButton pbChooseFurniture;
        PushButtonData pbdFurnitureLocation;
        PushButton pbFurnitureLocation;
        PushButtonData pbdImportRevit;
        PushButton pbImportRevit;
        PushButtonData pbdImportDwg;
        PushButton pbImportDwg;
        PushButtonData pbdCollectFloorPlan;
        PushButton pbCollectFloorPlan;
        PushButtonData pbdAreaPartition;
        PushButton pbAreaPartition;
        PushButtonData pbdDoorStone;
        PushButton pbDoorStone;
        PushButtonData pbdSplitLine;
        PushButton pbSplitLine;
        PushButtonData pbdPave;
        PushButton pbPave;
        PushButtonData pbdResultExport;
        PushButton pbResultExport;
        PushButtonData pbd3DPreview;
        PushButton pb3DPreview;
        PushButtonData pbdFloorPlanManage;
        PushButton pbFloorPlanManage;
        PushButtonData pbdPaveModelManage;
        PushButton pbPaveModelManage;
        PushButtonData pbdTileProductManage;
        PushButton pbTileProductManage;
        PushButtonData pbdOnlineLearning;
        PushButton pbOnlineLearning;
        PushButtonData pbdOnlineHelp;
        PushButton pbOnlineHelp;
        PulldownButtonData pudbdWall;
        PulldownButtonData pudbdDoor;
        PulldownButtonData pudbdWindow;
        PulldownButtonData pudbdPillar;
        PulldownButtonData pudbdFurniture;
        PulldownButtonData pudbdAreaSplit;
        PulldownButton pudbWall;
        PulldownButton pudbDoor;
        PulldownButton pudbWindow;
        PulldownButton pudbPillar;
        PulldownButton pudbFurniture;
        PulldownButton pudbAreaSplit;
        #endregion
        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        {
            try
            {
                CreateRibbonSamplePanel(application);
                InitializeRibbon();
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

            String userInfoShow = "\n您好！\n          请登录!         ";
            pbdWelcome = new PushButtonData("userInfoShow", userInfoShow, AddInPath, "userInfoShow");
            pbWelcome = rp1.AddItem(pbdWelcome) as PushButton;
            pbWelcome.Enabled = false;

            //pbd1.AvailabilityClassName = "RevitRedevelop.AvailabilityControll";

            pbdLogin = new PushButtonData("UserInfo", "个人信息", AddInPath, "RevitRedevelop.UserInfoDockablePane");
            pbLogin = rp1.AddItem(pbdLogin) as PushButton;
            pbLogin.ToolTip = "查看个人信息";
            pbLogin.LongDescription = "查看个人信息";
            pbLogin.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdRegister = new PushButtonData("PackagePurchase", "套餐购买", AddInPath, "RevitRedevelop.PackagePurchaseDockablePane");
            pbRegister = rp1.AddItem(pbdRegister) as PushButton;
            pbRegister.ToolTip = "进行套餐的浏览和购买";
            pbRegister.LongDescription = "进行套餐的浏览和购买";
            pbRegister.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdLogout = new PushButtonData("LogOut", "退出登录", AddInPath, "RevitRedevelop.LogOut");
            pbLogout = rp1.AddItem(pbdLogout) as PushButton;
            pbLogout.ToolTip = "退出当前登录";
            pbLogout.LongDescription = "退出当前登录";
            pbLogout.LargeImage = GetBitmapImage("F:/StrcturalWall.png");


            pbdChooseFloorPlan = new PushButtonData("ChooseFloorPlan", "选择户型图", AddInPath, "RevitRedevelop.DrawFloorPlanDockablePane");
            pbChooseFloorPlan = rp2_1.AddItem(pbdChooseFloorPlan) as PushButton;
            pbChooseFloorPlan.ToolTip = "进行户型图的选择";
            pbChooseFloorPlan.LongDescription = "进行户型图的选择";
            pbChooseFloorPlan.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
            //pbdEnsureFloorPlan = new PushButtonData("EnsureFloorPlan", "户型图读入", AddInPath, "RevitRedevelop.ImportFloorPlan");
            //pbEnsureFloorPlan = rp2_1.AddItem(pbdEnsureFloorPlan) as PushButton;
            //pbEnsureFloorPlan.ToolTip = "确认选择的户型图";
            //pbEnsureFloorPlan.LongDescription = "进行户型图的选择";
            //pbEnsureFloorPlan.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
           
            rp2_1.AddSeparator();

            pbdFloorPlan = new PushButtonData("FloorPlan", "\n手动绘制\n户型图", AddInPath, "LogOut");
            pbFloorPlan = rp2_1.AddItem(pbdFloorPlan) as PushButton;
            pbFloorPlan.Enabled = false;
            //SplitButtonData spbd = new SplitButtonData("NewWallSplit", "创建墙");
            //SplitButton spb = rp2_1.AddItem(spbd) as SplitButton;

            pudbdWall = new PulldownButtonData("WallPull", "墙体");
            pudbWall = rp2_1.AddItem(pudbdWall) as PulldownButton;
            pudbWall.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdWall = new PushButtonData("Wall", "绘制墙的轮廓", AddInPath, "RevitRedevelop.DrawWall");
            pbWall = pudbWall.AddPushButton(pbdWall);
            pbWall.ToolTip = "绘制墙的轮廓";
            pbWall.LongDescription = "绘制墙的轮廓";
            pbWall.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdChooseSize = new PushButtonData("ChooseSize", "选择墙的尺寸", AddInPath, "RevitRedevelop.ChooseSize");
            pbChooseSize = pudbWall.AddPushButton(pbdChooseSize);
            pbChooseSize.ToolTip = "选择墙的尺寸";
            pbChooseSize.LongDescription = "选择墙的尺寸";
            pbChooseSize.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdGenerateWall = new PushButtonData("GenerateWall", "生成墙体", AddInPath, "RevitRedevelop.GenerateWall");
            pbGenerateWall = pudbWall.AddPushButton(pbdGenerateWall);
            pbGenerateWall.ToolTip = "生成墙体";
            pbGenerateWall.LongDescription = "生成墙体";
            pbGenerateWall.LargeImage = GetBitmapImage("F:/StrcturalWall.png");


            pudbdDoor = new PulldownButtonData("DoorPull", "门");
            pudbDoor = rp2_1.AddItem(pudbdDoor) as PulldownButton;
            pudbDoor.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdDoor = new PushButtonData("Door", "绘制门位置", AddInPath, "RevitRedevelop.DrawDoor");
            pbDoor = pudbDoor.AddPushButton(pbdDoor);
            pbDoor.ToolTip = "绘制门位置";
            pbDoor.LongDescription = "绘制门位置";
            pbDoor.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdChooseDoorSize = new PushButtonData("ChooseDoorSize", "选择门尺寸", AddInPath, "RevitRedevelop.ChooseDoorSize");
            pbChooseDoorSize = pudbDoor.AddPushButton(pbdChooseDoorSize);
            pbChooseDoorSize.ToolTip = "选择门尺寸";
            pbChooseDoorSize.LongDescription = "选择门尺寸";
            pbChooseDoorSize.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdGenerateDoor = new PushButtonData("GenerateDoor", "生成门", AddInPath, "RevitRedevelop.GenerateDoor");
            pbGenerateDoor = pudbDoor.AddPushButton(pbdGenerateDoor);
            pbGenerateDoor.ToolTip = "生成门";
            pbGenerateDoor.LongDescription = "生成门";
            pbGenerateDoor.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pudbdWindow = new PulldownButtonData("WindowPull", "窗");
            pudbWindow = rp2_1.AddItem(pudbdWindow) as PulldownButton;
            pudbWindow.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdDrawWindow = new PushButtonData("DrawWindow", "窗", AddInPath, "RevitRedevelop.DrawWindow");
            pbDrawWindow = pudbWindow.AddPushButton(pbdDrawWindow);
            pbDrawWindow.ToolTip = "绘制窗";
            pbDrawWindow.LongDescription = "绘制窗";
            pbDrawWindow.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdChooseWindowSize = new PushButtonData("ChooseWindowSize", "选择窗户大小", AddInPath, "RevitRedevelop.ChooseWindowSize");
            pbChooseWindowSize = pudbWindow.AddPushButton(pbdChooseWindowSize);
            pbChooseWindowSize.ToolTip = "选择窗户大小";
            pbChooseWindowSize.LongDescription = "选择窗户大小";
            pbChooseWindowSize.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdGenerateWindow = new PushButtonData("GenerateWindow", "生成窗户", AddInPath, "RevitRedevelop.GenerateWindow");
            pbGenerateWindow = pudbWindow.AddPushButton(pbdGenerateWindow);
            pbGenerateWindow.ToolTip = "生成窗户";
            pbGenerateWindow.LongDescription = "生成窗户";
            pbGenerateWindow.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pudbdPillar = new PulldownButtonData("PillarPull", "柱子");
            pudbPillar = rp2_1.AddItem(pudbdPillar) as PulldownButton;
            pudbPillar.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdDrawPillar = new PushButtonData("DrawPillar", "放置柱子", AddInPath, "RevitRedevelop.DrawColumn");
            pbDrawPillar = pudbPillar.AddPushButton(pbdDrawPillar);
            pbDrawPillar.ToolTip = "放置柱子";
            pbDrawPillar.LongDescription = "放置柱子";
            pbDrawPillar.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdChoosePillarSize = new PushButtonData("ChoosePillarSize", "选择柱子尺寸", AddInPath, "RevitRedevelop.ChoosePillarSize");
            pbChoosePillarSize = pudbPillar.AddPushButton(pbdChoosePillarSize);
            pbChoosePillarSize.ToolTip = "选择柱子尺寸";
            pbChoosePillarSize.LongDescription = "选择柱子尺寸";
            pbChoosePillarSize.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdGeneratePillar = new PushButtonData("GeneratePillar", "生成柱子", AddInPath, "RevitRedevelop.GeneratePillar");
            pbGeneratePillar = pudbPillar.AddPushButton(pbdGeneratePillar);
            pbGeneratePillar.ToolTip = "生成柱子";
            pbGeneratePillar.LongDescription = "生成柱子";
            pbGeneratePillar.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pudbdFurniture = new PulldownButtonData("Furniture", "放置构件");
            pudbFurniture = rp2_1.AddItem(pudbdFurniture) as PulldownButton;
            pudbFurniture.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdChooseFurniture = new PushButtonData("ChooseFurniture", "选择构件", AddInPath, "RevitRedevelop.ChooseFurniture");
            pbChooseFurniture = pudbFurniture.AddPushButton(pbdChooseFurniture);
            pbChooseFurniture.ToolTip = "选择构件";
            pbChooseFurniture.LongDescription = "选择构件";
            pbChooseFurniture.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdFurnitureLocation = new PushButtonData("FurnitureLocation", "选择构件位置", AddInPath, "RevitRedevelop.ChooseFurniture");
            pbFurnitureLocation = pudbFurniture.AddPushButton(pbdFurnitureLocation);
            pbFurnitureLocation.ToolTip = "选择构件位置";
            pbFurnitureLocation.LongDescription = "选择构件位置";
            pbFurnitureLocation.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            rp2_1.AddSeparator();

            pbdImportRevit = new PushButtonData("ImportRevit", "导入Revit文件", AddInPath, "RevitRedevelop.ImportRevit");
            pbdImportDwg = new PushButtonData("ImportDwg", "导入DWG图纸", AddInPath, "RevitRedevelop.ImportCAD");
            IList<RibbonItem> ribbonItems = rp2_1.AddStackedItems(pbdImportRevit, pbdImportDwg);
            pbImportRevit = ribbonItems[0] as PushButton;
            pbImportDwg = ribbonItems[1] as PushButton;
            pbImportRevit.ToolTip = "导入Revit文件";
            pbImportRevit.LongDescription = "导入Revit文件";
            pbImportRevit.Image = GetBitmapImage("F:/StrcturalWall.png");
            pbImportDwg.ToolTip = "导入DWG图纸";
            pbImportDwg.LongDescription = "导入DWG图纸";
            pbImportDwg.Image = GetBitmapImage("F:/StrcturalWall.png");

            rp2_1.AddSlideOut();

            PushButtonData pbdDrawInfo1 = new PushButtonData("DrawInfo1", "  信息显示  \n高(m):\n宽(m):", AddInPath, "asdasd");
            PushButton pbpbdDrawInfo1 = rp2_1.AddItem(pbdDrawInfo1) as PushButton;
            pbpbdDrawInfo1.ToolTip = "墙体信息显示";
            pbpbdDrawInfo1.LongDescription = "墙体信息显示";
            pbpbdDrawInfo1.Enabled = false;

            TextBoxData txd1 = new TextBoxData("InfoShow1");
            TextBoxData txd2 = new TextBoxData("InfoShow2");
            
            ribbonItems = rp2_1.AddStackedItems(txd1, txd2);
            TextBox txt1 = ribbonItems[0] as TextBox;
            TextBox txt2 = ribbonItems[1] as TextBox;
            txt1.Width = 100;
            txt2.Width = 100;
            PushButtonData pbdDrawInfo2 = new PushButtonData("DrawInfo2", "\n\n长度(m):", AddInPath, "asdasdads");
            PushButton pbDrawInfo2 = rp2_1.AddItem(pbdDrawInfo2) as PushButton;
            pbDrawInfo2.ToolTip = "墙体信息显示";
            pbDrawInfo2.LongDescription = "墙体信息显示";
            pbDrawInfo2.Enabled = false;

            TextBoxData txd3 = new TextBoxData("InfoShow3");

            TextBox txt3 = rp2_1.AddItem(txd3) as TextBox;
            txt3.Width = 100;

            pbdCollectFloorPlan = new PushButtonData("CollectFloorPlan","收藏户型图",AddInPath,"RevitRedevelop.Collect");
            pbCollectFloorPlan = rp2_1.AddItem(pbdCollectFloorPlan) as PushButton;
            pbCollectFloorPlan.ToolTip = "收藏户型图图纸";
            pbCollectFloorPlan.LongDescription = "收藏户型图图纸";
            pbCollectFloorPlan.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pudbdAreaSplit = new PulldownButtonData("AreaSplit", "区域划分");
            pudbAreaSplit = rp2_2.AddItem(pudbdAreaSplit) as PulldownButton;
            pudbAreaSplit.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdAreaPartition = new PushButtonData("AreaPartition", "铺贴区域", AddInPath, "RevitRedevelop.AreaPartition");
            pbAreaPartition = pudbAreaSplit.AddPushButton(pbdAreaPartition);
            pbAreaPartition.ToolTip = "铺贴区域";
            pbAreaPartition.LongDescription = "铺贴区域";
            pbAreaPartition.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdDoorStone = new PushButtonData("DoorStone", "门槛石", AddInPath, "RevitRedevelop.DoorStone");
            pbDoorStone = pudbAreaSplit.AddPushButton(pbdDoorStone);
            pbDoorStone.ToolTip = "门槛石";
            pbDoorStone.LongDescription = "门槛石";
            pbDoorStone.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdSplitLine = new PushButtonData("SplitLine", "区域划分线", AddInPath, "RevitRedevelop.SplitLine");
            pbSplitLine = pudbAreaSplit.AddPushButton(pbdSplitLine);
            pbSplitLine.ToolTip = "区域划分线";
            pbSplitLine.LongDescription = "区域划分线";
            pbSplitLine.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdPave = new PushButtonData("Pave", "铺贴", AddInPath, "RevitRedevelop.Pave");
            pbPave = rp2_2.AddItem(pbdPave) as PushButton;
            pbPave.ToolTip = "铺贴";
            pbPave.LongDescription = "铺贴";
            pbPave.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            PushButtonData pbdPave1 = new PushButtonData("Pave1", "铺贴", AddInPath, "RevitRedevelop.Pave1");
            PushButton pbPave1 = rp2_2.AddItem(pbdPave1) as PushButton;
            pbPave1.ToolTip = "铺贴";
            pbPave1.LongDescription = "铺贴";
            pbPave1.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbd3DPreview = new PushButtonData("3DPreview", "三维预览", AddInPath, "RevitRedevelop.ThreeDPreview");
            pb3DPreview = rp2_3.AddItem(pbd3DPreview) as PushButton;
            pb3DPreview.ToolTip = "三维预览";
            pb3DPreview.LongDescription = "三维预览";
            pb3DPreview.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdResultExport = new PushButtonData("ResultExport", "      出图    ", AddInPath, "RevitRedevelop.ResultExport");
            pbResultExport = rp2_3.AddItem(pbdResultExport) as PushButton;
            pbResultExport.ToolTip = "See Selected Element";
            pbResultExport.LongDescription = "方案生成";
            pbResultExport.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdFloorPlanManage = new PushButtonData("FloorPlanManage", "户型图管理", AddInPath, "RevitRedevelop.FloorPlanManage");
            pbFloorPlanManage = rp3.AddItem(pbdFloorPlanManage) as PushButton;
            pbFloorPlanManage.ToolTip = "See Selected Element";
            pbFloorPlanManage.LongDescription = "户型图的管理";
            pbFloorPlanManage.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdPaveModelManage = new PushButtonData("PaveModelManage", " 模板管理", AddInPath, "RevitRedevelop.PaveModelManage");
            pbPaveModelManage = rp3.AddItem(pbdPaveModelManage) as PushButton;
            pbPaveModelManage.ToolTip = "See Selected Element";
            pbPaveModelManage.LongDescription = "铺砖模板管理";
            pbPaveModelManage.LargeImage = new BitmapImage(new Uri("F:/StrcturalWall.png"));

            pbdTileProductManage = new PushButtonData("TileProductManage", " 单品管理", AddInPath, "RevitRedevelop.TileProductManage");
            pbTileProductManage = rp3.AddItem(pbdTileProductManage) as PushButton;
            pbTileProductManage.ToolTip = "See Selected Element";
            pbTileProductManage.LongDescription = "铺砖模板管理";
            pbTileProductManage.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdOnlineLearning = new PushButtonData("OnlineLearning", "在线视频", AddInPath, "OnlineLearning");
            pbOnlineLearning = rp4.AddItem(pbdOnlineLearning) as PushButton;
            pbOnlineLearning.ToolTip = "See Selected Element";
            pbOnlineLearning.LongDescription = "";
            pbOnlineLearning.LargeImage = GetBitmapImage("F:/StrcturalWall.png");

            pbdOnlineHelp = new PushButtonData("OnlineHelp", "在线帮助", AddInPath, "OnlineHelp");
            pbOnlineHelp = rp4.AddItem(pbdOnlineHelp) as PushButton;
            pbOnlineHelp.ToolTip = "See Selected Element";
            pbOnlineHelp.LongDescription = "";
            pbOnlineHelp.LargeImage = GetBitmapImage("F:/StrcturalWall.png");
        }
        private void InitializeRibbon()
        {
            pbWelcome.Enabled = false;
            pbWelcome.ItemText = "\n      您好           \n    请登录         ";
            pbLogin.Enabled = true;
            pbLogin.ItemText = "登录";
            pbRegister.Enabled = true;
            pbRegister.ItemText = "注册";
            pbLogout.Enabled = false;
            pbChooseFloorPlan.Enabled = false;
            pbFloorPlan.Enabled = false;
            pbChooseSize.Enabled = false;
            pbWall.Enabled = false;
            pbGenerateWall.Enabled = false;
            pbDoor.Enabled = false;
            pbChooseDoorSize.Enabled = false;
            pbGenerateDoor.Enabled = false;
            pbDrawWindow.Enabled = false;
            pbChooseWindowSize.Enabled = false;
            pbGenerateWindow.Enabled = false;
            pbDrawPillar.Enabled = false;
            pbChoosePillarSize.Enabled = false;
            pbGeneratePillar.Enabled = false;
            pbChooseFurniture.Enabled = false;
            pbFurnitureLocation.Enabled = false;
            pbImportRevit.Enabled = false;
            pbImportDwg.Enabled = false;
            pbAreaPartition.Enabled = false;
            pbDoorStone.Enabled = false;
            pbSplitLine.Enabled = false;
            pbPave.Enabled = false;
            pbResultExport.Enabled = false;
            pb3DPreview.Enabled = false;
            pbFloorPlanManage.Enabled = false;
            pbPaveModelManage.Enabled = false;
            pbTileProductManage.Enabled = false;
            //pudbWall.Enabled = false;
            //pudbDoor.Enabled = false;
            //pudbWindow.Enabled = false;
            //pudbPillar.Enabled = false;
            //pudbFurniture.Enabled = false;
            //pudbAreaSplit.Enabled = false;
        }
        public void RegisterDockableSamplePane(UIControlledApplication application)
        {
            Guid retval;
            DockablePane temp;

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

            //string Guid4 = ConstGuid.PaveGuid;
            //UI.Pave pave = new UI.Pave();

            //retval = Guid.Empty;
            //retval = new Guid(Guid4);
            //DockablePaneId Pave_UserDockablePaneId = new DockablePaneId(retval);

            //application.RegisterDockablePane(Pave_UserDockablePaneId, "铺砖", pave as IDockablePaneProvider);

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