namespace _4870.library.Models
{
    public class Treatment
    {
        public int Id { get; set; } // Unique identifier for each treatment
        public string Name { get; set; } // Name of the treatment
        public string Description { get; set; } // Description of the treatment
        public decimal Price { get; set; } // Price of the treatment
        public decimal PriceWithInsurance { get; set; }

        public string DisplayText => $"{Name} - ${Price:F2}";
    }
}



