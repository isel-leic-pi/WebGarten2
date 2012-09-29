using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebGarten2.Html;

namespace WebGarten2.Demos.Second
{
    class Controller
    {
        [HttpMethod("GET", "/xpto/{s}")]
        public HttpResponseMessage Get(string s)
        {
            return new HttpResponseMessage
                       {
                           Content = new StringContent(s)
                       };
        }

        [HttpMethod("GET", "/calc")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
                       {
                           Content = new FormView("Form").AsHttpContent("text/html")
                       };
        }

        [HttpMethod("POST", "/calc")]
        public HttpResponseMessage Post(NameValueCollection content)
        {
            var a = GetFromContent("a", content);
            var b = GetFromContent("b", content);
            if (!a.HasValue || !b.HasValue)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest){
                    Content = new FormView("Erro nos parâmetros").AsHttpContent("text/html")
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
                       {
                           Content = new FormView(a.Value+b.Value).AsHttpContent("text/html")
                       };
        }

        public int? GetFromContent(string name, NameValueCollection content)
        {
            var s = content[name];
            int i;
            if (s == null || !Int32.TryParse(s, out i))
            {
                return null;
            }
            return i;
        }
    }
}
