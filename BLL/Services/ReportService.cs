using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Services;
using Interfaces.DTO;
using Interfaces.Repository;
using DomainModel;

namespace BLL.Services
{
    public class ReportService : IReportService
    {
        private IDbRepos db;

        public ReportService(IDbRepos db)
        {
            this.db = db;
        }

        public List<ReportAllTransactionsDto> ReportProfit(DateTime stDate, DateTime endDate, List<CustomDto> customs, List<ProcurementDto> procurements)
        {

            List<ReportAllTransactionsDto> result = new List<ReportAllTransactionsDto>();

            for (int i = 0; i < customs.Count; i++)
            {
                result.Add(new ReportAllTransactionsDto()
                {
                    Id = result.Count + 1,
                    CreatedDate = (DateTime)customs[i].CreatedDate,
                    TypeTransaction = "Заказ",
                    Sum = (int)customs[i].Sum,
                    UserLogin = GetUserCustom(customs[i].Id).Login
                });
            }

            for (int i = 0; i < procurements.Count; i++)
            {
                result.Add(new ReportAllTransactionsDto()
                {
                    Id = result.Count + 1,
                    CreatedDate = (DateTime)procurements[i].CreatedDate,
                    TypeTransaction = "Поставка",
                    Sum = -1 * (int)procurements[i].Sum,
                    UserLogin = ""
                });
            }

            result = result.Where(i => i.CreatedDate >= stDate && i.CreatedDate < endDate.AddDays(1)).OrderBy(x => x.CreatedDate).ToList();

            return result;
        }

        private UserDto GetUserCustom(int IdCustom)
        {
            return db.User.GetList().Select(i => new UserDto(i)).Single(i => i.Id == db.Custom.GetItem(IdCustom).IdUser);
        }
    }
}
