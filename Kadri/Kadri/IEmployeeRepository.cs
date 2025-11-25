using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRApp.Services;

namespace HRApp.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        bool Exists(int id);
        bool HasActiveRecords(int id);
        DeleteResult DeleteEmployee(int id);
    }

    public enum DeleteResult
    {
        Success,
        NotFound,
        HasActiveRecords
    }
}
