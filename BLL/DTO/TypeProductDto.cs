﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TypeProductDto
    {
        public TypeProductDto(TypeProduct tp)
        {
            Id = tp.Id;
            Name = tp.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
