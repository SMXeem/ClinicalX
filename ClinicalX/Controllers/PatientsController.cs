using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClinicalX.Models;

namespace ClinicalX.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PatientsController : ApiController
    {
        private readonly ClinicalXEntities _aClinicalXEntities = new ClinicalXEntities();
        private HttpResponseMessage _response;
        /// <summary>
        /// Get list of patient
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _aClinicalXEntities.Patients.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = _aClinicalXEntities.Patients.FirstOrDefault(w => w.Id == id);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get booked seat details by patient id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetPatientBooking(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vBookedSeatPatients.FirstOrDefault(w => w.PatientId == id);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get patient by mobile no
        /// </summary>
        /// <param name="mobileNo">mobileNo</param>
        /// <returns></returns>
        public HttpResponseMessage GetPatientByMobile(string mobileNo)
        {
            try
            {
                var result = _aClinicalXEntities.Patients.FirstOrDefault(w => w.Mobile == mobileNo);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }

        

        // POST: api/Patients
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        [ResponseType(typeof(Patient))]
        public HttpResponseMessage PostPatient(Patient patient)
        {
            try
            {
                _aClinicalXEntities.Patients.Add(patient);
                _aClinicalXEntities.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            
        }
    }
}