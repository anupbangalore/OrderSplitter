using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSplitter
{
    /*
     * Class to define the Orders as an object so as to make 
     * CsvHelper context to operate for read and write.
     * 
     */

    class Orders
    {
        // Holds the orders
        public List<Dto> OrderList { get; set; }

        // Holds all the unique order numbers
        public List<int> UniqueOrderList { get; set; }


        public Orders()
        {
            this.OrderList = new List<Dto>();
            this.UniqueOrderList = new List<int>();
        }

        
    }


}
