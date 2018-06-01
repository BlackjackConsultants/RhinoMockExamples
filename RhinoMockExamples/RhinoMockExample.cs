using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RhinoMockExamples.Model;
using RhinoMockExamples.Service;

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
        public void WhenUsingMockingLinqDependenciesReturnDesiredResults() {
            var query = MockRepository.GenerateStub<IQueryable>();
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

    }
}
