using Green.Core;
using Green.Core.Data;
using Green.Core.Domain.Security;
using Green.Core.Domain.Tasks;
using Green.Core.Infrastructure;
using Green.Services.Configuration;
using Microsoft.AspNetCore.Hosting;


namespace Green.Services.Installation
{
    public partial class InstallationService : IInstallationService
    {
        #region Fields

        private readonly IRepository<ScheduleTask> _scheduleTaskRepository;
        private readonly IWebHelper _webHelper;
        private readonly IHostingEnvironment _hostingEnvironment;

        #endregion

        #region Ctor

        public InstallationService(
            IRepository<ScheduleTask> scheduleTaskRepository,
            IWebHelper webHelper,
            IHostingEnvironment hostingEnvironment)
        {
           this._scheduleTaskRepository = scheduleTaskRepository;
            this._webHelper = webHelper;
            this._hostingEnvironment = hostingEnvironment;
        }

        #endregion


   

        #region Methods

        protected virtual void InstallSettings(){
            
            var settingService = EngineContext.Current.Resolve<ISettingService>();

			settingService.SaveSetting(new SecuritySettings
			{
				ForceSslForAllPages = false,
				EncryptionKey = CommonHelper.GenerateRandomDigitCode(16)
			});
        }

        public virtual void InstallData(string defaultUserEmail = "amir.gholzam@live.com",
            string defaultUserPassword = "p@55w0rd", bool installSampleData = true)
        {
           

            InstallSettings();

            if (installSampleData)
            {
                
        
            }
        }

        #endregion
    }
}