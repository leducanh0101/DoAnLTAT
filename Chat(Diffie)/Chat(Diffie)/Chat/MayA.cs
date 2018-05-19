using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace A
{
    public partial class MayA : Form
    {
        private int sec = 0;
        byte[] dataTextNhan, dataTextGui,publicKeyA,nhanPublicKey,_a;
        Socket client;

        IPEndPoint ipep = new IPEndPoint(IPAddress.Loopback, 1234);
        IPEndPoint ipc = new IPEndPoint(IPAddress.Loopback, 9050);
        EndPoint ep;
        AES aes256 = new AES();
        private string dateTimeIV;
        Thread thr = null;
        DiffieHellmanA hellman = new DiffieHellmanA();
        public MayA()
        {
            InitializeComponent();
        }

        private void MayA_Load(object sender, EventArgs e)
        {
            
            txtAEncrypt.Enabled = false;
            txtAKey.Enabled = false;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.BeginConnect(ipep, new AsyncCallback(Connected), client);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        
        }
        private void Connected(IAsyncResult i)
        {
            client = ((Socket)i.AsyncState);
            client.EndConnect(i);

            thr = new Thread(new ThreadStart(nhanDuLieu));
            thr.Start();
        }
        void nhanDuLieu()
        {
            while (true)
            {
                if (client.Poll(1000000, SelectMode.SelectRead))
                {

                    dataTextNhan = new byte[1024 * 24];
                    client.BeginReceive(dataTextNhan, 0, dataTextNhan.Length, SocketFlags.None, new AsyncCallback(ReceivedData), client);
               }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sec = sec + 1;
            if (sec == 15)
            {
                MessageBox.Show("Time Out. Change Key!!!");
                string a = Convert.ToBase64String(_a);
                txtAKey.Text = a.Substring(0, 32);
                timer1.Stop();
                sec = 0;
                KhoiTaoTimer();
            }
        }
        public void KhoiTaoTimer()
        {

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();

        }
        private void btnASend_Click(object sender, EventArgs e)
        {
            try
            {

                dateTimeIV = DateTime.Now.ToString();

                //Tạo public key
                publicKeyA = hellman.generatePublicKey();
                string publicKey = Convert.ToBase64String(publicKeyA);
                //Tạo secret key
                byte[] secretKeyA = hellman.secretKey(nhanPublicKey);
                if (txtAKey.Text == "")
                {
                    string a1 = Convert.ToBase64String(_a);
                    txtAKey.Text = a1.Substring(0, 32);
                }
                dataTextGui = new byte[1024 * 24];
                string encryptText = Encrypted(txtAMess.Text, txtAKey.Text, dateTimeIV);
                string strTextMD5 = MD5.maHoaMd5(encryptText);
                txtAEncrypt.Text = encryptText;
                richTextBox1.Text += "\nA: " + txtAMess.Text;
                txtAMess.Clear();

                string finalText = encryptText + ";" + dateTimeIV + ";" + strTextMD5+";"+publicKey;
                dataTextGui = Encoding.UTF8.GetBytes(finalText);

                client.BeginSend(dataTextGui, 0, dataTextGui.Length, SocketFlags.None, new AsyncCallback(SendData), client);
               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static string PhatSinhNgauNhienKyTu()
        {
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            Random r = new Random();
            int i = r.Next(chars.Length);
            return chars[i].ToString();
        }
        private void SendData(IAsyncResult i)
        {
            client = (Socket)i.AsyncState;
            int sent = client.EndSend(i);

        }
        private void ReceivedData(IAsyncResult i)
        {
            client = (Socket)i.AsyncState;
            int recv = client.EndReceive(i);
            string s = Encoding.ASCII.GetString(dataTextNhan, 0, recv);
            string[] arrString = s.Split(';');
            string encryptText = arrString[0];
            string iv = arrString[1];
            string md5EncryptText = arrString[2];
            string publicKey = arrString[3];
            string a = arrString[4];
           
            nhanPublicKey = Convert.FromBase64String(publicKey);
            _a = Convert.FromBase64String(a);
            
            string hashEncryptedText = MD5.maHoaMd5(encryptText);
            if (md5EncryptText == hashEncryptedText)
            {
                string rawText = Decrypt(encryptText, iv);
                richTextBox1.Invoke((MethodInvoker)delegate ()
                {
                    richTextBox1.Text += "\nB: " + rawText;
                });
            }
            else
            {
                richTextBox1.Invoke((MethodInvoker)delegate ()
                {
                    richTextBox1.Text += "\n Nội dung bên B đã bị thay đổi !";
                });
            }
        }



        private void btnSendNoise_Click(object sender, EventArgs e)
        {
            try
            {

                dateTimeIV = DateTime.Now.ToString();
                publicKeyA = hellman.generatePublicKey();
                string publicKey = Convert.ToBase64String(publicKeyA);
                byte[] secretKeyA = hellman.secretKey(nhanPublicKey);
                if (txtAKey.Text == "")
                {
                    string a1 = Convert.ToBase64String(_a);
                    txtAKey.Text = a1.Substring(0, 32);
                }
                dataTextGui = new byte[1024 * 24];
                string encryptText = Encrypted(txtAMess.Text, txtAKey.Text, dateTimeIV);

                string a = encryptText;
                int length = encryptText.Length;
                Random r = new Random();
                int randomPos = r.Next(0, length + 1);
                string stringDauDenPos = a.Substring(0, randomPos);
                string veKyTuCuoi = a.Substring(randomPos);
                string textChanged = stringDauDenPos + PhatSinhNgauNhienKyTu() + veKyTuCuoi;


                string md5EncryptText = MD5.maHoaMd5(textChanged);
                txtAEncrypt.Text = encryptText;
                richTextBox1.Text += "\nA: " + txtAMess.Text;
                txtAMess.Clear();

                string finalText = encryptText + ";" + dateTimeIV + ";" + md5EncryptText+";"+publicKey;
                dataTextGui = Encoding.UTF8.GetBytes(finalText);
                client.BeginSend(dataTextGui, 0, dataTextGui.Length, SocketFlags.None, new AsyncCallback(SendData), client);
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
            timer1.Stop();
            sec = 0;
            KhoiTaoTimer();
        }

        private void txtAKey_TextChanged(object sender, EventArgs e)
        {

        }

        public string Decrypt(string textMaHoa, string Time)
        {
            string encryptedText = textMaHoa;
            string key = txtAKey.Text;
            string rawText = aes256.Decrypt(key, encryptedText, Time);
            return rawText;
        }

        private void MayA_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            Application.Exit();
        }

        private void txtAEncrypt_TextChanged(object sender, EventArgs e)
        {

        }

        public string Encrypted(string rawText, string rawKey, string iv)
        {
            string rawString = rawText;
            string key = rawKey;
            string encryptedText = aes256.Encrypt(key, rawText, iv);
            return encryptedText;
        }




    }
}
