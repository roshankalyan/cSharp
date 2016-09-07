﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using DataLayer;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            fileSelector.fileType = "csv";
            bool check = false;
          
            try
            {
                fileSelector.strfilename = @"C:\Users\Roshan\SkyDrive\user.csv";
                    if (!File.Exists(@"C:\Users\Roshan\SkyDrive\user.csv"))
                    throw new FileNotFoundException();
            }
            catch (FileNotFoundException e)
            {
                if(check == false)
                {
                    Console.WriteLine("pleases enter file filter type");
                    Filter.filter = (Console.ReadLine());
                    fileSelector.fileType = Filter.Cleaned();
                    check = true;

                }
                Console.WriteLine("pleases Select User file");
            fileSelector.fileSelectors();
            }
  IEnumerable<user> users = ingest.userReads(fileSelector.filepath());
            try
            {
                fileSelector.strfilename = @"C:\Users\Roshan\SkyDrive\location.csv";
                if (!File.Exists(@"C:\Users\Roshan\SkyDrive\location.csv"))
                    throw new FileNotFoundException();
            }
            catch (FileNotFoundException e)
            {
                if (check == false)
                {
                    Console.WriteLine("pleases enter file filter type");
                    Filter.filter = (Console.ReadLine());
                    fileSelector.fileType = Filter.Cleaned();
                    check = true;

                }
                Console.WriteLine("pleases Select location file");
                fileSelector.fileSelectors();
            }











            IEnumerable<Location> locations = ingest.locationReads(fileSelector.filepath());
          /*  var joined = from user in users
                         join location in locations
                         on user.locationID equals location.id
                         select new { users, locations }.;
            

    */
                         
            var userAddress = users.Where(e => e.locationID == "1").Select(e =>e )  ;

            var query = users.Filter(u => u.locationID == "1");
            foreach (var item in query )
            {
            Console.WriteLine(item.userName + " " + );
            }
           
            Console.ReadLine();


            
        }
    }
}
