using NUnit.Framework;
using RestSharp;

namespace Tic_Tac_Toe.Tests
{
    [SetUpFixture]
    public class BaseMapControllerTest : BaseAPITest
    {
        protected string baseMapControllerUrl = baseUrl + "/map";
        [OneTimeSetUp]
        public void Setup()
        {
            client = new RestClient(baseMapControllerUrl);
            request = new RestRequest();
        }
    }
}
