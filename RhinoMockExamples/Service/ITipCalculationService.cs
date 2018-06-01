using RhinoMockExamples.Model;

namespace RhinoMockExamples.Service {
    public interface ITipCalculationService {
        Meal Meal { get; set; }

        double CalculateTip(double cost, double tipPercentage);
        string GetTippedEmployee();
    }
}