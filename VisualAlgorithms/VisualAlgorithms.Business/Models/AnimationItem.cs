using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public class AnimationItem
    {
        public static string EdgeHighlight = "eh";
        public static string NodeHighlight = "nh";
        public static string QueueAdd = "qa";
        public static string QueueRemove = "qr";

        public AnimationItem(string command, string id)
        {
            this.command = command;
            this.id = id;
        }
        public string command { get; set; }
        public string id { get; set; }
    }
}
