using System;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasChannelWebApp.Domain;
using GasChannelWebApp.Infrastructure;
using GasChannelWebApp.Models;

namespace GasChannelWebApp.Controllers
{
    [Authorize]
    public class VariantsController : Controller
    {
        IVariantsRepository _variants;
        IUserProfileRepository _users;

        public VariantsController()
            : this(new DALContext())
        {
        }

        public VariantsController(IDALContext context)
        {
            _variants = context.Variants;
            _users = context.Users;
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "ClearTable")]
        public ActionResult Index(Object sender)
        {
            GasChannelDB _database = new GasChannelDB();
            _database.Variants.RemoveRange(_database.Variants.Where(o => o.Owner.ID_User == _users.CurrentUser.ID_User));
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "LoadTable")]
        public ActionResult Index(Variants variants)
        {
            #region --- Ввод тестовых данных в базу данных

            Variants var_1 = new Variants { NameVariant = "Вариант 1", DateVariant = new DateTime(2020, 11, 01), Owner = _users.CurrentUser };
            _variants.InsertOrUpdate(var_1);
            _variants.Save();

            #endregion --- Ввод тестовых данных в базу данных

            return RedirectToAction("Index");
        }



        // GET: Variants
        public ActionResult Index()
        {
            return View(_users.CurrentUser.Variants.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Variants variants)
        {
            if (ModelState.IsValid)
            {
                variants.Owner = _users.CurrentUser;
                _variants.InsertOrUpdate(variants);
                _variants.Save();
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Variants/Edit/1
        //[Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        public ActionResult Edit(int id)
        {
            return View(_variants.All.FirstOrDefault(t => t.ID_Variant == id));
        }

        //
        // POST: /Variants/Edit/

        //[Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        [HttpPost]
        public ActionResult Edit(Variants variants)
        {
            if (ModelState.IsValid)
            {
                _variants.InsertOrUpdate(variants);
                _variants.Save();
            }
            return RedirectToAction("Index");
        }

        //
        // Edit: /Variants/Delete/1
        // [Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        public ActionResult Delete(int id)
        {
            return View(_variants.All.FirstOrDefault(t => t.ID_Variant == id));
        }

        //
        // POST: /Variants/Delete/1
        //[Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _variants.Remove(_variants.All.FirstOrDefault(t => t.ID_Variant == id));
            _variants.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_variants.All.FirstOrDefault(t => t.ID_Variant == id));
        }
    }
}