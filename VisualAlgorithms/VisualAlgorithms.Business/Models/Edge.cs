using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public class Edge
    {
        public Vertex Source { get; set; }
        public Vertex Destionation { get; set; }
        public double Weight { get; set; }

    }
}
