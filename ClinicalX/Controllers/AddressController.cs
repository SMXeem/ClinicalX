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
    /// Address info
    /// </summary>
    public class AddressController : ApiController
    {
        readonly ClinicalXEntities _aClinicalXEntities = new ClinicalXEntities();
        // GET: api/Address
        /// <summary>
        /// To get all District
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var result = _aClinicalXEntities.Districts.ToList();
                response = Request.CreateResponse(HttpStatusCode.Found, result);
            }
            catch (Exception e)
            {
               response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            
            return response;
        }

        // GET: api/Address/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Address
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Address/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Address/5
        //public void Delete(int id)
        //{
        //}
    }
}
