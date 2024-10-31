using System.Drawing;
using System.Windows.Forms;

namespace TicketManagerApp
{
    public partial class Form1 : Form
    {
        private Button btnAddTicket;
        private Button btnRemoveTicket;
        private Button btnUpdateTicket;
        private Button btnViewAllTickets;
        private Button btnSearchTicket;
        private ListBox listBoxTickets;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private ComboBox cmbPriority;
        private DateTimePicker dtpDueDate;
        private Label lblTitle;
        private Label lblDescription;
        private Label lblPriority;
        private Label lblDueDate;
        private GroupBox groupBoxTicketInfo;
        private FlowLayoutPanel buttonPanel;
        private TableLayoutPanel mainLayout;

        private void InitializeComponent()
        {
            // Initialize controls
            this.btnAddTicket = new Button();
            this.btnRemoveTicket = new Button();
            this.btnUpdateTicket = new Button();
            this.btnViewAllTickets = new Button();
            this.btnSearchTicket = new Button();
            this.listBoxTickets = new ListBox();
            this.txtTitle = new TextBox();
            this.txtDescription = new TextBox();
            this.cmbPriority = new ComboBox();
            this.dtpDueDate = new DateTimePicker();
            this.lblTitle = new Label();
            this.lblDescription = new Label();
            this.lblPriority = new Label();
            this.lblDueDate = new Label();
            this.groupBoxTicketInfo = new GroupBox();
            this.buttonPanel = new FlowLayoutPanel();
            this.mainLayout = new TableLayoutPanel();

            // Form settings
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.BackColor = Color.LightSteelBlue;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Ticket Manager - Manage Your Tickets Efficiently";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;

            // Main Layout (TableLayoutPanel) settings
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            this.Controls.Add(this.mainLayout);

            // GroupBox for ticket information
            this.groupBoxTicketInfo.Text = "Ticket Information";
            this.groupBoxTicketInfo.Dock = DockStyle.Fill;
            this.groupBoxTicketInfo.BackColor = Color.WhiteSmoke;

            // Button styling
            this.btnAddTicket.Text = "Add Ticket";
            this.btnAddTicket.Size = new Size(120, 40);
            this.btnAddTicket.BackColor = Color.DarkCyan;
            this.btnAddTicket.ForeColor = Color.White;
            this.btnAddTicket.FlatStyle = FlatStyle.Flat;
            this.btnAddTicket.Click += new System.EventHandler(this.BtnAddTicket_Click);

            // Add Ticket button
this.btnAddTicket.Text = "Add Ticket";
this.btnAddTicket.Size = new Size(120, 40);
this.btnAddTicket.BackColor = Color.DarkCyan;
this.btnAddTicket.ForeColor = Color.White;
this.btnAddTicket.FlatStyle = FlatStyle.Flat;
this.btnAddTicket.Click += new System.EventHandler(this.BtnAddTicket_Click);

// Remove Ticket button
this.btnRemoveTicket.Text = "Remove Ticket";
this.btnRemoveTicket.Size = new Size(120, 40);
this.btnRemoveTicket.BackColor = Color.Firebrick;
this.btnRemoveTicket.ForeColor = Color.White;
this.btnRemoveTicket.FlatStyle = FlatStyle.Flat;
this.btnRemoveTicket.Click += new System.EventHandler(this.BtnRemoveTicket_Click);

// Update Ticket button
this.btnUpdateTicket.Text = "Update Ticket";
this.btnUpdateTicket.Size = new Size(120, 40);
this.btnUpdateTicket.BackColor = Color.Orange;
this.btnUpdateTicket.ForeColor = Color.White;
this.btnUpdateTicket.FlatStyle = FlatStyle.Flat;
this.btnUpdateTicket.Click += new System.EventHandler(this.BtnUpdateTicket_Click);

// View All Tickets button
this.btnViewAllTickets.Text = "View All Tickets";
this.btnViewAllTickets.Size = new Size(120, 40);
this.btnViewAllTickets.BackColor = Color.DarkGreen;
this.btnViewAllTickets.ForeColor = Color.White;
this.btnViewAllTickets.FlatStyle = FlatStyle.Flat;
this.btnViewAllTickets.Click += new System.EventHandler(this.BtnViewAllTickets_Click);

   // Search Ticket button
this.btnSearchTicket.Text = "Search Ticket";
this.btnSearchTicket.Size = new Size(120, 40);
this.btnSearchTicket.BackColor = Color.MediumBlue;
this.btnSearchTicket.ForeColor = Color.White;
this.btnSearchTicket.FlatStyle = FlatStyle.Flat;
this.btnSearchTicket.Click += new System.EventHandler(this.BtnSearchTicket_Click);

// FlowLayoutPanel for buttons
this.buttonPanel.Dock = DockStyle.Fill;
this.buttonPanel.FlowDirection = FlowDirection.LeftToRight;
this.buttonPanel.BackColor = Color.LightSteelBlue;
this.buttonPanel.Controls.Add(this.btnAddTicket);
this.buttonPanel.Controls.Add(this.btnRemoveTicket);
this.buttonPanel.Controls.Add(this.btnUpdateTicket);
this.buttonPanel.Controls.Add(this.btnViewAllTickets);
this.buttonPanel.Controls.Add(this.btnSearchTicket);


            // FlowLayoutPanel for buttons
            this.buttonPanel.Dock = DockStyle.Fill;
            this.buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            this.buttonPanel.BackColor = Color.LightSteelBlue;
            this.buttonPanel.Controls.Add(this.btnAddTicket);
            this.buttonPanel.Controls.Add(this.btnRemoveTicket);
            this.buttonPanel.Controls.Add(this.btnUpdateTicket);
            this.buttonPanel.Controls.Add(this.btnViewAllTickets);
            this.buttonPanel.Controls.Add(this.btnSearchTicket);

            // ListBox for tickets
            this.listBoxTickets.Dock = DockStyle.Fill;
            this.listBoxTickets.Font = new Font("Consolas", 10);
            this.listBoxTickets.BackColor = Color.White;
            this.listBoxTickets.ForeColor = Color.DarkSlateGray;

            // Labels and input controls setup
            this.lblTitle.Text = "Title:";
            this.lblDescription.Text = "Description:";
            this.lblPriority.Text = "Priority:";
            this.lblDueDate.Text = "Due Date:";

            // Increase width for title and description input fields
            this.txtTitle.Width = 500;
            this.txtDescription.Width = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Height = 50;

            // Priority ComboBox
            this.cmbPriority.Items.AddRange(new string[] { "Low", "Medium", "High" });
            this.cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;

            // Organize controls in a nested layout
            var ticketInfoLayout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            ticketInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            ticketInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ticketInfoLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            ticketInfoLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            ticketInfoLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            ticketInfoLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            // Add Ticket Info controls to the layout
            ticketInfoLayout.Controls.Add(this.lblTitle, 0, 0);
            ticketInfoLayout.Controls.Add(this.txtTitle, 1, 0);
            ticketInfoLayout.Controls.Add(this.lblDescription, 0, 1);
            ticketInfoLayout.Controls.Add(this.txtDescription, 1, 1);
            ticketInfoLayout.Controls.Add(this.lblPriority, 0, 2);
            ticketInfoLayout.Controls.Add(this.cmbPriority, 1, 2);
            ticketInfoLayout.Controls.Add(this.lblDueDate, 0, 3);
            ticketInfoLayout.Controls.Add(this.dtpDueDate, 1, 3);

            // GroupBox integration
            this.groupBoxTicketInfo.Controls.Add(ticketInfoLayout);

            // Add controls to Main Layout
            this.mainLayout.Controls.Add(this.listBoxTickets, 0, 0);
            this.mainLayout.Controls.Add(this.groupBoxTicketInfo, 0, 1);
            this.mainLayout.Controls.Add(this.buttonPanel, 0, 2);
        }
    }
}
