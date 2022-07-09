using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.FunTranslationService.Models
{
    public class ResponseModel
    {
        [JsonProperty("success")]
        public Success Success { get; set; }
        [JsonProperty("contents")]
        public Contents Contents { get; set; }
    }
    public class Success
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }
    public class Contents
    {
        [JsonProperty("translated")]
        public string Translated { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("translation")]
        public string Translation { get; set; }
    }

}
