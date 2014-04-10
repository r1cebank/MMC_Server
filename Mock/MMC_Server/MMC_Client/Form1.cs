﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using Lidgren.Network;
using SamplesCommon;
using MMC;

namespace MMC_Client
{
    public partial class Form1 : Form
    {
        private static MMCPeer s_server;

        public Form1()
        {
            InitializeComponent();

        }

        private void Output(string text)
        {
            NativeMethods.AppendText(richTextBox1, text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetPeerConfiguration config = new NetPeerConfiguration("MMC");
            config.MaximumConnections = 100;
            config.Port = 39393;
            // Enable DiscoveryResponse messages
            config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);
            config.EnableMessageType(NetIncomingMessageType.DiscoveryRequest);

            MMCPeerConfig pConfig = new MMCPeerConfig(config, PeerType.CHARACTER, "Peer1");

            s_server = new MMCPeer(pConfig);
            Output("listening on " + config.Port.ToString());
            s_server.RegisterCallback(new Action(GotMessage));
            s_server.Start();
        }

        public void GotMessage()
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s_server.Shutdown("bye");
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
