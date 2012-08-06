using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DAL;
using Model;
using System.Web;
using Newtonsoft;
namespace BLL
{
    public class BLLTicket
    {
        ITicket iticket;
        BLLScenic bllScenic = new BLLScenic();

        public ITicket Iticket
        {
            get
            {
                if (iticket == null)
                {
                    iticket = new DALTicket();
                }
                return iticket;
            }
            set { iticket = value; }
        }

        /// <summary>
        /// 如果不存在该景区门票 则自动创建
        /// </summary>
        public Model.Ticket EnsureTicket(int scid)
        {
            IList<Model.Ticket> tickets = Iticket.GetTicketByscId(scid);
            Model.Ticket ticket = null;
            if (tickets.Count == 0)
            {
                ticket = new Ticket();
                ticket.Scenic = bllScenic.GetScenicById(scid);
                SaveOrUpdateTicket(ticket);
            }
            else if (tickets.Count == 1)
            {
                ticket = tickets[0];
            }
            return ticket;
        }
        /// <summary>
        /// 首页展示的是 门票 而不是景区.
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        public IList<Model.Ticket> GetTicketByAreaId(int areaid)
        {
            return Iticket.GetTicketByAreaId(areaid);
        }
        public IList<Model.Scenic> GetTicketByAreaIdAndLevel(int areaId, int level,string topic, int pageIndex, int pageSize, out int totalRecord)
        {
            return Iticket.GetTicketByAreaIdAndLevel(areaId, level,topic, pageIndex - 1, pageSize, out totalRecord);
        }
        public IList<Model.Ticket> GetTicketByscId(int scid)
        {
            //EnsureTicket(scid);  删除，与下文重复
            IList<Model.Ticket> tickets = Iticket.GetTicketByscId(scid);
            if (tickets.Count == 0)
            {
                Model.Ticket newTicket = new Ticket();
                newTicket.Scenic = bllScenic.GetScenicById(scid);
                SaveOrUpdateTicket(newTicket);
                tickets.Add(newTicket);
            }
            //else if (tickets.Count > 1)
            //{
            //    throw new Exception("一个景区限定为一张门票");
            //}
            return tickets;
        }
        public Ticket GetTicket(int ticketId)
        {
            return Iticket.Get(ticketId);
        }

        public Ticket GetTicketByScenicSeoName(string scenicSeoName)
        {
            return Iticket.GetByScenicSeo(scenicSeoName);
        }

        BLLTicketPrice bllTp = new BLLTicketPrice();
        public void SaveOrUpdateTicket(string ticketname, string yuan, string mxp, string xf, string zx, string ticketid, string scid)
        {
            Model.Ticket ticket;
            if (!string.IsNullOrEmpty(ticketid))
            {
                ticket = GetTicket(int.Parse(ticketid));
                ticket.TicketPrice.Where(x => x.PriceType == PriceType.Normal).First().Price = decimal.Parse(yuan);
                ticket.TicketPrice.Where(x => x.PriceType == PriceType.PostCardDiscount).First().Price = decimal.Parse(mxp);
                ticket.TicketPrice.Where(x => x.PriceType == PriceType.PreOrder).First().Price = decimal.Parse(xf);
                ticket.TicketPrice.Where(x => x.PriceType == PriceType.PayOnline).First().Price = decimal.Parse(zx);
                ticket.Name = ticketname;
                ticket.Lock = true;
            }
            else
            {
                ticket = new Ticket();
                ticket.Name = ticketname;
                ticket.Scenic = bllScenic.GetScenicById(int.Parse(scid));
                ticket.Lock = true;
                ticket.TicketPrice = new List<TicketPrice>() { 
                        new TicketPrice(){PriceType=PriceType.Normal,Price=decimal.Parse(yuan),Ticket=ticket},
                        new TicketPrice(){PriceType=PriceType.PostCardDiscount,Price=decimal.Parse(mxp),Ticket=ticket},
                        new TicketPrice(){PriceType=PriceType.PreOrder,Price=decimal.Parse(xf),Ticket=ticket},
                        new TicketPrice(){PriceType=PriceType.PayOnline,Price=decimal.Parse(zx),Ticket=ticket}
                    };
            }
            SaveOrUpdateTicket(ticket);
        }
        public void SaveOrUpdateTicket(Model.Ticket ticket)
        {
            Iticket.SaveOrUpdateTicket(ticket);
            foreach (TicketPrice tp in ticket.TicketPrice)
            {
                bllTp.SaveOrUpdateTicketPrice(tp);
            }
        }
        public void SaveOrUpdateTicket(IList<Model.Ticket> tickets)
        {
            foreach (var item in tickets)
            {
                foreach (TicketPrice tp in item.TicketPrice)
                {
                    bllTp.SaveOrUpdateTicketPrice(tp);
                }
            }
        }

        public IList<Scenic> Search(string paramKey, int pageIndex, int pageSize, out int totalRecord)
        {
            return Iticket.Search(paramKey, pageIndex - 1, pageSize, out totalRecord);
        }
        /// <summary>
        /// 购物车内的门票
        /// </summary>
        /// <returns></returns>
        public IList<Ticket> GetTicketsFromCart()
        {
            List<Ticket> Tickets = new List<Ticket>();
            foreach (CartItem item in GetCartFromCookies())
            {
                OrderDetail od = new OrderDetail();
                Ticket ti = GetTicket(item.TicketId);
                Tickets.Add(ti);
            }

            return Tickets;
        }

        public IList<CartItem> GetCartFromCookies()
        {
            IList<CartItem> CartItems = new List<CartItem>();
            HttpRequest Request = HttpContext.Current.Request;
            HttpResponse Response = HttpContext.Current.Response;
            HttpServerUtility Server = HttpContext.Current.Server;
            string cookieName = "_cart";
            HttpCookie cookie = Request.Cookies[cookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName, "[]");
                Response.Cookies.Add(cookie);
                return CartItems;
            }
            string cartJson = Server.UrlDecode(cookie.Value);
            Newtonsoft.Json.Linq.JArray arrya = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(cartJson);
            if (CartItems == null)
            {
                cookie.Value = "[]";
                Response.Cookies.Add(cookie);
                return CartItems;
            }
            CartItems = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<CartItem>>(cartJson);
            return CartItems;
        }

        public IList<Model.Ticket> GetTp(int scid)
        {
            return Iticket.GetTp(scid);
        }
    }

    public class CartItem
    {
        public int TicketId;
        public int Qty;
    }
}
