using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebGarten2.Demos.First
{
    class VerySimpleCommand : ICommand
    {
        public HttpResponseMessage Execute(HttpRequestMessage req)
        {
            return new HttpResponseMessage()
                       {
                           Content = new StringContent("Hello Web")
                       };
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HttpHost("http://localhost:8080");
            host.Add(new CommandBind(new VerySimpleCommand(), HttpMethod.Get, new UriTemplate("*")));
            host.Open();
            Console.WriteLine("Server is running, press any key to continue...");
            Console.ReadKey();
            host.Close();
        }
    }
}
