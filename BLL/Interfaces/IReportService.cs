using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReportService
    {
        List<ReportAllTransactionsDto> ReportProfit(DateTime stDate, DateTime endDate, List<CustomDto> customs, List<ProcurementDto> procurements);
    }
}
