using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RhinoMockExamples.Model;

namespace RhinoMockExamples.Service {
    public class TipCalculationService : ITipCalculationService {
        public Meal Meal { get; set; }

        public double CalculateTip(double cost, double tipPercentage) {
            return cost * (1 + tipPercentage);
        }

        public string GetTippedEmployee() {
            return Meal.ServerName;
        }
    }
}
