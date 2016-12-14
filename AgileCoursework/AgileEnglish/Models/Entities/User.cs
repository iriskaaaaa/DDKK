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
        
        public ObjectId _id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        public string Password { get; set; }
        public string Email { get; set; }

        
        //public Gender Gender { get; set; }
        //public int Age { get; set; }

       
        public List<Word> Words_en { get; set; }
        
    }


    public enum Gender
    {
        Male,
        Female
    }
}