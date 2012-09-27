using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 产品
    /// </summary>
    public class DJ_Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        /// <summary>
        /// 产品模板:具体的产品信息会复制模板产品,并在此基础上做修改(如果必要)
        /// </summary>
        public virtual bool IsTemplate { get; set; }
        /// <summary>
        /// 天数
        /// </summary>
        public virtual int DaysAmount { get; set; }
        /// <summary>
        /// 行程安排
        /// </summary>
        public virtual IList<DJ_Route> Routes { get; set; }

        public virtual DJ_Product Copy()
        {
            if (!IsTemplate)
            {
                throw new Exception("只有模板产品才可以复制");
            }
            DJ_Product product = new DJ_Product();
            product.Id = Guid.NewGuid();
            product.Name = this.Name;
            product.IsTemplate = false;
            product.DaysAmount = this.DaysAmount;

            DJ_Route[] routesArr = new DJ_Route[] { };
            // this.Routes.
            this.Routes.CopyTo(routesArr, 0);
            IList<DJ_Route> newRoutes = new List<DJ_Route>();
            foreach (DJ_Route r in routesArr)
            {
                newRoutes.Add(r);
            }
            product.Routes = newRoutes;
           

            return product;
        }

        public virtual DJ_DijiesheInfo DJ_DijiesheInfo { get; set; }
    }

}
