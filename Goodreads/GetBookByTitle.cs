using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MyLibraryWebApp.Goodreads
{
    public class GetBookByTitle : IGetBookByTitle
    {


        public async Task<GoodreadsResponse> ReturnBookBasedOnTitle(string searchInput)
        {
            const string goodreadsKey = "T6VTLiOTkiHHTmNwRWEzJw";

            using (var client = new HttpClient())
            {
                var url = new Uri($"https://www.goodreads.com/book/title.xml?key={goodreadsKey}&title={searchInput}");

                var response = await client.GetAsync(url);

                string xml;

                using (var content = response.Content)
                {                  
                    xml = await content.ReadAsStringAsync();
                };



                GoodreadsResponse myObject;
                // Construct an instance of the XmlSerializer with the type  
                // of object that is being deserialized.  
                XmlSerializer mySerializer =
                new XmlSerializer(typeof(GoodreadsResponse));
                // To read the file, create a FileStream.  
                TextReader sr = new StringReader(xml);
               // FileStream myFileStream =new FileStream(xml, );
                // Call the Deserialize method and cast to the object type.  
                myObject = (GoodreadsResponse)mySerializer.Deserialize(sr);

                return myObject;
            };

        }


    }
}
