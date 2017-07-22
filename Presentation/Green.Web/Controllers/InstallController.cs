using Green.Services.Installation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Green.Web.Controllers
{
    [Route("api/[controller]")]
    public class InstallController : Controller
    {


        #region Fields

        private readonly IInstallationService _installationService;

		#endregion


		#region Constructor

		public InstallController(IInstallationService installationService)
		{
            this._installationService = installationService;
		}

		#endregion

		#region Methods

		[HttpGet()]
		public IActionResult Get()
		{

            _installationService.InstallData();

			return Ok();
		}

        #endregion



    }
}
