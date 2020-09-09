
using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public class Base
    {
        [BsonId]
        [BsonElement("_id")]
        public int Id { get; set; }

        [BsonElement("backdrop_path")]
        public string BackdropPath { get; set; }

        [BsonElement("genre_ids")]
        public List<int> GenreIds { get; set; }

        [BsonElement("origin_country")]
        public List<string> OriginCountry { get; set; }

        [BsonElement("genres")]
        public string Genres { get; set; }

        [BsonElement("original_language")]
        public string OriginalLanguage { get; set; }

        [BsonElement("overview")]
        public string Overview { get; set; }

        [BsonElement("popularity")]
        public double Popularity { get; set; }

        [BsonElement("poster_path")]
        public string PosterPath { get; set; }

        [BsonElement("vote_average")]
        public double VoteAverage { get; set; }

        [BsonElement("vote_count")]
        public int VoteCount { get; set; }

        [BsonElement("youtubeId")]
        public string YoutubeId { get; set; }

    }
}