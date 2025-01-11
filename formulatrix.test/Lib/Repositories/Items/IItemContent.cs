



using Formulatrix.Repositories.Items;

namespace Formulatrix.Repositories.items;

public interface IItemContent
{
    string Content { get; }
    ContentType ContentType{ get; }
}
