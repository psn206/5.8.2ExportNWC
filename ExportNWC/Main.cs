using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportNWC
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файл NWC (*.nwc)|*.nwc";

            if (saveFileDialog.ShowDialog() == true)
            {
                NavisworksExportOptions options = new NavisworksExportOptions();
                doc.Export(Path.GetDirectoryName(saveFileDialog.FileName), saveFileDialog.SafeFileName, options);
                TaskDialog.Show("Сообщение", "Файл записан!");
            }
            return Result.Succeeded;
        }
    }
}
