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
                        pushbutton.ItemText = "\n您好！\n          请登录!         ";
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
                    if (item.Name == "Door")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "Window")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "Pillar")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "Furniture")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "3DPreview")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "ImportDwg")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "AreaSplit")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;

                    }
                    if (item.Name == "ChoosePaveModel")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = false;
                    }
                    if (item.Name == "AdaptPave")
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
                    if (item.Name == "Wall")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "Door")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "Window")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "Pillar")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "Furniture")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;

                    }
                    if (item.Name == "3DPreview")
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
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;

                    }
                    if (item.Name == "ChoosePaveModel")
                    {
                        pushbutton = item as PushButton;
                        pushbutton.Enabled = true;
                    }
                    if (item.Name == "AdaptPave")
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
