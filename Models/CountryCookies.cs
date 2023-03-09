namespace MultiPageAppApierce.Models
{
    public class CountryCookies
    {
        private const string CountryKey = "myCountries";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; } = null!;
        private IResponseCookies responseCookies { get; set; } = null!;

        public CountryCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        public CountryCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetMyCountryIds(List<Country> myCountry)
        {
            List<string> ids = myCountry.Select(x => x.CountryId).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            RemoveMyCountryIds();
            responseCookies.Append(CountryKey, idsString, options);
        }

        public string[] GetMyCountryIds()
        {
            string cookie = requestCookies[CountryKey] ?? String.Empty;
            if (string.IsNullOrEmpty(cookie)) return Array.Empty<string>();
            else return cookie.Split(Delimiter);
        }

        public void RemoveMyCountryIds()
        {
            responseCookies.Delete(CountryKey);
        }
    }
}
