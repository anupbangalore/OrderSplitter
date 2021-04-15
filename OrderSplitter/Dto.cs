using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSplitter
{

    // Defining the shape of the Order (data transfer object)
    class Dto
    {
        /*
         * Maintaining the same property names as given in the orders.csv file for simplicity reasons.
        */
        public int OrderNumber { get; set; }
        public int SKUs { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public Dto() { }
        
    }
}
