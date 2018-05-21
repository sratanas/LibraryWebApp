using System.Runtime.Serialization;

namespace MyLibraryWebApp.Models
{
    [DataContract]
    public class Book
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}