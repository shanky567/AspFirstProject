﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Employee
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }

    }
}