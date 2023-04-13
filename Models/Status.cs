namespace MultiPageAppApierce.Models
{
    public class Status
    {
        public Status()
        {
        }

        public Status(string id)
        {
            this.StatusId = id;
            SetNameFromId(id);
        }
        public string StatusId { get; set; } = null!;
        public string Name { get; set; } = null!;

        internal void SetNameFromId(string id)
        {
            switch (id)
            {
                case "inprog":
                    Name = "In Progress";
                    break;
                case "qa":
                    Name = "Quality Assurance";
                    break;
                case "done":
                    Name = "Done";
                    break;
                case "todo":
                    Name = "Todo";
                    break;
                default:
                    throw new ArgumentException($"Invalid status id: {StatusId}");
            }
        }
    }
}
