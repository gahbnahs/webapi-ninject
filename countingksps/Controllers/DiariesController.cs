using countingksps.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace countingksps.Controllers
{
    public class DiariesController : BaseApiController
    {

        public DiariesController(ICountingKSRepository repository):base(repository)
        {

        }

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            string userName = "gs";
            var results = Repository.GetDiaries(userName);
            if(results==null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, string.Format("No diary exists for user={0}",userName));
            }
            else
            {
                results = results.Select(r => TheModelFactory.Create(r));
                response = Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return response;
        }


        public HttpResponseMessage Get(DateTime diaryId)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            string userName = "gs";
            var results = Repository.GetDiary(userName, diaryId);
            if (results == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, string.Format("No diary exists for user={0} and date ={1}", userName, diaryId));
            }
            else
            {
                results =  TheModelFactory.Create(results);
                response = Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return response;
        }

    }
}
