using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
public class RoutesChangedEventArgs : EventArgs
{
    public IList<DJ_ProductRoute> ProductRoutes { get; set; }
}