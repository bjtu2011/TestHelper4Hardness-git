/************************************************************************
* Copyright (c) 2020 All Rights Reserved.
*命名空间：TestHelper4Hardness.Utils
*文件名： COMHelper
*创建人： wanghuabin
*创建时间：2020/6/2 8:29:52
*描述
*=======================================================================
*修改标记
*修改时间：2020/6/2 8:29:52
*修改人：wanghuabin
*描述：
************************************************************************/
using log4net;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading;
using TestHelper4Hardness.Kernel;

namespace TestHelper4Hardness.Utils
{
    class COMHelper
    {
        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>初始化串行端口</summary>
        private SerialPort _serialPort;

        public SerialPort serialPort
        {
            get { return _serialPort; }
            set { _serialPort = value; }
        }

        /// <summary>
        /// COM口通信构造函数
        /// </summary>
        /// <param name="PortID">通信端口</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="dataBits">标准数据位长度</param>
        /// <param name="stopBits">每个字节的标准停止位数</param>
        /// <param name="readTimeout">获取或设置读取操作未完成时发生超时之前的毫秒数</param>
        /// <param name="writeTimeout">获取或设置写入操作未完成时发生超时之前的毫秒数</param>
        public COMHelper(string PortID, int baudRate, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One, int readTimeout = 100, int writeTimeout = 100)
        {
            try
            {
                serialPort = new SerialPort();
                serialPort.PortName =  PortID;//通信端口
                serialPort.BaudRate = baudRate;//波特率
                serialPort.Encoding = Encoding.ASCII;
                serialPort.Parity = parity;//奇偶校验位
                serialPort.DataBits = dataBits;//标准数据位长度
                serialPort.StopBits = stopBits;//每个字节的标准停止位数
                serialPort.ReadTimeout = readTimeout;//获取或设置读取操作未完成时发生超时之前的毫秒数
                serialPort.WriteTimeout = writeTimeout;//获取或设置写入操作未完成时发生超时之前的毫秒数
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// 打开COM口
        /// </summary>
        /// <returns>true 打开成功；false 打开失败；</returns>
        public bool Open()
        {
            try
            {
                if (serialPort.IsOpen == false)
                {
                    serialPort.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Debug(ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// 关闭COM口
        /// </summary>
        /// <returns>true 关闭成功；false 关闭失败；</returns>
        public bool Close()
        {
            try
            {
                serialPort.Dispose();
                serialPort.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断端口是否打开
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            try
            {
                return serialPort.IsOpen;
            }
            catch { throw; }
        }

        /// <summary>
        /// 向COM口发送信息
        /// </summary>
        /// <param name="sendData">16进制的字节</param>
        public void WriteData(byte[] sendData)
        {
            try
            {
                if (IsOpen())
                {
                    Thread.Sleep(5);
                    serialPort.Write(sendData, 0, sendData.Length);
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// 接收来自COM的信息
        /// </summary>
        /// <returns>返回收到信息的数组</returns>
        public string[] ReceiveDataArray()
        {

            try
            {
                Thread.Sleep(5);
                if (!serialPort.IsOpen) return null;
                int DataLength = serialPort.BytesToRead;
                byte[] ds = new byte[DataLength];
                int bytecount = serialPort.Read(ds, 0, DataLength);
                return ByteToStringArry(ds);
            }
            catch (Exception ex)
            {
                log.Debug("" + ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// 把字节型转换成十六进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string[] ByteToStringArry(byte[] bytes)
        {
            try
            {
                string[] strArry = new string[bytes.Length];
                for (int i = 0; i < bytes.Length; i++)
                {
                    strArry[i] = String.Format("{0:X2} ", bytes[i]).Trim();
                }
                return strArry;
            }
            catch { throw; }
        }

        /// <summary>
        /// 清除缓存数据
        /// </summary>
        public void ClearDataInBuffer()
        {
            try
            {
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                
            }
            catch { throw; }
        }

        public Boolean isComplete()
        {
            return serialPort.BytesToRead <= 0;
        }


        /// <summary>
        /// 注册 数据接收事件，在接收到数据时 触发
        /// </summary>
        /// <param name="serialPort_DataReceived"></param>
        public void AddReceiveEventHanlder(SerialDataReceivedEventHandler serialPort_DataReceived)
        {
            try
            {
                serialPort.DataReceived += serialPort_DataReceived;
            }
            catch { throw; }
        }

        //接收事件是否有效 true开始接收，false停止接收。默认true

        public static bool ReceiveEventFlag = true;
        /// <summary>
        /// 接收数据触发，将接收的数据，通过一个定义的数据接收事件，传递出去。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (ReceiveEventFlag == false)
            {
                return;
            }
            string strReceive = ReceiveDataString();
            if (!string.IsNullOrEmpty(strReceive))
            {
                OnReceiveDataHanlder(strReceive);
            }
        }

        private string ReceiveDataString()
        {
            int len = serialPort.BytesToRead;
            string receivedata = string.Empty;
            if (len != 0)
            {
                byte[] buff = new byte[len];
                serialPort.Read(buff, 0, len);
                receivedata = Encoding.Default.GetString(buff);

            }
            return receivedata;
        }

        #region 数据接收事件
        public event SerialPortDataReceivedDelegate ReceiveDataHandler;

        protected void OnReceiveDataHanlder(String receiveData)
        {
            SerialPortDataReceivedDelegate handler = ReceiveDataHandler;
            if (handler != null) handler(receiveData);
        }
        #endregion
    }
}
