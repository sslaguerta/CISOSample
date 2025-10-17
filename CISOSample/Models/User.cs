namespace CISOSample.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Status? Status { get; set; } = null;

    }
    public enum Status
    {
        Approved = 1,
        Rejected,
        ForConsideration,
    };
}
