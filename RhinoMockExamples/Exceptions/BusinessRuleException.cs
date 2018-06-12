using System;
using System.Runtime.Serialization;
using System.Security;

namespace RhinoMockExamples.Exceptions {

    [Serializable]
    public class BusinessRuleException : Exception {

        public BusinessRuleException() {
        }

        public BusinessRuleException(string message)
            : base(message) {
        }

        public BusinessRuleException(string message, Exception exception)
            : base(message, exception) {
        }

        protected BusinessRuleException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) {
        }

        [SecurityCritical]
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);
        }
    }
}

