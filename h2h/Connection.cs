﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h2h
{
    internal class Connection
    {
        public string MyCon()
        {
            string con = "Data Source=PC;Initial Catalog=test;User ID=sa;Password=Bookspot8130";
            return con;
        }

        public string ConH2H() 
        {
            string con = "Data Source=DESKTOP-GQRD8GC\\SQLEXPRESS;Initial Catalog=H2H;Integrated Security=True;Encrypt=False";
            return con;
        }
    }
}
