using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.WebGarten.Demos.Todos.Model;

namespace WebGarten2.Demos.Todos
{
    static class ResolveUri
    {
        public static string For(ToDo td)
        {
            return string.Format("http://localhost:8080/todos/{0}", td.Id);
        }

        public static string ForTodos()
        {
            return "http://localhost:8080/todos";
        }
    }
}
