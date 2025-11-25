using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRApp.Models;

namespace HRApp.Repositories
{
    public interface IDepartmentRepository
    {
        Department GetById(int id);
    }
}
