using System;
using System.Runtime.Serialization;
using System.Security;
using System.Text;

namespace RhinoMockExamples.Exceptions.BusinessRules {

    [Serializable]
    public class ConstraintViolationException {

        private readonly ConstraintReturn[] constraintReturns;

        public ConstraintViolationException() {
            constraintReturns = new ConstraintReturn[] { };
        }

        ////public ConstraintViolationException(string message)
        ////    : base(message) {
        ////    constraintReturns = new ConstraintReturn[] { };
        ////}

        ////public ConstraintViolationException(string message, ConstraintReturn[] constraintReturns)
        ////    : base(message) {
        ////    this.constraintReturns = constraintReturns;
        ////}

        public ConstraintViolationException(ConstraintReturn[] constraintReturns) {
            this.constraintReturns = constraintReturns;
        }

        public ConstraintReturn[] ConstraintReturns {
            get { return constraintReturns; }
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

        ////[SecurityCritical]
        ////public override void GetObjectData(SerializationInfo info, StreamingContext context) {
        ////    base.GetObjectData(info, context);
        ////}
    }
}

