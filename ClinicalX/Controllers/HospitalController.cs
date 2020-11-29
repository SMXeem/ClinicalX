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
    /// Hospital Info
    /// </summary>
    public class HospitalController : ApiController
    {
        private readonly ClinicalXEntities _aClinicalXEntities=new ClinicalXEntities();
        // GET: api/Hospital
        /// <summary>
        /// To get all Hospital
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var result = _aClinicalXEntities.vHospitals.ToList();
                response = Request.CreateResponse(HttpStatusCode.Found, result);
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return response;
        }

        // GET: api/Hospital/5
        /// <summary>
        /// To get hospital using id
        /// </summary>
        /// <param name="id">Hospital Id</param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            try
            {
                var result = _aClinicalXEntities.vHospitals.Where(w => w.Id == id).ToList();
                response = Request.CreateResponse(HttpStatusCode.Found, result);
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return response;
        }

        /// <summary>
        /// To get hospital using district code
        /// </summary>
        /// <param name="id">Area Id</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public HttpResponseMessage GetByArea(int id)
        {
            HttpResponseMessage response;
            try
            {
                var result = _aClinicalXEntities.vHospitals.Where(w => w.Address == id).ToList();
                response = Request.CreateResponse(HttpStatusCode.Found, result);
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return response;
        }

        // POST: api/Hospital
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Hospital/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Hospital/5
        //public void Delete(int id)
        //{
        //}
    }
}
