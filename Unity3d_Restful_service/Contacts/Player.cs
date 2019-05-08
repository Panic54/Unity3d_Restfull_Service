using System;
using Newtonsoft.Json;
namespace Unity3d_Restful_service.Contacts
{
    [JsonObject, Serializable]
    public class Player
    {
        public int Id { get; set; }

        public string DateTime { get; set; }

        public string FullName { get; set; }

        public float Score { get; set; }
    }
}
