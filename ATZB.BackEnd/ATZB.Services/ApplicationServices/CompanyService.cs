namespace ATZB.Services.ApplicationServices
{
    using ATZB.Data.DataContext;
    using ATZB.Domain.Models;

    public class CompanyService : ICompanyService
    {
        private readonly ATZBDbContext _context;

        public CompanyService(ATZBDbContext context)
        {
            _context = context;
        }

        public void RegisterCompany(string userId , Company company)
        {
            throw new System.NotImplementedException();
        }
    }
}
