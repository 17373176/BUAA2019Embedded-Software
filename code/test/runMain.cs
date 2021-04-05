using our.webService.dal;
using our.webService.dal.imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace our.test
{
    public class runMain
    {
        public static void Main(string[] args)
        {
            try
            {
                ManagerDao aDao = new ManagerImp();
            }catch(Exception e) {
                Console.WriteLine("Exception: ", e.Message);
            }
        }

    }
}