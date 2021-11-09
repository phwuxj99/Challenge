using Challenge.Models;
using Challenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Challenge.Controllers
{

    /// <summary>
    /// Insurance Policiy API 
    /// </summary>                
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("InsurancePolicies")]
    public class InsurancePoliciesController : ControllerBase
    {
        #region private properties 


        private IConfiguration configuration;
        private IInsurancePolicyRepository insurancePolicyRepository;


        #endregion


        #region public properties

        public InsurancePoliciesController(IConfiguration configuration, IInsurancePolicyRepository insurancePolicyRepository)
        {

            this.configuration = configuration;
            this.insurancePolicyRepository = insurancePolicyRepository;            

        }

        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [Produces("application/json")]
        [Route("InsurancePolicy", Name = "CreateInsurancePolicies")]
        [HttpPost]
        public async Task<IActionResult> CreateInsurancePoliciesAsync([FromQuery] InsurancePolicy insurancePolicy)
        {
            int returnValue;
            string jsonString = string.Empty;

            try
            {

                (returnValue, jsonString) = insurancePolicyRepository.CreateInsurancePolicy(insurancePolicy);
                jsonString = "Successfully!";

            }
            catch (Exception ex)
            {
                jsonString = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, jsonString);
            }

            return StatusCode(StatusCodes.Status200OK, jsonString);
        }

        #endregion
    }
}
