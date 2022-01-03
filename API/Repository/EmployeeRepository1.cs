using API.Context;
using API.Model;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace API.Repository
{
    public class EmployeeRepository1 : GeneralRepository<MyContext,Employee,string>
    {
        public MyContext myContext;
        public EmployeeRepository1(MyContext myContext):base(myContext)
        {
            this.myContext = myContext;
        }
        public int Delete<Entity>(string NIK)
        {
            var entity = myContext.Employees.Find(NIK);
            if (entity != null)
            {
                myContext.Remove(entity);
                myContext.SaveChanges();
                return 0;
            }
            else
            {
                return 1;
            }

        }

        public IEnumerable<Employee> Get<Entity>()
        {
            return myContext.Employees.ToList();
        }

        public Employee Get<Entity>(string NIK)
        {
            //return myContext.Employees.Find(NIK);
            //return myContext.Employees.Where(e => e.NIK == NIK).SingleOrDefault();
            return myContext.Employees.Where(e => e.NIK == NIK).FirstOrDefault();
        }

       /* public string ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            var hasil = "";
            var getEmail = myContext.Employees.SingleOrDefault(e => e.Email == resetPasswordVM.Email);
            if (getEmail != null)
            {
                var getPassword = myContext.Account.Find(getEmail.NIK);
                Guid obj = Guid.NewGuid();
                getPassword.Guid = obj.ToString();

                myContext.Entry(getPassword).State = EntityState.Modified;
                myContext.SaveChanges();
                hasil = obj.ToString() + "." + getEmail.FirstName;
            }
            else
            {
                hasil = "";
            }
            return hasil;
        }*/

        public int Insert<Entity>(Employee employee)
        {
            var checkEmail = myContext.Employees.Any(x => x.Email == employee.Email);
            var checkPhone = myContext.Employees.Any(x => x.Phone == employee.Phone);
            var checkNIK = myContext.Employees.Any(x => x.NIK == employee.NIK);
            if (checkNIK)
            {
                return 3;
            }
            else
            {
                if (checkEmail)
                {
                    return 1;
                }
                else
                {
                    if (checkPhone)
                    {
                        return 2;
                    }
                    else
                    {
                        var empCount = this.Get().Count();
                        var year = DateTime.Now.Year;
                        employee.NIK = year + '0' + empCount.ToString();
                        myContext.Employees.Add(employee);
                        var result = myContext.SaveChanges();
                        return 0;
                    }

                }
            }
            /*var data = myContext.Employees.Find(employee.NIK);
            if (data==null)
            {
                myContext.Employees.Add(employee);
                int respond = myContext.SaveChanges();
                return respond;
            }
            else
            {
                if (data.NIK == employee.NIK)
                {
                    return 2;
                }
                else
                {
                    if (data.Phone == employee.Phone)
                    {
                        return 3;
                    }
                    else
                    {
                        if (data.Email == employee.Email)
                        {
                            return 4;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }*/
        }

        public int Update(string NIK, Employee employee)
        {
            /*var data = myContext.Employees.Find(NIK);
            if (data != null)
            {
                myContext.Entry(data).State = EntityState.Detached;
                var checkEmail = myContext.Employees.Any(x => x.Email == employee.Email);
                var checkPhone = myContext.Employees.Any(x => x.Phone == employee.Phone);
                //var checkNIK = myContext.Employees.Any(x => x.NIK == NIK);
                if (checkEmail)
                {
                    return 1;
                }
                else
                {
                    if (checkPhone)
                    {
                        return 2;
                    }
                    else
                    {
                        employee.NIK = NIK;
                        myContext.Entry(employee).State = EntityState.Modified;
                        myContext.SaveChanges();
                        return 0;
                    }
                }
            }
            else
            {
                return 3;
            }*/

            var checkData = myContext.Employees.Find(NIK);
            if (checkData != null)
            {
                myContext.Entry(checkData).State = EntityState.Detached;
            }
            else
            {
                return 3;
            }
            if (checkData.Email == employee.Email)
            {
                if (checkData.Phone == employee.Phone)
                {
                    employee.NIK = NIK;
                    myContext.Entry(employee).State = EntityState.Modified;
                    myContext.SaveChanges();
                    return 0;
                }
                else
                {
                    var checkPhone = myContext.Employees.Any(x => x.Phone == employee.Phone);
                    if (checkPhone)
                    {
                        return 2;
                    }
                    else
                    {
                        employee.NIK = NIK;
                        myContext.Entry(employee).State = EntityState.Modified;
                        myContext.SaveChanges();
                        return 0;
                    }
                }
            }
            else
            {
                if (checkData.Phone == employee.Phone)  
                {
                    var checkEmail = myContext.Employees.Any(x => x.Email == employee.Email);
                    if (checkEmail)
                    {
                        return 1;
                    }
                    else
                    {
                        employee.NIK = NIK;
                        myContext.Entry(employee).State = EntityState.Modified;
                        myContext.SaveChanges();
                        return 0;
                    }
                }
                else
                {
                    var checkEmailPhone = myContext.Employees.Any(x => x.Email == employee.Email&&x.Phone==employee.Phone);
                    if (checkEmailPhone)
                    {
                        return 4;
                    }
                    else
                    {
                        employee.NIK = NIK;
                        myContext.Entry(employee).State = EntityState.Modified;
                        myContext.SaveChanges();
                        return 0;
                    }
                }

            }
            /*var checkData = myContext.Employees.AsNoTracking().FirstOrDefault(e => e.NIK == NIK);
            if (checkData != null)
            {
                myContext.Entry(checkData).State = EntityState.Detached;
                if (checkData.Phone == employee.Phone||myContext.Employees.Where(e => e.Phone == employee.Phone).FirstOrDefault() == null)
                {
                    if (checkData.Email == employee.Email||myContext.Employees.Where(e => e.Email == employee.Email).FirstOrDefault() == null )
                    {
                        employee.NIK = NIK;
                        myContext.Entry(employee).State = EntityState.Modified;
                        myContext.SaveChanges();
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 3;
            }*/

        }
    }
}

