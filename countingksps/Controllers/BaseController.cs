using countingksps.Models;
using countingksps.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace countingksps.Controllers
{
    public class BaseApiController : ApiController
    {
        ICountingKSRepository _repository;
        ModelFactory _modelFactory;
        public BaseApiController(ICountingKSRepository repository)
        {
            this._repository = repository;
        }

        public ICountingKSRepository Repository { get { return _repository; } }

        public ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                    _modelFactory = new ModelFactory(this.Request);
                return _modelFactory;
            }
            
        }
    }
}
