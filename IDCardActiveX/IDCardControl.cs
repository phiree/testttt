using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace IDCardActiveX
{
    [Guid("6c78bcd1-ac43-4fb9-8d89-d9f7b717d021")]
    public partial class IDCardControl : UserControl, IObjectSafe
    {
        private static String[] strArray = new string[10]; //存储用户信息

        string name = string.Empty;
        string sex = string.Empty;
        string nation = string.Empty;
        string brith = string.Empty;
        string address = string.Empty;
        string ID = string.Empty;
        string SignGov = string.Empty;
        string StartDate = string.Empty;
        string EndDate = string.Empty;
        public IDCardControl()
        {
            InitializeComponent();
        }

        #region dll 入口申明

        //[DllImport("termb.dll")]
        [DllImport("termb.dll", EntryPoint = "CVR_InitComm", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern int InitComm(int port); //打开端口
        [DllImport("termb.dll", EntryPoint = "CVR_CloseComm", CharSet = CharSet.Auto, SetLastError = false)]
        //[DllImport("termb.dll")]
        private static extern int CloseComm(); //关闭端口
        //[DllImport("termb.dll")]
        [DllImport("termb.dll", EntryPoint = "CVR_Authenticate", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern int Authenticate(); //卡认证
        //[DllImport("termb.dll")]
        [DllImport("termb.dll", EntryPoint = "CVR_Read_Content", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern int Read_Content(int active); //读取卡
        [DllImport("termb.dll")]
        private static extern int Read_Content_Path(string cPath, int active); //读取卡

        #endregion

        #region 自定义方法

        public void OnTimer()
        {
            byte[] infos = new byte[255];
            strArray = new string[10];
            bool sign = false;
            //打开端口
            for (int i = 1001; i <= 1010; i++)
            {
                if (InitComm(i) == 1)
                {
                    sign = true;
                    //MessageBox.Show("连接到设备");
                    break;
                }
            }
            if (!sign)
            {
                for (int i = 1; i < 10; i++)
                {
                    if (InitComm(i) == 1)
                    {
                        sign = true;
                       // MessageBox.Show("连接到设备");
                        break;
                    }
                }
            }
            if (!sign)
            {
                //MessageBox.Show("未找到设备");
                return;
            }
            //卡认证
            if (Authenticate() != 1)
            {
                //MessageBox.Show("卡认证失败2,请重新放好卡" + Authenticate());
                return;
            }
            //读卡
            if (Read_Content(4) != 1)
            {
                //MessageBox.Show("读卡失败!");
                return;
            }
            //MessageBox.Show("取卡成功");
            FileStream fsphotho = new FileStream("D:\\zp.bmp", FileMode.Open, FileAccess.Read);
            this.picbPhoto.Image = Image.FromStream(fsphotho);
            fsphotho.Close();
            FileStream fs = new FileStream("D:\\wz.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            int length = infos.Length;
            fs.Read(infos, 0, length);
            strArray[0] = Encoding.Unicode.GetString(infos, 0, 30);   //姓名
            strArray[1] = Encoding.Unicode.GetString(infos, 30, 2);   //性别
            strArray[2] = Encoding.Unicode.GetString(infos, 32, 4);   //名族
            strArray[3] = Encoding.Unicode.GetString(infos, 36, 16);  //出生
            strArray[4] = Encoding.Unicode.GetString(infos, 52, 70);  //地址
            strArray[5] = Encoding.Unicode.GetString(infos, 122, 36); //身份证号
            strArray[6] = Encoding.Unicode.GetString(infos, 158, 30); //签发机关
            strArray[7] = Encoding.Unicode.GetString(infos, 188, 16); //有效开始时间
            strArray[8] = Encoding.Unicode.GetString(infos, 204, 16); //有效结束时间
            fs.Close();
        }

        /// <summary>
        /// 打印文字
        /// </summary>
        /// <param name="mes"></param>
        public void ShowMessage(string mes)
        {
            if (!string.IsNullOrEmpty(mes))
            {
                //MessageBox.Show(mes);
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public string GetUserInfo()
        {
            string str = string.Empty;
            foreach (string s in strArray)
            {
                str += s + ",";
            }
            str = str.TrimEnd(',');
            return str;
        }

        #endregion

        #region IObjectSafety 成员

        public void GetInterfaceSafeOptions(ref Guid riid, ref int pdwSupportedOptions, ref int pdwEnabledOptions)
        {
            pdwSupportedOptions = 1;
            pdwEnabledOptions = 2;
        }

        public void SetInterfaceSafeOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
