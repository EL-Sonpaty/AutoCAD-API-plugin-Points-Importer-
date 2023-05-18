using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using CADAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADAPI
{
    public class Start_WPF : ICadCommand
    {
       
      

        public override void Execute()
        {
            Start_The_WPF();
        }

        
        public void Start_The_WPF()
        {
            Window1 main = new Window1();
             Application.ShowModalWindow(main);
        }
       

    }
}
