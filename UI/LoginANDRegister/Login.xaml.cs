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
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login(object sender, RoutedEventArgs e)
        {
            //**********************************
            //登录逻辑UserLogin.cs
            //**********************************
            //登陆成功
            UIEntityApp.InitUIAfterLogin();
            this.Close();
        }

        private void LoginAndRegister(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void ForgetPassword(object sender, RoutedEventArgs e)
        {
            ForgetPassWord forgetPassword = new ForgetPassWord();
            forgetPassword.Show();
        }
    }
}
