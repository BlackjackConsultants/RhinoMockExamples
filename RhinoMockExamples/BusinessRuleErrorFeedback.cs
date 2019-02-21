using RhinoMockExamples.Exceptions;
using RhinoMockExamples.Exceptions.BusinessRules;
using RhinoMockExamples.Model;

namespace RhinoMockExamples {
    internal class BusinessRuleErrorFeedback<T> {
        private ConstraintViolationException businessRule;
        private IDataImportJobSchemaService dataImportJobSchemaService;

        public BusinessRuleErrorFeedback(ConstraintViolationException businessRule, IDataImportJobSchemaService dataImportJobSchemaService) {
            this.businessRule = businessRule;
            this.dataImportJobSchemaService = dataImportJobSchemaService;
            if (businessRule.ConstraintReturns != null && businessRule.ConstraintReturns.Length > 0) {
                dataImportJobSchemaService.Test();
                Meal meal = new Meal() { Id = 1, ServerName = "Pepe" };
                dataImportJobSchemaService.Test2(meal);
                var test = dataImportJobSchemaService.AProperty;
            }
        }
        public BusinessRuleErrorFeedback() {

        }

        public bool Test(IDataImportJobSchemaService dataImportJobSchemaService) {
            Meal meal = new Meal() { Id = 1, ServerName = "Pepe", Cost = 1 };
            Meal meal2 = new Meal() { Id = 2, ServerName = "Pepe2", Cost = 2};
            return dataImportJobSchemaService.Test4(meal, meal2);
        }
    }
}