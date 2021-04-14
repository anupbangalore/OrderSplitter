using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSplitter
{
    class Orders
    {
        public List<Dto> OrderList { get; set; }

        public Orders()
        {
            this.OrderList = new List<Dto>();
        }

        public void addOrder(Dto nextorder)
        {
            OrderList.Add(nextorder);
        }
    }
}
