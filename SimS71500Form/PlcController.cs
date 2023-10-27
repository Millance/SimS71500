using S7.Net;
using System.Text;
using static SimS71500Form.Responses;

namespace SimS71500Form
{
    public class PlcController
    {
        // 饿汉单例模式
        private static readonly PlcController myPlc = new PlcController();
        private Plc? plc;

        public static PlcController MyPlc
        {
            get { return myPlc; }
        }

        public void Connect(CpuType cpuType, string ipAddress, short rack, short slot)
        {
            if (plc == null || plc.IsConnected == false)
            {
                try
                {
                    // 初始化PLC连接
                    plc = new Plc(cpuType, ipAddress, rack, slot);
                    plc.Open();
                }
                catch (Exception ex)
                {
                    // 处理连接错误
                    throw new Exception("PLC连接错误: " + ex.Message);
                }
            }
        }

        public void Disconnect()
        {
            // 断开PLC连接
            if (plc != null && plc.IsConnected)
            {
                plc.Close();
            }
        }

        public bool IsConnected
        {
            get
            {
                if (plc != null)
                {
                    return plc.IsConnected;
                }
                return false;
            }
        }

        /// <summary>
        /// 读取指定地址的数据
        /// </summary>
        /// <param name="dataType">存储区域的数据类型</param>
        /// <param name="dbArea">存储区域的地址</param>
        /// <param name="startByteAdr">起始字节地址</param>
        /// <param name="varType">要读取的变量类型</param>
        /// <param name="varCount">变量的数量</param>
        /// <param name="bitAdr">比特地址</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ReadResponce ReadVariable(DataType dataType, int dbArea, int startByteAdr, VarType varType, int varCount, byte bitAdr = 0)
        {
            ReadResponce responce = new ReadResponce();
            try
            {
                if (plc == null || !plc.IsConnected)
                {
                    responce.ReaponceMsg = "PLC未连接";
                    return responce;
                }

                switch (varType)
                {
                    case VarType.Bit:
                        responce.Data = plc.Read(dataType, dbArea, startByteAdr, VarType.Bit, varCount, bitAdr);
                        responce.IsSuccess = true;
                        break;

                    case VarType.Byte:
                    case VarType.Word:
                    case VarType.DWord:
                    case VarType.Int:
                    case VarType.DInt:
                    case VarType.Real:
                    case VarType.LReal:
                        responce.Data = plc.Read(dataType, dbArea, startByteAdr, varType, varCount);
                        responce.IsSuccess = true;
                        break;

                    case VarType.String:
                        byte[] dataS = plc.ReadBytes(dataType, dbArea, 68, 256);
                        int stringLen = dataS[1];
                        string gbkString = Encoding.GetEncoding("GBK").GetString(dataS, 2, stringLen);
                        responce.Data = gbkString;
                        responce.IsSuccess = true;
                        break;

                    case VarType.S7String:
                    case VarType.S7WString:
                    case VarType.Timer:
                    case VarType.Counter:
                    case VarType.DateTime:
                    case VarType.DateTimeLong:
                        responce.ReaponceMsg = "未处理相关逻辑，请自行探索";
                        break;
                    default:
                        break;
                }

                return responce;
            }
            catch (Exception ex)
            {
                // 处理读取错误
                responce.ReaponceMsg = "PLC读取错误: " + ex.Message;
                return responce;
            }
        }

        /// <summary>
        /// 写入指定地址的数据
        /// </summary>
        /// <param name="dataType">存储区域的数据类型</param>
        /// <param name="dbArea">存储区域的地址</param>
        /// <param name="startByteAdr">起始字节地址</param>
        /// <param name="varType">要读取的变量类型</param>
        /// <param name="value">需要写入的值</param>
        /// <param name="bitAdr">比特地址</param>
        /// <returns></returns>
        public WriteResponce WriteVariable(DataType dataType, int dbArea, int startByteAdr, VarType varType, string value, int bitAdr = -1)
        {
            WriteResponce responce = new WriteResponce();

            try
            {
                if (plc == null || !plc.IsConnected)
                {
                    responce.ReaponceMsg = "PLC未连接";
                    return responce;
                }


                switch (varType)
                {
                    case VarType.Bit:
                        plc.Write(dataType, dbArea, startByteAdr, Convert.ToBoolean(value), bitAdr);
                        responce.IsSuccess = true;
                        break;

                    case VarType.Byte:
                        plc.Write(dataType, dbArea, startByteAdr, Convert.ToByte(value));
                        responce.IsSuccess = true;
                        break;

                    case VarType.Word:
                        plc.Write(dataType, dbArea, startByteAdr, Convert.ToUInt16(value));
                        responce.IsSuccess = true;
                        break;

                    case VarType.DWord:
                        plc.Write(dataType, dbArea, startByteAdr, Convert.ToUInt32(value));
                        responce.IsSuccess = true;
                        break;

                    case VarType.Int:
                        plc.Write(dataType, dbArea, startByteAdr, Convert.ToInt16(value));
                        responce.IsSuccess = true;
                        break;

                    case VarType.DInt:
                        plc.Write(dataType, dbArea, startByteAdr, Convert.ToInt32(value));
                        responce.IsSuccess = true;
                        break;

                    case VarType.Real:
                        plc.Write(dataType, dbArea, startByteAdr, Convert.ToSingle(value));
                        responce.IsSuccess = true;
                        break;

                    case VarType.LReal:
                        plc.Write(dataType, dbArea, startByteAdr, Convert.ToDouble(value));
                        responce.IsSuccess = true;
                        break;

                    case VarType.String:
                        // 编码为字节数组
                        byte[] stringBytes = Encoding.GetEncoding("GBK").GetBytes(value);
                        // 构建带控制信息的字节数组
                        byte[] dataString = new byte[stringBytes.Length + 2]; // 加2是为了存储控制信息
                        // 添加控制信息
                        dataString[0] = 254; // 第一个字节固定为254
                        dataString[1] = (byte)(stringBytes.Length); // 第二个字节表示字符长度
                        // 复制字符串数据到字节数组
                        Array.Copy(stringBytes, 0, dataString, 2, stringBytes.Length);
                        // 将字节数组写入PLC
                        plc.WriteBytes(dataType, dbArea, startByteAdr, dataString);
                        responce.IsSuccess = true;
                        break;

                    case VarType.S7String:
                    case VarType.S7WString:
                    case VarType.Timer:
                    case VarType.Counter:
                    case VarType.DateTime:
                    case VarType.DateTimeLong:
                        responce.ReaponceMsg = "未处理相关逻辑，请自行探索";
                        break;
                    default:
                        break;
                }

                return responce;
            }
            catch (Exception ex)
            {
                // 处理读取错误
                responce.ReaponceMsg = "PLC读取错误: " + ex.Message;
                return responce;
            }
        }
    }
}
