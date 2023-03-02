namespace MultiPageAppApierce.Models
{
    public class Country
    {
        public string CountryId { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public Game Game { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public string CountryFlag { get; set; } = String.Empty;
    }
}
