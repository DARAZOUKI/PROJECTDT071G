// Form1.cs

using System;
using System.Windows.Forms;

namespace TicketManagerApp
{
    public partial class Form1 : Form
    {
        private readonly TicketManager ticketManager = new();

        public Form1()
        {
            InitializeComponent();
            dtpDueDate.Value = DateTime.Now;
            LoadTickets();
        }

       // Clears and reloads the ticket list in the list box.
        private void LoadTickets()
        {
             listBoxTickets.Items.Clear();
    foreach (var ticket in ticketManager.GetAllTickets())
    {
        // Displaying in the format [ID] Title - Priority
        listBoxTickets.Items.Add($"[{ticket.Id}] {ticket.Title} - {ticket.Status}");
    }
}
        

        // btnAddTicket_Click: Adds a new ticket using input from text fields.
        private void BtnAddTicket_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string? priority = cmbPriority.SelectedItem?.ToString();
            DateTime dueDate = dtpDueDate.Value;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(priority))
            {
                MessageBox.Show("Please fill in all fields before adding a ticket.");
                return;
            }

            ticketManager.AddTicket(title, description, priority, dueDate);
            LoadTickets();
            ClearInputFields();
            MessageBox.Show("Ticket added successfully.");
        }

      // Removes a selected ticket.
        private void BtnRemoveTicket_Click(object sender, EventArgs e)
        {
            if (listBoxTickets.SelectedItem is string selectedTicketString)
            {
                var ticketId = ExtractTicketIdFromString(selectedTicketString);
                if (ticketId != -1)
                {
                    ticketManager.RemoveTicket(ticketId);
                    LoadTickets();
                    MessageBox.Show("Ticket removed successfully.");
                }
            }
            else
            {
                MessageBox.Show("Please select a ticket to remove.");
            }
        }
 
      // Toggles status of the selected ticket.
        private void BtnUpdateTicket_Click(object sender, EventArgs e)
{
    if (listBoxTickets.SelectedItem is string selectedTicketString)
    {
        var ticketId = ExtractTicketIdFromString(selectedTicketString);
        if (ticketId != -1)
        {
            var ticket = ticketManager.GetTicketById(ticketId); // Retrieve the ticket by ID
            if (ticket != null)
            {
                // Toggle status: if it's "In Progress," change to "Closed"; if not, set to "In Progress"
                if (ticket.Status == "In Progress")
                {
                    ticketManager.UpdateTicketStatus(ticketId, "Closed");
                }
                else
                {
                    ticketManager.UpdateTicketStatus(ticketId, "In Progress");
                }

                LoadTickets();
                MessageBox.Show($"Ticket status updated to {ticket.Status}.");
            }
        }
    }
    else
    {
        MessageBox.Show("Please select a ticket to update.");
    }
}

       //Searches tickets by title keyword.
        private void BtnSearchTicket_Click(object sender, EventArgs e)
        {
            string keyword = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a keyword to search.");
                return;
            }

            // Filter tickets where the title contains the keyword, ignoring case sensitivity
               var filteredTickets = ticketManager.GetAllTickets()
                                       .Where(t => t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                                       .ToList();

            listBoxTickets.Items.Clear();
            foreach (var ticket in filteredTickets)
            {
                listBoxTickets.Items.Add(ticket.ToString());
            }

            if (filteredTickets.Count == 0)
            {
                MessageBox.Show("No tickets found matching the search criteria.");
            }
        }

        private static int ExtractTicketIdFromString(string ticketString)
        {
            var idString = ticketString.Split(']')[0].TrimStart('[');
            return int.TryParse(idString, out int id) ? id : -1;
        }

        private void ClearInputFields()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            cmbPriority.SelectedIndex = -1;
            dtpDueDate.Value = DateTime.Now;
        }


         // Reloads the full ticket list.
        private void BtnViewAllTickets_Click(object sender, EventArgs e)
        {
            LoadTickets();
        }
    }
}
