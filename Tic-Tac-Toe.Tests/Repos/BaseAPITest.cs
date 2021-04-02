using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.Tests
{
    public class BaseAPITest 
    {
        protected RestClient client;
        protected RestRequest request;
        protected static string baseUrl = "http://localhost:5000/api";
    }
}
