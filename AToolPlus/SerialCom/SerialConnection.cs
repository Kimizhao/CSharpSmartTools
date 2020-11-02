using System;
using System.Collections.Generic;
using System.Text;

namespace AToolPlus
{
    /// <summary>
    /// 串口连接
    /// </summary>
    public class SerialConnection
    {
        private static SerialConnection instance = new SerialConnection();
        private SsCommApp ssCommApp = new SsCommApp();

        public static SerialConnection Instance
        {
            get { return SerialConnection.instance; }
            set { SerialConnection.instance = value; }
        }

        public bool Initialize(string s, string s1)
        {
            if (ssCommApp == null)
            {
                ssCommApp = new SsCommApp();
            }

            if (!ssCommApp.com.IsOpen)
            {
                SsCommApp.Com_Struct comParam = new SsCommApp.Com_Struct();
                comParam.PortName = s;
                comParam.Baudrate = int.Parse(s1);
                comParam.Parity = "不校验";
                comParam.StopBit = "1位";
                comParam.ByteSize = 8;
                if (ssCommApp.InitPort(comParam))
                {
                    //ssCommApp.Handlers += new SsCommApp.HandleCommData(HandleCommData);
                }

                return true;
            }
            else
            {
                ssCommApp.UnInitPort();
                ssCommApp = null;
            }

            return false;
        }

        public SsCommApp GetSsComApp()
        {
            return ssCommApp;
        }

        public void HandleCommData(byte[] data)
        {
            //Console.WriteLine(data.ToHexString());
        }

        public bool IsOpened()
        {
            if (ssCommApp != null)
            {
                return ssCommApp.com.IsOpen;
            }

            return false;
        }

        public bool Close()
        {
            if (ssCommApp != null)
            {
                ssCommApp.UnInitPort();
                ssCommApp = null;
                return true;
            }

            return false;
        }

        public bool SendData(byte[] s)
        {
            if (ssCommApp != null)
            {
                return ssCommApp.SendData(s);
            }

            return false;
        }
    }
}
