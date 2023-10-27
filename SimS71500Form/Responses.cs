namespace SimS71500Form
{
    public class Responses
    {
        public class PLCResponce
        {
            public bool IsSuccess { get; set; } = false;
            public string ReaponceMsg { get; set; } = "";
        }

        /// <summary>
        /// 读取PLC后返回的数据结构
        /// </summary>
        public class ReadResponce : PLCResponce
        {
            public object? Data { get; set; }
        }

        /// <summary>
        /// 写入PLC后返回的数据结构
        /// </summary>
        public class WriteResponce : PLCResponce
        {

        }
    }
}
