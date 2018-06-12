using RhinoMockExamples.Exceptions;
using RhinoMockExamples.Exceptions.BusinessRules;

namespace RhinoMockExamples {
    internal class BusinessRuleErrorFeedback<T> {
        private EntityFeedbackInfo entityFeedbackInfo;
        private ConstraintViolationException businessRule;
        private BusinessRuleException businessRule2;
        private object insert;
        private EntitySerializationInfo entitySerializationInfo;
        private IDataImportJobSchemaService dataImportJobSchemaService;

        public BusinessRuleErrorFeedback(EntityFeedbackInfo entityFeedbackInfo, ConstraintViolationException businessRule, object insert, EntitySerializationInfo entitySerializationInfo, IDataImportJobSchemaService dataImportJobSchemaService) {
            this.entityFeedbackInfo = entityFeedbackInfo;
            this.businessRule = businessRule;
            this.insert = insert;
            this.entitySerializationInfo = entitySerializationInfo;
            this.dataImportJobSchemaService = dataImportJobSchemaService;
        }

        public BusinessRuleErrorFeedback(EntityFeedbackInfo entityFeedbackInfo, BusinessRuleException businessRule, object insert, EntitySerializationInfo entitySerializationInfo, IDataImportJobSchemaService dataImportJobSchemaService) {
            this.entityFeedbackInfo = entityFeedbackInfo;
            this.businessRule2 = businessRule;
            this.insert = insert;
            this.entitySerializationInfo = entitySerializationInfo;
            this.dataImportJobSchemaService = dataImportJobSchemaService;
        }
    }
}