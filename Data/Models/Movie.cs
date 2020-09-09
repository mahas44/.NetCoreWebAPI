using System;
using System.Collections.Generic;
using Data.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    [BsonCollection("Movies")]
    public class Movie : Base
    {
        [BsonElement("adult")] 
        public bool Adult { get; set; }

        [BsonElement("original_title")] 
        public string OriginalTitle { get; set; }

        [BsonElement("release_date")] 
        public string ReleaseDate { get; set; }

        [BsonElement("title")] 
        public string Title { get; set; }

        [BsonElement("video")] 
        public bool Video { get; set; }
    }
}