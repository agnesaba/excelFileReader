using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using ExcelFileReaderWeb.Exceptions;
using ExcelFileReaderWeb.Logger;
using ExcelFileReaderWeb.Models;
using Ganss.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelFileReaderWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// Gets a list of all Employees from uploaded file. 
        /// Can be tested with the testFile in ExcelFileReaderTest
        /// </summary>
        /// <returns>A list of Employees</returns>
        /// <param name="file"></param>  
        // GET: api/Employee
        [HttpPost]
        public IEnumerable<Employee> ReadExcelFile([FromServices] ILog log, IFormFile file)
        {
            log.Info($"ReadExcelFile executed for: {file.FileName}");
            IEnumerable<Employee> employees = new List<Employee>();

            try
            {
                if (file.FileName.EndsWith(".xlsx"))
                {
                    using (Stream reader = file.OpenReadStream())
                    {
                        employees = new ExcelMapper(reader).Fetch<Employee>();
                    }
                }
            }
            catch (Exception)
            {
                throw new EmployeeDataFileNotFoundException(file.FileName);
            }
            
            return employees;
        }
    }
}
