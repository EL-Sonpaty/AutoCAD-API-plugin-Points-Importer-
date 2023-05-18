using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using OfficeOpenXml;
using System;
using System.Windows.Controls;
using System.Windows.Forms;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace CADAPI

#region CAD Logic For Points Painter
{
    public class Logic
    {


        // the EXcel package must be set set for copy local as true
        // the files are EPPlus , Epplus.interface , Epplus.System.Drawing , Microsoft.IO.RecycablememoryStream

       




        
        public static void DropMyPoints(string thepath,int X, int Y , int Z)
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            Database db = document.Database;
            Editor editor = document.Editor;
            using (DocumentLock docLock = document.LockDocument())

            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        // Importing and Reading Excel Sheet

                        string MyExcel = thepath;
                        using (ExcelPackage Package = new ExcelPackage(MyExcel))
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            var sheet = Package.Workbook.Worksheets["Sheet1"];
                            ObjectId BlockId = db.CurrentSpaceId;
                            BlockTableRecord btr = tr.GetObject(BlockId, OpenMode.ForWrite)
                            as BlockTableRecord;

                            // Variable Identifires
                            int rowNums = 1000;
                            double firstCell = 0;
                            double secondCell = 0;
                            double thirdCell = 0;
                            object va = 0;
                            object vao = 0;
                            object va3 = 0;
                            int i = 1;
                            int j = 1;
                            int k = 1;

                            //Getting Every Cell's Point
                            for (i = 1, j = 2, k = 3; i <= rowNums; i++)
                            {
                                try
                                {
                                    va = sheet.Cells[i, 1].Value;
                                    string stt = va.ToString();
                                    firstCell = double.Parse(stt);

                                    vao = sheet.Cells[i, j].Value;
                                    string sttp = vao.ToString();
                                    secondCell = double.Parse(sttp);

                                    va3 = sheet.Cells[i, k].Value;
                                    string sds = va3.ToString();
                                    thirdCell = double.Parse(sds);

                                    Point3d P = new Point3d(firstCell+X, secondCell+Y, thirdCell+Z);
                                    DBPoint DP = new DBPoint(P);
                                    btr.AppendEntity(DP);
                                    tr.AddNewlyCreatedDBObject(DP, true);
                                   
                                }
                                catch (NullReferenceException)
                                {
                                    if (va == null && ((int.Parse(vao.ToString())) != 0 || (int.Parse(va3.ToString())) != 0))
                                    {
                                        MessageBox.Show($"! DONE SUCCESSFULLY\nIF some points are missing , " +
                                                    $"Please Check back your Excel sheet ( First Column Probably ) " +
                                                    $"And Fill The Empty Cells If Found", "Points Painter", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading, true);
                                        break;
                                    }
                                    else if (va == null && vao != null && va3 != null)
                                    {
                                        MessageBox.Show($"WARNING: DRAWING STOPPED AT ROW NO.{i} COLUMN NO.{1}" +
                                            $"\nDue To An An Empty Cell, Please Check Back Your Excel Sheet And Fill It Correctly!",
                                            "Points Painter", MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading, true);
                                        break;
                                    }
                                    else if (vao == null)
                                    {
                                        MessageBox.Show($"WARNING: DRAWING STOPPED AT ROW NO.{i} COLUMN NO.{j}" +
                                            $"\nDue To An Empty Cell, Please Check Back Your Excel Sheet And Fill It Correctly!",
                                            "Points Painter", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading, true);
                                        break;
                                    }
                                    else if (va3 == null)
                                    {
                                        MessageBox.Show($"WARNING: DRAWING STOPPED AT ROW NO.{i} COLUMN NO.{k}" +
                                            $"\nDue To An Empty Cell, Please Check Back Your Excel Sheet And Fill It Correctly!", "Points Painter", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading, true);
                                        break;
                                    }
                                }
                            }
                        }
                        tr.Commit();
                        Application.DocumentManager.MdiActiveDocument.Editor.Regen();
                    }
                    catch (System.Exception ex)
                    {
                        editor.WriteMessage("Error : " + ex.Message);
                        tr.Abort();
                    }
                }
            }
        }

        #region Excel Path Method
        public static string GetPath()
        {
            Autodesk.AutoCAD.Windows.OpenFileDialog Ofd = new Autodesk.AutoCAD.Windows.OpenFileDialog
                ("Get Your Excel Sheet", "", "xlsx", "Confirm",
                Autodesk.AutoCAD.Windows.OpenFileDialog.OpenFileDialogFlags.SearchPath);

            if (Ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = Ofd.Filename;
                return fileName;
            }
            else
                return null;
        }
        #endregion

        #region SetPointsStyle

        public static void SetPointsStyle(int style)
        {
            // Get the current document and database
            Document document = Application.DocumentManager.MdiActiveDocument;

            Editor editor = document.Editor;

            Database database = document.Database;

            // Start a transaction
            using (DocumentLock acLckDoc = document.LockDocument())
            {

                using (Transaction trans = database.TransactionManager.StartTransaction())
                {
                    try
                    {

                        // Open the Block table for read
                        BlockTable blocktableID;
                        blocktableID = trans.GetObject(database.BlockTableId,
                                                     OpenMode.ForRead) as BlockTable;

                        // Open the Block table record Model space for write
                        BlockTableRecord blocktablerecord;
                        blocktablerecord = trans.GetObject(blocktableID[BlockTableRecord.ModelSpace],
                                                        OpenMode.ForWrite) as BlockTableRecord;





                        // Set the style for all point objects in the drawing
                        database.Pdmode = style;
                        //database.Pdsize = 1;

                        // Save the new object to the database
                        trans.Commit();

                        //update all geomtry in the drawings
                        Application.DocumentManager.MdiActiveDocument.Editor.Regen();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                        trans.Abort();
                    }

                }
            }

        }
        #endregion
        #region SetPointsSize
        public static void SetPointsSize(int Size)
        {
            // Get the current document and database
            Document document = Application.DocumentManager.MdiActiveDocument;
            Database database = document.Database;
            Editor editor = document.Editor;
            // Start a transaction
            using (DocumentLock docLock = document.LockDocument())

            {
                using (Transaction trans = database.TransactionManager.StartTransaction())
                {
                    try
                    {
                        // Open the Block table for read
                        BlockTable blocktableID;
                        blocktableID = trans.GetObject(database.BlockTableId,
                                                     OpenMode.ForRead) as BlockTable;

                        // Open the Block table record Model space for write
                        BlockTableRecord blocktablerecord;
                        blocktablerecord = trans.GetObject(blocktableID[BlockTableRecord.ModelSpace],
                                                        OpenMode.ForWrite) as BlockTableRecord;






                        // Set the style for all point objects in the drawing

                        database.Pdsize = Size;

                        // Save the new object to the database
                        trans.Commit();
                        Application.DocumentManager.MdiActiveDocument.Editor.Regen();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                        trans.Abort();
                    }

                }
            }
        }
        #endregion

        #region SetPointsStyle
        [CommandMethod("test")]
        public  void test()
        {
            // Get the current document and database
            Document document = Application.DocumentManager.MdiActiveDocument;

            Editor editor = document.Editor;

            Database database = document.Database;

            // Start a transaction
            using (DocumentLock acLckDoc = document.LockDocument())
            {

                using (Transaction trans = database.TransactionManager.StartTransaction())
                {
                    try
                    {

                        // Open the Block table for read
                        BlockTable blocktableID;
                        blocktableID = trans.GetObject(database.BlockTableId,
                                                     OpenMode.ForRead) as BlockTable;

                        // Open the Block table record Model space for write
                        BlockTableRecord blocktablerecord;
                        blocktablerecord = trans.GetObject(blocktableID[BlockTableRecord.ModelSpace],
                                                        OpenMode.ForWrite) as BlockTableRecord;





                        // Set the style for all point objects in the drawing
                        database.Pdmode = 0;
                        //database.Pdsize = 1;
                        document.SendStringToExecute("Regen", true, false, false);
                        // Save the new object to the database
                        trans.Commit();
                        Application.DocumentManager.MdiActiveDocument.Editor.Regen();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                        trans.Abort();
                    }

                }
            }

        }
        #endregion
    }
}
#endregion