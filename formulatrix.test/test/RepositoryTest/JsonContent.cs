

using Formulatrix.Repositories;
using Formulatrix.Repositories.items;
using Formulatrix.Repositories.Items;

namespace Formulatrix.Repositories.test;

public class JsonContentTest
{
    [Fact]
    public void Constructor_ShouldThorwExceptionForInvalidJsonData()
    {
        // Arrange
        string invalidJson = "{key:value}";
        
        //Act and Assert
        var exception= Assert.Throws<ArgumentException> (() => new JsonContent (invalidJson));
        Assert.Equal ("Invalid JSON data.", exception.Message);
    }

    [Fact]  
    public void Constructor_ShouldContentWhenValidJsonData()
    {
        // Arrange
        string validJson = "{\"key\":\"value\"}";

        //Act
        var jsonContent = new JsonContent (validJson);

        //Assert
        Assert.Equal (validJson, jsonContent.Content);
        Assert.Equal (ContentType.JSON, jsonContent.ContentType);
    }
}