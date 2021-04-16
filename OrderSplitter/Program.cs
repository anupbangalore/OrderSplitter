using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace OrderSplitter
{
    class Program
    {

        static void Main(string[] args)
        {
            Orders ords = new Orders();

            /*
             * 1. Reading orders.csv using CsvHelper library
             */
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };
            using (var reader = new StreamReader("D:\\.Net\\OrderSplitter\\OrderSplitter\\orders.csv"))
            using (var csv = new CsvReader(reader, config))

            {
                ords.OrderList = csv.GetRecords<Dto>().ToList<Dto>();
            }

            // Getting unique list of order numbers
            ords.UniqueOrderList = ords.OrderList.Select(x => x.OrderNumber).Distinct().ToList<int>();

            // Ordering the order list in case the order numbers are not sorted
            ords.OrderList = ords.OrderList.OrderBy(ord => ord.OrderNumber).ToList();

            string filename = null;

            /*
             * 2 & 3. Using unique order list to make the individual files and 
             * writing a seperate csv for earch order number
             */

            foreach (var uo in ords.UniqueOrderList)
            {
                filename = "D:\\.Net\\OrderSplitter\\OrderSplitter\\" + uo + "_" + 
                    DateTime.Now.ToString("yyyyMMddTHHmmss")+ ".csv";

                using (var writer = new StreamWriter(filename))
                using (var csvWriter = new CsvWriter(writer, config))
                {
                    csvWriter.WriteHeader<Dto>();
                    csvWriter.NextRecord();

                    foreach(var record in ords.OrderList)
                    {
                        if (record.OrderNumber == uo)
                        {
                            csvWriter.WriteRecord(record);
                            csvWriter.NextRecord();

                        }
                    }

                }
            }
 
            Console.WriteLine("\nEnd...!!!");
        }
    }
    
}

