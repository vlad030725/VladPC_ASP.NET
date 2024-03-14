using Microsoft.EntityFrameworkCore;
using DAL;

using (ComputerStoreContext db = new ComputerStoreContext())
{
    db.Company.Select(i => i).ToList();
}
