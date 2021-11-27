using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ToDo.Shared
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        [BsonElement]
        public string Title { get; set; }
        [BsonElement]
        public string Email { get; set; }
        [BsonElement]
        public int Sort { get; set; }
        [BsonElement]
        public int Active { get; set; } 
        [BsonElement]
        public List<TodoItem> ToDo{get; set;}
    }
}