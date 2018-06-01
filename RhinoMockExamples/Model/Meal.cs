using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoMockExamples.Model {
    public class Meal {
        public double Cost { get; set; }
        public double Tip { get; set; }
        public double Tax { get; set; }
        public int Id { get; set; }
        public string ServerName { get; internal set; }
        public DateTime Date { get; internal set; }
    }
}
