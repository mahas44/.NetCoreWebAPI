using System.Collections.Generic;
using Data.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    [BsonCollection("Series")]
    public class Series : Base
    {
        [BsonElement("original_name")] 
        public string OriginalName { get; set; }

        [BsonElement("first_air_date")] 
        public string FirstAirDate { get; set; }

        [BsonElement("name")] 
        public string Name { get; set; }
    }
}