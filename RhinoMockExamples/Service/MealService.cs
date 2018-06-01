using RhinoMockExamples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoMockExamples.Service {
    public class MealService : IMealService {
        public double GetTip(Meal meal) {
            return TipCalculationService.CalculateTip(meal.Cost, .15);
        }

        public string GetEmployeeName(Meal meal) {
            TipCalculationService.Meal = meal;
            return TipCalculationService.GetTippedEmployee();
        }

        public string GetEmployeeName() {
            return TipCalculationService.Meal.ServerName;
        }

        public IList<Meal> GetMealsByDate(IList<Meal> allMeals, DateTime date) {
            return allMeals.Where(x => x.Date == date).ToList();
        }

        public ITipCalculationService TipCalculationService { get; set; }
    }
}
