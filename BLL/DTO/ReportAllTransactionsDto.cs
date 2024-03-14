using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReportAllTransactionsDto
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string TypeTransaction { get; set; }

        public int Sum { get; set; }

        public string UserLogin { get; set; }
    }
}
