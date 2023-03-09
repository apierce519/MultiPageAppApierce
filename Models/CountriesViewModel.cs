namespace MultiPageAppApierce.Models
{
    public class CountriesViewModel
    {
        public String UserName { get; set; } = string.Empty;
        public string ActiveCategory { get; set; } = "all";
        public string ActiveGame { get; set; } = "all";
        public Country Country { get; set; } = new Country();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Game> Games { get; set; } = new List<Game>();

        public string CheckActiveCategory(string c) { return c.ToLower() == ActiveCategory.ToLower() ? "active" : ""; }
        public string CheckActiveGame(string g) { return g.ToLower() == ActiveGame.ToLower() ? "active" : ""; }

    }
}
