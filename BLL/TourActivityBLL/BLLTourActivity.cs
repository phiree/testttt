using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
namespace BLL
{
    public class BLLTourActivity : BLLBase<TourActivity>
    {
        DALTourActivity dalTourActivity;
        public DAL.DALTourActivity DalTourActivity {
            get {
                if (dalTourActivity == null)
                {
                    dalTourActivity = new DALTourActivity();
                }
                return dalTourActivity;
            }
            set {
                dalTourActivity = value;
            }
        }
        public TourActivity GetOneByActivityCode(string activityCode)
        {
            return DalTourActivity.GetOneCode(activityCode);
        }
   }
}
