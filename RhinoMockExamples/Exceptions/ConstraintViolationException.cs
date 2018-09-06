using RhinoMockExamples.Model;
using System;
using System.Runtime.Serialization;
using System.Security;
using System.Text;

namespace RhinoMockExamples.Exceptions.BusinessRules {

    [Serializable]
    public class ConstraintViolationException { //: BusinessRuleException {

        private readonly ConstraintReturn[] constraintReturns;

        public ConstraintViolationException() {
            constraintReturns = new ConstraintReturn[] { };
        }

        public ConstraintViolationException(ConstraintReturn[] constraintReturns) {
            this.constraintReturns = constraintReturns;
        }

        public ConstraintViolationException(Meal[] meals) {
        }

        public ConstraintViolationException(Meal meal) {
        }

        public ConstraintViolationException(string message) /*: base(message)*/ {
        }

        public ConstraintViolationException(string message, Exception exception)/* : base(message, exception)*/ {
        }

        protected ConstraintViolationException(SerializationInfo serializationInfo, StreamingContext streamingContext) /*: base(serializationInfo, streamingContext)*/ {
        }

        public ConstraintReturn[] ConstraintReturns {
            get; set;
        }

        public string Details {
            get {
                // create builder
                var builder = new StringBuilder();
                // loop constraint returns
                foreach (var constraintReturn in constraintReturns) {
                    // append constraint return details
                    builder.AppendLine(constraintReturn.ToString());
                }
                return builder.ToString();
            }
        }
    }
}

