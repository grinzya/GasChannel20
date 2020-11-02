using GasChannelLib;
using GasChannelWebApp.Domain;
using GasChannelWebApp.Infrastructure;
using GasChannelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GasChannelWebApp.Controllers
{
    [Authorize] // К контроллеру получают доступ только аутентифицированные пользователи.
    public class InputDataVariantsController : Controller
    {
        // Dependency Injection
        // Данные поля будут хранит ссылки на реальные репозитории или на тестовые в соответствии с параметрами переданными в конструктор
        IInputDataVariantsRepository _inputDataVariants;
        IVariantsRepository _variants;
        IUserProfileRepository _users;

        public InputDataVariantsController()
            : this(new DALContext())
        {
        }
        public InputDataVariantsController(IDALContext context)
        {
            _variants = context.Variants;
            _inputDataVariants = context.InputDataVariants;
            _users = context.Users;
        }

        public ActionResult Index()
        {
            ViewBag.ID_Variant = new SelectList(_variants.All.Where(t => t.Owner.ID_User == _users.CurrentUser.ID_User), "ID_Variant", "NameVariant");
            return View(_users.CurrentUser.InputDataVariants.ToList());
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "ClearTable")]
        public ActionResult Index(Object sender)
        {
            GasChannelDB _database = new GasChannelDB();
            _database.InputDataVariants.RemoveRange(_database.InputDataVariants.Where(o => o.Owner.ID_User == _users.CurrentUser.ID_User));
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Filter")]
        public ActionResult Index(Variants variant)
        {
            if (variant.ID_Variant != 0) // если выбран элемент списка "Все", который прописан при формировании выпадающего списка в представлении Index
            {
                ViewBag.ID_Variant = new SelectList(_variants.All.Where(t => t.Owner.ID_User == _users.CurrentUser.ID_User), "ID_Variant", "NameVariant");
                return View(_users.CurrentUser.InputDataVariants.Where(t => t.ID_Variant == variant.ID_Variant).ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        ///Доделать

    }
}