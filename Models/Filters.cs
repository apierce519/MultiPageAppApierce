namespace MultiPageAppApierce.Models
{
    public class Filters
    {
        public Filters(string filterString)
        {
            FilterString = filterString ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            StatusId = filters[0];
        }

        public string FilterString { get; }
        public string StatusId { get; }

        public bool HasStatus => StatusId.ToLower() != "all";
    }
}
