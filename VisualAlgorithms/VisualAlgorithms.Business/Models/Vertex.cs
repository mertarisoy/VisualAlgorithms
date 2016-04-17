using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VisualAlgorithms.Business.Models
{
    public class Vertex
    { 
        public int Id { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "position")]
        public Point Position { get; set; }
    }
}
