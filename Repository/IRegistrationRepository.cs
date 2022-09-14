using DataRegistration.Models;
using System.Collections.Generic;

namespace DataRegistration.Repository
{
    public interface IRegistrationRepository
    {
        RegistrationModel AddData(RegistrationModel registration);

        RegistrationModel ListById(int id);

        List<RegistrationModel> SearchAll();

        RegistrationModel Update(RegistrationModel registration);

        bool Delete(int id);

    }
}
