

using Formulatrix.Formulatrix.Repositories.items;
using Formulatrix.Repositories;

namespace Formulatrix.Object_Oriented.test;

public class XMLContentTest
{
      [Fact]
    public void Constructor_ShouldThorwExceptionForInvalidXMLData()
    {
        // Arrange
        string invalidXML = "<xml></xml><xml></xml>";
        
        //Act and Assert
        var exception= Assert.Throws<ArgumentException> (() => new XMLContent (invalidXML));
        Assert.Equal ("Invalid XML data.", exception.Message);
    }

    [Fact]  
    public void Constructor_ShouldContentWhenValidXMLData()
    {
        // Arrange
        string validXML = @"
                        <root>
                            <heading>Reminder</heading>
                            <body>Don't forget to check the updates!</body>
                        </root>";
                    

        //Act
        var XMLContent = new XMLContent (validXML);

        //Assert
        Assert.Equal (validXML, XMLContent.Content);
        Assert.Equal (ContentType.XML, XMLContent.ContentType);
    }
}