using NHibernate;
using RhinoMockExamples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoMockExamples.Service {
    public class MealService : IMealService {
        public ISession Session { get; set; }

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

        public IList<Meal> GetMealsByDate(DateTime date) {
            var meals = Session.Query<Meal>().Where(x => x.Date == date).ToList();
            return meals;
        }


        public IList<Meal> GetMealsByGender(IList<Meal> allMeals, int gender) {
            var meals = allMeals.Where(x => x.ServerGender == gender).ToList();
            return meals;
        }

        public ITipCalculationService TipCalculationService { get; set; }
    }
}
