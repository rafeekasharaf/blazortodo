using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDo.Shared
{
    public class TodoItem
    {
         public int ItemID {get; set;}
         public string Title { get; set; }
         public int Sort{get; set;}
         public int Active {get; set;} 
         public int Completed {get; set;} 

         public string CompletedCssClass{get; set;} ="row";

    }
}