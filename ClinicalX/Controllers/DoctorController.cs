using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClinicalX.Models;

namespace ClinicalX.Controllers
{
    /// <summary>
    /// Doctor Info
    /// </summary>
    public class DoctorController : ApiController
    {
        readonly ClinicalXEntities _aClinicalXEntities = new ClinicalXEntities();
        /// <summary>
        /// To get All Doctor
        /// </summary>
        /// <returns></returns>
        // GET: api/Doctor
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var result = _aClinicalXEntities.vDoctors.ToList();
                response = Request.CreateResponse(HttpStatusCode.Found, result);
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return response;
        }
        /// <summary>
        /// To get a specific doctor
        /// </summary>
        /// <param name="id">Doctor Id</param>
        /// <returns>Doctor Object and Message</returns>
        // GET: api/Doctor/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            try
            {
                var result = _aClinicalXEntities.vDoctors.Where(w => w.Id == id).ToList();
                response = Request.CreateResponse(HttpStatusCode.Found, result);
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return response;
        }

        // POST: api/Doctor
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Doctor/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Doctor/5
        //public void Delete(int id)
        //{
        //}
    }
}
