using Interfaces.Repository;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class DbReposPgs : IDbRepos
    {
        private ComputerStoreContext db;
        private ProductRepositoryPgs ProductRepository;
        private CompanyRepositoryPgs CompanyRepository;
        private TypeProductRepositoryPgs TypeProductRepository;
        private SocketRepositoryPgs SocketRepository;
        private CustomRepositoryPgs CustomRepository;
        private CustomRowRepositoryPgs CustomRowRepository;
        private FormFactorRepositoryPgs FormFactorRepository;
        private ProcurementRepositoryPgs ProcurementRepository;
        private UserRepositoryPgs UserRepository;
        private ProcurementRowRepositoryRow ProcurementRowRepository;
        private StatusRepositoryPgs StatusRepository;
        private TypeMemoryRepositoryPgs TypeMemoryRepository;
        private PromoCodeRepositoryPgs PromoCodeRepository;

        public DbReposPgs()
        {
            db = new ComputerStoreContext();
        }

        public IRepository<Product> Product
        {
            get
            {
                if (ProductRepository == null)
                    ProductRepository = new ProductRepositoryPgs(db);
                return ProductRepository;
            }
        }

        public IRepository<Company> Company
        {
            get
            {
                if (CompanyRepository == null)
                    CompanyRepository = new CompanyRepositoryPgs(db);
                return CompanyRepository;
            }
        }

        public IRepository<TypeProduct> TypeProduct
        {
            get
            {
                if (TypeProductRepository == null)
                    TypeProductRepository = new TypeProductRepositoryPgs(db);
                return TypeProductRepository;
            }
        }

        public IRepository<Socket> Socket
        {
            get
            {
                if (SocketRepository == null)
                    SocketRepository = new SocketRepositoryPgs(db);
                return SocketRepository;
            }
        }

        public IRepository<Custom> Custom
        {
            get
            {
                if (CustomRepository == null)
                    CustomRepository = new CustomRepositoryPgs(db);
                return CustomRepository;
            }
        }

        public IRepository<CustomRow> CustomRow
        {
            get
            {
                if (CustomRowRepository == null)
                    CustomRowRepository = new CustomRowRepositoryPgs(db);
                return CustomRowRepository;
            }
        }

        public IRepository<FormFactor> FormFactor
        {
            get
            {
                if (FormFactorRepository == null)
                    FormFactorRepository = new FormFactorRepositoryPgs(db);
                return FormFactorRepository;
            }
        }

        public IRepository<Procurement> Procurement
        {
            get
            {
                if (ProcurementRepository == null)
                    ProcurementRepository = new ProcurementRepositoryPgs(db);
                return ProcurementRepository;
            }
        }

        public IRepository<ProcurementRow> ProcurementRow
        {
            get
            {
                if (ProcurementRowRepository == null)
                    ProcurementRowRepository = new ProcurementRowRepositoryRow(db);
                return ProcurementRowRepository;
            }
        }

        public IRepository<Status> Status
        {
            get
            {
                if (StatusRepository == null)
                    StatusRepository = new StatusRepositoryPgs(db);
                return StatusRepository;
            }
        }

        public IRepository<TypeMemory> TypeMemory
        {
            get
            {
                if (TypeMemoryRepository == null)
                    TypeMemoryRepository = new TypeMemoryRepositoryPgs(db);
                return TypeMemoryRepository;
            }
        }

        public IRepository<User> User
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserRepositoryPgs(db);
                return UserRepository;
            }
        }

        public IRepository<PromoCode> PromoCode
        {
            get
            {
                if (PromoCodeRepository == null)
                    PromoCodeRepository = new PromoCodeRepositoryPgs(db);
                return PromoCodeRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges(true);
        }
    }
}
