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

        public DJ_Product Copy()
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

            IList<DJ_Route> Routs=new List<DJ_Route>();
           // this.Routes.

            return product;
        }
    }
    
}
