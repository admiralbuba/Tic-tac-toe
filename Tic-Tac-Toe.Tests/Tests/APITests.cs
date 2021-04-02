using Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace Tic_Tac_Toe.Tests
{
    [TestFixture]
    public class APITests : BaseMapControllerTest
    {
        [Test]
        public void CheckStatusCodeFromMapController()
        {
            var result = client.Get(request);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void CheckDataFromMapController()
        {
            var result = client.Get(request);
            var buttonData = JsonConvert.DeserializeObject<List<ButtonInfo>>(result.Content);
            Assert.AreEqual(9, buttonData.Count);
        }
    }
}