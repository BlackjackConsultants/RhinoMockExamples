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
    }
}
