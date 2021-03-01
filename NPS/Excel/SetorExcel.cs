//Author: Larson Kremer Vicente

using NPS.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Drawing;

namespace NPS.Excel
{
    public class SetorExcel
    {
        int rowIndex = 2;
        ExcelRange cell;
        ExcelFill fill;
        Border border;

        public byte[] GenerateExcel(List<Setor> setores)
        {
            using (var excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "PMG";
                excelPackage.Workbook.Properties.Title = "PMG";
                var sheet = excelPackage.Workbook.Worksheets.Add("Setor Excel");
                sheet.Name = "Setor Excel Report";
                sheet.Column(2).Width = 20; //ID
                sheet.Column(3).Width = 40; //Name
              

                #region Report Header 
                sheet.Cells[rowIndex, 2, rowIndex, 3].Merge = true;
                cell = sheet.Cells[rowIndex, 2];
                cell.Value = "Prefeitura Municipal de Gaspar";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 20;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Yellow);
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowIndex = rowIndex + 2;

                sheet.Cells[rowIndex, 2, rowIndex, 3].Merge = true;
                cell = sheet.Cells[rowIndex, 2];
                cell.Value = "Setores";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 15;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
               
                rowIndex = rowIndex + 1;
                #endregion

                #region Table header
                cell = sheet.Cells[rowIndex, 2];
                cell.Value = "ID";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                cell = sheet.Cells[rowIndex, 3];
                cell.Value = "Nome";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                #endregion

                rowIndex = rowIndex + 1;

                #region Table body
                int serialNumber = 1;
                if (setores.Count > 0)
                {
                    foreach (Setor setor in setores)
                    {
                        cell = sheet.Cells[rowIndex, 2];
                        cell.Value = serialNumber++.ToString();
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        cell = sheet.Cells[rowIndex, 3];
                        cell.Value = setor.Nome;
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion
                return excelPackage.GetAsByteArray();
            }
        }
    }
}