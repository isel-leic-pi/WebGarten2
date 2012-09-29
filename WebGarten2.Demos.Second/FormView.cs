using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGarten2.Html;

namespace WebGarten2.Demos.Second
{
    internal class FormView : HtmlDoc
    {
        public FormView()
            : base("Form",
                H1(Text("Operação")),
                Form())
        { }

        public FormView(int res)
            : base("Título",
                H1(Text("Operação")),
                H2(Text("O resultado é " + res)),
                Form()
                )
        { }

        public FormView(string msg)
            : base("Título",
                H1(Text("Operação")),
                H2(Text(msg)),
                Form()
                )
        { }

        private static IWritable Form()
        {
            return
                Form("post", "/calc",
                    Label("a", "a"), InputText("a"),
                    Label("b", "b"), InputText("b"),
                    InputSubmit("Submeter"));

        }
    }
}
