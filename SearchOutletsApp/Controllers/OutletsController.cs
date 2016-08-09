using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using SearchOutletsApp.Model.Exceptions;
using SearchOutletsApp.Model.SearchObjects;
using SearchOutletsApp.Util;

namespace SearchOutletsApp.Controllers
{
    [RoutePrefix("api/Outlets")]
    public class OutletsController : ApiController
    {
        private readonly WebConfig _webconfig;
        private readonly FileReader _file;
        public OutletsController()
        {
            _webconfig = new WebConfig();
            _file = new FileReader();
        }

        // GET api/<controller>
        [Route("")]
        public IEnumerable<Outlet> GetOutlets()
        {
            return GetAllOutlets();
        }

        // GET api/<controller>/5
        [Route("{id:int}")]
        public Outlet GetOutletById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(id + "is out of range");
            }

            var outlets = GetAllOutlets();
            var collectOfOutlets = from outlet in outlets
                where outlet.Id == id
                select outlet;
            var listofOutlets = collectOfOutlets as IList<Outlet> ?? collectOfOutlets.ToList();
            if (!listofOutlets.Any())
            {
                throw new EmptyException("Not found the Outlet Id");
            }

            if (listofOutlets.Count() > 1)
            {
                throw new NotSingleException("The id is not unique");
            }

            return listofOutlets.FirstOrDefault();
        }

        #region Methods
        private IEnumerable<Outlet> GetAllOutlets()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Outlet>>(_file.GetFile(_webconfig.OutletsFile));
        }
        #endregion
    }
}