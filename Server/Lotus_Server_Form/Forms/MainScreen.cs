using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using Server.StaticVariables;

namespace Lotus_Server_Form.Forms
{
    public partial class MainScreen : Form
    {
        private Server.Server server;
        public MainScreen()
        {
            InitializeComponent();
            lb_bilgiler.HorizontalScrollbar = true;
        }
        private void btn_SunucuAc_Click(object sender, EventArgs e)
        {
            if (server == null)
            {
                server = new Server.Server(53447, AddClientToList, RemoveClientFromList);
                server.Start();

                btn_SunucuAc.Text = "Sunucuyu Kapat";
                pb_sDurum.BackColor = Color.Green;
                lbl_durum.Text = "Sunucu Şuan Açık";
            }
            else
            {
                foreach (var item in StaticVariables.Clients)
                {
                    item.Dispose();
                }
                server.Stop();
                server = null;
                btn_SunucuAc.Text = "Sunucuyu Başlat";
                pb_sDurum.BackColor = Color.Red;
                lbl_durum.Text = "Sunucu Şuan Kapalı";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LogLayer1 logLayer1 = new LogLayer1();
            LogLayer2 logLayer2 = new LogLayer2();
            LogLayer3 logLayer3 = new LogLayer3();
            logLayer1.Show();
            logLayer2.Show();
            logLayer3.Show();
        }
    }
}
