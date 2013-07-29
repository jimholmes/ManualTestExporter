using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ManualTestParser
{
    class Excel_writer
    {
        IList<string>descriptions;
        string fileLocation;

        public Excel_writer(IList<string>descriptions, string fileLocation)
        {
            if (descriptions.Count <= 0|| 
                fileLocation==null ||
                !is_valid_file_location(fileLocation))
            {
                throw new ArgumentException("Check descriptions and fileLocation params. They've got to contain stuff.");
            }
            this.descriptions = descriptions;
            this.fileLocation = fileLocation;

            create_output_file();
        }

        private void create_output_file()
        {
            FileInfo newFile = prepare_new_file();
			
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Sheet");
                add_header_row(sheet);
                add_description_rows(sheet);
            }
        }

        private FileInfo prepare_new_file()
        {
            FileInfo newFile = new FileInfo(fileLocation);

            try { newFile.Delete(); }
            catch { FileNotFoundException e; } //Just delete, swallow exception. Avoids races

            newFile = new FileInfo(fileLocation);
            return newFile;
        }

        private bool is_valid_file_location(string fileLocation)
        {
            FileInfo file = new FileInfo(fileLocation);
            DirectoryInfo dir = new DirectoryInfo(file.DirectoryName);
            if (! dir.Exists)
            {
                throw new FileNotFoundException();
            }
            return true;
        }

        private void add_description_rows(ExcelWorksheet sheet)
        {
            //int currentRow = 2; //start past header
            //foreach (var step in descriptions)
            //{
            //    sheet.Cells[currentRow, 1].Value = currentRow;
            //    sheet.Cells[currentRow,2].Value = step.
            //}
        }

        private void add_header_row(ExcelWorksheet sheet)
        {
            sheet.Cells[1, 1].Value = "Step";
            sheet.Cells[1, 2].Value = "Description";
            sheet.Cells[1, 3].Value = "Custom Description";
        }


    }
}
