using Microsoft.AspNetCore.Session;

namespace MultiPageAppApierce.Models
{
    public class MySession
    {
        private const string CountryKey = "countries";

        private ISession session { get; set; }
        public MySession(ISession sess) => session = sess;
        public List<Country> GetCountries() => session.GetObject<List<Country>>(CountryKey) ?? new List<Country>();
        public void SetCountries(List<Country> countries) => session.SetObject(CountryKey, countries);
    }
}
