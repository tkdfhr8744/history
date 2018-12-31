using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using webapi.Modules;

namespace webapi.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        // POST api/values
        
        [Route("api/Insert")]
        [HttpPost]
        public ActionResult<ArrayList> Insert([FromForm] Test test)
        {
            return Query.Getinsert(test);
        }

        [Route("api/Update")]
        [HttpPost]
        public ActionResult<ArrayList> Update([FromForm] Test test)
        {
            return Query.GetUpdate(test);
        }

        [Route("api/Delete")]
        [HttpPost]
        public ActionResult<ArrayList> Delete([FromForm] Test test)
        {
          return Query.GetDelete(test);
        }
        
        [Route("api/Select")]
        [HttpPost]
        public ActionResult<ArrayList> Select([FromForm] Test test)
        {
          return Query.GetSelect();
        }
    }
}
