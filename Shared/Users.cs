using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ToDo.Shared
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserID { get; set; }
        [BsonElement]
        public string Email { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public int Active { get; set; } 
        
    }
}