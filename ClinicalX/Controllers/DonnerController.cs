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
    /// Donner Info
    /// </summary>
    public class DonnerController : ApiController
    {
        private readonly ClinicalXEntities _aClinicalXEntities = new ClinicalXEntities();
        private HttpResponseMessage _response;
        /// <summary>
        /// To get all donner
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _aClinicalXEntities.vDonners.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// To get donner by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vDonners.FirstOrDefault(w => w.Id == id);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// To get donner by address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetByAddress(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vDonners.Where(w => w.Address == id).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// To get donner by BloodGroup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetByBloodGroup(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vDonners.Where(w => w.BloodGroup == id).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }

        /// <summary>
        /// To get donner by address and BloodGroupId
        /// </summary>
        /// <param name="addressId"></param>
        /// <param name="bloodGroupId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetByAddressBloodGroup(int addressId,int bloodGroupId)
        {
            try
            {
                var result = _aClinicalXEntities.vDonners.Where(w => w.Address == addressId && w.BloodGroup == bloodGroupId).ToList();
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
