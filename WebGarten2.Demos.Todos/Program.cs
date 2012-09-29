using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGarten2.Demos.Todos.Controllers;

namespace WebGarten2.Demos.Todos
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HttpHost("http://localhost:8080");
            host.Add(DefaultMethodBasedCommandFactory.GetCommandsFor(typeof(ToDoController)));
            host.Open();
            Console.WriteLine("Server is running, press any key to continue...");
            Console.ReadKey();
            host.Close();
        }
    }
}
