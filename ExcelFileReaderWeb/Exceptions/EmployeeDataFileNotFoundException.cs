using System;

namespace ExcelFileReaderWeb.Exceptions
{
    [Serializable]
    public class EmployeeDataFileNotFoundException : Exception
    {
        public EmployeeDataFileNotFoundException() { }

        public EmployeeDataFileNotFoundException(string message)
           : base(String.Format("Invalid File by Name: {0}", message)) { }
    }
}
