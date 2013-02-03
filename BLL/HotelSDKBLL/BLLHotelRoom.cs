using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelModel.HotelSDKModel;

namespace BLL
{
    public class BLLHotelRoom
    {
        DAL.DALHotel DataBaseManager = new DAL.DALHotel();

        public IList<RoomDetailinfo> GetRoomDetailinfo(string HotelId, string RoomtypeId)
        {
            return DataBaseManager.GetRoomDetailinfo(HotelId, RoomtypeId);
        }
    }
}
