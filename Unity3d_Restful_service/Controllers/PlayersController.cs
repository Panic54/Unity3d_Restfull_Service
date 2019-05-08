using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Unity3d_Restful_service.Contacts;

namespace Unity3d_Restful_service.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        SaveAndLoadScoreBoard saveAndLoad = new SaveAndLoadScoreBoard();
        private static List<Player> Players = new List<Player>() {
        new Player{
            Id = 1,
            DateTime = "24/05/2019",
            FullName = "Mads",
            Score = 100 },
         new Player{

            Id = 2,
            DateTime = "01/03/2019",
            FullName = "Frederik",
            Score = 200 },
          new Player{

            Id = 3,
            DateTime = "14/12/2018",
            FullName = "Troels",
            Score = 300 },
           new Player{

            Id = 4,
            DateTime = "21/04/2019",
            FullName = "Thomas",
            Score = 400 },
        };


         // GET api/values
         [HttpGet]
        public JsonResult Get()
        {
           // saveAndLoad.LoadLog();
            return Json(saveAndLoad.LoadLog());
           //return Json(Players);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Player player = Players.Single(p => p.Id == id);
            //return Json(saveAndLoad.LoadLog(player));
            return Json(player);
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] Player newPlayer)
        {

            Players = saveAndLoad.LoadLog();
            Players.Add(newPlayer);
            saveAndLoad.Write(newPlayer);

            return Json(Players);
            //return Json(Players);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] float newScore)
        {
            Player player = Players.Single(p => p.Id == id);
            player.Score = newScore;
            return Json(player);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Player player = Players.Single(p => p.Id == id);
            Players.Remove(player);
        }
    }
}
