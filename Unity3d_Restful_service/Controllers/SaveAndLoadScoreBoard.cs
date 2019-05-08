using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unity3d_Restful_service.Contacts;
namespace Unity3d_Restful_service.Controllers
{
    public class SaveAndLoadScoreBoard
    {
        public SaveAndLoadScoreBoard()
        {

        }
        private String LogfilePath = @"Log/log.txt";

        public void Write(Player item)
        {

            string output = JsonConvert.SerializeObject(item);

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(LogfilePath, true))
            {
                file.WriteLine(output);
            }
        }


        public List<Player> LoadLog()
        {
            List<Player> returnList = new List<Player>();

            foreach (string line in File.ReadLines(LogfilePath, Encoding.UTF8))
            {
                Player scoreItem = new Player();
                JObject jObject = JObject.Parse(line);
                scoreItem.Id = (int)jObject["Id"];
                scoreItem.FullName = (string)jObject["FullName"];
                scoreItem.DateTime = (string)jObject["DateTime"];
                scoreItem.Score = (int)jObject["Score"];

                returnList.Add(scoreItem);
            }

            return returnList;
        }



    }
}
