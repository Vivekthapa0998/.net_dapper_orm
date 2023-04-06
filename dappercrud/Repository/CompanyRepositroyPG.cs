using Dapper;
//using dappercrud.Data;
using dappercrud.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Npgsql;

namespace dappercrud.Repository
{
    public class CompanyRepositroyPG : ICompanyRepository
    {
        private IDbConnection _db;

        public CompanyRepositroyPG(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnections"));
        }
    
        public Company Add(Company company)
        {
           // var sql = "INSERT INTO Companies (Name,Address,City,State,PostalCode) VALUES (@Name,@Address,@City,@State,@PostalCode)" +
           //          "SELECT CAST(SCOPE_IDENTITY() as int); ";
            var sql = "INSERT INTO Companies (Name,Address,City,State,PostalCode) VALUES (@Name,@Address,@City,@State,@PostalCode)" +
                     "RETURNING CompanyId; ";

            var id = _db.Query<int>(sql, new
            { 
            @Name=company.Name,
            @Address=company.Address,
            @City=company.City,
            @State=company.State,
            @PostalCode=company.PostalCode
            }).Single();
            company.CompanyId= id;
            return company;
            
        }

        public Company Find(int id)
        {
            var sql = "SELECT * FROM Companies WHERE Companyid = @Companyid";
            return _db.Query<Company>(sql, new { @Companyid= id}).Single();
        }

        public List<Company> GetAll()
        {
            
            var sql = "SELECT * FROM Companies";
            return _db.Query<Company>(sql).ToList();
            
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Companies WHERE CompanyId=@Id";
            _db.Execute(sql, new { @Id = id });
            
        }

        public Company Update(Company company)
        {
            var sql = "UPDATE Companies SET Name=@Name, Address=@Address, City=@City, State= @State, PostalCode= @PostalCode " +
                    "WHERE CompanyId=@CompanyId;";
            _db.Execute(sql, new 
            {
                @CompanyId= company.CompanyId,
                @Name=company.Name,
                @Address=company.Address,
                @City=company.City,
                @State=company.State,
                @PostalCode=company.PostalCode,
            });
            return company;
        }
    }
}
