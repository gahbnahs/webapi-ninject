using countingksps.Models;
using countingksps.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace countingksps.Controllers
{
    public class MeasuresController : BaseApiController
    {
        public MeasuresController(ICountingKSRepository repository):
            base(repository)
        { }
        

        public HttpResponseMessage Get(int foodId)
        {
            HttpResponseMessage response;
            IEnumerable<Measure> results = Repository.GetMeasuresForFood(foodId).Select(m => TheModelFactory.Create(m)); ;
            //var results = results1.Select(m => new 
            //       {
                      
            //          Description = m.Description,
            //           Food =
            //        TheModelFactory.Create(m.Food),
            //}
                
            //);
            if (results==null || results.Count() == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("no measures for foodId={0}", foodId));
            }
            else
            {
                 response = Request.CreateResponse(HttpStatusCode.OK,results);
            }
            
            return response;
        }


        public HttpResponseMessage Get(int foodId, int id)
        {
            HttpResponseMessage response;
            var results = Repository.GetMeaure(foodId, id);
            if (results == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("no measures for foodId={0} and measure id={1}", foodId, id));
            }
            else
            {
                results = TheModelFactory.Create(results);
                results.Food = TheModelFactory.Create(results.Food);
                response = Request.CreateResponse(HttpStatusCode.OK, results);
            }

            return response;
        }


    }
}
