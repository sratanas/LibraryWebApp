using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyLibraryWebApp.Goodreads
{
    [XmlRoot("GoodreadsResponse")]
    public class GoodreadsResponse
    {
        //for xml deserialization
        [XmlElement("book")]
        public List<book> Books { get; set; }


    }

    public class book
    {
        [XmlElement("id")]
        public int id { get; set; }

        [XmlElement("title")]
        public string title { get; set; }
        //public string description { get; set; }
    }
}
