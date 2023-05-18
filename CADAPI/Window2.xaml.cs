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
using System.Windows.Shapes;
using CADAPI;
namespace CADAPI
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            DataContext = this.DataContext;
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(1);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(2);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(3);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(4);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(32);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(33);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(34);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(35);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(36);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(64);
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(65);
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(66);
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(67);
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(68);
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(96);
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(97);
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(98);
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(99);
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(100);
        }

        private void Small_Checked(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsSize(3);
        }

        private void Medium_Checked(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsSize(6);
        }

        private void Large_Checked(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsSize(9);
        }

        public void Key02_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Window1 w = new Window1();
            //main.setwindowstate(false)



            //Window1 w1 = new Window1();
            //Start_WPF s = new Start_WPF(w1);
            
            
            //w1.Visibility = System.Windows.Visibility.Visible;
        }

        private void Key01_Click(object sender, RoutedEventArgs e)
        {
            Logic.SetPointsStyle(0);
            Logic.SetPointsSize(0);
            this.Close();
            

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }

        }

        
    }
}