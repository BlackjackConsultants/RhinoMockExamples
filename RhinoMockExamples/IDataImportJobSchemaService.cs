using RhinoMockExamples.Model;

namespace RhinoMockExamples {
    public interface IDataImportJobSchemaService {
        int Test();
        int Test2(Meal meal);
        void Test3(Meal meal);
        int AProperty { get; set; }
    }
}