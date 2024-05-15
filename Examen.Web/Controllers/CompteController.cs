using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class CompteController : Controller
    {
        IServiceCompte serviceCompte;
        IServiceBanque serviceBanque;

        public CompteController(IServiceCompte serviceCompte, IServiceBanque serviceBanque)
        {
            this.serviceCompte = serviceCompte;
            this.serviceBanque = serviceBanque;
        }

        // GET: CompteController
        public ActionResult Index(TypeCompte TypeCompte)
        {
            if (TypeCompte == null)
                return View(serviceCompte.GetMany());
            else
                return View(serviceCompte.GetMany(f => f.Type.Equals(TypeCompte)));

        }

        // GET: CompteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompteController/Create
        public ActionResult Create()
        {
            ViewBag.BanqueList = new SelectList(serviceBanque.GetAll(),"Code","Nom");
            return View();
        }

        // POST: CompteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compte compte)
        {
            
                serviceCompte.Add(compte);
                serviceCompte.Commit();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: CompteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
