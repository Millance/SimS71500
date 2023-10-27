using S7.Net;
using static SimS71500Form.PlcController;
using static SimS71500Form.Responses;

namespace SimS71500Form
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] cpuTypes = Enum.GetNames(typeof(CpuType));
            foreach (var item in cpuTypes)
            {
                cmbPLcType.Items.Add(item);
            }
            string[] dataTypes = Enum.GetNames(typeof(DataType));
            foreach (var item in dataTypes)
            {
                cmbDataType.Items.Add(item);
            }
            string[] varTypes = Enum.GetNames(typeof(VarType));
            foreach (var item in varTypes)
            {
                cmbVarType.Items.Add(item);
            }
        }

        private void btnConnPlc_Click(object sender, EventArgs e)
        {
            try
            {
                MyPlc.Connect(
                      (CpuType)Enum.Parse(typeof(CpuType), cmbPLcType.Text),
                      txtPlcIp.Text,
                      Convert.ToInt16(cmbPlcRack.Text),
                      Convert.ToInt16(cmbPlcSlot.Text)
                      );
                if (MyPlc.IsConnected)
                {
                    txtConnLog.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}  连接成功！\r\n");
                }
            }
            catch (Exception ex)
            {
                // 处理读取错误
                txtConnLog.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}  {ex.Message}\r\n");
            }
        }

        private void btnDisConnPlc_Click(object sender, EventArgs e)
        {

            try
            {
                MyPlc.Disconnect();
                if (MyPlc.IsConnected == false)
                {
                    txtConnLog.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}  断开成功！\r\n");
                }
            }
            catch (Exception ex)
            {
                // 处理读取错误
                txtConnLog.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}  {ex.Message}\r\n");
            }
        }

        private void btnReadPlc_Click(object sender, EventArgs e)
        {
            ReadResponce responce = MyPlc.ReadVariable(
                 (DataType)Enum.Parse(typeof(DataType), cmbDataType.Text),
                 Convert.ToInt16(numDbArea.Value),
                 Convert.ToInt16(numStartByteAdr.Value),
                 (VarType)Enum.Parse(typeof(VarType), cmbVarType.Text),
                 Convert.ToInt16(numVarCount.Value),
                 Convert.ToByte(numBitAdr.Value)
                );
            if (responce == null)
            {
                txtReadWriteLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  读取失败！\r\n");
            }
            else if (responce.IsSuccess == false)
            {
                txtReadWriteLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  读取失败！{responce.ReaponceMsg}\r\n");
            }
            else
            {
                txtReadWriteLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  {responce.Data}\r\n");
            }

        }

        private void btnWritePlc_Click(object sender, EventArgs e)
        {
            WriteResponce responce = MyPlc.WriteVariable(
                (DataType)Enum.Parse(typeof(DataType), cmbDataType.Text),
                Convert.ToInt16(numDbArea.Value),
                Convert.ToInt16(numStartByteAdr.Value),
                (VarType)Enum.Parse(typeof(VarType), cmbVarType.Text),
                txtInputData.Text,
                Convert.ToByte(numBitAdr.Value)
                );
            if (responce == null)
            {
                txtReadWriteLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  写入失败！\r\n");
            }
            else if (responce.IsSuccess == false)
            {
                txtReadWriteLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  写入失败！{responce.ReaponceMsg}\r\n");
            }
            else
            {
                txtReadWriteLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  写入成功！\r\n");
            }
        }

        Motor motor;
        private void btnCreateMotor_Click(object sender, EventArgs e)
        {
            motor = new Motor("电机001", 2);
        }
        private void btnReadMotor_Click(object sender, EventArgs e)
        {
            if (motor != null)
            {
                ReadResponce responce = motor.Read();

                if (responce == null)
                {
                    txtDeviceLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  {motor.Name}读取失败！\r\n");
                }
                else if (responce.IsSuccess == false)
                {
                    txtDeviceLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  {motor.Name}读取失败！{responce.ReaponceMsg}\r\n");
                }
                else
                {
                    if (motor.CurrentStatus == 0)
                    {
                        ledMotorState.StatusColor = Color.Gray;
                    }
                    else if (motor.CurrentStatus == 1)
                    {
                        ledMotorState.StatusColor = Color.LimeGreen;
                    }
                    else
                    {
                        ledMotorState.StatusColor = Color.Red;
                    }
                }
            }
            else
            {
                txtDeviceLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  电机未创建！\r\n");
            }
        }

        MobileDevice mobileDevice;
        private void btnCreateMobile_Click(object sender, EventArgs e)
        {
            mobileDevice = new MobileDevice("一维移动设备001", 2);
        }

        private void btnReadMobile_Click(object sender, EventArgs e)
        {
            if (mobileDevice != null)
            {
                ReadResponce responce = mobileDevice.Read();

                if (responce == null)
                {
                    txtDeviceLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  {mobileDevice.Name}读取失败！\r\n");
                }
                else if (responce.IsSuccess == false)
                {
                    txtDeviceLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  {mobileDevice.Name}读取失败！{responce.ReaponceMsg}\r\n");
                }
                else
                {
                    if (mobileDevice.CurrentStatus == 0)
                    {
                        ledMobileDeviceState.StatusColor = Color.Gray;
                    }
                    else if (mobileDevice.CurrentStatus == 1)
                    {
                        ledMobileDeviceState.StatusColor = Color.LimeGreen;
                    }
                    else
                    {
                        ledMobileDeviceState.StatusColor = Color.Red;
                    }
                }
            }
            else
            {
                txtDeviceLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  移动设备未创建！\r\n");
            }
        }

        bool bAutoReadMotor = false;
        bool bAutoReadMobile = false;

        private void timerReadWrite_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int data = now.Second % 3;
            if (bAutoReadMotor && motor != null)
            {
                btnReadMotor_Click(null, null);
                motor.Write((short)data);
            }
            if (bAutoReadMobile)
            {
                btnReadMobile_Click(null, null);
                data = 3 - data;
                mobileDevice.Write((short)data);
            }
        }

        private void btnAutoReadMotor_Click(object sender, EventArgs e)
        {
            bAutoReadMotor = !bAutoReadMotor;
        }

        private void btnAutoReadMobile_Click(object sender, EventArgs e)
        {
            bAutoReadMobile = !bAutoReadMobile;
        }
    }
}