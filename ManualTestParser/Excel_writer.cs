﻿using System;
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
            if (descriptions.Count <= 0|| fileLocation==null)
            {
                throw new ArgumentException("Check descriptions and fileLocation params. They've got to contain stuff.");
            }
            this.descriptions = descriptions;
            this.fileLocation = fileLocation;

            CreateOutputFile();
        }

        private void CreateOutputFile()
        {
            FileInfo newFile = new FileInfo(fileLocation);

            try 
            {
                newFile.Delete();
            } catch { FileNotFoundException e;} //Just delete, swallow exception. Avoids races

            newFile = new FileInfo(fileLocation);
			
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Sheet");
                AddHeaders(sheet);
                AddDescriptionRows(sheet);
            }
        }

        private void AddDescriptionRows(ExcelWorksheet sheet)
        {
            int currentRow = 2; //start past header
            foreach (var step in descriptions)
            {
                sheet.Cells[currentRow, 1].Value = currentRow;
                sheet.Cells[currentRow,2].Value = step.
            }
        }

        private void AddHeaders(ExcelWorksheet sheet)
        {
            sheet.Cells[1, 1].Value = "Step";
            sheet.Cells[1, 2].Value = "Description";
            sheet.Cells[1, 3].Value = "Custom Description";
        }


    }
}
