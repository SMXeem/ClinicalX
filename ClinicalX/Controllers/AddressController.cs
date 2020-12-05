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
        private readonly ClinicalXEntities _aClinicalXEntities = new ClinicalXEntities();
        private HttpResponseMessage _response;
        // GET: api/Address
        /// <summary>
        /// To get all District
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _aClinicalXEntities.Districts.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
               _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            
            return _response;
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
