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
    [RoutePrefix("api/Contacts")]
    public class ContactsController : ApiController
    {
        private readonly WebConfig _webconfig;
        private readonly FileReader _file;

        public ContactsController()
        {
            _webconfig = new WebConfig();
            _file = new FileReader();
        }

        // GET api/<controller>
        [Route("")]
        public IEnumerable<Contact> GetContacts()
        {
            return GetAllContacts();
        }

        // GET api/<controller>/5
        [Route("{id:int}")]
        public Contact GetContactById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(id + "is out of range");
            }

            var contacts = GetAllContacts();
            var collectOfContacts = from contact in contacts
                                   where contact.Id == id
                                   select contact;
            var listofContacts = collectOfContacts as IList<Contact> ?? collectOfContacts.ToList();
            if (!listofContacts.Any())
            {
                throw new EmptyException("Not found the Contact Id");
            }

            if (listofContacts.Count() > 1)
            {
                throw new NotSingleException("The id is not unique");
            }

            return listofContacts.FirstOrDefault();
        }

        #region Methods
        private IEnumerable<Contact> GetAllContacts()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(_file.GetFile(_webconfig.ContactsFile));
        }
        #endregion
    }
}