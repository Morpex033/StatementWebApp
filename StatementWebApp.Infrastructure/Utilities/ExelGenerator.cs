using OfficeOpenXml;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Infrastructure.Utilities;

public static class ExelGenerator
{
    public static byte[] GenerateExel(Statement statement)
    {
        ExcelPackage.License.SetNonCommercialPersonal("Andrey Sharipov");

        using (var package = new ExcelPackage())
        {
            var groupedData = statement.Grades
                .Where(g => g.Student != null && g.Student.Group != null) 
                .GroupBy(g => g.Student.Group.Name) 
                .OrderBy(g => g.Key)
                .ToList();

            foreach (var groupGrades in groupedData)
            {
                var groupName = groupGrades.Key;
                var ws = package.Workbook.Worksheets.Add(groupName); 

                int row = 1;

                ws.Cells[row, 1].Value = $"Группа: {groupName}";
                ws.Cells[row, 1, row, groupedData.Count + 1].Merge = true;
                ws.Cells[row, 1].Style.Font.Bold = true;
                ws.Cells[row, 1].Style.Font.Size = 14;
                row++;

                var students = groupGrades
                    .GroupBy(g => g.Student)
                    .OrderBy(s => s.Key.LastName) 
                    .ToList();

                foreach (var studentGrades in students)
                {
                    var student = studentGrades.Key;

                    ws.Cells[row, 1].Value = $"Студент: {student.LastName} {student.LastName}";
                    ws.Cells[row, 1, row, groupedData.Count + 1].Merge = true;
                    ws.Cells[row, 1].Style.Font.Bold = true;
                    ws.Cells[row, 1].Style.Font.Size = 12;
                    row++;

                    ws.Cells[row, 1].Value = "Предмет";
                    ws.Cells[row, 2].Value = "Оценка";
                    ws.Row(row).Style.Font.Bold = true;
                    row++;

                    var gradeDict = studentGrades
                        .Where(g => g.Subject != null)
                        .GroupBy(g => g.Subject.Name)
                        .Select(g => g.First()) 
                        .ToDictionary(g => g.Subject.Name, g => g.Value);

                    foreach (var subject in gradeDict)
                    {
                        ws.Cells[row, 1].Value = subject.Key;
                        ws.Cells[row, 2].Value = subject.Value;
                        row++;
                    }

                    row++;
                }

                row++;
            }

            return package.GetAsByteArray();
        }
    }
}