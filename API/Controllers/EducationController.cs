using API.Model;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : BaseController<Education, EducationRepository, int>
    {
        private readonly EducationRepository educationRepository;

        //public EmployeesController(EmployeeRepository employeeRepository)
        public EducationController(EducationRepository educationRepository) : base(educationRepository)
        {
            this.educationRepository = educationRepository;
        }
    }
}
