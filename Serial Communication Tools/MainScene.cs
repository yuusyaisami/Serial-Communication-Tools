using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using SaveSystem;
using System.Runtime.InteropServices;

namespace Serial_Communication_Tools
{
    public partial class MainScene : UserControl
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey); //キー入力の状態を取得するための関数
        ListViewItem TextBoxItem = new ListViewItem();
        public MainScene()
        {
            InitializeComponent();
            string[] PortList = SerialPort.GetPortNames();
            SendType_CombBox.SelectedIndex = 0;
            FormatCombo.SelectedIndex = 0;
            // 使用できるシリアルポート名をコンボボックスの選択肢に追加
            SerialPortNames.Items.Clear();
            foreach (string PortName in PortList)
            {
                SerialPortNames.Items.Add(PortName);
            }
            if (SerialPortNames.Items.Count > 0)
            {
                SerialPortNames.SelectedIndex = 0;
            }
        }

        private void ConnectText_Click(object sender, EventArgs e)
        {
            ConnectSerialPort();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReloadText_Click(object sender, EventArgs e)
        {
            string[] PortList = SerialPort.GetPortNames();
            SerialPortNames.Items.Clear();
            foreach (string PortName in PortList)
            {
                SerialPortNames.Items.Add(PortName);
            }
            if (SerialPortNames.Items.Count > 0)
            {
                SerialPortNames.SelectedIndex = 0;
            }
        }

        private void SerialPortNames_MouseEnter(object sender, EventArgs e)
        {
            string[] PortList = SerialPort.GetPortNames();
            SerialPortNames.Items.Clear();
            foreach (string PortName in PortList)
            {
                SerialPortNames.Items.Add(PortName);
            }
            if (SerialPortNames.Items.Count > 0)
            {
                SerialPortNames.SelectedIndex = 0;
            }
        }
        private void ConnectSerialPort()
        {
            if (SerialPort1.IsOpen == true)
            {
                SerialPort1.Close();
                return;
            }
            else
            {
                try
                {
                    // シリアルポートに接続する
                    SerialPort1.PortName = SerialPortNames.SelectedItem.ToString(); // Comboボックスで選択したシリアルポート番号をポート名に設定
                    SerialPort1.BaudRate = 9600; // ボーレートを設定
                    SerialPort1.DataBits = 8; // データビットを設定
                    SerialPort1.Parity = Parity.None; // パリティビットを設定
                    SerialPort1.StopBits = StopBits.One; // ストップビットを設定
                    SerialPort1.Handshake = Handshake.None; // フロー制御を設定
                    SerialPort1.Encoding = Encoding.ASCII; // 文字コードを設定
                    SerialPort1.WriteTimeout = 50000;
                    SerialPort1.ReadTimeout = 100000;
                    SerialPort1.Open();
                    NowPortNameText.Visible = true;
                    NowPortNameText.Text = "SerialPortName : " + SerialPortNames.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("エラーが発生しました: " + ex.Message);
                }
            }
        }
       

        private void SerialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            SerialPort1.Close();
            NowPortNameText.Visible = false;
            NowPortNameText.Text = "";
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (SerialPort1.IsOpen == true)
            {
                string Type = SendType_CombBox.SelectedItem.ToString();
                Send(SerialPortSend.Text, Type);
            }
        }
        public void Send(string data, string data_type)
        {
            if (SerialPort1.IsOpen == false) return;  //ポートが閉じている場合は戻す
            try
            {
                switch (data_type) {
                    case "Int":
                        int dataInt;
                        if (int.TryParse(data, out dataInt))
                        {
                            int.TryParse(data, out dataInt);
                            Convert.ToInt32(dataInt);
                            byte[] dataByte = BitConverter.GetBytes(dataInt);
                            SerialPort1.Write(dataByte, 0, data.Length);  //データ書き込み
                            TextBoxItem = new ListViewItem(" > " + dataInt);
                            ListView1.Items.Add(TextBoxItem);
                        }
                        break;

                    case "String":
                        SerialPort1.WriteLine(data);  //データ書き込み
                        TextBoxItem = new ListViewItem(" > " + data);
                        ListView1.Items.Add(TextBoxItem);
                        break;

                }
            }
            catch (Exception ex)
            {
                //PlaySound("SoundFile/Erroron.wav");
                Debug.WriteLine("エラーが発生しました: " + ex.Message);
            }
        }

        private void ClearText_Click(object sender, EventArgs e)
        {
            SerialPort1.Close();
            NowPortNameText.Visible = false;
            NowPortNameText.Text = "";
        }

        public void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // データの受信処理を行う
            Read = SerialPort1.ReadExisting(); // 受信したデータを取得
            // 受信したデータを処理するなどの必要な処理を行う
        }
        public string namedete, Use;

        

        public string Read
        {
            set
            {
                namedete = value;
                DebugText.Text = namedete;
            }
            get 
            { 
                return namedete; 
            }
        }
        //クレイジーコードズ
        string olddata,data;

        private void ControllerVisible_CheckedChanged(object sender, EventArgs e)
        {
            if(ControllerVisible.Checked)
                MainFunction.Enabled = true;
            else
                MainFunction.Enabled = false;
        }

        private void MainFunction_Tick(object sender, EventArgs e)
        {
            if ((GetAsyncKeyState((int)ConsoleKey.W) & 0x8000) != 0)
            {
                data = WkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.A) & 0x8000) != 0)
            {
                data = AkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.S) & 0x8000) != 0)
            {
                data = SkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D) & 0x8000) != 0)
            {
                data = DkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.E) & 0x8000) != 0)
            {
                data = EkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.Q) & 0x8000) != 0)
            {
                data = QkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.Z) & 0x8000) != 0)
            {
                data = ZkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.X) & 0x8000) != 0)
            {
                data = XkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.C) & 0x8000) != 0)
            {
                data = CkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.V) & 0x8000) != 0)
            {
                data = VkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F) & 0x8000) != 0)
            {
                data = FkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.R) & 0x8000) != 0)
            {
                data = RkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.T) & 0x8000) != 0)
            {
                data = TkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.G) & 0x8000) != 0)
            {
                data = GkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.B) & 0x8000) != 0)
            {
                data = BkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.Y) & 0x8000) != 0)
            {
                data = YkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.H) & 0x8000) != 0)
            {
                data = HkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.N) & 0x8000) != 0)
            {
                data = NkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.U) & 0x8000) != 0)
            {
                data = UkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.J) & 0x8000) != 0)
            {
                data = JkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.M) & 0x8000) != 0)
            {
                data = MkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.I) & 0x8000) != 0)
            {
                data = IkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.K) & 0x8000) != 0)
            {
                data = KkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.O) & 0x8000) != 0)
            {
                data = OkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.L) & 0x8000) != 0)
            {
                data = LkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.P) & 0x8000) != 0)
            {
                data = PkeyB.Text;
            }

            else if ((GetAsyncKeyState((int)ConsoleKey.UpArrow) & 0x8000) != 0)
            {
                data = UpkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.LeftArrow) & 0x8000) != 0)
            {
                data = LeftkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.DownArrow) & 0x8000) != 0)
            {
                data = DownkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.RightArrow) & 0x8000) != 0)
            {
                data = RightkeyB.Text;
            }

            else if ((GetAsyncKeyState((int)ConsoleKey.D1) & 0x8000) != 0)
            {
                data = Number1keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D2) & 0x8000) != 0)
            {
                data = Number2keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D3) & 0x8000) != 0)
            {
                data = Number3keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D4) & 0x8000) != 0)
            {
                data = Number4keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D5) & 0x8000) != 0)
            {
                data = Number5keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D6) & 0x8000) != 0)
            {
                data = Number6keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D7) & 0x8000) != 0)
            {
                data = Number7keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D8) & 0x8000) != 0)
            {
                data = Number8keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D9) & 0x8000) != 0)
            {
                data = Number9keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.D0) & 0x8000) != 0)
            {
                data = Number0keyB.Text;
            }

            else if ((GetAsyncKeyState((int)ConsoleKey.F1) & 0x8000) != 0)
            {
                data = F1keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F2) & 0x8000) != 0)
            {
                data = F2keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F3) & 0x8000) != 0)
            {
                data = F3keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F4) & 0x8000) != 0)
            {
                data = F4keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F5) & 0x8000) != 0)
            {
                data = F5keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F6) & 0x8000) != 0)
            {
                data = F6keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F7) & 0x8000) != 0)
            {
                data = F7keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F8) & 0x8000) != 0)
            {
                data = F8keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F9) & 0x8000) != 0)
            {
                data = F9keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F10) & 0x8000) != 0)
            {
                data = F10keyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.F11) & 0x8000) != 0)
            {
                data = F11keyB.Text;
            }

            else if ((GetAsyncKeyState((int)ConsoleKey.Tab) & 0x8000) != 0)
            {
                data = TabkeyB.Text;
            }
            else if ((GetAsyncKeyState(0xA0) & 0x8000) != 0)
            {
                data = LShiftkeyB.Text;
            }
            else if ((GetAsyncKeyState(0xA1) & 0x8000) != 0)
            {
                data = RShiftkeyB.Text;
            }
            else if ((GetAsyncKeyState(0xA4) & 0x8000) != 0)
            {
                data = AltkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.Spacebar) & 0x8000) != 0)
            {
                data = SpacekeyB.Text;
            }
            else if ((GetAsyncKeyState(0xA2) & 0x8000) != 0)
            {
                data = CtrlkeyB.Text;
            }
            else if ((GetAsyncKeyState((int)ConsoleKey.Backspace) & 0x8000) != 0)
            {
                data = BackSpacekeyB.Text;
            }
            else if ((GetAsyncKeyState(0x14) & 0x8000) != 0)
            {
                data = CapskeyB.Text;
            }
            else
            {
                data = "";
            }
            if(data != olddata)
            {
                olddata = data;
                string Type = FormatCombo.SelectedItem.ToString();
                if (data != "" && Type != null)
                {
                    Send(data, Type);
                }
            }
        }
    }
}
