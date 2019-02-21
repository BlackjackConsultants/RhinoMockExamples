using RhinoMockExamples.Model;

namespace RhinoMockExamples {
    public interface IDataImportJobSchemaService {
        int Test();
        int Test2(Meal meal);
        void Test3(Meal meal);
        bool Test4(Meal meal1, Meal meal2);
        int AProperty { get; set; }
    }
}