

using Formulatrix.Repositories.items;
using Formulatrix.Repositories.Items;

namespace Formulatrix.Formulatrix.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IDictionary<string, IItemContent> _contentsRepository;
    private readonly IDictionary<string, string> _itemNameKey;

    public RepositoryManager()
    {
        _contentsRepository = new Dictionary<string, IItemContent>();
        _itemNameKey = new Dictionary<string, string>();
    }

    public void Deregister(string itemName)
    {
        if (!this.IsItemNameExist(itemName)) throw new ArgumentException($"Item with name {itemName} not found.");
        var key = _itemNameKey[itemName];
        _contentsRepository.Remove(key);
        _itemNameKey.Remove(itemName);
    }

    public async Task DeregisterAsync(string itemName)
    {
        await Task.Run(() =>this.Deregister(itemName));
    }

    public ContentType GetType(string itemName)
    {
        if (!this.IsItemNameExist(itemName)) throw new ArgumentException($"Item with name {itemName} not found.");
        var key = _itemNameKey[itemName];
        var content = GetContentByKey(key);
        return content == null ? ContentType.Unknown : content.ContentType;
    }

    public async Task<ContentType> GetTypeAsync(string itemName)
    {
       return await Task.Run(() =>this.GetType(itemName));
    }

    public void Register(string itemName, string itemContent, ContentType contentType)
    {
        if (_itemNameKey.ContainsKey(itemName))
        {
            throw new ArgumentException($"Item with name {itemName} already exist.");
        }

        var uniqeKey = Guid.NewGuid().ToString();
        var item = ContentFactory.CreateContent(itemContent, contentType);
        _contentsRepository[uniqeKey] = item;
        _itemNameKey[itemName] = uniqeKey;

        Console.WriteLine("Item registered successfully. Unique key: " + uniqeKey);

    }

    public async Task RegisterAsync(string itemName, string itemContent, ContentType contentType)
    {
       await Task.Run(()=> this.Register(itemName, itemContent, contentType));
    }

    public string Retrieve(string itemName)
    {
        if (_itemNameKey.TryGetValue(itemName, out var key))
        {
            var content = GetContentByKey(key);
            return content == null ? "Item not found" : content.Content;
        }

        return "Item not found";
    }

    public async Task<string> RetrieveAsync(string itemName)
    {
        return await Task.Run(()=>this.Retrieve(itemName));
    }

    private IItemContent? GetContentByKey(string key)
    {
        var content = _contentsRepository.TryGetValue(key, out var itemContent) ? itemContent : null;
        return content;
    }

    private bool IsItemNameExist(string itemName)
    {
        return _itemNameKey.ContainsKey(itemName);
    }
}
