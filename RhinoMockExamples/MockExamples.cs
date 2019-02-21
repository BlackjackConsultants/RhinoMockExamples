using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RhinoMockExamples.Model;
using RhinoMockExamples.Service;
using NHibernate;
using RhinoMockExamples.Exceptions.BusinessRules;
using System.Transactions;
using RhinoMockExamples.Exceptions;

namespace RhinoMockExamples {

    [TestClass]
    public class MockExamples {

        /// <summary>
        /// Verfify that the Mocked class method was called.  In this case the method has no parameters
        /// </summary>
        [TestMethod]
        public void AssertWasCalledWithoutParamsExample() {
            var constraint = MockRepository.GenerateMock<ConstraintViolationException>();
            var dataImportJobSchemaService = MockRepository.GenerateMock<IDataImportJobSchemaService>();
            var errorFeedback = new BusinessRuleErrorFeedback<Transaction>(constraint, dataImportJobSchemaService);
            Assert.IsNotNull(errorFeedback);
            dataImportJobSchemaService.AssertWasNotCalled(r => r.Test());
            constraint.ConstraintReturns = new ConstraintReturn[1];
            constraint.ConstraintReturns[0] = new ConstraintReturn();
            var errorFeedback1 = new BusinessRuleErrorFeedback<Transaction>(constraint, dataImportJobSchemaService);
            dataImportJobSchemaService.AssertWasCalled(r => r.Test());
        }

        /// <summary>
        /// Verfify that the Mocked class method was called.  In this case the method has parameters
        /// </summary>
        [TestMethod]
        public void AssertWasCalledWithParamsExample() {
            var constraint = MockRepository.GenerateMock<ConstraintViolationException>();
            var dataImportJobSchemaService = MockRepository.GenerateMock<IDataImportJobSchemaService>();
            var errorFeedback = new BusinessRuleErrorFeedback<Transaction>(constraint, dataImportJobSchemaService);
            Assert.IsNotNull(errorFeedback);
            Meal meal = new Meal() { Id = 1, ServerName = "Pepe" };
            dataImportJobSchemaService.AssertWasNotCalled(r => r.Test2(Arg<Meal>.Matches(p => p.Id == 1 && p.ServerName == "Pepe")));
            constraint.ConstraintReturns = new ConstraintReturn[1];
            constraint.ConstraintReturns[0] = new ConstraintReturn();
            var errorFeedback1 = new BusinessRuleErrorFeedback<Transaction>(constraint, dataImportJobSchemaService);
            dataImportJobSchemaService.AssertWasCalled(r => r.Test2(Arg<Meal>.Matches(p => p.Id == 1 && p.ServerName == "Pepe")));
        }


        /// <summary>
        /// In this method we mock the dataImportJobSchemaService to return true even though inside the method it should return false.
        /// </summary>
        [TestMethod]
        public void AssertWasCalledWithMultipleParamsExample() {
            //mock example
            var dataImportJobSchemaService = MockRepository.GenerateMock<IDataImportJobSchemaService>();
            var errorFeedback = new BusinessRuleErrorFeedback<Transaction>();
            dataImportJobSchemaService.Expect(r => r.Test4(Arg<Meal>.Is.Anything, Arg<Meal>.Is.Anything)).Return(true);
            var retValue = errorFeedback.Test(dataImportJobSchemaService);
            Assert.IsTrue(retValue);
            // here we show what happens in real class
            var dataImportJobSchemaService2 = new DataImportJobSchemaService();
            var errorFeedback2 = new BusinessRuleErrorFeedback<Transaction>();
            var retValue2 = errorFeedback.Test(dataImportJobSchemaService2);
            Assert.IsFalse(retValue2);

        }

        /// <summary>
        /// Verfify that the Mocked class method was called.  In this case the method has parameters
        /// </summary>
        [TestMethod]
        public void AssertPropertyWasCalledWithParamsExample() {
            var constraint = MockRepository.GenerateMock<ConstraintViolationException>();
            var dataImportJobSchemaService = MockRepository.GenerateMock<IDataImportJobSchemaService>();
            var errorFeedback = new BusinessRuleErrorFeedback<Transaction>(constraint, dataImportJobSchemaService);
            Assert.IsNotNull(errorFeedback);
            Meal meal = new Meal() { Id = 1, ServerName = "Pepe" };
            dataImportJobSchemaService.AssertWasNotCalled(r => r.AProperty);
            constraint.ConstraintReturns = new ConstraintReturn[1];
            constraint.ConstraintReturns[0] = new ConstraintReturn();
            var errorFeedback1 = new BusinessRuleErrorFeedback<Transaction>(constraint, dataImportJobSchemaService);
            dataImportJobSchemaService.AssertWasCalled(r => r.AProperty);
        }

        /// <summary>
        /// this method shows how to create an array of mock objects. AmbiguousMatchException is thrown.
        /// </summary>
        [TestMethod]
        public void CreatingMockObjectsWithAndWithoutArguments() {
            var constraintReturns = new ConstraintReturn[1];
            constraintReturns[0] = new ConstraintReturn();
            Meal[] meals = new Meal[1];
            var meal = MockRepository.GenerateMock<Meal>();
            var test = new ConstraintViolationException(constraintReturns);
            // mock exception without arguments
            var constraint1 = MockRepository.GenerateMock<ConstraintViolationException>();
            // mock exception with string arguments
            var constraint2 = MockRepository.GenerateMock<ConstraintViolationException>("with string arg");
            // mock exception with an object
            var constraint3 = MockRepository.GenerateMock<ConstraintViolationException>(meal);
            // mock exception with an object
            var constraint4 = MockRepository.GenerateMock<ConstraintViolationException>(new object[] { new Meal[0] });
            // mock service
            var dataImportJobSchemaService = MockRepository.GenerateMock<IDataImportJobSchemaService>();
            // run test
            var errorFeedback = new BusinessRuleErrorFeedback<Transaction>(constraint4, dataImportJobSchemaService);
            Assert.IsNotNull(errorFeedback);
        }
    }
}
