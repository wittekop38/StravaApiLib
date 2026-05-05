using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApiLib.DTOs.Activities
{
    public class MetaActivityDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}
