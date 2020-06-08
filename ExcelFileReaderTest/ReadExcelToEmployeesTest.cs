using ExcelFileReaderWeb.Models;
using Ganss.Excel;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace ExcelFileReaderTest
{
    public class ReadExcelToEmployeesTest
    {
        [Fact]
        public void CanReadAndMapExcelDataToEmployees()
        {
            // Arrange
            string path = GetTestFileDirectory();
            // Act
            var employees = new ExcelMapper(path).Fetch<Employee>();
            // Assert
            Assert.Equal(2, employees.Count());
        }

        private string GetTestFileDirectory()
        { 
            const string file = "testDoc.xlsx";
            var currentDirectory = Directory.GetCurrentDirectory();
            return Path.Combine(currentDirectory, @"..\..\..\", "Test Files", file);
        }
    }
}
