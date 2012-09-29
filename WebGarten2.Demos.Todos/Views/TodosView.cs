using WebGarten2.Demos.Todos;
using WebGarten2.Html;

namespace PI.WebGarten.Demos.Todos
{
    using System.Collections.Generic;
    using System.Linq;

    using PI.WebGarten.Demos.Todos.Model;
    
    class TodosView : HtmlDoc
    {
        public TodosView(IEnumerable<ToDo> t)
            :base("To Dos",
                H1(Text("To Do list")),
                Ul(
                    t.Select(td => Li(A(ResolveUri.For(td),td.Description))).ToArray()
                    ),
                H2(Text("Create a new ToDo")),
                Form("post","/todos",
                    Label("desc","Description: "),InputText("desc")
                    )
                ){}
    }
}