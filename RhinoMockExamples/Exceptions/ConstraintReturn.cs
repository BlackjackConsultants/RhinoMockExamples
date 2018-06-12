using System;
using System.Linq;
using System.Text;

namespace RhinoMockExamples.Exceptions.BusinessRules {

    public sealed class ConstraintReturn {

        private readonly bool result;
        private readonly string message;
        private readonly object target;
        private readonly string[] propertyNames;
        private readonly Rule rule;
        private readonly ConstraintReturn[] constraintReturns;

        public ConstraintReturn() {
            result = true;
            constraintReturns = new ConstraintReturn[] { };
        }

        public ConstraintReturn(Rule rule, bool result) {
            this.rule = rule;
            this.result = result;
            constraintReturns = new ConstraintReturn[] { };
        }

        public ConstraintReturn(Rule rule, bool result, string message) {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");
            this.rule = rule;
            this.result = result;
            this.message = message;
            constraintReturns = new ConstraintReturn[] { };
        }

        public ConstraintReturn(Rule rule, bool result, object target) {
            if (target == null)
                throw new ArgumentNullException("target");
            this.rule = rule;
            this.result = result;
            this.target = target;
            constraintReturns = new ConstraintReturn[] { };
        }

        public ConstraintReturn(Rule rule, bool result, object target, string message) {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");
            this.rule = rule;
            this.result = result;
            this.target = target;
            this.message = message;
            constraintReturns = new ConstraintReturn[] { };
        }

        public ConstraintReturn(Rule rule, bool result, object target, string[] propertyNames, string message) {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");
            this.rule = rule;
            this.result = result;
            this.target = target;
            this.message = message;
            this.propertyNames = propertyNames;
            constraintReturns = new ConstraintReturn[] { };
        }

        public ConstraintReturn(bool result, ConstraintReturn[] constraintReturns)
            : this(null, result, constraintReturns) {
        }

        public ConstraintReturn(Rule rule, bool result, ConstraintReturn[] constraintReturns) {
            if (constraintReturns == null)
                throw new ArgumentNullException("constraintReturns");
            this.rule = rule;
            this.result = result;
            this.constraintReturns = constraintReturns;
        }

        public ConstraintReturn(Rule rule, bool result, object target, string[] propertyNames, ConstraintReturn[] constraintReturns) {
            if (constraintReturns == null)
                throw new ArgumentNullException("constraintReturns");
            this.rule = rule;
            this.result = result;
            this.target = target;
            this.propertyNames = propertyNames;
            this.constraintReturns = constraintReturns;
        }

        public bool Result {
            get { return result; }
        }

        public object Target {
            get { return target; }
        }

        public string[] PropertyNames {
            get { return propertyNames; }
        }

        public string Message {
            get { return message; }
        }

        public Rule Rule {
            get { return rule; }
        }

        public ConstraintReturn[] ConstraintReturns {
            get { return constraintReturns; }
        }

        public override string ToString() {
            return ToString(0);
        }

        private string ToString(int level) {
            // create prefix
            var prefix = String.Join("\t", new string[level]);
            // create string builder
            var builder = new StringBuilder();
            // start return text
            builder.Append(prefix).AppendLine("ConstraintReturn {");
            // dump result
            builder.Append(prefix).Append("\tResult: ").Append(result).AppendLine();
            // dump business rule
            builder.Append(prefix).Append("\tRule: ").Append(rule != null ? rule.Name : "<not set>").AppendLine();
            // dump target
            builder.Append(prefix).Append("\tTarget: ").Append(target != null ? target.ToString() : "<not set>").AppendLine();
            // dump propertyNames
            var properties = propertyNames != null ? propertyNames.Aggregate((p1, p2) => p1 + ", " + p2) : "";
            builder.Append(prefix).Append("\tProperties: ").Append(target != null ? properties : "<not set>").AppendLine();
            // dump message
            builder.Append(prefix).Append("\tMessage: ").Append(!String.IsNullOrEmpty(message) ? message : "<not set>").AppendLine();
            // dump constraint returns
            builder.Append(prefix).AppendLine("\tConstraint Returns: [");
            // loop constraint returns
            foreach (ConstraintReturn constraintReturn in constraintReturns)
                builder.AppendLine(constraintReturn.ToString(level + 2));
            // close constraint returns
            builder.Append(prefix).AppendLine("\t]");
            // close constraint return
            builder.Append(prefix).Append("}");
            // return
            return builder.ToString();
        }
    }
}
