namespace MultiPageAppApierce.Models
{
    public class CountrySession
    {
        public Country Country { get; set; } = new Country();

        private const string CountriesKey = "myCountries";
        private const string CountKey = "countryCount";
        private const string CategKey = "categ";
        private const string GameKey = "game";
        private const string NameKey = "Name";

        private ISession session { get; set; }
        public CountrySession(ISession session) { this.session = session; }
        public void SetMyCountries(List<Country> countries)
        {
            session.SetObject(CountriesKey, countries);
            session.SetInt32(CountKey, countries.Count);
        }
        public List<Country> GetMyCountries() { return session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>(); }

        public int? GetMyCountryCount() { return session.GetInt32(CountKey); }

        public void SetActiveCateg(string activeCateg) { session.SetString(CategKey, activeCateg); }
        public string GetActiveCateg() { return session.GetString(CategKey) ?? string.Empty; }

        public void SetActiveGame(string activeGame) { session.SetString(GameKey, activeGame); }
        public string GetActiveGame() { return session.GetString(GameKey) ?? string.Empty; }
        public void SetName(string userName)
        {
            if (String.IsNullOrEmpty(userName))
            {
                session.Remove(NameKey);
            }
            else
            {
                session.SetString(NameKey, userName);
            }
        }
        public string GetName()
        {
            return session.GetString(NameKey) ?? string.Empty;
        }
        public void RemoveMyCountries()
        {
            session.Remove(CountriesKey);
            session.Remove(CountKey);
        }
    }

}
