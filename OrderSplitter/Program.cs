using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
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

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };
            using (var reader = new StreamReader("D:\\.Net\\OrderSplitter\\OrderSplitter\\orders.csv"))
            using (var csv = new CsvReader(reader, config))

            {
                ords.OrderList = csv.GetRecords<Dto>().ToList<Dto>();
            }

            ords.UniqueOrderList = ords.OrderList.Select(x => x.OrderNumber).Distinct().ToList<int>();

            using (var writer = new StreamWriter("D:\\.Net\\OrderSplitter\\OrderSplitter\\temp.csv"))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteHeader<Dto>();
                csvWriter.NextRecord();
                foreach (var record in ords.OrderList)
                {
                    if (record.OrderNumber == ords.UniqueOrderList.First())
                    {
                        csvWriter.WriteRecord(record);
                        csvWriter.NextRecord();
                    }
                }
            }
                Console.WriteLine("\nEnd");

            
        }
    }
    
}

