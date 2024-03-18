using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class CustomDto
    {
        public CustomDto(Custom c, List<CustomRowDto> thisCustomRows)
        {
            Id = c.Id;
            IdUser = c.IdUser;
            IdStatus = c.IdStatus;
            IdPromoCode = c.IdPromoCode;
            CreatedDate = c.CreatedDate;
            CustomRows = thisCustomRows;
            Sum = c.Sum;
        }
        public CustomDto() { }

        public int Id { get; set; }

        public int? Sum { get; set; }

        public int? IdUser { get; set; }

        public int? IdStatus { get; set; }

        public int? IdPromoCode { get; set; }

        public DateTime? CreatedDate { get; set; }

        public List<CustomRowDto> CustomRows { get; set; }
        public User User { get; set; }
    }
}
