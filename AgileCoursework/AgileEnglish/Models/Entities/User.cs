using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//Remove un
namespace AgileEnglish.Models.Entities
{
    public class User
    {
        
        [BsonId]
        public ObjectId _id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
        [BsonElement(elementName: "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        [BsonElement(elementName: "Password")]
        public string Password { get; set; }
        [BsonElement(elementName: "Email")]
        public string Email { get; set; }


        //public Gender Gender { get; set; }
        //public int Age { get; set; }


        private List<Word> words_en;
        [BsonIgnoreIfNull]
        [BsonElement(elementName: "Words_en")]
        //[BsonRepresentation(BsonType.Array)]
        public List<Word> Words_en {
            get
            {
                if (words_en == null)
                {
                    words_en = new List<Word>();
                }
                return words_en;
            }
            set
            {
                words_en = value;
            }
        }
        
    }


    public enum Gender
    {
        Male,
        Female
    }
}