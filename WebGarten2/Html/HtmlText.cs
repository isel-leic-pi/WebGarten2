using System.IO;
using System.Web;

namespace WebGarten2.Html
{
    public class HtmlText : IWritable
    {
        private readonly string _text;

        public HtmlText(string text)
        {
            _text = text;
        }

        public void WriteTo(TextWriter w)
        {
            w.Write(HttpUtility.HtmlEncode(_text));
        }
    }
}