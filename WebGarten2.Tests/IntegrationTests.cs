using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebGarten2.Tests
{
    internal class Controller
    {
        [HttpMethod("GET","/ok")]
        public HttpResponseMessage Ok()
        {
            return new HttpResponseMessage();
        }

        [HttpMethod("GET", "/500")]
        public HttpResponseMessage InternalException()
        {
            throw new Exception();
        }

        [HttpMethod("GET", "/t1/{p1}")]
        public HttpResponseMessage T1(int p1)
        {
            return new HttpResponseMessage();
        }

        [HttpMethod("POST", "/form")]
        public HttpResponseMessage Form(NameValueCollection values)
        {
            if(values.Count !=  2) throw new Exception();
            return new HttpResponseMessage();
        }
    }

    public class IntegrationTests : IDisposable
    {
        private readonly HttpHost _host;

        [Fact]
        public void When_internal_exception_Then_500_response()
        {
            using(var client = new HttpClient())
            {
                Assert.Equal(HttpStatusCode.InternalServerError, 
                    client.GetAsync("http://localhost:8080/500").Result.StatusCode);
            }   
        }

        [Fact]
        public void When_uri_with_invalid_path_Then_404_response()
        {
            using (var client = new HttpClient())
            {
                Assert.Equal(HttpStatusCode.NotFound, 
                    client.GetAsync("http://localhost:8080/t1/aa").Result.StatusCode);
            }
        }

        [Fact]
        public void When_content_form_url_encoded_Then_can_bind_to_namevaluecollection()
        {
            using (var client = new HttpClient())
            {
                Assert.Equal(HttpStatusCode.OK,
                    client.PostAsync("http://localhost:8080/Form",new FormUrlEncodedContent(new Dictionary<string, string>(){
                        {"name1","value2"},
                        {"name2","value2"}}
                    )).Result.StatusCode);
            }
        }

        public IntegrationTests()
        {
            _host = new HttpHost("http://localhost:8080");
            _host.Add(DefaultMethodBasedCommandFactory.GetCommandsFor(typeof(Controller)));
            _host.Open();
        }

        public void Dispose()
        {
            if(_host != null) _host.Close();
        }
    }
}
