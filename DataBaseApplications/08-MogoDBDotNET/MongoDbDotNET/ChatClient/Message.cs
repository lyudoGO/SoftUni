namespace ChatClient
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string text { get; set; }

        public DateTime date { get; set; }

        public User user { get; set; }
    }
}
