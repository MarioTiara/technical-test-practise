using Formulatrix.Formulatrix.Repositories.items;
using Formulatrix.Repositories;

namespace Formulatrix.Object_Oriented.test;

public class ContentFactoryTest
{
    [Theory]
    [InlineData("{}", ContentType.JSON)]
    [InlineData("<root></root>", ContentType.XML)]
    public void CreateContent_ShouldReturnCorrectContentType(string content, ContentType contentType)
    {
        //Act
        var itemContent= ContentFactory.CreateContent(content, contentType);

        //Assert
        if (contentType == ContentType.XML)
        {
            Assert.IsType<XMLContent>(itemContent);
            Assert.Equal(content, itemContent.Content);
            Assert.Equal(ContentType.XML, itemContent.ContentType);
        }
        else if (contentType == ContentType.JSON)
        {
            Assert.IsType<JsonContent>(itemContent);
            Assert.Equal(content, itemContent.Content);
            Assert.Equal(ContentType.JSON, itemContent.ContentType);
        }
    }

    [Fact]
    public void CreateContent_ShouldThrowExceptionForUnsupportedContentType()
    {
        //Arrange
        string content="<html></html>";
        ContentType contentType = (ContentType)9999;

        //Act & Assert
        Assert.Throws<NotImplementedException>(() => ContentFactory.CreateContent(content, contentType));
    }
}