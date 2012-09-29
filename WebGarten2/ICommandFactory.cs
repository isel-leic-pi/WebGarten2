using System.Collections.Generic;

namespace WebGarten2
{
    public interface ICommandFactory
    {
        IEnumerable<CommandBind> Create();
    }
}