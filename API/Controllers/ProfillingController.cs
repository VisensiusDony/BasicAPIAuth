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
    public class ProfillingController : BaseController<Profilling, ProfillingRepository, string>
    {
        private readonly ProfillingRepository profillingRepository;

        //public EmployeesController(EmployeeRepository employeeRepository)
        public ProfillingController(ProfillingRepository profillingRepository) : base(profillingRepository)
        {
            this.profillingRepository = profillingRepository;
        }
    }
}
