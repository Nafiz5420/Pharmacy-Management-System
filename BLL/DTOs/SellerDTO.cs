﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SellerDTO
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Section { get; set; }
    }
}