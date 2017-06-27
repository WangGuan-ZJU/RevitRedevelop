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

namespace RevitRedevelop.UI
{
    /// <summary>
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Enroll(object sender, RoutedEventArgs e)
        {
            //**********************************
            //注册逻辑UserEnroll.cs
            //**********************************
            //注册成功
            UIEntityApp.InitUIAfterLogin();
            this.Close();
        }
        private void SendVerificationCode(object sender, RoutedEventArgs e)
        {

        }
    }
}
