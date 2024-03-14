using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProcurementRowDto
    {
        public ProcurementRowDto(ProcurementRow r, List<ProductDto> products)
        {
            Id = r.Id;
            IdProcurement = r.IdProcurement;
            IdProduct = r.IdProduct;
            Price = r.Price;
            Count = r.Count;
            Product = products.Where(i => i.Id == IdProduct).Single();

        }

        public int Id { get; set; }

        public int? IdProduct { get; set; }

        public int? IdProcurement { get; set; }

        public int? Price { get; set; }
        public int? Count { get; set; }

        public ProductDto Product { get; set; }
    }
}
