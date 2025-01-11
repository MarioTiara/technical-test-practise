using Formulatrix.Formulatrix.Repositories;
using Formulatrix.Repositories;
using Formulatrix.Repositories.Items;

namespace Formulatrix.Repositories.test;

public class RepositoryManagerTest
{
    private readonly IRepositoryManager _repositoryManager;

    public RepositoryManagerTest()
    => _repositoryManager = new RepositoryManager();

    [Fact]
    public void Register_ShouldRegisterItenSuccessFully()
    {
        //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;

        //Act
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Assert
        var result = _repositoryManager.Retrieve(itemName);
        Assert.Equal(itemContent, result);
    }
    [Fact]
    public async Task RegisterAsync_ShouldRegisterItenSuccessFully()
    {
        //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;

        //Act
        await _repositoryManager.RegisterAsync(itemName, itemContent, contentTpe);

        //Assert
        var result = _repositoryManager.Retrieve(itemName);
        Assert.Equal(itemContent, result);
    }

    [Fact]
    public void Register_ShouldThrowExceptionForDuplicateItemName()
    {
        //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
          _repositoryManager.Register(itemName, itemContent, contentTpe));

        Assert.Equal($"Item with name {itemName} already exist.", exception.Message);
    }
    [Fact]
    public async Task RegisterAsync_ShouldThrowExceptionForDuplicateItemName()
    {
        //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Act & Assert
        var exception = await Assert.ThrowsAnyAsync<ArgumentException>(() =>
          _repositoryManager.RegisterAsync(itemName, itemContent, contentTpe));

        Assert.Equal($"Item with name {itemName} already exist.", exception.Message);
    }

    [Fact]
    public void Retrieve_ExistingItem_ShouldReturnCorrectContent()
    {
        //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Act
        var result = _repositoryManager.Retrieve(itemName);

        //Assert
        Assert.Equal(itemContent, result);
    }

    [Fact]
    public async Task RetrieveAsync_ExistingItem_ShouldReturnCorrectContent()
    {
        //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        await _repositoryManager.RegisterAsync(itemName, itemContent, contentTpe);

        //Act
        var result = await _repositoryManager.RetrieveAsync(itemName);

        //Assert
        Assert.Equal(itemContent, result);
    }

    [Fact]
    public void Retrive_NonExitingData_ShouldReturnNotFoundMessage()
    {
        //arrange
        var itemName="non-existing-item";

        //Act 
        var result = _repositoryManager.Retrieve(itemName);

        //Assert
        Assert.Equal("Item not found", result);
    }

    [Fact]
    public async Task RetriveAsync_NonExitingData_ShouldReturnNotFoundMessage()
    {
        //arrange
        var itemName="non-existing-item";

        //Act 
        var result = await _repositoryManager.RetrieveAsync(itemName);

        //Assert
        Assert.Equal("Item not found", result);
    }

    [Fact]
    public void GetType_ShouldReturnCorrectContentTypeForExistingItem()
    {
         //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Act
        var type=_repositoryManager.GetType(itemName);

        //Assert
        Assert.Equal(ContentType.JSON, type);
    }
    [Fact]
    public async Task GetTypeAsync_ShouldReturnCorrectContentTypeForExistingItem()
    {
         //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Act
        var type=await _repositoryManager.GetTypeAsync(itemName);

        //Assert
        Assert.Equal(ContentType.JSON, type);
    }

    [Fact]
    public void GetType_ShouldThrowExceptionForNonExistingItem()
    {
         //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Act & Assert
        var err= Assert.Throws<ArgumentException>(()=> _repositoryManager.GetType("non-existing-item"));

        Assert.Equal($"Item with name non-existing-item not found.", err.Message);
    }

    [Fact]
    public async Task GetTypeAsync_ShouldThrowExceptionForNonExistingItem()
    {
         //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Act & Assert
        var err= await Assert.ThrowsAnyAsync<ArgumentException>(()=> _repositoryManager.GetTypeAsync("non-existing-item"));

        Assert.Equal($"Item with name non-existing-item not found.", err.Message);
    }

    [Fact]
    public void Deregister_ShouldRemoveExistingItemFromRepository()
    {
        //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Act
        _repositoryManager.Deregister(itemName);

        //Assert
        var result = _repositoryManager.Retrieve(itemName);
        Assert.Equal("Item not found", result);
    }

    [Fact]
    public async Task DeregisterAsync_ShouldRemoveExistingItemFromRepository()
    {
        //Arrange
        string itemName = "item-json";
        string itemContent = "{\"name\":\"item-json\",\"content\":\"content-json\",\"contentType\":\"JSON\"}";
        var contentTpe = ContentType.JSON;
        _repositoryManager.Register(itemName, itemContent, contentTpe);

        //Act
        await _repositoryManager.DeregisterAsync(itemName);

        //Assert
        var result = await _repositoryManager.RetrieveAsync(itemName);
        Assert.Equal("Item not found", result);
    }


    [Fact]
    public void Deregister_ShouldThrowErrorForNonExistingItemFromRepository()
    {
        //Arrange
        string itemName = "item-json";

        //Act & Assert
         var err=Assert.Throws<ArgumentException>(()=> _repositoryManager.Deregister(itemName));

        //Assert
        Assert.Equal($"Item with name {itemName} not found.", err.Message);

    }

    [Fact]
    public async Task DeregisterAsync_ShouldThrowErrorForNonExistingItemFromRepository()
    {
        //Arrange
        string itemName = "item-json";

        //Act & Assert
         var err=await Assert.ThrowsAnyAsync<ArgumentException>(()=> _repositoryManager.DeregisterAsync(itemName));

        //Assert
        Assert.Equal($"Item with name {itemName} not found.", err.Message);

    }
}