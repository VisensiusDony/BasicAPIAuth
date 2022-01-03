using API.Repository.Interface;
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
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;


        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var data = repository.Get().Count();
            if (data != 0)
            {
                var success = repository.Get();
                return Ok(new { status = HttpStatusCode.OK, success });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data is empty" });
            }
        }

        [HttpGet("{key}")]
        public ActionResult Get(Key key)
        {
            var data = repository.Get(key);
            return Ok(new { status = HttpStatusCode.OK, data, message = "Data found" });
        }

        [HttpPost]
        public ActionResult<Entity> Insert(Entity entity)
        {
            //return Ok(new { status = HttpStatusCode.OK, message = "Insert Data Successfull" });
            var insert = repository.Insert(entity);
            return insert switch
            {
                0 => Ok(new { status = HttpStatusCode.OK, message = "Insert Data Successfull" }),
                1 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, Email already exists!" }),
                2 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, Phone already exists!" }),
                _ => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, NIK already exists!" }),
            };
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            var data = repository.Get().Count();
            var nik = repository.Delete(key);
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
        }

        [HttpPut]
        public ActionResult Update(Entity entity)
        {
            repository.Update(entity);
            return Ok(new { status = HttpStatusCode.OK, message = "Update Success" });
        }
    }
}
