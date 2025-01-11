using Formulatrix.Repositories.items;
using Formulatrix.Repositories;
using Formulatrix.Repositories.Items;

namespace Formulatrix.Repositories.items;

public static class ContentFactory
{
    public static IItemContent CreateContent(string content, ContentType contentType)=>
    contentType switch
    {
        ContentType.JSON => new JsonContent(content),
        ContentType.XML => new XMLContent(content),
        _ => throw new NotImplementedException("Invalid item type. Supported types: 1 = JSON, 2 = XML.")
    };
}