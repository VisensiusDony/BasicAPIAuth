using API.Model;
using API.Repository;
using API.Repository.Data;
using API.ViewModel;
using DurableTask.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //public class EmployeesController : ControllerBase
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        public IConfiguration _configuration;

        public object NIK { get; private set; }


        //public EmployeesController(EmployeeRepository employeeRepository)
        public EmployeesController(EmployeeRepository employeeRepository, IConfiguration configuration) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this._configuration = configuration;
        }
        [HttpPost]
        [Route("/Insert")]
        public ActionResult Inserted(Employee employee)
        {
            var insert = employeeRepository.Inserted(employee);
            return insert switch
            {
                0 => Ok(new { status = HttpStatusCode.OK, message = "Insert Data Successfull" }),
                1 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, Email already exists!" }),
                2 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, Phone already exists!" }),
                _ => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, NIK already exists!" }),
            };

            /*if (insert == 0)
            {
                //employeeRepository.Insert(employee);
                return Ok(new { status = HttpStatusCode.OK, message = "Insert Data Successfull" });
            }
            else if (insert == 1)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, Email already exists!" });
            }
            else if (insert == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, Phone already exists!" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, NIK already exists!" });
            }*/
            /*var insert = employeeRepository.Insert(employee);
            if (insert == 0)
            {
                return Ok("Insert Data Successfull");
            }
            else
            {
                if (insert == 2) 
                {
                    return BadRequest("Insert Failed, NIK already exists!");
                }
                else if (insert == 3)
                {
                    return BadRequest("Insert Failed, Phone already exists!");
                }
                else
                {
                    return BadRequest("Insert Failed, Email already exists!");
                }
            }*/
        }
        /*[HttpDelete("{NIK}")]
        public ActionResult Delete<entity> (string NIK)
        {
            var data = employeeRepository.Get().Count();
            var nik = employeeRepository.Delete(NIK);
            if (data != 0)
            {
                if (nik != 1) 
                {
                    return Ok(new { status = HttpStatusCode.OK, message = "Delete data successfull!" });
                }
                else
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Delete data not successfull!" });
                }
               
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data is empty, can't delete data!!" });
            }
        }*/

        [HttpPut("{NIK}")]
        public ActionResult Update(string NIK, Employee employee)
        {
            var data = employeeRepository.Get().Count();
            var nik = employeeRepository.Update(NIK, employee);
            if (data != 0)
            {
                return nik switch
                {
                    0 => Ok(new { status = HttpStatusCode.OK, message = "Update Success" }),
                    1 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update Failed, Email already exists!" }),
                    2 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update Failed, Phone already exists!" }),
                    3 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "NIK not found " }),
                    _ => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update data not successfull, email and phone number already " }),
                };
                /*if (nik == 0)
{
  return Ok(new { status = HttpStatusCode.OK, message = "Update Success" });
}
else if (nik == 1)
{
  return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update Failed, Email already exists!" });
}
else if (nik == 2)
{
  return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update Failed, Phone already exists!" });
}
else if(nik==3)
{
  return BadRequest(new { status = HttpStatusCode.BadRequest, message = "NIK not found " });
}
else
{
  return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update data not successfull, email and phone number already " });
}*/
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data is empty, can't update data!!" });
            }

        }

        [HttpGet]
        public ActionResult Get<Entity>()
        {
            var data = employeeRepository.Get().Count();
            if (data != 0)
            {
                var success = employeeRepository.Get();
                return Ok(new { status = HttpStatusCode.OK, success });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data is empty" });
            }
        }

        [HttpPost]
        [Route("/Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var register = employeeRepository.Register(registerVM);
            return register switch
            {
                1 => Ok(new { status = HttpStatusCode.OK, register, message = "Register Success" }),
                2 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "NIK already exists" }),
                3 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Email already exists" }),
                4 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Phone already exists" }),
                _ => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Register Failed" }),
            };
        }

        [Authorize(Roles = "Director")]
        [HttpPost]
        [Route("/AssignManager")]
        public ActionResult AssignManager(AssignManagerVM assignManagerVM)
        {
            var register = employeeRepository.AssignManager(assignManagerVM);
            return register switch
            {
                1 => Ok(new { status = HttpStatusCode.OK, register, message = "Assign Manager Success" }),
                2 => BadRequest(new { status = HttpStatusCode.BadRequest,register, message = "Already assign manager" }),
                _ => BadRequest(new { status = HttpStatusCode.BadRequest,register, message = "Assign Manager Failed" }),
            };
        }

        [Authorize]
        [HttpGet("/TestJWT")]
        public ActionResult TestJWT() {
            return Ok("Test JWT berhasil");
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Director,Manager")]
        [HttpGet("/GetRegisteredData")]
        public ActionResult GetRegisteredData()
        {
            var getData = employeeRepository.GetRegisteredData();
            if (getData != null)
            {
                return Ok(getData);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = getData, message = "Data empty" });
            }

           
        }
        [HttpGet("/GetRegisteredEager")]
        public ActionResult GetRegisteredEager()
        {
            var getData = employeeRepository.GetRegisteredData2();
            if (getData != null)
            {
                return Ok(getData);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = getData, message = "Data empty" });
            }


        }

        [HttpGet("/GetRegisteredEager/{NIK}")]
        public ActionResult GetRegisteredEager(string NIK)
        {

            var getData = employeeRepository.GetRegisteredData2(NIK);
            if (getData != null)
            {
                return Ok(getData);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = getData, message = "Employee not found" });
            }
        }

        [HttpGet("/GetRegisteredData/{NIK}")]
        public ActionResult GetRegisteredData(string NIK)
        {

            var getData = employeeRepository.GetRegisteredData(NIK);
            if (getData != null)
            {
                return Ok(getData);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = getData, message = "Employee not found" });
            }
        }

        [HttpGet("TestCORS")]
        [EnableCors("AllowOrigin")]
        public ActionResult TestCORS()
        {
            return Ok("Test CORS berhasil");
        }


    }
}
