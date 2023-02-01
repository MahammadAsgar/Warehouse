﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Product:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Lenght { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int MeatureTypeId { get; set; }
        public MeatureType MeatureType { get; set; }
        public double UnitOfMeasure { get; set; }
        public IEnumerable<ProductFile> ProductFiles { get; set; }
    }
}