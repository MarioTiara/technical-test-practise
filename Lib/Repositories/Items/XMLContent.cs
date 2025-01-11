
using System.Xml;
using Formulatrix.Repositories;

namespace Formulatrix.Formulatrix.Repositories.items;

public class XMLContent : IItemContent
{
    private string _xmlData;
    public XMLContent(string xmlData)
    {
        if (!IsValidXml(xmlData)) throw new ArgumentException("Invalid XML data.");
        _xmlData = xmlData;

    }
    public string Content => _xmlData;

    public ContentType ContentType => ContentType.XML;

    private bool IsValidXml(string xml)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml); 
            return true;
        }
        catch (XmlException)
        {
            return false; 
        }
    }
}
