using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CRASHAPI.Models;
using System.Net.Http.Headers;
using System.Web.Http.Cors;

namespace CRASHAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ReferenceController : ApiController
    {
        private ReferenceEntities db = new ReferenceEntities();

        [HttpGet]
        public IEnumerable<REFACCESSCONTROL> AccessControls()
        {
            return db.REFACCESSCONTROLs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFADMINCLASS> AdminClasses()
        {
            return db.REFADMINCLASSes.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFALCOHOLTEST> AlchoholTests()
        {
            return db.REFALCOHOLTESTs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFAPPARANTOPCOND> ApparantOpConditions()
        {
            return db.REFAPPARANTOPCONDs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFCARGOBODYTYPE> CargoBodyTypes()
        {
            return db.REFCARGOBODYTYPEs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFCENSUSCATEGORY> CensusCategories()
        {
            return db.REFCENSUSCATEGORies.AsEnumerable();
        }
        //citycodes
        [HttpGet]
        public IEnumerable<REFCLASS1TOWNHIGHWAYS> Class1TownHighways()
        {
            return db.REFCLASS1TOWNHIGHWAYS.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFCLOSEYEAR> CloseYears()
        {
            return db.REFCLOSEYEARs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFCONTRIBCIRCUMSTANCE> ContributingCircumstances()
        {
            return db.REFCONTRIBCIRCUMSTANCES.AsEnumerable();
        }
        //countycodes
        //crashtypes
        [HttpGet]
        public IEnumerable<REFDEFECTIVEEQUIPMENT> DefectiveEquipments()
        {
            return db.REFDEFECTIVEEQUIPMENTs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFDIRECTION> Directions()
        {
            return db.REFDIRECTIONs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFDIROFCOLLISION> DirectionOfCollision()
        {
            return db.REFDIROFCOLLISIONs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFDISTANCETYPE> DistanceTypes()
        {
            return db.REFDISTANCETYPEs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFDOMAINNAME> DomainNames()
        {
            return db.REFDOMAINNAMEs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFDRUGTESTRESULT> DrugTestResults()
        {
            return db.REFDRUGTESTRESULTs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFDRUGTEST> DrugTests()
        {
            return db.REFDRUGTESTs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFEJECTED> Ejected()
        {
            return db.REFEJECTEDs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFEMSAGENCy> MSAgencies()
        {
            return db.REFEMSAGENCIES.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFEQUIPMENTAR> EquipMentars()
        {
            return db.REFEQUIPMENTARS.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFFASYSDESIGNWAY> AsysDesignWay()
        {
            return db.REFFASYSDESIGNWAYs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFFASYSTRAVELWAY> AsysTravelWay()
        {
            return db.REFFASYSTRAVELWAYs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFFAUAREA> AuAreea()
        {
            return db.REFFAUAREAs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFFIVEYRIMPROVEMENT> FiveYrImprovements()
        {
            return db.REFFIVEYRIMPROVEMENTS.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFFUNCTCLASS> FunctClass()
        {
            return db.REFFUNCTCLASSes.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFGOVLEVOFCTR> GovLevofCTRs()
        {
            return db.REFGOVLEVOFCTRs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<RefGVWROrGCWR> GVWOrGCWRs()
        {
            return db.RefGVWROrGCWRs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFHIGHWAYDISTRICT> HighwayDistrict()
        {
            return db.REFHIGHWAYDISTRICTs.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFHOSPITAL> Hospitals()
        {
            return db.REFHOSPITALS.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<RefImageType> ImageTypes()
        {
            return db.RefImageTypes.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFINJURY> Injuries()
        {
            return db.REFINJURies.AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<REFINSURANCECO> InsuranceCos()
        {
            return db.REFINSURANCECOes.AsEnumerable();
        }
        [HttpGet]
        public HttpResponseMessage InterstateRoutes()
        {
            var result = db.REFINTERSTATEROUTES.AsEnumerable();

            var response = Request.CreateResponse(HttpStatusCode.OK, result.ToList());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            return response;
        }

        //missing a bunch here
        //below are the ones required for the query buyilder in the PQT.
        [HttpGet]
        public HttpResponseMessage RouteCodes()
        {
            var result = db.REFROUTECODES.AsEnumerable().OrderBy(x => x.ID);

            var response = Request.CreateResponse(HttpStatusCode.OK, result.ToList());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            return response;
        }
        [HttpGet]
        public HttpResponseMessage ReportingAgencies()
        {
            var result = db.REFREPORTINGAGENCies.Where(agency => agency.ID.Contains("VT") || agency.ID == "OTHER").OrderBy(x => x.DESCRIPTION);

            var response = Request.CreateResponse(HttpStatusCode.OK, result.ToList());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            return response;
        }
        [HttpGet]
        public HttpResponseMessage CrashTypes()
        {
            var result = db.REFCRASHTYPEs.AsEnumerable().OrderBy(x => x.DESCRIPTION);

            var response = Request.CreateResponse(HttpStatusCode.OK, result.ToList());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            return response;
        }
        [HttpGet]
        public HttpResponseMessage CityCodes()
        {
            var result = db.REFCITYCODEs.AsEnumerable().OrderBy(x => x.DESCRIPTION);

            var response = Request.CreateResponse(HttpStatusCode.OK, result.ToList());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            return response;
        }
        ///<summary>
        ///Allows filtering cities by countycode
        ///</summary>
        [HttpGet,Route("api/Reference/CityCodes/county/{countyid}")]
        public HttpResponseMessage CityCodes(string countyid)
        {
            var result = (from city in db.REFCITYCODEs.AsEnumerable()
                   where city.COUNTYCODE == countyid
                   select city).OrderBy(x => x.DESCRIPTION);

            var response = Request.CreateResponse(HttpStatusCode.OK, result.ToList());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            return response;
        }
        [HttpGet]
        public HttpResponseMessage CountyCodes()
        {
            var result = db.REFCOUNTYCODEs.AsEnumerable().OrderBy(x => x.DESCRIPTION);
 
            var response =Request.CreateResponse(HttpStatusCode.OK,result.ToList());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            return response;
        }
    }
}
