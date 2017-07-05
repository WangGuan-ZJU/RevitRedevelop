using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
//using RApplication = Autodesk.Revit.ApplicationServices.Application;

namespace RevitRedevelop
{
    public static class UIEntityApp
    {
        public static Autodesk.Revit.UI.UIApplication myApp;
        public static Autodesk.Revit.DB.ElementSet ElementSet;
        public static Autodesk.Revit.UI.ExternalCommandData commandData;
        public static Autodesk.Revit.UI.UIDocument uidoc;
        public static Autodesk.Revit.DB.Document document;
        public static string message;
        //public UIApp(Autodesk.Revit.UI.UIApplication app)
        //{
        //    myApp = app;
        //}
        //public Autodesk.Revit.UI.UIApplication get()
        //{
        //    return myApp;
        //}
        public static void InitUI()
        {
            RibbonPanel ribbonpanel = null;
            List<RibbonPanel> listRobbonPanel = myApp.GetRibbonPanels("砖+宝");
            foreach (RibbonPanel panel in listRobbonPanel)
            {
                ribbonpanel = panel;
                IList<RibbonItem> listItem = ribbonpanel.GetItems();
                PushButton pushbutton = null;
                PulldownButton pulldownbuuton = null;
                foreach (RibbonItem item in listItem)
                {
                    if (item.Name == "UserInfo")//Ribbon的Name属性
                    {
                        pushbutton = item as PushButton;
                        pushbutton.ItemText = "登录";
                    }
                    if (item.Name == "PackagePurchase")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.ItemText = "注册";
                    }
                    if (item.Name == "userInfoShow")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.ItemText = "\n      您好           \n  请登录           ";
                    }
                    if (item.Name == "LogOut")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "ChooseFloorPlan")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "EnsureFloorPlan")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "Wall")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "ChooseSize")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "GenerateWall")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "Door")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "ChooseDoorSize")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "GenerateDoor")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "DrawWindow")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    } if (item.Name == "ChooseWindowSize")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "GenerateWindow")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "DrawPillar")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "ChoosePillarSize")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "GeneratePillar")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "FurnitureLocation")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "ChooseFurniture")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "ImportRevit")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "ImportDwg")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "AreaPartition")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "ChoosePaveModel")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "DoorStone")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "SplitLine")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "Pave")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "3DPreview")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "ResultExport")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "FloorPlanManage")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "PaveModelManage")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "TileProductManage")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                }
            }
            
        }
        public static void InitUIAfterLogin()
        {
            RibbonPanel ribbonpanel = null;
            List<RibbonPanel> listRobbonPanel = myApp.GetRibbonPanels("砖+宝");        
            foreach (RibbonPanel panel in listRobbonPanel)
            {  
                ribbonpanel = panel;
                IList<RibbonItem> listItem = ribbonpanel.GetItems();
                PushButton pushbutton = null;
                PulldownButton pulldownbuuton = null;
                foreach (RibbonItem item in listItem)
                {
                    if (item.Name == "UserInfo")//Ribbon的Name属性
                    {
                        pushbutton = item as PushButton;
                        pushbutton.ItemText = "个人信息";
                    }
                    if (item.Name == "PackagePurchase")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.ItemText = "套餐购买";
                    }
                    if (item.Name == "userInfoShow")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.ItemText = "\nAdministrator，您好！\n testtsetsetsetset!";
                    }
                    if (item.Name == "LogOut")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "ChooseFloorPlan")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "EnsureFloorPlan")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "WallPull")
                    {
                        pulldownbuuton = item as PulldownButton;
                        IList<PushButton> list = pulldownbuuton.GetItems();
                        foreach (PushButton pb in list)
                        {
                            pb.Enabled = true;
                            //if (pb.Name == "Wall")
                            //{
                            //    pushbutton = pb as PushButton;
                            //    pushbutton.Enabled = true;
                            //}
                            //if (pb.Name == "ChooseSize")
                            //{
                            //    pushbutton = pb as PushButton;
                            //    pushbutton.Enabled = true;
                            //}
                            //if (pb.Name == "GenerateWall")
                            //{
                            //    pushbutton = pb as PushButton;
                            //    pushbutton.Enabled = true;
                            //}
                        }
                    }
                   
                    if (item.Name == "DoorPull")
                    {
                        pulldownbuuton = item as PulldownButton;
                        pulldownbuuton = item as PulldownButton;
                        IList<PushButton> list = pulldownbuuton.GetItems();
                        foreach (PushButton pb in list)
                        {
                            pb.Enabled = true;
                            //if (item.Name == "Door")
                            //{
                            //    pushbutton = item as PushButton;
                            //    pushbutton.Enabled = true;
                            //}
                            //if (item.Name == "ChooseDoorSize")
                            //{
                            //    pushbutton = item as PushButton;
                            //    pushbutton.Enabled = true;
                            //}
                            //if (item.Name == "GenerateDoor")
                            //{
                            //    pushbutton = item as PushButton;
                            //    pushbutton.Enabled = true;
                            //}
                        }
                    }
                    //if (item.Name == "Door")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;
                    //}
                    //if (item.Name == "ChooseDoorSize")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;
                    //}
                    //if (item.Name == "GenerateDoor")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;
                    //}

                    if (item.Name == "WindowPull")
                    {
                        pulldownbuuton = item as PulldownButton;
                        pulldownbuuton = item as PulldownButton;
                        IList<PushButton> list = pulldownbuuton.GetItems();
                        foreach (PushButton pb in list)
                        {
                            pb.Enabled = true;
                        }
                    }
                    //if (item.Name == "DrawWindow")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;
                    //} if (item.Name == "ChooseWindowSize")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;
                    //}
                    //if (item.Name == "GenerateWindow")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;
                    //}
                    if (item.Name == "PillarPull")
                    {
                        pulldownbuuton = item as PulldownButton;
                        pulldownbuuton = item as PulldownButton;
                        IList<PushButton> list = pulldownbuuton.GetItems();
                        foreach (PushButton pb in list)
                        {
                            pb.Enabled = true;
                        }
                    }
                    //if (item.Name == "DrawPillar")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;
                    //}
                    //if (item.Name == "ChoosePillarSize")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;

                    //}
                    //if (item.Name == "GeneratePillar")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;

                    //}
                    if (item.Name == "Furniture")
                    {
                        pulldownbuuton = item as PulldownButton;
                        pulldownbuuton = item as PulldownButton;
                        IList<PushButton> list = pulldownbuuton.GetItems();
                        foreach (PushButton pb in list)
                        {
                            pb.Enabled = true;
                        }
                    }
                    //if (item.Name == "FurnitureLocation")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;

                    //}
                    //if (item.Name == "ChooseFurniture")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;

                    //}
                    if (item.Name == "ImportRevit")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;

                    }
                    if (item.Name == "ImportDwg")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;

                    }
                    if (item.Name == "AreaSplit")
                    {
                        pulldownbuuton = item as PulldownButton;
                        pulldownbuuton = item as PulldownButton;
                        IList<PushButton> list = pulldownbuuton.GetItems();
                        foreach (PushButton pb in list)
                        {
                            pb.Enabled = true;
                        }
                    }
                    //if (item.Name == "AreaPartition")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;

                    //}
                    //if (item.Name == "DoorStone")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;
                    //}
                    //if (item.Name == "SplitLine")
                    //{
                    //    pushbutton = item as PushButton;
                    //    pushbutton.Enabled = true;
                    //}
                    if (item.Name == "Pave")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "3DPreview")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "ResultExport")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "FloorPlanManage")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "PaveModelManage")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "TileProductManage")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                }
            }
        }
    }
}
