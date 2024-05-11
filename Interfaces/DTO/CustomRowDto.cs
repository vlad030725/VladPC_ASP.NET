using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class CustomRowDto
    {
        public CustomRowDto(CustomRow r, List<ProductDto> products)
        {
            Id = r.Id;
            IdCustom = r.IdCustom;
            IdProduct = r.IdProduct;
            ProductName = products.FirstOrDefault(i => i.Id == IdProduct) == null? null: products.FirstOrDefault(i => i.Id == IdProduct).Name;
            Price = r.Price;
            Count = r.Count;
            Product = products.Where(i => i.Id == IdProduct).SingleOrDefault();
        }

        public CustomRowDto() { }

        public int Id { get; set; }

        public int? IdCustom { get; set; }

        public int? IdProduct { get; set; }

        public string? ProductName { get; set; }

        public int? Price { get; set; }

        public int? Count { get; set; }

        public ProductDto? Product { get; set; }
    }
}
