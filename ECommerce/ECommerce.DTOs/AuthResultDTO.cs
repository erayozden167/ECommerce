﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs
{
    public class AuthResultDTO
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
    }
}
