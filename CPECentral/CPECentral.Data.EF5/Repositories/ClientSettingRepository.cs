using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.Data.EF5.Repositories
{
    public class ClientSettingRepository : RepositoryBase<ClientSetting>
    {
        public ClientSettingRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public string GetWindowsDataDirectory()
        {
            return UnitOfWork.Entities.ClientSettings.First().WindowsDataDirectory;
        }
    }
}
