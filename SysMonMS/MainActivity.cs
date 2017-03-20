using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using System.Collections.Generic;

namespace SysMonMS
{
    [Activity(Label = "SysMonMS", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //private Button sp;
        private Button btn_connect;
        private Button btn_cancel;
        private Button btn_gtlist;

        private static IList<SerMod> servlist;
        private TextView tv_status;

        private static Socket cSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] result = new byte[256];
        private Thread cThread = null;

        private Handler cHandler;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            EditText et_ip = FindViewById<EditText>(Resource.Id.et_address);
            EditText et_port = FindViewById<EditText>(Resource.Id.et_port);

            tv_status = FindViewById<TextView>(Resource.Id.tv_status);

            btn_connect = FindViewById<Button>(Resource.Id.btn_connect);
            btn_cancel = FindViewById<Button>(Resource.Id.btn_cancel);
            btn_gtlist = FindViewById<Button>(Resource.Id.btn_list);

            btn_connect.Enabled = true;
            btn_cancel.Enabled = false;
            btn_gtlist.Enabled = false;

            et_ip.Text = "222.222.222.3";
            et_port.Text = "18888";

            cHandler = new ProgressHandler(this);


            btn_connect.Click += (object sender, EventArgs e) =>
            {
                if (StringURL.isEmpty(et_ip.Text) || StringURL.isEmpty(et_port.Text)) //Determine whether the IP address and the port are empty
                {
                    tv_status.Append("Please input IP address and port.\n");
                }
                else if (cSocket != null && cSocket.Connected == true)  //Determine whether the client connects to server
                {
                    tv_status.Append("Already Connected.\n");
                }
                else
                {
                    Init(et_ip.Text, int.Parse(et_port.Text));
                    btn_cancel.Enabled = true;
                    btn_connect.Enabled = false;
                    btn_gtlist.Enabled = true;
                    //sp.Enabled = true;
                    //tv_status.Append("Connection in process.\n");
                }
            };

            btn_cancel.Click += (object sender, EventArgs e) =>
            {
                DisConnection();
                btn_cancel.Enabled = false;
                btn_connect.Enabled = true;
                btn_gtlist.Enabled = false;
                //sp.Enabled = false;
            };

            btn_gtlist.Click += (object sender, EventArgs e) =>
            {
                IList<SerMod> test = new List<SerMod>();
                SerMod t1 = new SerMod("1;1;1;1;1;1;1;1;1;1;1;1;1;1;1;1;1;1;");
                SerMod t2 = new SerMod("2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;");
                SerMod t3 = new SerMod("3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;3;");
                test.Add(t1);
                test.Add(t2);
                test.Add(t3);
                servlist = test;

                string msg = "";
                foreach (SerMod ele in test) { msg += (ele.ToStringExt() + "/"); }
                Intent result = new Intent();
                result.SetClass(this, typeof(ServActivity));
                result.PutExtra("servlist", msg);
                StartActivity(result);
            };
        }

        private void UpdateMsg(string msg)
        {
            TextView tv_status = FindViewById<TextView>(Resource.Id.tv_status);
            tv_status.Append("\n" + msg);
        }
    

        public void Init(string addr, int port)
        {
            //设定服务器IP地址
            IPAddress ip = IPAddress.Parse(addr);
            try
            {
                cSocket.Connect(new IPEndPoint(ip, port));
                UpdateMsg("succed");
                SendMessage("GetServerList");
            }
            catch
            {
                UpdateMsg("error");
                return;
            }

            cThread = new Thread(ReceiveMessage);
            cThread.Start();

        }

        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    int receiveNumber = cSocket.Receive(result);
                    int tmp = (result[3] | result[2] << 8 | result[1] << 16 | result[0] << 24);

                    Message msg = new Message();
                    if (tmp == 1)  msg.What = 0x1;
                    else msg.What = 0x0;
                    cHandler.SendMessage(msg);
                }
                catch (Exception ex)
                {
                    //showmsg(ex.Message);
                    cSocket.Shutdown(SocketShutdown.Both);
                    cSocket.Close();
                    break;
                }
            }
        }
        public void SendMessage(string message)
        {
            string sendMessage = message;
            cSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
        }

        public void DisConnection()   //disconnection
        {
            if (cSocket.Connected == true)
            {
                //cSocket.Shutdown(SocketShutdown.Both);
                //cSocket.Close();
                UpdateMsg("Disconnected.");
            }
            else
            {
                UpdateMsg("No connection existed.");
            }
        }
        private class ProgressHandler : Handler
        {
            private MainActivity samples;

            public ProgressHandler(MainActivity samples)
            {
                this.samples = samples;
            }

            public override void HandleMessage(Message msg)
            {
                base.HandleMessage(msg);

                if (msg.What == 0x1)
                {
                    samples.tv_status.Append("12345");
                }
                else
                {
                    samples.tv_status.Append("67890");
                }
            }
        }
    }
}

