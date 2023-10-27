using S7.Net;

namespace SimS71500
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plc plc = new Plc(CpuType.S71500, "192.168.0.100", 0, 1);
            plc.Open();

            // 接收键入的值
            string inputKey = "";

            int dbArea = 2;
            Motor motor = new Motor("电机001", plc, dbArea);
            MobileDevice mobileDevice = new MobileDevice("一维移动设备001", plc, dbArea);

            // 使用 AutoResetEvent 进行任务协调
            AutoResetEvent readComplete = new AutoResetEvent(false);
            AutoResetEvent writeComplete = new AutoResetEvent(true);
            bool needReadLock = false; // 控制是否需要读锁

            Task readPLCTask = Task.Factory.StartNew(() =>
            {
                while (plc.IsConnected && inputKey != "q")
                {
                    Console.Clear();
                    motor.ReadValues();
                    Console.WriteLine($"*********************{motor.Name}*********************");
                    Console.WriteLine($"{motor.TaskNumber} - {motor.TaskStatus} - {motor.CurrentStatus} - {motor.MotorForward} - {motor.MotorReverse} - {motor.FaultCode}");
                    mobileDevice.ReadValues();
                    Console.WriteLine($"****************{mobileDevice.Name}******************");
                    Console.WriteLine($"{mobileDevice.TaskNumber} - {mobileDevice.TaskStatus} - {mobileDevice.StartPosition} - {mobileDevice.EndPosition} - {mobileDevice.CurrentStatus} - {mobileDevice.CurrentCoordinate} - {mobileDevice.FaultCode}");
                    Task.Delay(200).Wait();

                    if (needReadLock)
                    {
                        writeComplete.Set(); // 通知写任务可以执行
                        readComplete.WaitOne(); // 等待写任务完成
                    }
                }
            });

            bool boolFlag = false;
            short iCount = 1;
            Task writePLCTask = Task.Factory.StartNew(() =>
            {
                while (plc.IsConnected && inputKey != "q")
                {
                    if (!needReadLock)
                    {
                        writeComplete.WaitOne(); // 等待读任务完成
                        needReadLock = true; // 设置需要读锁
                    }
                    iCount++;
                    motor.WriteValues((uint)(iCount + 1), (short)(iCount + 2), (short)(iCount + 3), boolFlag, !boolFlag, (short)(iCount + 4));
                    mobileDevice.WriteValues((uint)(iCount + 5), (short)(iCount + 6), (uint)(iCount + 7), (uint)(iCount + 8), (short)(iCount + 9), (short)(iCount + 10), (short)(iCount + 11));
                    boolFlag = !boolFlag;
                    needReadLock = false; // 取消读锁
                    readComplete.Set(); // 通知读任务可以执行
                    Task.Delay(2000).Wait();
                }
            });

            inputKey = Console.ReadLine();

            plc.Close();
            Task.WaitAll(readPLCTask, writePLCTask);
        }

        internal class Motor
        {
            private Plc plc;
            private int dbArea;

            public Motor(string name, Plc plc, int dbArea)
            {
                this.Name = name;
                this.plc = plc;
                this.dbArea = dbArea;
            }

            // 字段属性
            public string Name { get; private set; }
            public uint TaskNumber { get; private set; }      // 任务号
            public short TaskStatus { get; private set; }     // 任务状态
            public short CurrentStatus { get; private set; }  // 当前状态
            public bool MotorForward { get; private set; }   // 电机正转
            public bool MotorReverse { get; private set; }   // 电机反转
            public short FaultCode { get; private set; }     // 故障码

            // 读取PLC数据
            public void ReadValues()
            {
                TaskNumber = (uint)plc.Read(DataType.DataBlock, dbArea, 0, VarType.DWord, 1);
                TaskStatus = (short)plc.Read(DataType.DataBlock, dbArea, 4, VarType.Int, 1);
                CurrentStatus = (short)plc.Read(DataType.DataBlock, dbArea, 6, VarType.Int, 1);
                MotorForward = (bool)plc.Read(DataType.DataBlock, dbArea, 8, VarType.Bit, 1);
                MotorReverse = (bool)plc.Read(DataType.DataBlock, dbArea, 8, VarType.Bit, 1, 1);
                FaultCode = (short)plc.Read(DataType.DataBlock, dbArea, 10, VarType.Int, 1);
            }

            // 写入PLC数据
            public void WriteValues(uint taskNumber, short taskStatus, short currentStatus, bool motorForward, bool motorReverse, short faultCode)
            {
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 0, taskNumber);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 4, taskStatus);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 6, currentStatus);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 8, motorForward);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 8, motorReverse, 1);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 10, faultCode);
            }
        }

        internal class MobileDevice
        {
            private Plc plc;
            private int dbArea;

            public MobileDevice(string name, Plc plc, int dbArea)
            {
                this.Name = name;
                this.plc = plc;
                this.dbArea = dbArea;
            }
            // 字段属性
            public string Name { get; private set; }
            public uint TaskNumber { get; private set; }           // 任务号
            public short TaskStatus { get; private set; }          // 任务状态
            public uint StartPosition { get; private set; }        // 起始位置
            public uint EndPosition { get; private set; }          // 终止位置
            public short CurrentStatus { get; private set; }       // 当前状态
            public short CurrentCoordinate { get; private set; }   // 当前坐标
            public short FaultCode { get; private set; }           // 故障码

            // 读取PLC数据
            public void ReadValues()
            {
                TaskNumber = (uint)plc.Read(DataType.DataBlock, dbArea, 12, VarType.DWord, 1);
                TaskStatus = (short)plc.Read(DataType.DataBlock, dbArea, 16, VarType.Int, 1);
                StartPosition = (uint)plc.Read(DataType.DataBlock, dbArea, 18, VarType.DWord, 1);
                EndPosition = (uint)plc.Read(DataType.DataBlock, dbArea, 22, VarType.DWord, 1);
                CurrentStatus = (short)plc.Read(DataType.DataBlock, dbArea, 26, VarType.Int, 1);
                CurrentCoordinate = (short)plc.Read(DataType.DataBlock, dbArea, 28, VarType.Int, 1);
                FaultCode = (short)plc.Read(DataType.DataBlock, dbArea, 30, VarType.Int, 1);
            }

            // 写入PLC数据
            public void WriteValues(uint taskNumber, short taskStatus, uint startPosition, uint endPosition, short currentStatus, short currentCoordinate, short faultCode)
            {
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 12, taskNumber);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 16, taskStatus);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 18, startPosition);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 22, endPosition);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 26, currentStatus);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 28, currentCoordinate);
                Thread.Sleep(100); // 添加一个延迟以验证效果
                plc.Write(DataType.DataBlock, dbArea, 30, faultCode);
            }
        }
    }
}
