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

        public void Test3(Meal meal) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// test passing 2 parameters to mock
        /// </summary>
        /// <param name="meal1"></param>
        /// <param name="meal2"></param>
        /// <returns></returns>
        public bool Test4(Meal meal1, Meal meal2) {
            return meal1.Cost == meal2.Cost;
        }

        public int AProperty { get; set; }
    }
}

