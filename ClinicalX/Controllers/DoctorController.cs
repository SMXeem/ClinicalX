using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        /// <summary>
        /// Get all doctor booking
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAllDoctorBooking()
        {
            try
            {
                var result = _aClinicalXEntities.vDoctorBookings.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }

        /// <summary>
        /// Get all booking by doctor id
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetAllDoctorBookingByDoctorId(int doctorId)
        {
            try
            {
                var result = _aClinicalXEntities.vDoctorBookings.Where(w=>w.DoctorId==doctorId).ToList();
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
        /// <param name="patientId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetAllDoctorBookingByPatientId(int patientId)
        {
            try
            {
                var result = _aClinicalXEntities.vDoctorBookings.Where(w => w.PatientId == patientId).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Insert a booking
        /// </summary>
        /// <param name="aBooking"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post(DoctorBooking aBooking)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response = Request.CreateResponse(HttpStatusCode.NotAcceptable);
                }
                aBooking.Time = DateTime.Now;
                var a = _aClinicalXEntities.DoctorBookings.Add(aBooking);
                var b = _aClinicalXEntities.SaveChanges();
                _response = Request.CreateResponse(HttpStatusCode.OK, a);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            return _response;
        }
        /// <summary>
        /// Update doctor booking
        /// </summary>
        /// <param name="aBooking"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateBooking(DoctorBooking aBooking)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response = Request.CreateResponse(HttpStatusCode.NotAcceptable);
                }
                aBooking.Time = DateTime.Now;
                _aClinicalXEntities.DoctorBookings.AddOrUpdate(aBooking);
                var b = _aClinicalXEntities.SaveChanges();
                _response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            return _response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteBooking(int bookingId)
        {
            try
            {
                var aBooking = _aClinicalXEntities.DoctorBookings.Find(bookingId);
                if(aBooking!=null)
                    _aClinicalXEntities.DoctorBookings.Remove(aBooking);
                _aClinicalXEntities.SaveChanges();
                _response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
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
