using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus_Server_Form
{
    public partial class Form1 : Form
    {
        private Server server;

        public Form1()
        {
            InitializeComponent();
            lb_bilgiler.HorizontalScrollbar = true;
        }

        private void btn_SunucuAc_Click(object sender, EventArgs e)
        {
            if (server == null)
            {
                server = new Server(53447, AddEvent, AddClientToList, RemoveClientFromList, AddMessage);
                server.Start();
                btn_SunucuAc.Text = "Sunucuyu Kapat";
                pb_sDurum.BackColor = Color.Green;
                lbl_durum.Text = "Sunucu Şuan Açık";
            }
            else
            {
                server.Stop();
                server = null;
                btn_SunucuAc.Text = "Sunucuyu Başlat";
                pb_sDurum.BackColor = Color.Red;
                lbl_durum.Text = "Sunucu Şuan Kapalı";
            }
        }

        private void AddEvent(string eventMessage)
        {
            if (lb_bilgiler.InvokeRequired)
            {
                lb_bilgiler.Invoke(new MethodInvoker(delegate {
                    lb_bilgiler.Items.Add(eventMessage);
                }));
            }
            else
            {
                lb_bilgiler.Items.Add(eventMessage);
            }
        }

        private void AddClientToList(TcpClient client)
        {
            if (lb_kullanıcılar.InvokeRequired)
            {
                lb_kullanıcılar.Invoke(new MethodInvoker(delegate { lb_kullanıcılar.Items.Add(client.Client.RemoteEndPoint.ToString()); }));
            }
            else
            {
                lb_kullanıcılar.Items.Add(client.Client.RemoteEndPoint.ToString());
            }
        }

        private void RemoveClientFromList(TcpClient client)
        {
            if (lb_kullanıcılar.InvokeRequired)
            {
                lb_kullanıcılar.Invoke(new MethodInvoker(delegate { lb_kullanıcılar.Items.Remove(client.Client.RemoteEndPoint.ToString()); }));
            }
            else
            {
                lb_kullanıcılar.Items.Remove(client.Client.RemoteEndPoint.ToString());
            }
        }

        private void AddMessage(string message)
        {
            if (lb_chat.InvokeRequired)
            {
                lb_chat.Invoke(new MethodInvoker(delegate { lb_chat.Items.Add(message); }));
            }
            else
            {
                lb_chat.Items.Add(message);
            }
        }
    }
}
