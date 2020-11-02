using System;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace AToolPlus
{
    /// <summary>
    /// 数据采集与设置
    /// </summary>
    public class SsCommApp
    {
        ////数据处理函数
        public delegate void HandleCommData(byte[] data);

        ////事件侦听
        public event HandleCommData Handlers;

        /// <summary>
        /// 串口信息
        /// </summary>
        public struct Com_Struct
        {
            public string PortName;
            public int Baudrate;
            public byte ByteSize;
            public string Parity;
            public string StopBit;
        }

        private const int MAX_BUFFER_LEN = 1024;
        private byte[] RecvBuf = new byte[MAX_BUFFER_LEN];
        private int RecvLen = 0;
        
        /// <summary>
        /// 采集一般数据的等待时间
        /// </summary>
        //private const int WAIT_TIME_COMMON = 10000;
        public SsComm com;
        
        public SsCommApp()
        {
            com = new SsComm();
        }

        /// <summary>
        /// 开启串口
        /// </summary>
        /// <param name="comSetUP">串口参数</param>
        /// <returns></returns>
        public bool InitPort(Com_Struct comSetUP)
        {
            try
            {
                if (com.IsOpen)
                {
                    com.Close();
                }

                com.PortName = comSetUP.PortName;
                com.BaudRate = comSetUP.Baudrate;
                com.DataBits = comSetUP.ByteSize;
                com.Parity = SsComm.StringToParity(comSetUP.Parity);
                com.StopBits = SsComm.StingToStopBits(comSetUP.StopBit);
                com.Open();
                if (com.IsOpen)
                {
                    com.DataReceived += new SerialDataReceivedEventHandler(DataReceived); //订阅委托  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //if (com.IsOpen)     //此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了  
            //{   
                Byte[] receivedData = null;
                Byte[] tmp = null;
                try
                {
                    while (com.BytesToRead > 0)
                    {
                        Thread.Sleep(50);
                        receivedData = new Byte[com.BytesToRead];
                        com.Read(receivedData, 0, receivedData.Length);
                        com.DiscardInBuffer();

                        Array.Copy(receivedData,0,RecvBuf,RecvLen,receivedData.Length);
                        RecvLen = RecvLen + receivedData.Length;
                        //Thread.Sleep(50);
                        //LogHelper.WriteDebug(typeof(Comm_App), "串口接收"+EncodeConvert.ByteArrayToHexString(receivedData));                           
                    }
                     //通知处理器处理数据
                    if (Handlers != null)
                    {
                        tmp = new byte[RecvLen];
                        Array.Copy(RecvBuf,0,tmp,0,RecvLen);
                        Handlers(tmp);
                        RecvLen = 0;
                        Array.Clear(RecvBuf, 0, RecvBuf.Length);
                    }                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }               
            //}
        }  
        /// <summary>
        /// 关闭串口s
        /// </summary>
        /// <returns></returns>
        public void UnInitPort()
        {
            try
            {
                if (com.IsOpen)
                {
                    com.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="cmd"></param>
       /// <param name="byteToSend"></param>
       /// <param name="byteRecved"></param>
       /// <param name="WaitTime"></param>
       /// <returns></returns>
        public bool SendData(byte[] byteToSend)
        {
            try
            {
                if (com != null && com.IsOpen)
                {
                    com.Write(byteToSend, 0, byteToSend.Length);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
