using DataRegistration.Data;
using DataRegistration.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataRegistration.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly BancoContext _context;

        public RegistrationRepository(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public RegistrationModel ListById(int id)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public List<RegistrationModel> SearchAll()
        {
            return _context.Contacts.ToList();
        }

        public RegistrationModel AddData(RegistrationModel registration)
        {
            _context.Contacts.Add(registration);
            _context.SaveChanges();
            return registration;
        }

        public RegistrationModel Update(RegistrationModel registration)
        {
            RegistrationModel registrationDB = ListById(registration.Id);

            if (registrationDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            registrationDB.Id = registration.Id;
            registrationDB.Name = registration.Name;
            registrationDB.Email = registration.Email;
            registrationDB.Cpf = registration.Cpf;
            registrationDB.Phone = registration.Phone;

            _context.Contacts.Update(registrationDB);
            _context.SaveChanges();

            return registrationDB;
        }

        public bool Delete(int id)
        {
            RegistrationModel registrationDB = ListById(id);

            if (registrationDB == null) throw new System.Exception("Houve um erro em deletar o contato!");

            _context.Contacts.Remove(registrationDB);
            _context.SaveChanges();

            return true;
        }
    }
}
