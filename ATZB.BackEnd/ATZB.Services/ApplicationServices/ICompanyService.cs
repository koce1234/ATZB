namespace ATZB.Services.ApplicationServices
{
    using ATZB.Domain.Models;

    public interface ICompanyService
    {
        void RegisterCompany(string userId, Company company);
    }
}
