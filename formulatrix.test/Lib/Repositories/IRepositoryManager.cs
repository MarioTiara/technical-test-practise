
using Formulatrix.Repositories.Items;

namespace Formulatrix.Formulatrix.Repositories;

public interface IRepositoryManager
{
    void Register(string itemName, string itemContent, ContentType contentType);
    Task RegisterAsync(string itemName, string itemContent, ContentType contentType);
    string Retrieve(string itemName);
    Task<string> RetrieveAsync(string itemName);
    ContentType GetType(string itemName);
    Task<ContentType> GetTypeAsync(string itemName);
    void Deregister(string itemName);
    Task DeregisterAsync(string itemName);
}