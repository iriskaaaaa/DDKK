using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileEnglish.Models.Entities
{

    public class Word
    {
        [BsonElement(elementName: "ID")]
        public int ID { get; set; }
        [BsonElement(elementName: "Value")]
        public string Value { get; set; }
        [BsonElement(elementName: "Translation")]
        public string Translation { get; set; }
    }
}