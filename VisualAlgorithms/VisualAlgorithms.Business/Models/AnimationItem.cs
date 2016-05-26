using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public class AnimationItem
    {
        public static string RedHighlight = "rh";
        public static string GreenHighlight = "gh";
        public static string BlackHighlight = "bh";
        public static string RemoveHighlight = "Rh";
        public static string QueueAdd = "qa";
        public static string QueueRemove = "qr";
        public static string SetLabel = "sl";

        public AnimationItem(string command, string id, string data = "")
        {
            this.command = command;
            this.id = id;
            this.data = data;
        }
        public string command { get; set; }
        public string id { get; set; }
        public string data { get; set; }
    }
}
