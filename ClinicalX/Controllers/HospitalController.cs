using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

        private HttpResponseMessage _response;
        // GET: api/Hospital
        /// <summary>
        /// To get all Hospital
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _aClinicalXEntities.vHospitals.ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }

        // GET: api/Hospital/5
        /// <summary>
        /// To get hospital using id
        /// </summary>
        /// <param name="id">Hospital Id</param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = _aClinicalXEntities.vHospitals.FirstOrDefault(w => w.Id == id);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
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
            try
            {
                var result = _aClinicalXEntities.vHospitals.Where(w => w.Address == id).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }

        // POST: api/Hospital
        /// <summary>
        /// 
        /// </summary>
        //[HttpPost]
        //public HttpResponseMessage Insert()
        //{
        //    var request = HttpContext.Current.Request;
        //    var a = request.Form["a"];
        //    var file = request.Files["photo"];
        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}
        /// <summary>
        /// Seat booking
        /// </summary>
        /// <param name="aBookedSeatPatient"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage BookingSeat([FromBody]BookedSeatPatient aBookedSeatPatient)
        {
            try
            {
                var check = _aClinicalXEntities.BookedSeatPatients.FirstOrDefault(w =>
                    w.PatientId == aBookedSeatPatient.PatientId
                    && w.HospitalId==aBookedSeatPatient.HospitalId);
                if (check!=null)
                {
                    check.BPACCabin += aBookedSeatPatient.BPACCabin;
                    check.BPNonACCabin += aBookedSeatPatient.BPNonACCabin;
                    check.BPMaleWard += aBookedSeatPatient.BPMaleWard;
                    check.BPFemaleWard += aBookedSeatPatient.BPFemaleWard;
                    check.BPICU += aBookedSeatPatient.BPICU;
                    _aClinicalXEntities.BookedSeatPatients.AddOrUpdate(check);
                    _aClinicalXEntities.SaveChanges();
                }
                else
                {
                    _aClinicalXEntities.BookedSeatPatients.Add(aBookedSeatPatient);
                    _aClinicalXEntities.SaveChanges();
                }

                var bookedSeat = _aClinicalXEntities.BookedSeats.FirstOrDefault(w=>w.HospitalId==aBookedSeatPatient.HospitalId);
                if (bookedSeat != null)
                {
                    bookedSeat.BACCabin += aBookedSeatPatient.BPACCabin;
                    bookedSeat.BNonACCabin += aBookedSeatPatient.BPNonACCabin;
                    bookedSeat.BMaleWard += aBookedSeatPatient.BPMaleWard;
                    bookedSeat.BFemaleWard += aBookedSeatPatient.BPFemaleWard;
                    bookedSeat.BICU += aBookedSeatPatient.BPICU;
                    _aClinicalXEntities.BookedSeats.AddOrUpdate(bookedSeat);
                    _aClinicalXEntities.SaveChanges();
                }
            }
            catch (Exception e)
            {

                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


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
