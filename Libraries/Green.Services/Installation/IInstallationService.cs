
namespace Green.Services.Installation
{
    public partial interface IInstallationService
    {
        void InstallData(string defaultUserEmail = "amir.gholzam@live.com", string defaultUserPassword = "p@55w0rd", bool installSampleData = true);
    }
}
