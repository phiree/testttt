using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 产品
    /// </summary>
    public class DJ_Product:IProductPublisher
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        /// <summary>
        /// 产品模板:具体的产品信息会复制模板产品,并在此基础上做修改(如果必要)
        /// </summary>
       
        /// <summary>
        /// 天数
        /// </summary>
        public virtual int DaysAmount { get; set; }
        /// <summary>
        /// 行程安排
        /// </summary>
        public virtual IList<DJ_ProductRoute> Routes { get; set; }
        public virtual DJ_DijiesheInfo DJ_DijiesheInfo { get; set; }
        public virtual void CopyToGroup(DJ_TourGroup group)
        {
            group.Routes.Clear();
            foreach (DJ_ProductRoute pr in Routes)
            {
                DJ_Route r = new DJ_Route();
                r.DJ_TourGroup = group;
                r.DayNo = pr.DayNo;
                r.Description = pr.Description;
                r.Enterprise = pr.Enterprise;
                r.RD_EnterpriseName = pr.RD_EnterpriseName;
                group.Routes.Add(r);
            }
        }
        IList<IProductObserver> observers = new List<IProductObserver>();
        public virtual void AddObserver(IProductObserver observer)
        {
            observers.Add(observer);
        }

        public virtual void RemoveObserver(IProductObserver observer)
        {
            observers.Remove(observer);
        }

        public virtual void NoticeObservers()
        {
            foreach (IProductObserver observer in observers)
            {
                observer.BeNoticed();
            }
        }
    }

}
