using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IProm
    {
        IList<Model.PromotionStatic> GetPromById(int psid);
        Model.PromotionStatic GetPromByUsername(string username);
        void AddPromInfo(Model.PromotionStatic prom);
        void UpdatePromInfo(Model.PromotionStatic prom);
    }
}
