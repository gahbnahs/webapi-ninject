using countingksps.Models;
using countingksps.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Routing;

namespace countingksps.Controllers
{
    public class FoodsController : BaseApiController
    {
        const int PAGE_SIZE = 1;
        public int MyProperty { get; set; }
        public FoodsController(ICountingKSRepository repository):base(repository)
        {
        }

        //setting as default (parameter is optional) rather this be passed as a query string.
        public object Get(bool includeMeasures =true, int pageNumber=0)
        {
            IEnumerable<Food> query;
            if(includeMeasures)
            {
                query = Repository.GetAllFoodsWithMeasures();
            }
            else
            {
                query = Repository.GetAllFoods();
            }
            var baseQuery = query.
                            OrderBy(f => f.Description);
            var numberOfRecords = baseQuery.Count();
            var numberofPages = Math.Ceiling((double) numberOfRecords / PAGE_SIZE);
            var result = baseQuery.
                            Skip(PAGE_SIZE * pageNumber).
                            Take(PAGE_SIZE).
                            ToList().Select(f => TheModelFactory.Create(f));


            var helper = new UrlHelper(Request);

            var prevUrl = pageNumber > 0 ? helper.Link("Food", new { pageNumber = pageNumber - 1 }) : "";
            var nextUrl = pageNumber < numberofPages - 1 ? helper.Link("Food", new { pageNumber = pageNumber + 1 }) : "";

            return new 
            {
                TotalPages = numberofPages,
                TotalRecords = numberOfRecords,
                //NextUrl= nextUrl,
                //PreviousUrl = prevUrl,
                //Result = result,
            };
        }


        public Food Get(int foodId)
        {
            //CountingKSRepository repo = new CountingKSRepository(new CountingKSContext());

            var results = Repository.GetFood(foodId);
            if(results!=null)
            {
                results = TheModelFactory.Create(results);
            }
            return results;
        }


    }
}
