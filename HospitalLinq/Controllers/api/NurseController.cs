using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HospitalLinq.Models;

namespace HospitalLinq.Controllers.api
{
    public class NurseController : ApiController
    {

        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=HospitalDBNEW;Integrated Security=True;Pooling=False";
        HospitalDBcontextDataContext HopsitalDB = new HospitalDBcontextDataContext(stringConnection);
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(HopsitalDB.Nurses.ToList());
             }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        public IHttpActionResult Get(int id)
        {

            try
            {
                return Ok(HopsitalDB.Nurses.First(nurse => nurse.Id == id));
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
        public IHttpActionResult Post([FromBody]Nurse value)
        {
            try
            {
                HopsitalDB.Nurses.InsertOnSubmit(value);
                HopsitalDB.SubmitChanges();
                return Ok(HopsitalDB.Nurses.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
        public IHttpActionResult Put(int id, [FromBody] Nurse value)
        {
            try
            {
                Nurse someNurse = HopsitalDB.Nurses.First(nurse => nurse.Id == id);
                someNurse.Id = value.Id;
                someNurse.FirstName = value.FirstName;
                someNurse.LastName = value.LastName;
                someNurse.BirthDate = value.BirthDate;
                someNurse.Wage = value.Wage;
                someNurse.WorkHours = value.WorkHours;
                HopsitalDB.Nurses.InsertOnSubmit(value);
                HopsitalDB.SubmitChanges();
                return Ok(HopsitalDB.Nurses.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
        public IHttpActionResult Delete(int id)
        {
            try
            {
                HopsitalDB.Nurses.DeleteOnSubmit(HopsitalDB.Nurses.First(nurse => nurse.Id == id));
                HopsitalDB.SubmitChanges();
                return Ok(HopsitalDB.Nurses.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
