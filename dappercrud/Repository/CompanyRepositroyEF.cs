/*using dappercrud.Data;
using dappercrud.Models;

namespace dappercrud.Repository
{
    public class CompanyRepositroyEF : ICompanyRepository
    {
        private readonly ApplicaionDbContext _db;

        public CompanyRepositroyEF(ApplicaionDbContext db)
        {
            _db = db;
        }
    
        public Company Add(Company company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
            return company;
        }

        public Company Find(int id)
        {
            return _db.Companies.Find(id);
        }

        public List<Company> GetAll()
        {
            return _db.Companies.ToList();
        }

        public void Remove(int id)
        {
            Company company = _db.Companies.Find(id);
            if (company != null)
            {
                _db.Companies.Remove(company);
                _db.SaveChanges();
                
            }
            
        }

        public Company Update(Company company)
        {
            _db.Companies.Update(company);
            _db.SaveChanges();
            return company;
        }
    }
}
*/