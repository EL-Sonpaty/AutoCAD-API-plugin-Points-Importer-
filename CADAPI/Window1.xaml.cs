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
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.Geometry;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
using Autodesk.AutoCAD.Windows;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OfficeOpenXml;
using System.Security.Cryptography;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;




namespace CADAPI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        public void setwindowstate(bool minimized)
        {
            if (minimized)
            {
                this.WindowState = WindowState.Minimized;

            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        
        public Window1()
        {
            DataContext = this.DataContext;
            InitializeComponent();
        }

        private void Change_Points_Style(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            //setwindowstate(true);
            //this.WindowState = WindowState.Minimized;
            //this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void Execute_Click(object sender, RoutedEventArgs e)
        {
            
            Logic.DropMyPoints(filepath.Text, Convert.ToInt32(Xvalue.Text), Convert.ToInt32(Yvalue.Text), Convert.ToInt32(Zvalue.Text));
            this.Close();
        }


        public void Import_Click(object sender, RoutedEventArgs e)
        {

            filepath.Text = Logic.GetPath();
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                this.DragMove();
            }

        }
    }
}

