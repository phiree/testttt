using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{  /// <summary>
    /// 产品更改后,修改使用本产品的团队
    /// </summary>
    public interface IProductPublisher
    {
        void AddObserver(IProductObserver observer);
        void RemoveObserver(IProductObserver observer);
        void NoticeObservers();
    }
}
