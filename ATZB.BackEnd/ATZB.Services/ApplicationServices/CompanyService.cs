namespace ATZB.Services.ApplicationServices
{
    using ATZB.Data.DataContext;
    using ATZB.Domain.Models;
    using System.Linq;

    public class CompanyService : ICompanyService
    {
        private readonly ATZBDbContext _context;

        public CompanyService(ATZBDbContext context)
        {
            _context = context;
        }

        public void RegisterCompany(string userId , Company company)
        {
            _context.Companies.Add(company);

            _context.SaveChanges();

            var kur = _context.Companies
                .FirstOrDefault(x => x.UserId == userId)
                .Id;

            var putka = _context.Users.FirstOrDefault(x => x.Id == userId);

            putka.CompanyId = kur;

            _context.SaveChanges();
        }
    }
}
