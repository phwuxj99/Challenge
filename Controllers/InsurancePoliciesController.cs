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

        //private ILogger logger;
        private IConfiguration configuration;
        private IInsurancePolicyRepository insurancePolicyRepository;
        //private string registryKey;
        //private DBConnectionType connectionType;
        //private IEventNotificationRepository eventNotficationRepository;

        #endregion


        #region public properties

        public InsurancePoliciesController(IConfiguration configuration, IInsurancePolicyRepository insurancePolicyRepository)
        {

            this.configuration = configuration;
            this.insurancePolicyRepository = insurancePolicyRepository;
            //this.logger = logger;
            //this.eventNotficationRepository = eventNotficationRepository;
            //this.registryKey = configuration.GetSection("Registry:Key").Get<string>();

            //#region Connection type set up
            //connectionType = new DBConnectionType()
            //{
            //    ConnectionSource = DBConnectionSource.REGISTRY,
            //    RegistryKey = this.registryKey
            //};
            //#endregion

        }

        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [Produces("application/json")]
        //[Route("InsurancePolicy")]
        [Route("InsurancePolicy", Name = "CreateInsurancePolicies")]
        [HttpPost]
        public async Task<IActionResult> CreateInsurancePoliciesAsync([FromQuery] InsurancePolicy insurancePolicy)
        {
            int returnValue;
            string jsonString = string.Empty;
            //var insurancePolicies = new InsurancePolicy() { FirstName="stephen", LastName="wu" };
            try
            {
                ////Basic validation. Also used by unit test
                //if (notificationId <= 0)
                //{
                //    return BadRequest(notificationId);
                //}

                (returnValue, jsonString) = insurancePolicyRepository.CreateInsurancePolicy(insurancePolicy);

                //if (returnValue != const_db_return_value_success ||
                //    string.IsNullOrWhiteSpace(jsonEventNotificationDetails))
                //{
                //    return NotFound(notificationId);
                //}
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            //return StatusCode(StatusCodes.Status200OK, jsonEventNotificationDetails);
            return StatusCode(StatusCodes.Status200OK, jsonString);
        }

        #endregion
    }
}
