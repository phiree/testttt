using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelModel.HotelSDKModel;
using BLL.NorthBoundAPIService;
using HotelModel.HotelDB;

namespace BLL
{
    public class BLLHotelOrder
    {
        DAL.DALHotel dal = new DAL.DALHotel();

        public SubmitOrderResponse SubmitOrder(SubmitOrderRequest SubmitOrderRequest)
        {
            SubmitOrderResponse OrderResponse = new SubmitOrderResponse();
            SubmitHotelOrderResponse SubmitHotelOrderResponse = new SubmitHotelOrderResponse();
            #region 提交订单
            SubmitHotelOrderRequest SubmitHotelOrderRequest = new SubmitHotelOrderRequest();
            NorthBoundAPIServiceSoapClient client = new NorthBoundAPIServiceSoapClient();

            #region RequestHead
            LoginRequest loginreq = new LoginRequest();
            loginreq.UserName = System.Configuration.ConfigurationManager.AppSettings["NB_UserName"].ToString();
            loginreq.Password = System.Configuration.ConfigurationManager.AppSettings["NB_Pwd"].ToString();

            LoginResponse loginres = new LoginResponse();
            loginres = client.Login(loginreq);
            GetHotelListRequest HotelListReq = new GetHotelListRequest();
            RequestHead RequestHead = new RequestHead();
            RequestHead.Language = "CN";
            RequestHead.LoginToken = loginres.LoginToken.ToString();
            RequestHead.GUID = Guid.NewGuid().ToString();
            #endregion
            HotelListReq.RequestHead = RequestHead;

            SubmitHotelOrderRequest.RequestHead = RequestHead;
            HotelOrderForSubmitHotelOrder order = new HotelOrderForSubmitHotelOrder();

            RoomForSubmitHotelOrder[] rooms = new RoomForSubmitHotelOrder[1];
            #region rooms

            RoomForSubmitHotelOrder room = new RoomForSubmitHotelOrder();
            room.ArrivalEarlyTime = SubmitOrderRequest.ArrivalEarlyTime;
            room.ArrivalLateTime = SubmitOrderRequest.ArrivalLateTime;
            room.CheckInDate = SubmitOrderRequest.CheckInDate;
            room.CheckOutDate = SubmitOrderRequest.CheckOutDate;
            room.ConfirmLanguageCode = SubmitOrderRequest.ConfirmLanguageCode;
            room.ConfirmTypeCode = SubmitOrderRequest.ConfirmTypeCode;
            ContacterForSubmitHotelOrder[] contacters = new ContacterForSubmitHotelOrder[1];
            #region contacters

            ContacterForSubmitHotelOrder contacter = new ContacterForSubmitHotelOrder();
            contacter.Name = SubmitOrderRequest.ContacterName;
            contacter.Mobile = SubmitOrderRequest.ContacterMobile;
            contacter.GenderCode = "2";//默认未知
            contacters[0] = contacter;
            #endregion
            room.Contacters = contacters;

            CreditCardForSubmitHotelOrder creditcard = new CreditCardForSubmitHotelOrder();
            #region creditcard
            creditcard.CardHolderName = SubmitOrderRequest.CardHolderName;
            creditcard.IdNumber = SubmitOrderRequest.IDNumber;
            creditcard.IdTypeCode = "0";//表示身份证
            creditcard.Number = SubmitOrderRequest.CardNumber;
            creditcard.ValidMonth = SubmitOrderRequest.ValidMonth;
            creditcard.ValidYear = SubmitOrderRequest.ValidYear;
            creditcard.VeryfyCode = SubmitOrderRequest.VeryfyCode;
            #endregion
            room.CreditCard = creditcard;

            room.CurrencyCode = SubmitOrderRequest.CurrencyCode;

            #region 解析客人信息
            string[] guestNames = SubmitOrderRequest.GuestNames.Split(',');
            string[] guestNations = SubmitOrderRequest.GuestNationals.Split(',');
            room.GuestAmount = guestNames.Count();
            GuestForSubmitHotelOrder[] guests = new GuestForSubmitHotelOrder[room.GuestAmount];
            for (int i = 0; i < room.GuestAmount; i++)
            {
                GuestForSubmitHotelOrder guest = new GuestForSubmitHotelOrder();
                guest.Name = guestNames[i];
                guest.GenderCode = "2";//默认未知
                if (guestNations != null && i < guestNations.Count())
                {
                    guest.Nationality = string.IsNullOrEmpty(guestNations[i]) ? "" : guestNations[i];
                }
                guests[i] = guest;
            }
            room.Guests = guests;
            #endregion

            room.GuestTypeCode = SubmitOrderRequest.GuestTypeCode;
            room.HotelId = SubmitOrderRequest.HotelId;
            room.PaymentTypeCode = "0";//默认前台自付
            room.RatePlanID = int.Parse(SubmitOrderRequest.RatePlanID);
            room.RoomAmount = SubmitOrderRequest.RoomAmount;
            room.RoomTypeId = SubmitOrderRequest.RoomTypeId;
            room.TotalPrice = SubmitOrderRequest.TotalPrice;

            rooms[0] = room;
            #endregion
            order.RoomGroups = rooms;

            SubmitHotelOrderRequest.HotelOrder = order;


            SubmitHotelOrderResponse = client.SubmitHotelOrder(SubmitHotelOrderRequest);
            #endregion

            #region 解析下单情况
            if (SubmitHotelOrderResponse.ResponseHead.ResultCode == "0")
            {
                OrderResponse.IsSubmitOrderSucceed = true;
                OrderResponse.OrderID = SubmitHotelOrderResponse.SubmitHotelOrderResult.HotelOrderID.ToString();
                OrderResponse.GuaranteeMoney = SubmitHotelOrderResponse.SubmitHotelOrderResult.GuaranteeMoney;
                OrderResponse.CancelDeadline = SubmitHotelOrderResponse.SubmitHotelOrderResult.CancelDeadline;


            }
            else
            {
                OrderResponse.FailedMessage = SubmitHotelOrderResponse.ResponseHead.ResultMessage;
            }
            #endregion
            return OrderResponse;
        }

        public bool SubmitOrder(nbapisdk_HotelOrder nbapisdk_HotelOrder)
        {
            return dal.SubmitOrder(nbapisdk_HotelOrder);
        }

        public nbapisdk_HotelOrder GetOrderdetail(string orderid)
        {
            return dal.GetOrderdetail(orderid);
        }

        public IList<nbapisdk_HotelOrder> GetOrderList(string memid)
        {
            return dal.GetOrderList(memid);
        }
    }
}
