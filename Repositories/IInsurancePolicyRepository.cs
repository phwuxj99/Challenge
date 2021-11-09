using Challenge.Models;

namespace Challenge.Repositories
{
    public interface IInsurancePolicyRepository
    {
        (int returnValue, string returnString) CreateInsurancePolicy(InsurancePolicy insurancePolicy);

    }
}
