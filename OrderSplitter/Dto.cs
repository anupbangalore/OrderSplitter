using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSplitter
{

    // Defining the shape of the Order (data transfer object)
    class Dto
    {
        public string orderNumber { get; set; }
        public string sku { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string quantity { get; set; }
        public string weight { get; set; }
    }
}
