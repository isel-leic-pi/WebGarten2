using System.IO;

namespace WebGarten2.Html
{
    public interface IWritable
    {
        void WriteTo(TextWriter tw);
    }
}