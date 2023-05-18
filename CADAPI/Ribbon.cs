using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Windows;
using CADAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CADAPI
{
    public static class BitmapExtensions
    {
        public static BitmapImage ToBitmapImage(this Bitmap image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            BitmapImage bi = new BitmapImage();

            
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            return bi;
            
        }
    }



    public class Ribbon
    {
        public const string RibbonTitle = "ITI-Addins";
        public const string RibbonId = "10 10";
        //public BitmapImage getBitmap(string fileName)

        //{

        //    BitmapImage bmp = new BitmapImage();

        //    // BitmapImage.UriSource must be in a BeginInit/EndInit block.

        //    bmp.BeginInit();

        //    bmp.UriSource = new Uri(string.Format(

        //      "pack://application:,,,/{0};component/{1}",

        //      Assembly.GetExecutingAssembly().GetName().Name,

        //      fileName));

        //    bmp.EndInit();



        //    return bmp;

        //}



        public BitmapImage getBitmap(string fileName)

        {

            BitmapImage bmp = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block.

            bmp.BeginInit();

            bmp.UriSource = new Uri(string.Format(

              "pack://application:,,,/{0};component/{1}",

              Assembly.GetExecutingAssembly().GetName().Name,

              fileName));

            bmp.EndInit();



            return bmp;

        }



        [CommandMethod("ITI")]

        public void CreateRibbon()
        {
            RibbonControl ribbon = ComponentManager.Ribbon;
            if (ribbon != null)
            {
                RibbonTab rtab = ribbon.FindTab(RibbonId);
                if (rtab != null)
                {
                    ribbon.Tabs.Remove(rtab);
                }

                rtab = new RibbonTab();
                rtab.Title = RibbonTitle;
                rtab.Id = RibbonId;
                ribbon.Tabs.Add(rtab);
                AddContentToTab(rtab);
            }
        }

        private void AddContentToTab(RibbonTab rtab)
        {
            rtab.Panels.Add(AddPanelOne());
        }

        private static RibbonPanel AddPanelOne()
        {
            RibbonPanelSource rps = new RibbonPanelSource();
            rps.Title = "ITI-Addins";
            RibbonPanel rp = new RibbonPanel();
            rp.Source = rps;
            RibbonButton rci = new RibbonButton();
            rci.Name = "ITI Addin";
            rps.DialogLauncher = rci;
            //create button1
            var addinAssembly = typeof(Ribbon).Assembly;


            RibbonButton btnPythonShell = new RibbonButton
            {
                Orientation = Orientation.Vertical,
                AllowInStatusBar = true,
                Size = RibbonItemSize.Large,
                Name = "ITI",
                //Image = "",
                ShowText = true,
                Text = "Points Importer",
                Description = "ITI Plugin",
                CommandHandler = new RelayCommand(new Start_WPF().Execute)

            };

            btnPythonShell.ShowImage = true;
            //btnPythonShell.Image = getBitmap("close_hover.png");

            //btnPythonShell.Image = BitmapExtensions.ToBitmapImage(Bitmap.FromStream);


            rps.Items.Add(btnPythonShell);


            return rp;
        }
        public static System.Windows.Media.ImageSource GetEmbeddedPng(System.Reflection.Assembly app, string imageName)
        {
            var file = app.GetManifestResourceStream(imageName);
            BitmapDecoder source = PngBitmapDecoder.Create(file, BitmapCreateOptions.None, BitmapCacheOption.None);
            return source.Frames[0];
        }

    }

    


}
