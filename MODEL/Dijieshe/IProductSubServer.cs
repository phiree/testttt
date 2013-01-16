using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 团队自动修改路线信息,当其使用的产品发生变化之时.
    /// </summary>
	public interface IProductObserver
	{
        void BeNoticed();
	}
}
