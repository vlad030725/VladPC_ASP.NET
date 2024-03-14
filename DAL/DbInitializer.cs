using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbInitializer
    {
        private readonly ComputerStoreContext _context;

        public DbInitializer(ComputerStoreContext context)
        {
            _context = context;
        }

        public void Run()
        {

        }
    }
}
