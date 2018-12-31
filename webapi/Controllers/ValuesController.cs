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
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<ArrayList> Get()
        {
            Mysql my=new Mysql();
            string sql="select * from test;";
            ArrayList list=new ArrayList();
            MySqlDataReader sdr= my.Reader(sql);
            while(sdr.Read())
            {
                Hashtable ht=new Hashtable();
                for(int i=0;i<sdr.FieldCount;i++)
                {
                    ht.Add(sdr.GetName(i),sdr.GetValue(i));
                }
                list.Add(ht);
            }
            return list;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

    }
}
