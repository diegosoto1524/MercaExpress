﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int IdClient { get; set; }  
        public DateTime Date { get; set; }


    }
}
