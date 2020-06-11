/************************************************************************
* Copyright (c) 2020 All Rights Reserved.
*命名空间：TestHelper4Hardness.Utils
*文件名： Utils
*创建人： XXX
*创建时间：2020/6/2 16:13:42
*描述
*=======================================================================
*修改标记
*修改时间：2020/6/2 16:13:42
*修改人：XXX
*描述：
************************************************************************/

using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TestHelper4Hardness.Utils
{
    internal class Util
    {
        public static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }

        public static List<String> getMatchData(String text, String pat)
        {
            List< String> result = new List<String>();
            //实例化r，第二个参数为匹配的要求，这里为忽略大小写
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            //这里还可以写成这样
            //MatchCollection mc = r.Matches(text);
            //然后用下标的形式访问每个mc，返回一个匹配的结果
            //Match m = mc[i];
            Match m = r.Match(text);
            int matchCount = 0;
            //此属性判断是否匹配成功
            while (m.Success)
            {
                //匹配的个数
                Console.WriteLine("Match" + (++matchCount));
                //这里为什么要从下标1开始，因为下面获取组时：
                //下标0为一个整组，是根据匹配规则“(\w+)\s+(car)”获取的整组
                //下标1为第一个小括号里面的数据
                //下标2为第二个括号里面的数据....依次论推
            
                Group g = m.Groups[1];
                result.Add(g.ToString());
               
                //匹配下一个
                m = m.NextMatch();
            }
            return result;
        }
        /**
         * 对com口接收的数据根据样本点数分组
         *
         * */
        public static String[][] dataFormat(List<String> sourceData, int limit=3)
        {
            if (sourceData.Count <= 0) return null;
            decimal a = (decimal)sourceData.Count / (decimal)limit;
            int rows = (int)Math.Ceiling(a);
            String[][] result = new string[rows][];
            for (int init = 0; init < rows-1; init++)
                result[init] =new String[limit];
            if(sourceData.Count % limit==0)
            {
                result[rows - 1] = new string[limit];
            }
            else
            {
                result[rows - 1] = new string[sourceData.Count % limit];
            }
            int currentRow = 0;//当前行
            int currentCol = 0;//当前列
            for (int i = 0; i < sourceData.Count; i++)
            {
                if (currentCol < limit)
                {
                   
                        result[currentRow][currentCol] = sourceData[i];
                        currentCol++;
                  
                }
                else
                {
                    currentRow++;
                    currentCol = 0;
                    result[currentRow][currentCol] = sourceData[i];
                    currentCol++;
                }
            }


            return result;

        }


        /**
         * 文件写函数
         * */
        public static Boolean write2File(String path, String data, FileMode fileMode,FileAccess fileAccess)
        {
            try {
            byte[] myByte = System.Text.Encoding.UTF8.GetBytes(data);
            using (FileStream fsWrite = new FileStream(path, fileMode,fileAccess))
            {
                fsWrite.Write(myByte, 0, myByte.Length);
            };
                return true;
            }
            catch(Exception e)
            {
                log.Error(e.ToString());
                return false;
            }
        }


        /**
         * 文件读函数
         * */
        public static String read2File(String path, FileMode fileMode,FileAccess fileAccess)
        {
            try
            {
                using (FileStream fsRead = new FileStream(path, fileMode, fileAccess))
                {
                    int fsLen = (int)fsRead.Length;
                    byte[] heByte = new byte[fsLen];
                    int r = fsRead.Read(heByte, 0, heByte.Length);
                    string myStr = System.Text.Encoding.UTF8.GetString(heByte);
                    return myStr;
                  
                }
            }
            catch (Exception e)
            {
                log.Error(e.ToString());
                return "READ_ERROR";
            }
        }

        public static string HttpPostJson(string url, Dictionary<string, object> parameters, string authorization)
        {
            try
            {
                string text = "";
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.Method = "POST";
                if (parameters != null && parameters.Count != 0)
                {
                    string text2 = JsonConvert.SerializeObject(parameters);
                    log.Info("http post request url:" + url);
                    log.Info("http post request ContentLength:" + text2.Length.ToString());
                    log.Debug("http post request data:" + text2);
                    httpWebRequest.ContentType = "application/json;charset=utf-8;";
                    //                   httpWebRequest.ContentLength = text2.Length;
                    httpWebRequest.Headers.Add("Authorization", authorization);
                    using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(text2);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
                WebResponse response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(stream);
                    text = streamReader.ReadToEnd();
                    stream.Close();
                }
                log.Info("http post response:" + text);
                return text;
            }
            catch (Exception exception)
            {
                log.Error("http post ERROR", exception);
                return null;
            }
        }
        public static string ObjToJson<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }
        public static T JsonToObj<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static String OpenSelectFolderDialog_EMPTY = "0";
        public static String OpenSelectFolderDialog_CANCEL = "-1";
        public static String OpenSelectFolderDialog(Form form)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择记录生成文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(form, "文件夹路径不能为空", "提示");
                    return OpenSelectFolderDialog_EMPTY;
                }
                else
                {
                    return dialog.SelectedPath;
                }

            }
            return OpenSelectFolderDialog_CANCEL;
        }

        public static decimal sum(String[] source,int right)
        {
            decimal result = 0;
            try { 
         
            for(int i= source.Length-right; i<source.Length;i++)
            {
                result = result + Decimal.Parse(source[i]);
            }
            
            }
            catch(Exception e)
            {
                log.Error(e.ToString());
            }
            return result;

        }

        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        public static bool IsUnsign(string value)
        {
            return Regex.IsMatch(value, @"^\d*[.]?\d*$");
        }

        public static bool isTel(string strInput)
        {
            return Regex.IsMatch(strInput, @"\d{3}-\d{8}|\d{4}-\d{7}");
        }


    }
}