using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using BLL;
namespace BLL
{
    /// <summary>
    /// 结帐
    /// 1 门票/ 购买类型
    /// </summary>
    public class Checkout
    {

        public int TotalTickets { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid BuerId { get; set; }
        public PriceType PriceType { get; set; }
        public List<OrderDetail> Details { get; set; }
        

        public Model.Order MakeOrder()
        {

            Order order = new Order();
           
            order.BuyTime = DateTime.Now;
            order.IsPaid = false;
            order.MemberId = BuerId;
    

            order.OrderDetail = Details;

            BLLOrder bllOrder = new BLLOrder();
            bllOrder.SaveOrUpdateOrder(order);

            return order;
            
        }
    }
}
