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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using RestSharp;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using System.Web.Configuration;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace CRASHAPI.Controllers
{

    public class DefaultContentTypeMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post && request.Content.Headers.ContentType == null)
            {
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
    /*public class DefaultContentTypeMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var contenttypes = request.Content.Headers.ContentType;
            foreach (var h in request.Content.Headers)
            {
                Debug.WriteLine(h.Key + ": ");
                foreach (var v in h.Value) Debug.Write(v);
            }
            Debug.WriteLine("media type: " + contenttypes.MediaType);
            if (contenttypes == null)
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");


            var response = await base.SendAsync(request, cancellationToken);


            return response;
        }

    }*/

    public class AccidentController : ApiController
    {
        private VCSGEntities db = new VCSGEntities();

        // GET api/Default1
        //[ApiExplorerSettings(IgnoreApi = true)]
        public IEnumerable<vw_PQT_AccidentHeader> Getvw_PQT_AccidentHeader()
        {
            return db.vw_PQT_AccidentHeader.Take(100).AsEnumerable();
        }

        // GET api/Default1/5       
        public vw_PQT_AccidentHeader Getvw_PQT_AccidentHeader(string id)
        {
            vw_PQT_AccidentHeader vw_pqt_accidentheader = db.vw_PQT_AccidentHeader.Find(id);
            if (vw_pqt_accidentheader == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return vw_pqt_accidentheader;
        }
       
        [HttpPost]
        public List<AccidentModel.Accident> Search(BasicSearchParameters sp)
        {          
            List<AccidentModel.Accident> accidents = new List<AccidentModel.Accident>();

            IQueryable<vw_PQT_AccidentHeader> query = Query(sp);

            foreach (vw_PQT_AccidentHeader a in query) {
                accidents.Add(new AccidentModel.Accident(a));
            }
            return accidents;
            
        }
        [HttpPost]
        public IQueryable<vw_PQT_AccidentHeader> Query(BasicSearchParameters sp)
        {
            var query = db.vw_PQT_AccidentHeader.Where(x => x.REPORTNUMBER != null);
            if (!string.IsNullOrEmpty(sp.StartDate))
            {
                var startDate = Convert.ToDateTime(sp.StartDate);
                query = from a in query
                        where a.ACCIDENTDATE >= startDate
                        select a;
            }

            if (!string.IsNullOrEmpty(sp.EndDate))
            {
                var endDate = Convert.ToDateTime(sp.EndDate);
                query = from a in query
                        where a.ACCIDENTDATE <= endDate
                        select a;
            }

            if (sp.CityCode != null && sp.CityCode.Count > 0)
            {
                query = from a in query
                        where a.VCSG_CITYTOWN != null && sp.CityCode.Contains(a.VCSG_CITYTOWN)
                        select a;
            }

            if (sp.CountyCode != null && sp.CountyCode.Count > 0)
            {
                query = from a in query
                        where sp.CountyCode.Contains(a.VCSG_CITYTOWN.Substring(0, 2))
                        select a;
            }

            if (sp.CrashType != null && sp.CrashType.Count > 0)
            {
                query = from a in query
                        where sp.CrashType.Any(ct => ct == a.CRASHTYPEid)
                        select a;
            }

            if (sp.ReportingAgency != null && sp.ReportingAgency.Count > 0)
            {
                query = from a in query
                        where sp.ReportingAgency.Contains(a.REPORTINGAGENCYid)
                        select a;
            }

            if (sp.Route != null && sp.Route.Count > 0)
            {
                query = from a in query
                        where sp.Route.Contains(a.VCSG_AOTROUTE)
                        select a;
            }

            return query;
            
        }

        [HttpPost]
        public List<vw_PQT_AccidentHeader> SearchBasic(BasicSearchParameters sp)
        {
            return Query(sp).ToList();
        }

        [HttpPost]
        public int Count(BasicSearchParameters sp)
        {
            return Query(sp).Count();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}