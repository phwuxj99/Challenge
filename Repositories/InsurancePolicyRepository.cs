using Challenge.Models;
using Newtonsoft.Json;

namespace Challenge.Repositories
{
    public class InsurancePolicyRepository : IInsurancePolicyRepository
    {


        #region properties and constructor


        private IConfiguration config;
        private string registryKey;

        private readonly IWebHostEnvironment webHostEnvironment;

        /// <summary>
        /// Insurance Policy Repository
        /// </summary>
        /// <param name="config">config</param>
        public InsurancePolicyRepository(IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            this.config = config;
            this.webHostEnvironment = webHostEnvironment;
            // registryKey = config.GetSection("Registry:Key").Get<string>();
        }


        #endregion


        #region public methods


        /// <summary>
        /// Create insurance policy
        /// </summary>
        /// <param name="insurancePolicy">insurance policy</param>
        /// <returns></returns>
        public (int returnValue, string returnString) CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            int returnValue = 0;
            string returnStr = "Successfully";

            string jsonDataPath = webHostEnvironment.ContentRootPath + @"\data\InsurancePolicies.json";
            List<InsurancePolicy> tempDate = new List<InsurancePolicy>();
            InsurancePolicy D = new InsurancePolicy();
            D.FirstName = insurancePolicy.FirstName;
            D.LastName = insurancePolicy.LastName;
            D.Premium = insurancePolicy.Premium;
            D.PrincipalRegulator = insurancePolicy.PrincipalRegulator;
            D.Vehicledetails = insurancePolicy.Vehicledetails;
            D.Address = insurancePolicy.Address;
            D.DriversLicense = D.DriversLicense;
            D.EffectiveDate = insurancePolicy.EffectiveDate;
            D.ExpirationDate = insurancePolicy.ExpirationDate;
            tempDate.Add(D);

            string jsonResult = JsonConvert.SerializeObject(tempDate, Formatting.Indented);

            if (File.Exists(jsonDataPath))
            {
                File.AppendAllText(jsonDataPath, jsonResult);
            }
            else
            {
                System.IO.File.WriteAllText(jsonDataPath, jsonResult);
            }


            return (returnValue, returnStr);
        }


        #endregion
    }
}
