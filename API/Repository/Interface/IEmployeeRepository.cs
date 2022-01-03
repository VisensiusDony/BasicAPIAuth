using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();//Get all semua data, kumpulan penampung data (IList/Ienumerable)
        //IList --> memanggil list terlebih dahulu -> manipulasi table (update dan read)
        //IEnumerable --> karena read data cocoknya pakai enumerable (read saja)
        Employee Get(String NIK);
        int Insert(Employee employee);
        int Update(string NIK,Employee employee);
        int Delete(string NIK);
    }
}
