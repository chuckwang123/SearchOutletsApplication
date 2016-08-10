using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SearchOutletsApp.Controllers;
using SearchOutletsApp.Interfaces;
using SearchOutletsApp.Model.SearchObjects;

namespace SearchOutletsApp.Tests
{
    [TestClass]
    public class UserControllerUnitTests
    {
        private UserController _userController;
        private Mock<IFactory> _factoryMock;
        private Mock<IConfigurationManager> _configMock;
        private Mock<IFileReader> _fileMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _configMock = new Mock<IConfigurationManager>();
            _configMock.Setup(c => c.ContactsFile).Returns("ContactsFile");
            _configMock.Setup(c => c.FileLocation).Returns("FileLocation");
            _configMock.Setup(c => c.OutletsFile).Returns("OutletsFile");

            _fileMock = new Mock<IFileReader>();
            _fileMock.Setup(f => f.GetFile(It.IsAny<string>())).Returns("");

            _factoryMock = new Mock<IFactory>();
            _factoryMock.Setup(f => f.Files).Returns(_fileMock.Object);
            _factoryMock.Setup(f => f.WebConfig).Returns(_configMock.Object);

            _userController = new UserController(_factoryMock.Object);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void GetUses_withNoexception_ShouldReturnAllUsers()
        {
            var users = new User[2]
            {
                new User
                {
                    Id = 1,
                    OutletId = 1,
                    FirstName = "Kathleen",
                    LastName = "Mickey",
                    Name = "Kathleen Mickey",
                    OutletName = "Educational Marketer",
                    Profile = "profile",
                    Title = "Managing Editor"
                }, 
                new User
                {
                    Id = 2,
                    OutletId = 2,
                    FirstName = "Jon",
                    LastName = "Regardie",
                    Name = "Jon Regardie",
                    OutletName = "Downtown News",
                    Profile = "Rprofile1",
                    Title = "Executive Editor"
                }
            };
            _fileMock.Setup(f => f.GetFile(It.Is<string>(s=>s.Equals("ContactsFile")))).Returns("[\r\n  {\r\n    \"id\": 1,\r\n    \"outletId\": 1,\r\n    \"firstName\": \"Kathleen\",\r\n    \"lastName\": \"Mickey\",\r\n    \"title\": \"Managing Editor\",\r\n    \"profile\": \"profile\"\r\n  },\r\n  {\r\n    \"id\": 2,\r\n    \"outletId\": 2,\r\n    \"firstName\": \"Jon\",\r\n    \"lastName\": \"Regardie\",\r\n    \"title\": \"Executive Editor\",\r\n    \"profile\": \"Rprofile1\"\r\n  }\r\n  ]");
            _fileMock.Setup(f => f.GetFile(It.Is<string>(s => s.Equals("OutletsFile")))).Returns("[\r\n  {\r\n    \"id\": 1,\r\n    \"name\": \"Educational Marketer\"\r\n  },\r\n  {\r\n    \"id\": 2,\r\n    \"name\": \"Downtown News\"\r\n  }\r\n ]");
            var response =_userController.GetUsers();
            var responseArr = response as User[] ?? response.ToArray();
            responseArr.Count().ShouldBeEquivalentTo(2);
            responseArr.ShouldBeEquivalentTo(users);
        }
    }
}
