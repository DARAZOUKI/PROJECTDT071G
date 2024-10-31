//TicketManager.cs

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace TicketManagerApp
{
    public class TicketManager
    {
        private List<Ticket> tickets = [];
        private int nextId = 1;
        private const string filePath = "tickets.json";
        private readonly HashSet<int> removedIds = [];

        public TicketManager()
        {
            LoadTicketsFromFile();
        }

           public void AddTicket(string title, string description, string priority, DateTime dueDate)
        {
            int ticketId = tickets.Count > 0 ? tickets.Max(t => t.Id) + 1 : 1;
            tickets.Add(new Ticket
            {
                Id = ticketId,
                Title = title,
                Description = description,
                Priority = priority,
                DueDate = dueDate
            });
            SaveTicketsToFile();
        }

    public void RemoveTicket(int id)
    {
        var ticket = tickets.FirstOrDefault(t => t.Id == id);
        if (ticket != null)
        {
            tickets.Remove(ticket);
            ReorderTicketIds();  // Reorder IDs to fill the gap
            SaveTicketsToFile();
        }
    }

   private void ReorderTicketIds()
        {
            for (int i = 0; i < tickets.Count; i++)
            {
                tickets[i].Id = i + 1;  // Assign new sequential ID
            }
        }

    public void UpdateTicketStatus(int id, string newStatus)
    {
        var ticket = tickets.FirstOrDefault(t => t.Id == id);
        if (ticket != null)
        {
            ticket.Status = newStatus;
            SaveTicketsToFile();
        }
    }

    public List<Ticket> GetAllTickets() => tickets;

    public List<Ticket> SearchTickets(string keyword)
    {
        return tickets.Where(t => t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                  t.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    private void SaveTicketsToFile()
    {
        try
        {
            var json = JsonSerializer.Serialize(tickets);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving tickets: {ex.Message}");
        }
    }

    private void LoadTicketsFromFile()
    {
        if (File.Exists(filePath))
        {
            try
            {
                var json = File.ReadAllText(filePath);
                tickets = JsonSerializer.Deserialize<List<Ticket>>(json) ?? [];
                nextId = tickets.Count != 0 ? tickets.Max(t => t.Id) + 1 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tickets: {ex.Message}");
            }
        }
    }

        internal void UpdateTicket(object ticket)
        {
            throw new NotImplementedException();
        }
        public Ticket? GetTicketById(int id)
{
    return tickets.FirstOrDefault(t => t.Id == id);
}
    }
}