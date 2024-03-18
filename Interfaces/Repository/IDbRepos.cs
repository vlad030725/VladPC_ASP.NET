using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.Repository;

public interface IDbRepos
{
    IRepository<Product> Product { get; }
    IRepository<TypeProduct> TypeProduct { get; }
    IRepository<Company> Company { get; }
    IRepository<Socket> Socket { get; }
    IRepository<Custom> Custom { get; }
    IRepository<CustomRow> CustomRow { get; }
    IRepository<FormFactor> FormFactor { get; }
    IRepository<Procurement> Procurement { get; }
    IRepository<ProcurementRow> ProcurementRow { get; }
    IRepository<Status> Status { get; }
    IRepository<TypeMemory> TypeMemory { get; }
    IRepository<User> User { get; }
    IRepository<PromoCode> PromoCode { get; }
    int Save();
}
