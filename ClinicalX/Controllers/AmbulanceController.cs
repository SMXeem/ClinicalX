using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClinicalX.Models;

namespace ClinicalX.Controllers
{
    public class AmbulanceController : ApiController
    {
        private readonly ClinicalXEntities _aClinicalXEntities = new ClinicalXEntities();
        private HttpResponseMessage _response;
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _aClinicalXEntities.vAmbus.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        
        // GET: api/Ambulance/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vAmbus.FirstOrDefault(w => w.Id == id);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        public HttpResponseMessage GetByAddress(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vAmbus.FirstOrDefault(w => w.Address == id);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }

        
    }
}
