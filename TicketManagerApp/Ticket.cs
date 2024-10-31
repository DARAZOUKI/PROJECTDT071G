// Ticket.cs

namespace TicketManagerApp
{
    public class Ticket
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Open";

        public override string ToString()
        {
            return $"[ID: {Id}] | Title: {Title} \n" +
                   $"Description: {Description}\n" +
                   $"Priority: {Priority} | Due: {DueDate.ToString("d")} | Status: {Status}\n" +
                   new string('-', 60);
        }
    }
}
