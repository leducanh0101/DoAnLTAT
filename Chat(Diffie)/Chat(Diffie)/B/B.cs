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


namespace B
{
    public partial class frmB : Form
    {
        private int sec = 0;
        AES aes256 = new AES();
        private string dateTimeIV;
        Socket client1;
        Socket client2;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1234);
        IPEndPoint ipc = new IPEndPoint(IPAddress.Loopback,1234);
        byte[] dataTextNhan, dataTextGui,nhanPublicKey,secretKeyB,publicKeyB;
        Thread thr = null;
        DiffieHellmanB hellman = new DiffieHellmanB();
        public frmB()
        {
            InitializeComponent();
        }

        private void btnBSend_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimeIV = DateTime.Now.ToString();

                publicKeyB = hellman.generatePublicKey();//gen key ra public
                string _publicKey = Convert.ToBase64String(publicKeyB);//byte to string, from thì ngược lại.

                nhanPublicKey = publicKeyB;
               
                secretKeyB = hellman.secretKey(nhanPublicKey);//tạo ra secret key nhưng phải cần public key
                string _a = Convert.ToBase64String(secretKeyB);

                if (txtBKey.Text == "")
                {
                    string a1 = Convert.ToBase64String(secretKeyB);
                    txtBKey.Text = a1.Substring(0, 32);//cắt cho đủ 32byte,luôn phải cắt 
                }
                dataTextGui = new byte[1024 * 24];
                string encryptText = Encrypted(txtBMess.Text, txtBKey.Text, dateTimeIV);//cần key với iv để mã hóa text
                string md5EncryptText = MD5.maHoaMd5(encryptText);//mã hóa encrypttext (so sánh gói tin bị thay đổi)
                txtBEncrypt.Text = encryptText;

                richTextBox1.Text += "\nB: " + txtBMess.Text;
                txtBMess.Clear();

                string finalText = encryptText + ";" + dateTimeIV + ";" + md5EncryptText+";"+_publicKey+";"+_a;//cái cuối cùng để send
                dataTextGui = Encoding.UTF8.GetBytes(finalText);

                client2.BeginSend(dataTextGui, 0, dataTextGui.Length, SocketFlags.None, new AsyncCallback(SendData), client2);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendNoise_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimeIV = DateTime.Now.ToString();
                publicKeyB = hellman.generatePublicKey();
                string _publicKey = Convert.ToBase64String(publicKeyB);

                nhanPublicKey = publicKeyB;

                secretKeyB = hellman.secretKey(nhanPublicKey);
                string _a = Convert.ToBase64String(secretKeyB);
                if (txtBKey.Text == "")
                {
                    string a1 = Convert.ToBase64String(secretKeyB);
                    txtBKey.Text = a1.Substring(0, 32);
                }
                dataTextGui = new byte[1024 * 24];
                string encryptText = Encrypted(txtBMess.Text, txtBKey.Text, dateTimeIV);
                string a = encryptText;
                int length = encryptText.Length;
                Random r = new Random();
                int randomPos = r.Next(0, length + 1);
                string stringDauDenPos = a.Substring(0, randomPos);
                string veKyTuCuoi = a.Substring(randomPos);
                string textChanged = stringDauDenPos + PhatSinhNgauNhienKyTu() + veKyTuCuoi;


                string md5EncryptText = MD5.maHoaMd5(textChanged);
                txtBEncrypt.Text = encryptText;

                richTextBox1.Text += "\nB: " + txtBMess.Text;
                txtBMess.Clear();

                string finalText = encryptText + ";" + dateTimeIV + ";" + md5EncryptText + ";" + _publicKey + ";" + _a;
                dataTextGui = Encoding.UTF8.GetBytes(finalText);


                client2.BeginSend(dataTextGui, 0, dataTextGui.Length, SocketFlags.None, new AsyncCallback(SendData), client2);
                
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

        private void frmB_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public string Encrypted(string rawText,string rawKey,string iv)
        {
            string rawString = rawText;
            string key = rawKey;
            string encryptedText = aes256.Encrypt(key, rawText, iv);
            return encryptedText;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec = sec + 1;
            if (sec == 15)
            {
                MessageBox.Show("Time Out. Change Key!!!");
                string b= Convert.ToBase64String(secretKeyB) ;
                txtBKey.Text = b.Substring(0,32);
                    
                
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

        public string Decrypt(string textMaHoa, string Time)
        {
            string encryptedText = textMaHoa;
            string key = txtBKey.Text;
            string rawText = aes256.Decrypt(key, encryptedText, Time);
            return rawText;
        }
        private void frmB_Load(object sender, EventArgs e)
        {
            txtBEncrypt.Enabled = false;
            txtBKey.Enabled = false;
            client1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client1.Bind(ipep);
            client1.Listen(4);
            client1.BeginAccept(new AsyncCallback(CallAccept), client1);
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)// restart lại bộ đếm khi text trong richBox thay đổi.
        {
            timer1.Stop();
            sec = 0;
            KhoiTaoTimer();
        }
        void nhanDuLieu()
        {
            while (true)
            {
                if (client2.Poll(1000000, SelectMode.SelectRead))
                {
                    dataTextNhan = new byte[1024 * 24];
                    client2.BeginReceive(dataTextNhan, 0, dataTextNhan.Length, SocketFlags.None, new AsyncCallback(ReceiveData), client2);
                }
            }
        }
        private void CallAccept(IAsyncResult i)//goi ket noi
        {
            client2 = ((Socket)i.AsyncState).EndAccept(i);
            thr = new Thread(new ThreadStart(nhanDuLieu));
            thr.Start();
        }
        private void SendData(IAsyncResult i)
        {
            client2 = (Socket)i.AsyncState;
            int sent = client2.EndSend(i);
        }

        private void txtBEncrypt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReceiveData(IAsyncResult i)
        {
            client2 = (Socket)i.AsyncState;
            int recv = client2.EndReceive(i);

            string s = Encoding.ASCII.GetString(dataTextNhan, 0, recv);
            string[] arrString = s.Split(';');//tach chuoi theo dau ;
            string encryptText = arrString[0]; //bo encrypttext vao vi tri 0 cua array
            string iv = arrString[1];//bo iv vao vi tri 1 cua array
            string md5EncryptText = arrString[2];//tuong tu 2 cai tren
            string publicKey = arrString[3];
            nhanPublicKey = Convert.FromBase64String(publicKey);
            byte[] secretKeyB = hellman.secretKey(nhanPublicKey);
            string hashEncryptedText = MD5.maHoaMd5(encryptText);
            if (md5EncryptText == hashEncryptedText)
            {
                string rawText = Decrypt(encryptText, iv);
                richTextBox1.Invoke((MethodInvoker)delegate ()
                {
                    richTextBox1.Text += "\nA: " + rawText;
                });
            }
            else
            {
                richTextBox1.Invoke((MethodInvoker)delegate()
                {
                    richTextBox1.Text += "\n Nội dung bên A đã bị thay đổi !";
                });
            }
        }
        
    }
 
}
