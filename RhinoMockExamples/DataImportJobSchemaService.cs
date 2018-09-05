using RhinoMockExamples.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RhinoMockExamples {

    public class DataImportJobSchemaService : IDataImportJobSchemaService {
        public int Test() {
            return 2 + 3;
        }

        public int Test2(Meal meal) {
            return meal.Id;
        }
    }
}

