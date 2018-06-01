using RhinoMockExamples.Model;

namespace RhinoMockExamples.Service {
    public interface IMealService {
        double GetTip(Meal meal);
        string GetEmployeeName();
    }
}