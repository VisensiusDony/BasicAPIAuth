using API.Model;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : BaseController<University, UniversityRepository, int>
    {
        private readonly UniversityRepository universityRepository;

        //public EmployeesController(EmployeeRepository employeeRepository)
        public UniversityController(UniversityRepository universityRepository) : base(universityRepository)
        {
            this.universityRepository = universityRepository;
        }
       
    }
}
