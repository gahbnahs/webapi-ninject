using System.Net.Http;
using System.Web.Http.Routing;

namespace countingksps.Models
{
    public class ModelFactory
    {
        UrlHelper _urlHelper;
        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }

        public Food Create(Food argFood)
        {
            argFood.url = _urlHelper.Link("Food", new { foodId = argFood.Id });
            return argFood;
        }


        public Measure Create(Measure argMeasure)
        {
            argMeasure.url = _urlHelper.Link("Measures", new { foodId = argMeasure.Food.Id, id= argMeasure.Id });
            return argMeasure;
        }


        public Diary Create(Diary argDiary)
        {
            argDiary.url = _urlHelper.Link("Diaries", new { diaryId = argDiary.date.ToString("yyyy-MM-dd")});
            return argDiary;
        }

    }
}