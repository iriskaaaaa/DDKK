using AgileEnglish.Models.DataProvider;
using AgileEnglish.Models.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace AgileEnglish.Controllers
{
    public class UserPageController : Controller
    {
       

        [HttpGet]
        public ActionResult Index()
        {
            User user = (User)TempData["user"];

            return View("UserPage", user);
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            return UpdateUser(user);
        }


        [HttpPost]
        public ActionResult AddWord(string addValue, string addTranslation, string userId)
        {
            var user = FindUser(userId);
            var lastId = user.Words_en.OrderBy(x => x.ID).LastOrDefault()?.ID;
            user.Words_en.Add(new Word()
            {
                ID = lastId.HasValue ? lastId.Value + 1 : 1,
                Value = addValue,
                Translation = addTranslation
            });
            return UpdateUser(user);
        }

        [HttpGet]
        public ActionResult FilterWords(string filter, string userId)
        {
            
            var user = FindUser(userId);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                user.Words_en = user.Words_en.FindAll(x => x.Value.ToLower().Contains(filter.ToLower()) || x.Translation.ToLower().Contains(filter.ToLower()));
            }
            
            return View("UserPage", user);
        }

        public ActionResult UpdateUser(User user)
        {
            MongoDbProvider.Get.UsersRepository.ReplaceOneAsync(x => x._id == user._id , user);

            //refresh user
            user = MongoDbProvider.Get.UsersRepository.Find(x => x._id == user._id).SingleOrDefault();
            //Clear all textboxes
            ModelState.Clear();
            return View("UserPage", user);
        }


        public ActionResult EditWord(string wordId, string value, string translation, string userId)
        {
            var user = FindUser(userId);

            var wordToUpdate = user.Words_en.Find(x => x.ID == int.Parse(wordId));
            wordToUpdate.Value = value;
            wordToUpdate.Translation = translation;

            return UpdateUser(user);
        }

        User FindUser(string userId)
        {
            ObjectId userObjId = new ObjectId(userId);
            return MongoDbProvider.Get.UsersRepository.FindAsync(x => x._id == userObjId).Result.SingleOrDefault();
        }
        
        public ActionResult RemoveWord(int wordId, string userId)
        {
            var user = FindUser(userId);

            var word = user.Words_en.Find(x => x.ID == wordId);

            //var filter = Builders<BsonDocument>.Filter.Eq("_id", currentUser._id) & Builders<BsonDocument>.Filter.Eq("Words_en.$.ID", id);
            //  MongoDbProvider.Get.UsersRepository.DeleteOneAsync(User);

            user.Words_en.Remove(word);
            return UpdateUser(user);
        }
    }
}