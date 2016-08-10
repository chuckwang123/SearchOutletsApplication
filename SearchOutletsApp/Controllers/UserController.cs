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
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        private readonly WebConfig _webconfig;
        private readonly FileReader _file;

        public UserController()
        {
            _webconfig = new WebConfig();
            _file = new FileReader();
        }

        // GET api/<controller>
        [Route("")]
        public IEnumerable<User> GetUses()
        {
            return GetAllUsers();
        }

        // GET api/<controller>/5
        [Route("{id:int}")]
        public User GetUserByUserId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(id + "is out of range");
            }

            var users = GetAllUsers();
            var collectOfUsers = from user in users
                                   where user.Id == id
                                   select user;
            var listofUsers = collectOfUsers as IList<User> ?? collectOfUsers.ToList();
            if (!listofUsers.Any())
            {
                throw new SearchOutletsException("Not found the User Id");
            }

            if (listofUsers.Count() > 1)
            {
                throw new SearchOutletsException("The id is not unique");
            }

            return listofUsers.FirstOrDefault();
        }

        [Route("")]
        public IEnumerable<User> GetUsersByContactId(int outletId)
        {
            if (outletId < 0)
            {
                throw new ArgumentOutOfRangeException(outletId + "is out of range");
            }

            var users = GetAllUsers();
            var collectOfUsers = from user in users
                                 where user.OutletId== outletId
                                 select user;

            var listofUsers = collectOfUsers as IList<User> ?? collectOfUsers.ToList();
            if (!listofUsers.Any())
            {
                throw new SearchOutletsException("Not found the Contact Id");
            }
            return listofUsers;
        }

        #region Methods
        private IEnumerable<User> GetAllUsers()
        {
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(_file.GetFile(_webconfig.ContactsFile));
            var outlets = JsonConvert.DeserializeObject<IEnumerable<Outlet>>(_file.GetFile(_webconfig.OutletsFile));
            return from contact in contacts 
            join outlet in outlets on contact.OutletId equals outlet.Id
            select new User
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                OutletId = outlet.Id,
                OutletName = outlet.Name,
                Profile = contact.Profile,
                Title = contact.Title,
                Name = contact.FirstName + " " + contact.LastName
            };
        }
        #endregion
    }
}