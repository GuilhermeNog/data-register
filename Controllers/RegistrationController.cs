using DataRegistration.Models;
using DataRegistration.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DataRegistration.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }
        public IActionResult Index()
        {
            List<RegistrationModel> register = _registrationRepository.SearchAll();
            return View(register);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult CreateRegister(RegistrationModel registration)
        {
            _registrationRepository.AddData(registration);
            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int id)
        {
            RegistrationModel registration = _registrationRepository.ListById(id);
            return View(registration);
        }
        
        public IActionResult Change(RegistrationModel registration)
        {
            _registrationRepository.Update(registration);
            return RedirectToAction("Index");
        }

        public IActionResult ConfirmationDelete(int id)
        {
            RegistrationModel registration = _registrationRepository.ListById(id);
            return View(registration);
        }
        
        public IActionResult Delete(int id)
        {
            _registrationRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
