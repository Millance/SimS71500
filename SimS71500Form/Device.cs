using S7.Net;
using static SimS71500Form.Responses;

namespace SimS71500Form
{
    public abstract class Device
    {
        public Device(string name, int dbArea)
        {
            this.Name = name;
            this.dbArea = dbArea;
        }
        public int dbArea { get; private set; }
        public string Name { get; private set; }
        public uint TaskNumber { get; private set; }      // 任务号
        public short TaskStatus { get; private set; }     // 任务状态
        public short CurrentStatus { get; private set; }  // 当前状态
        public short FaultCode { get; private set; }     // 故障码

        public void SetCurrentStatus(short newStatus)
        {
            // 提供一个方法在外部更改 CurrentStatus
            this.CurrentStatus = newStatus;
        }

        // 抽象的 Read 方法，返回ReadResponce
        public abstract ReadResponce Read();

        // 抽象的 Write 方法，返回WriteResponce
        public abstract WriteResponce Write(short status);
    }

    public class Motor : Device
    {
        public Motor(string name, int dbArea) : base(name, dbArea)
        {

        }
        public bool MotorForward { get; private set; }   // 电机正转
        public bool MotorReverse { get; private set; }   // 电机反转

        public override ReadResponce Read()
        {
            ReadResponce responce = PlcController.MyPlc.ReadVariable(DataType.DataBlock, dbArea, 6, VarType.Int, 1);
            if (responce.IsSuccess && responce.Data != null)
            {
                SetCurrentStatus((short)responce.Data);
            }
            return responce;
        }

        public override WriteResponce Write(short status)
        {
            WriteResponce responce = PlcController.MyPlc.WriteVariable(DataType.DataBlock, dbArea, 6, VarType.Int, status.ToString());
            return responce;
        }

    }

    public class MobileDevice : Device
    {
        public MobileDevice(string name, int dbArea) : base(name, dbArea)
        {

        }
        public uint StartPosition { get; private set; }        // 起始位置
        public uint EndPosition { get; private set; }          // 终止位置
        public short CurrentCoordinate { get; private set; }   // 当前坐标

        public override ReadResponce Read()
        {
            ReadResponce responce = PlcController.MyPlc.ReadVariable(DataType.DataBlock, dbArea, 26, VarType.Int, 1);
            if (responce.IsSuccess && responce.Data != null)
            {
                SetCurrentStatus((short)responce.Data);
            }
            return responce;
        }

        public override WriteResponce Write(short status)
        {
            WriteResponce responce = PlcController.MyPlc.WriteVariable(DataType.DataBlock, dbArea, 26, VarType.Int, status.ToString());
            return responce;
        }


    }

}
