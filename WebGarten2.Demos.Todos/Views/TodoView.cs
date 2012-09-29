using WebGarten2.Demos.Todos;
using WebGarten2.Html;

namespace PI.WebGarten.Demos.Todos
{
    using PI.WebGarten.Demos.Todos.Model;
    
    class TodoView : HtmlDoc
    {
        public TodoView(ToDo t)
            :base("To Dos",
                H1(Text("To Do")),
                P(Text(t.Description)),
                A(ResolveUri.ForTodos(),"ToDo list")
                ){}
    }
}