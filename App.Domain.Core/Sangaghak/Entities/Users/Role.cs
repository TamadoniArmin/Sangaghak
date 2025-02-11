﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Sangaghak.Entities.Users
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<UserBase> Users { get; set; }
    }
}
