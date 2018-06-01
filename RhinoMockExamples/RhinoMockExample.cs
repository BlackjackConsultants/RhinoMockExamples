using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RhinoMockExamples.Model;
using RhinoMockExamples.Service;
using NHibernate;

namespace RhinoMockExamples {
    [TestClass]
    public class SubMethodParameters {
        [TestMethod]
        public void WhenUsingExactParamValuesReturnOnlyWhenThoseValuesArePassed() {
           var tipCalculationService = MockRepository.GenerateStub<ITipCalculationService>();
            tipCalculationService.Stub(x => x.CalculateTip(100, .15)).Return(115);
            var mealService = new MealService();
            mealService.TipCalculationService = tipCalculationService;
            // get tip
            Meal meal = new Meal() { Cost = 100, Tip = .15 };
            var tip = mealService.GetTip(meal);
            Assert.IsTrue(tip == 115);

            // get nothing
            Meal meal2 = new Meal();
            var tip2 = mealService.GetTip(meal2);
            Assert.IsTrue(tip2 == 0);
        }

        [TestMethod]
        public void WhenUsingAnyParamValueReturnAlwaysTheResults() {
            var tipCalculationService = MockRepository.GenerateStub<ITipCalculationService>();
            tipCalculationService.Stub(x => x.CalculateTip(Arg<Double>.Is.Anything, Arg<Double>.Is.Anything)).Return(115);
            var mealService = new MealService();
            mealService.TipCalculationService = tipCalculationService;
            // get tip
            Meal meal = new Meal() { Cost = 100, Tip = .15 };
            var tip = mealService.GetTip(meal);
            Assert.IsTrue(tip == 115);

            // get nothing
            Meal meal2 = new Meal() { Cost = 222, Tip = .11 };
            var tip2 = mealService.GetTip(meal2);
            Assert.IsTrue(tip2 == 115);
        }

        [TestMethod]
        public void WhenUsingNoParamValueReturnDesiredTheResults() {
            var tipCalculationService = MockRepository.GenerateStub<ITipCalculationService>();
            tipCalculationService.Stub(x => x.GetTippedEmployee()).Return("Michael Jordan");
            var mealService = new MealService();
            mealService.TipCalculationService = tipCalculationService;
            // get tip
            Meal meal = new Meal() { ServerName = "Mike Trout" };
            var tip = mealService.GetEmployeeName(meal);
            Assert.IsTrue(tip == "Michael Jordan");

            // get nothing
            Meal meal2 = new Meal() { ServerName = "Albert Pujols" };
            var tip2 = mealService.GetEmployeeName(meal2);
            Assert.IsTrue(tip2 == "Michael Jordan");

            // using no stub
            Meal meal3 = new Meal() { ServerName = "Tito Fuentes" };
            var mealServiceReal = new MealService();
            mealServiceReal.TipCalculationService = new TipCalculationService();
            var tip3 = mealServiceReal.GetEmployeeName(meal3);
            Assert.IsTrue(tip3 == "Tito Fuentes");
        }


        [TestMethod]
        public void WhenUsingMockingLinqDependenciesWithNHibernateSessionReturnDesiredResults() {
            /* 
             * note: when doing linq, simple create the fake list and let linq do its thing.
             */

            var meals = new List<Meal>() {
                         new Meal() { ServerName = "pancho", Cost = 333, Tip = .15, Id = 1, Date = DateTime.Now },
                         new Meal() { ServerName = "papo", Cost = 222, Tip = .15, Id = 2, Date = new DateTime(2018, 5, 14)}
                     };

            var session = MockRepository.GenerateStub<ISession>();
            IQueryable<Meal> query = MockRepository.GenerateStub<IQueryable<Meal>>();
            session.Stub(s => s.Query<Meal>()).Return(meals.AsQueryable());

            var mealService = new MealService();
            mealService.Session = session;
            var todayMeals = mealService.GetMealsByDate(meals, new DateTime(2018, 6, 1));
            Assert.IsTrue(todayMeals.Count == 1);

            //MockRepository.GenerateMock<IRepository>();
            //mealsQuery.Stub(mealsQuery.Expression).Return("Michael Jordan");
            //_repository.Stub(x => x.Query<ActionType>()).Return(_actionQuery);

        }

    }
}
