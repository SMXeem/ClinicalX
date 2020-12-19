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
        private readonly ClinicalXEntities _aClinicalXEntities = new ClinicalXEntities();
        private HttpResponseMessage _response;
        /// <summary>
        /// To get All Doctor
        /// </summary>
        /// <returns></returns>
        // GET: api/Doctor
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _aClinicalXEntities.vDoctors.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// To get doctor by Id
        /// </summary>
        /// <param name="id">Doctor Id</param>
        /// <returns>Doctor Object and Message</returns>
        // GET: api/Doctor/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vDoctors.FirstOrDefault(w => w.Id == id);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }

        /// <summary>
        /// To get doctor by hospital id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetByHospital(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vDoctors.Where(w => w.HospitalId == id).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// To get doctor by Specialist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetBySpecialist(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vDoctors.Where(w => w.Speciality == id).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }

        /// <summary>
        /// To get doctor by HospitalId and Specialist
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="specialist"></param>
        /// <returns></returns>
        public HttpResponseMessage GetByHospitalSpecialist(int hospitalId,int specialist)
        {
            try
            {
                var result = _aClinicalXEntities.vDoctors.Where(w => w.HospitalId == hospitalId && w.Speciality == specialist).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetSpecialities()
        {
            try
            {
                var result = _aClinicalXEntities.Specialities.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
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
