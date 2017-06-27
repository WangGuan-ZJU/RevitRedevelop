using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Autodesk.Revit.UI;

namespace RevitRedevelop.UI
{
    /// <summary>
    /// PaveModelManage.xaml 的交互逻辑
    /// </summary>
    public partial class PaveModelManage : Window{
        public PaveModelManage()
        {
            InitializeComponent();
        }

        private void OpenPaveModelLib(object sender, RoutedEventArgs e)
        {
            PaveModelLib pavemodellib = new PaveModelLib();
            pavemodellib.Show();
        }
    }
}
