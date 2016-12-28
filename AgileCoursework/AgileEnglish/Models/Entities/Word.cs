using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileEnglish.Models.Entities
{

    public class Word
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public string Translation { get; set; }
        public int Attempts { get; set; }
        public int  SuccessfulAttemtps { get; set; } 
    }
}