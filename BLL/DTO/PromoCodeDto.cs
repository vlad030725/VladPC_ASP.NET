using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PromoCodeDto
    {
        public PromoCodeDto(PromoCode promoCode)
        {
            Id = promoCode.Id;
            Code = promoCode.Code;
            Discount = promoCode.Discount;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public double Discount { get; set; }
    }
}
