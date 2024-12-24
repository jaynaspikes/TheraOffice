namespace _4870.library.Models
{
    public class Insurance
    {
          public int Id { get; set; } // Unique identifier for each insurance record
        public string InsuranceProvider { get; set; } // Name of the insurance provider
        public string PlanName { get; set; } // Name of the insurance plan
        public decimal CoveragePercentage { get; set; } // Coverage percentage (e.g., 80 for 80% coverage)
    }
}

