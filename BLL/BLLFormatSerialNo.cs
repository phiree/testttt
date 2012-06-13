using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
namespace BLL
{
    public class BLLFormatSerialNo 
    {
        DALFormatSerialNo dalFs = new DALFormatSerialNo();

        public string GetSerialNo(string flag)
        {
            return GetSerialNo(flag, true);
        }
        public string GetSerialNo(string flag, bool includeDay)
        {
            string serialNo = string.Empty;

            IList<FormatSerialNo> flagNos = dalFs.GetSerialNoList(flag);
            FormatSerialNo format = new FormatSerialNo();
            DateTime now = DateTime.Now;
            if (flagNos.Count == 0)
            {

                format.Day = EnsureFormatItemLength(2, now.Day);
                format.Flag = flag;
                format.Month = EnsureFormatItemLength(2, now.Month);
                format.Year = EnsureFormatItemLength(2, now.Year);
                format.Value = EnsureFormatItemLength(4, 1);
                serialNo = format.ToString();
                dalFs.Save(format);

            }
            else if (flagNos.Count == 1)
            {
                format = flagNos[0];
                int year = int.Parse(format.Year);
                int month = int.Parse(format.Month);
                int day = int.Parse(format.Day);
                int value = int.Parse(format.Value);
                if (now.Year % 100 > year)
                {
                    month = 1;
                    day = 1;
                    value = 1;

                }
                else if (now.Year % 100 == year)
                {
                    if (now.Month > month)
                    {

                        day = 1;
                        value = 1;
                    }
                    else if (now.Month == month)
                    {
                        if (now.Day > day)
                        {
                            value = 1;
                        }
                        else if (now.Day == day)
                        {
                            value = value + 1;
                        }
                        else
                        {
                            throw new Exception("日期错误,请检查电脑的时间设置");
                        }
                    }
                    else
                    {
                        throw new Exception("月份错误,请检查电脑的时间设置");
                    }
                }
                else
                {
                    throw new Exception("年份错误,请检查电脑的时间设置");
                }


                format.Day = EnsureFormatItemLength(2, now.Day);
                format.Month = EnsureFormatItemLength(2, now.Month);
                format.Year = EnsureFormatItemLength(2, now.Year);
                format.Value = EnsureFormatItemLength(4, value);
                serialNo = format.ToString();
                dalFs.Save(format);
            }
            else
            {
                throw new Exception("流水号生成错误:出现" + flagNos.Count + "个相同的Flag");
            }


            return serialNo;

        }
        private string EnsureFormatItemLength(int length, int value)
        {
            string zeros = string.Empty;
            for (int i = 0; i < length; i++)
            {
                zeros += "0";
            }
            string v = zeros + value;
            return v.Substring(v.Length - length);
        }
    }
}
