using GasChannelLib;
using GasChannelWebApp.Domain;
using GasChannelWebApp.Infrastructure;
using GasChannelWebApp.Models;
using System;
using System.Net;
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

        // POST: /InputDataVariants/
        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "LoadTable")]
        public ActionResult Index(InputDataVariants inputDataVariants)
        {
            GasChannelDB _database = new GasChannelDB();

            #region --- Ввод тестовых данных в базу данных       

            int _ID_Variant_1 = _database.Variants.Where(p => p.NameVariant == "Вариант 1" && p.Owner.ID_User == _users.CurrentUser.ID_User).First().ID_Variant;
            InputDataVariants inputDataVariants_1 = new InputDataVariants
            {
                ID_Variant = _ID_Variant_1,
                Kol_prod_gorenija = 19165,
                Ro_0 = 1.28,
                Ro_v = 1.29,
                H_pechi = 3.55,
                L_pechi = 2.15,
                T_fume = 1223,
                T_fume_v = 1198,
                L_vert = 1,
                b_vert = 0.7,
                H_vert = 3,
                lambda_vert = 0.05,
                L_bor_vert_rek = 11,
                Td_rek_fume_bor = 1176,
                Tv_bor = 293,
                H_bor = 2.15,
                L_bor = 6,
                T_rek = 450,
                L_rek = 1.4,
                W_rek = 2.5,
                d_trub_rek = 57,
                T_rek_vh = 1176,
                W0_rek = 4.8,                
                n_trub = 14,
                T_trub = 593,
                d_h_diag = 8,
                fi_s1 = 0.95,
                fi_s2 = 1,
                fi_d = 1.11,
                fi_t_st = 1.06,
                Owner = _users.CurrentUser
            };
            _inputDataVariants.InsertOrUpdate(inputDataVariants_1);
            _inputDataVariants.Save();

            #endregion --- Ввод тестовых данных в базу данных

            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            ViewBag.ID_Variant = new SelectList(_variants.All.Where(t => t.Owner.ID_User == _users.CurrentUser.ID_User), "ID_Variant", "NameVariant");
            return View();
        }

        [HttpPost]
        public ActionResult Create(InputDataVariants inputDataVariants)
        {
            if (ModelState.IsValid)
            {
                inputDataVariants.Owner = _users.CurrentUser;
                _inputDataVariants.InsertOrUpdate(inputDataVariants);
                _inputDataVariants.Save();
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /InputDataVariants/Edit/1
        //[Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        public ActionResult Edit(int id)
        {
            ViewBag.ID_Variant = new SelectList(_variants.All.Where(t => t.Owner.ID_User == _users.CurrentUser.ID_User), "ID_Variant", "NameVariant");
            return View(_inputDataVariants.All.FirstOrDefault(t => t.ID_InputDataVariant == id));
        }

        //
        // POST: /InputDataVariants/Edit/

        //[Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        [HttpPost]
        public ActionResult Edit(InputDataVariants inputDataVariants)
        {
            if (ModelState.IsValid)
            {
                _inputDataVariants.InsertOrUpdate(inputDataVariants);
                _inputDataVariants.Save();
            }
            return RedirectToAction("Index");
        }

        //
        // Edit: /InputDataVariants/Delete/1
        // [Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        public ActionResult Delete(int id)
        {
            return View(_inputDataVariants.All.FirstOrDefault(t => t.ID_InputDataVariant == id));
        }

        //
        // POST: /InputDataVariants/Delete/1
        //[Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _inputDataVariants.Remove(_inputDataVariants.All.FirstOrDefault(t => t.ID_InputDataVariant == id));
            _inputDataVariants.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_inputDataVariants.All.FirstOrDefault(t => t.ID_InputDataVariant == id));
        }

    }
}