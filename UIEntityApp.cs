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
    }
}
