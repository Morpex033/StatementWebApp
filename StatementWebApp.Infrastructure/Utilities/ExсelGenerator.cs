using OfficeOpenXml;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Infrastructure.Utilities;

public static class ExсelGenerator
{
    public static byte[] GenerateExcel(Statement statement)
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

                // Заголовок группы
                ws.Cells[row, 1].Value = $"Группа: {groupName}";
                ws.Cells[row, 1, row, 3].Merge = true;
                ws.Cells[row, 1].Style.Font.Bold = true;
                ws.Cells[row, 1].Style.Font.Size = 14;
                row += 2;

                // Студенты
                var students = groupGrades
                    .GroupBy(g => g.Student)
                    .OrderBy(s => s.Key.LastName)
                    .ThenBy(s => s.Key.FirstName)
                    .ToList();

                foreach (var studentGrades in students)
                {
                    var student = studentGrades.Key;

                    // Заголовок студента
                    ws.Cells[row, 1].Value = $"Студент: {student.LastName} {student.FirstName}";
                    ws.Cells[row, 1, row, 3].Merge = true;
                    ws.Cells[row, 1].Style.Font.Bold = true;
                    ws.Cells[row, 1].Style.Font.Size = 12;
                    row++;

                    // Заголовок таблицы
                    ws.Cells[row, 1].Value = "Предмет";
                    ws.Cells[row, 2].Value = "Оценка";
                    ws.Cells[row, 3].Value = "Комментарий";
                    ws.Row(row).Style.Font.Bold = true;
                    row++;

                    // Оценки
                    foreach (var grade in studentGrades.Where(g => g.Subject != null))
                    {
                        ws.Cells[row, 1].Value = grade.Subject.Name;
                        ws.Cells[row, 2].Value = grade.Value;
                        ws.Cells[row, 3].Value = grade.ToString();
                        row++;
                    }

                    row += 2; // Отступ между студентами
                }

                // Скрываем колонку "Комментарий"
                ws.Column(3).Hidden = true;

                // Автоподбор ширины
                ws.Cells[1, 1, row, 3].AutoFitColumns();
            }

            return package.GetAsByteArray();
        }
    }
}