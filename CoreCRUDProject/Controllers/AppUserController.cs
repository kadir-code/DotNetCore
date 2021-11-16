using CoreCRUDProject.Infrastructure.Repositories.Interface;
using CoreCRUDProject.Models.DTOs;
using CoreCRUDProject.Models.Entities.Abstract;
using CoreCRUDProject.Models.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUDProject.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IAppUserRepository _repo;

        public AppUserController(IAppUserRepository appUserRepository)
        {
            this._repo = appUserRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                _repo.Create(appUser);

                return View();
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult List()
        {
            return View(_repo.GetByDefaults(x=>x.Status!=Status.Passive));
        }

        public IActionResult Delete(int id)
        {
            AppUser appUser = _repo.GetByDefault(x=>x.Id==id);
            _repo.Delete(appUser);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            AppUser appUser = _repo.GetByDefault(x=>x.Id==id);
            UpdateAppUserDTO model = new UpdateAppUserDTO();
            model.Id = appUser.Id;
            model.FirstName = appUser.FirstName;
            model.LastName = appUser.LastName;

            return View(model);

        }

        [HttpPost]
        public IActionResult Update(UpdateAppUserDTO model)
        {
            if (ModelState.IsValid)
            {
            AppUser appUser = _repo.GetByDefault(x=>x.Id==model.Id);
            appUser.FirstName = model.FirstName;
            appUser.LastName = model.LastName;
            _repo.Update(appUser);

            return RedirectToAction("List");

            }
            else
            {
                return View(model);
            }
        }
    }
}
