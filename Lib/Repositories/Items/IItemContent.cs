


using Formulatrix.Repositories;

namespace Formulatrix.Formulatrix.Repositories.items;

public interface IItemContent
{
    string Content { get; }
    ContentType ContentType{ get; }
}
