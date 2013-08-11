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
        IList<Step>descriptions;
        string fileLocation;
        const int Title_row = 1;
        const int Header_row = 2;

        public Excel_writer(IList<Step>descriptions, string fileLocation)
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
                add_title_block(sheet);
                add_header_row(sheet);
                add_description_rows(sheet);
                package.Save();
            }
        }

        private void add_title_block(ExcelWorksheet sheet)
        {
            sheet.Cells[Title_row, 1].Value = descriptions[0].Description;
            descriptions.RemoveAt(0);
        }

        private FileInfo prepare_new_file()
        {
            FileInfo newFile = new FileInfo(fileLocation);

            try { newFile.Delete(); }
            catch ( FileNotFoundException e ) {/*Avoids races, swallow*/} 

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
            int currentRow = Header_row+1; //start past header
            foreach (var step in descriptions)
            {
                sheet.Cells[currentRow, 1].Value = currentRow;
                sheet.Cells[currentRow, 2].Value = step.Description;
                if (step.Custom != null)
                {
                    sheet.Cells[currentRow, 3].Value = step.Custom;
                }
            }
        }

        private void add_header_row(ExcelWorksheet sheet)
        {
            sheet.Cells[Header_row, 1].Value = "Step";
            sheet.Cells[Header_row, 2].Value = "Description";
            sheet.Cells[Header_row, 3].Value = "Custom Description";
        }


    }
}
