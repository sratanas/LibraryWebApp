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

        [XmlElement("description")]
        public string description { get; set; }

        [XmlElement("image_url")]
        public string image_url { get; set; }

        [XmlElement("num_pages")]
        public string num_pages { get; set; }

        [XmlElement("average_rating")]
        public string average_rating { get; set; }
    }
}
