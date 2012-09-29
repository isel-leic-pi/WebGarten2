using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PI.WebGarten.Demos.Todos;
using PI.WebGarten.Demos.Todos.Model;
using System.Net;
using WebGarten2.Html;

namespace WebGarten2.Demos.Todos.Controllers
{
    class ToDoController
    {
        private readonly IToDoRepository _repo;
        public ToDoController()
        {
            _repo = ToDoRepositoryLocator.Get();
        }

        [HttpMethod("GET", "/todos/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var td = _repo.GetById(id);
            return td == null ? new HttpResponseMessage(HttpStatusCode.NotFound) : 
                new HttpResponseMessage{
                    Content = new TodoView(td).AsHtmlContent()
                };
        }

        [HttpMethod("GET", "/todos")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage{
                Content = new TodosView(_repo.GetAll()).AsHtmlContent()
        };
        }

        [HttpMethod("POST", "/todos")]
        public HttpResponseMessage Post(NameValueCollection content)
        {
            
            var desc = content["desc"];
            if (desc == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var td = new ToDo { Description = desc };
            _repo.Add(td);
            var resp = new HttpResponseMessage(HttpStatusCode.SeeOther);
            resp.Headers.Location = new Uri(ResolveUri.For(td));
            return resp;
        }
    }
}
