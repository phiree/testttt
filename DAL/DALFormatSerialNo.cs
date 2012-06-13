using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace DAL
{
    public class DALFormatSerialNo : DalBase
    {

        public IList<FormatSerialNo> GetSerialNoList(string flag)
        {


            IList<FormatSerialNo> list = session.CreateQuery("select s from FormatSerialNo s where s.Flag='" + flag + "' ").List<FormatSerialNo>();

            return list;
        }
        public   void Save(FormatSerialNo fs)
        {
            session.SaveOrUpdate(fs);
            session.Flush();
        }
    }
}
