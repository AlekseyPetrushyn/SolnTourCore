﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Presentation.ViewModels
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string MobilNumber { get; set; }
        public string Email { get; set; }
        public DiscountViewModel Discount { get; set; }
        public int DiscountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
