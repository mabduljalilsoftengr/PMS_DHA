using Microsoft.AspNet.SignalR.Client;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmGoBackRemarks_Wth_Notification : Telerik.WinControls.UI.RadForm
    {
        private String UserName { get; set; }
        private IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://172.16.0.1:8181/signalr";
        private HubConnection Connection { get; set; }
        public frmGoBackRemarks_Wth_Notification()
        {
            InitializeComponent();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            //UserName = TextBoxUsername.Text;
            //if (!String.IsNullOrEmpty(UserName))
            //{
            //    StatusText.Visible = true;
            //    StatusText.Text = "Connecting to server...";
            //    ConnectAsync();
            //}
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            clsNDC.goBackRemarks = TextBoxMessage.Text;
            HubProxy.Invoke("Send", UserName, TextBoxMessage.Text);
            TextBoxMessage.Text = String.Empty;
            TextBoxMessage.Focus();
            this.Close();
        }
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyChatHub");
            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            //HubProxy.On<string, string>("AddMessage", (name, message) =>
            //    this.Invoke((Action)(() =>
            //        RichTextBoxConsole.AppendText(String.Format("{0}: {1}" + Environment.NewLine, name, message))
            //    ))
            //);
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                StatusText.Text = "Unable to connect to server: Start server before connecting clients.";
                //No connection: Don't enable Send button or show chat UI
                return;
            }

            //Activate UI
            ButtonSend.Enabled = true;
            TextBoxMessage.Enabled = true;
            TextBoxMessage.Focus();
            //TextBoxUsername.Enabled = false;
            //ButtonConnect.Enabled = false;
            //RichTextBoxConsole.AppendText("Connected to server at " + ServerURI + Environment.NewLine);
            StatusText.Text = "Connected.";
        }


        private void Connection_Closed()
        {
            //Deactivate chat UI; show login UI. 
            this.Invoke((Action)(() => ButtonSend.Enabled = false));
            this.Invoke((Action)(() => StatusText.Text = "You have been disconnected."));
        }

        private void frmGoBackRemarks_Wth_Notification_Load(object sender, EventArgs e)
        {
            UserName = "172.16.0.1:8181";
            if (!String.IsNullOrEmpty(UserName))
            {
                StatusText.Visible = true;
                StatusText.Text = "Connecting to server...";
                ConnectAsync();
            }
        }
    }
}
