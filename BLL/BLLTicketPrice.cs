using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;

namespace BLL
{
    public class BLLTicketPrice
    {
        IDAL.ITicketPrice iticketprice;

        public IDAL.ITicketPrice Iticketprice
        {
            get
            {
                if (iticketprice == null)
                {
                    iticketprice =new DALTicketPrice();
                }
                return iticketprice; 
            }
            set { iticketprice = value; }
        }
        public IList<Model.TicketPrice> GetTicketPriceByScenicId(int scenicid)
        {
            return Iticketprice.GetTicketPriceByScenicId(scenicid);
        }

        public void SaveOrUpdateTicketPrice(Model.TicketPrice ticketprice)
        {

           Model.TicketPrice tp = Iticketprice.GetTicketPriceByScenicandtypeid(ticketprice.Ticket.Scenic.Id,(int)ticketprice.PriceType);
           if (tp == null)
           {
              // ticketprice.Id = tp.Id;
               tp = new Model.TicketPrice();
               tp.PriceType = ticketprice.PriceType;
               tp.Ticket = ticketprice.Ticket;
           }
           tp.Price = ticketprice.Price;
             Iticketprice.SaveOrUpdateTicketPrice(tp);
        }

        public string GetPriceType(int scenicid, decimal price)
        {
            IList<Model.TicketPrice> list = Iticketprice.GetTicketPriceByScenicId(scenicid);
            foreach (Model.TicketPrice item in list)
            {
                if (item.Price == price)
                    return CommonLibrary.EnumHelper.GetEnumDescription(item.PriceType);
            }
            return "";
        }
        /// <summary>
        /// 获取某个类型的价格.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="priceType"></param>
        /// <returns></returns>
        public Model.TicketPrice GetTicketPriceByScenicandtypeid(Model.Ticket ticket,Model.PriceType priceType)
        {
            return GetTicketPriceByScenicandtypeid(ticket.Scenic.Id, (int)priceType);
        }

        public Model.TicketPrice GetTicketPriceByScenicandtypeid(int scenicid, int type)
        {

            return Iticketprice.GetTicketPriceByScenicandtypeid(scenicid, type);
        }
        public IList<Model.TicketPrice> GetTicketPriceByAreaId(int areaid, int typeid,string level,out int sceniccount,int pageindex,int pagesize)
        {
            return Iticketprice.GetTicketPriceByAreaId(areaid, typeid,level,out sceniccount,pageindex,pagesize);
        }
    }
}
