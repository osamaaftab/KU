using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Model.ResponseModel {
    public class AccountResponseModel {
        [JsonPropertyName("id")]
        public Guid CompanyId { get; set; }
        [JsonPropertyName("name")]
        public string CompanyName { get; set; }
    }
}
