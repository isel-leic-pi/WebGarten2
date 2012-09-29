using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebGarten2
{
    class SketchPad
    {
    }

    public class DefaultMethodBasedCommandFactory
    {
        private static IParameterBinderProvider _binder = new CompositeParameterBinderProvider(
                new UriTemplateParameterBinderProvider(),
                new RequestMessageParameterBinderProvider(),
                new FormUrlEncodingParameterBinderProvider()
        );

        public static CommandBind[] GetCommandsFor(params Type[] types)
        {
            return new MethodBasedCommandFactory(_binder, types).Create().ToArray();
        }
    }
}
