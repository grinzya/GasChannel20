using GasChannelLib;
using GasChannelWebApp.Domain;
using GasChannelWebApp.Infrastructure;
using GasChannelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;


namespace GasChannelWebApp.Controllers
{
    public class HomeController : Controller
    {
        IUserProfileRepository _users;
        IVariantsRepository _variants;
        IInputDataVariantsRepository _inputDataVariants;

        public HomeController()
          : this(new DALContext())
        {
        }

        public HomeController(IDALContext context)
        {
            _users = context.Users;
            _variants = context.Variants;
            _inputDataVariants = context.InputDataVariants;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Demo()
        {
            GasChannelDB gcdb = new GasChannelDB();
            if (gcdb.Variants.Where(p => p.Owner.ID_User == _users.CurrentUser.ID_User).FirstOrDefault() == null)
            {
                double _Kol_prod_gorenija = 19165;
                double _Ro_0 = 1.28;
                double _Ro_v = 1.29;
                double _H_pechi = 3.55;
                double _L_pechi = 2.15;
                double _T_fume = 1223;
                double _T_fume_v = 1198;
                double _L_vert = 1;
                double _b_vert = 0.7;
                double _H_vert = 3;
                double _lambda_vert = 0.05;
                double _L_bor_vert_rek = 11;
                double _Td_rek_fume_bor = 1176;
                double _Tv_bor = 293;
                double _T_rek = 450;
                double _L_rek = 1.4;
                double _W_rek = 2.5;
                double _d_trub_rek = 57;
                double _T_rek_vh = 1176;
                double _W0_rek = 4;
                int _n_trub = 14;
                double _T_trub = 593;
                double _d_h_diag = 8;
                double _fi_s1 = 0.95;
                double _fi_s2 = 1;
                double _fi_d = 1.11;
                double _fi_t_st = 1.06;
                string _NameDefaultVariant = "Шаблон";

                Variants var_default = new Variants
                {
                    NameVariant = _NameDefaultVariant,
                    DateVariant = System.DateTime.Now,
                    Owner = _users.CurrentUser
                };
                _variants.InsertOrUpdate(var_default);
                _variants.Save();

                int _ID_Variant_new = gcdb.Variants.Where(p => p.NameVariant == _NameDefaultVariant && p.Owner.ID_User == _users.CurrentUser.ID_User).First().ID_Variant;
                InputDataVariants inputDataVariants_new = new InputDataVariants
                {
                    ID_Variant = _ID_Variant_new,
                    Kol_prod_gorenija = _Kol_prod_gorenija,
                    Ro_0 = _Ro_0,
                    Ro_v = _Ro_v,
                    H_pechi = _H_pechi,
                    L_pechi = _L_pechi,
                    T_fume = _T_fume,
                    T_fume_v = _T_fume_v,
                    L_vert = _L_vert,
                    b_vert = _b_vert,
                    H_vert = _H_vert,
                    lambda_vert = _lambda_vert,
                    L_bor_vert_rek = _L_bor_vert_rek,
                    Td_rek_fume_bor = _Td_rek_fume_bor,
                    Tv_bor = _Tv_bor,
                    T_rek = _T_rek,
                    L_rek = _L_rek,
                    W_rek = _W_rek,
                    d_trub_rek = _d_trub_rek,
                    T_rek_vh = _T_rek_vh,
                    W0_rek = _W0_rek,
                    n_trub = _n_trub,
                    T_trub = _T_trub,
                    d_h_diag = _d_h_diag,
                    fi_s1 = _fi_s1,
                    fi_s2 = _fi_s2,
                    fi_d =_fi_d,
                    fi_t_st = _fi_t_st,
                    Owner = _users.CurrentUser
                };
                _inputDataVariants.InsertOrUpdate(inputDataVariants_new);
                _inputDataVariants.Save();
            }

            int _ID_Variant_First = gcdb.Variants.First(p => p.Owner.ID_User == _users.CurrentUser.ID_User).ID_Variant;

            GasChannelLib.GasChannelLib gcl = new GasChannelLib.GasChannelLib();

            #region --- Задать исходные данные для первого найденного варианта

            gcl.Kol_prod_gorenija = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).Kol_prod_gorenija;
            gcl.Ro_0 = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).Ro_0;
            gcl.Ro_v = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).Ro_v;
            gcl.H_pechi = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).H_pechi;
            gcl.L_pechi = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).L_pechi;
            gcl.T_fume = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).T_fume;
            gcl.T_fume_v = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).T_fume_v;
            gcl.L_vert = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).L_vert;
            gcl.b_vert = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).b_vert;
            gcl.H_vert = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).H_vert;
            gcl.lambda_vert = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).lambda_vert;
            gcl.L_bor_vert_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).L_bor_vert_rek;
            gcl.Td_rek_fume_bor = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).Td_rek_fume_bor;
            gcl.Tv_bor = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).Tv_bor;
            gcl.T_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).T_rek;
            gcl.L_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).L_rek;
            gcl.W_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).W_rek;
            gcl.d_trub_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).d_trub_rek;
            gcl.T_rek_vh = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).T_rek_vh;
            gcl.W0_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).W0_rek;
            gcl.n_trub = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).n_trub;
            gcl.T_trub = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).T_trub;
            gcl.d_h_diag = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).d_h_diag;
            gcl.fi_s1 = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).fi_s1;
            gcl.fi_s2 = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).fi_s2;
            gcl.fi_d = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).fi_d;
            gcl.fi_t_st = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant_First && p.Owner.ID_User == _users.CurrentUser.ID_User).fi_t_st;

            #endregion --- Задать исходные данные для первого найденного варианта

            ViewBag.InputData = gcl;
            ViewBag.ID_Variant = new SelectList(_variants.All.Where(t => t.Owner.ID_User == _users.CurrentUser.ID_User), "ID_Variant", "NameVariant");
            ViewBag.NameNewVariant = "Новый вариант";

            return View();
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "toApply")]
        public ActionResult Demo(string ID_Variant)
        {
            int _ID_Variant = int.Parse(ID_Variant);
            GasChannelLib.GasChannelLib gcl = new GasChannelLib.GasChannelLib();

            #region --- Задать исходные данные для выбранного варианта

            gcl.Kol_prod_gorenija = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).Kol_prod_gorenija;
            gcl.Ro_0 = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).Ro_0;
            gcl.Ro_v = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).Ro_v;
            gcl.H_pechi = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).H_pechi;
            gcl.L_pechi = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).L_pechi;
            gcl.T_fume = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).T_fume;

            gcl.T_fume_v = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).T_fume_v;
            gcl.L_vert = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).L_vert;
            gcl.b_vert = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).b_vert;
            gcl.H_vert = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).H_vert;
            gcl.lambda_vert = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).lambda_vert;

            gcl.L_bor_vert_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).L_bor_vert_rek;
            gcl.Td_rek_fume_bor = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).Td_rek_fume_bor;
            gcl.Tv_bor = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).Tv_bor;
            gcl.H_bor = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).H_bor;
            gcl.L_bor = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).L_bor;

            gcl.T_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).T_rek;
            gcl.L_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).L_rek;
            gcl.W_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).W_rek;
            gcl.d_trub_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).d_trub_rek;
            gcl.T_rek_vh = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).T_rek_vh;
            gcl.W0_rek = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).W0_rek;
            gcl.n_trub = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).n_trub;
            gcl.T_trub = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).T_trub;
            gcl.d_h_diag = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).d_h_diag;
            gcl.fi_s1 = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).fi_s1;
            gcl.fi_s2 = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).fi_s2;
            gcl.fi_d = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).fi_d;
            gcl.fi_t_st = _inputDataVariants.All.First(p => p.Variants.ID_Variant == _ID_Variant && p.Owner.ID_User == _users.CurrentUser.ID_User).fi_t_st;
            #endregion --- Задать исходные данные для выбранного варианта

            ViewBag.InputData = gcl;
            ViewBag.ID_Variant = new SelectList(_variants.All.Where(t => t.Owner.ID_User == _users.CurrentUser.ID_User), "ID_Variant", "NameVariant");
            ViewBag.NameNewVariant = "Новый вариант";

            return View();
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "toSaveAs")]
        public ActionResult Demo(InputDataModel InputData, string NameNewVariant)
        {
            GasChannelDB gcdb = new GasChannelDB();
            double _Kol_prod_gorenija = double.Parse(InputData.Kol_prod_gorenija.ToString());
            double _Ro_0 = double.Parse(InputData.Ro_0.ToString());
            double _Ro_v = double.Parse(InputData.Ro_v.ToString());
            double _H_pechi = double.Parse(InputData.H_pechi.ToString());
            double _L_pechi = double.Parse(InputData.L_pechi.ToString());
            double _T_fume = double.Parse(InputData.T_fume.ToString());

            double _T_fume_v = double.Parse(InputData.T_fume_v.ToString());
            double _L_vert = double.Parse(InputData.L_vert.ToString());
            double _b_vert = double.Parse(InputData.b_vert.ToString());
            double _H_vert = double.Parse(InputData.H_vert.ToString());
            double _lambda_vert = double.Parse(InputData.lambda_vert.ToString());

            double _L_bor_vert_rek = double.Parse(InputData.L_bor_vert_rek.ToString());
            double _Td_rek_fume_bor = double.Parse(InputData.Td_rek_fume_bor.ToString());
            double _Tv_bor = double.Parse(InputData.Tv_bor.ToString());
            double _H_bor = double.Parse(InputData.H_bor.ToString());
            double _L_bor = double.Parse(InputData.L_bor.ToString());

            double _T_rek = double.Parse(InputData.T_rek.ToString());
            double _L_rek = double.Parse(InputData.L_rek.ToString());
            double _W_rek = double.Parse(InputData.W_rek.ToString());
            double _d_trub_rek = double.Parse(InputData.d_trub_rek.ToString());
            double _T_rek_vh = double.Parse(InputData.T_rek_vh.ToString());
            double _W0_rek = double.Parse(InputData.W0_rek.ToString());
            int _n_trub = int.Parse(InputData.n_trub.ToString());
            double _T_trub = double.Parse(InputData.T_trub.ToString());
            double _d_h_diag = double.Parse(InputData.d_h_diag.ToString());
            double _fi_s1 = double.Parse(InputData.fi_s1.ToString());
            double _fi_s2 = double.Parse(InputData.fi_s2.ToString());
            double _fi_d = double.Parse(InputData.fi_d.ToString());
            double _fi_t_st = double.Parse(InputData.fi_t_st.ToString());

            string _NameNewVariant = NameNewVariant.ToString();

            Variants var_new = new Variants
            {
                NameVariant = _NameNewVariant,
                DateVariant = System.DateTime.Now,
                Owner = _users.CurrentUser
            };
            _variants.InsertOrUpdate(var_new);
            _variants.Save();

            int _ID_Variant_new = gcdb.Variants.Where(p => p.NameVariant == _NameNewVariant && p.Owner.ID_User == _users.CurrentUser.ID_User).First().ID_Variant;
            InputDataVariants inputDataVariants_new = new InputDataVariants
            {
                ID_Variant = _ID_Variant_new,
                Kol_prod_gorenija = _Kol_prod_gorenija,
                Ro_0 = _Ro_0,
                Ro_v = _Ro_0,
                H_pechi = _H_pechi,
                L_pechi = _L_pechi,
                T_fume = _T_fume,
                T_fume_v = _T_fume_v,
                L_vert = _L_vert,
                b_vert = _b_vert,
                H_vert = _H_vert,
                L_bor_vert_rek = _L_bor_vert_rek,
                Td_rek_fume_bor = _Td_rek_fume_bor,
                Tv_bor = _Tv_bor,
                H_bor = _H_bor,
                L_bor = _L_bor,
                T_rek = _T_rek,
                L_rek = _L_rek,
                W_rek = _W_rek,
                d_trub_rek = _d_trub_rek,
                T_rek_vh = _T_rek_vh,
                W0_rek = _W0_rek,
                n_trub = _n_trub,
                T_trub = _T_trub,
                d_h_diag = _d_h_diag,
                fi_s1 = _fi_s1,
                fi_s2 = _fi_s2,
                fi_d = _fi_d,
                fi_t_st = _fi_t_st,
                Owner = _users.CurrentUser
            };
            _inputDataVariants.InsertOrUpdate(inputDataVariants_new);
            _inputDataVariants.Save();

            return RedirectToAction("Demo", "Home");
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "toSolver")]
        public ActionResult Demo(InputDataModel InputData)
        {
            DemoModel _result = new DemoModel(InputData);

            ViewBag.s1 = _result.s1;
            ViewBag.T_rek_vyh = _result.T_rek_vyh;
            ViewBag.T_rek_sr = _result.T_rek_sr;
            ViewBag.W0 = _result.W0;
            ViewBag.W_vert0 = _result.W_vert0;
            ViewBag.F_kan = _result.F_kan;
            ViewBag.F_kazhd_kan = _result.F_kazhd_kan;
            ViewBag.d_vert_pr = _result.d_vert_pr;
            ViewBag.h_vert_tr = _result.h_vert_tr;
            ViewBag.h_vert_pov90 = _result.h_vert_pov90;
            ViewBag.h_vert_suzh = _result.h_vert_suzh;
            ViewBag.h_vert_local = _result.h_vert_local;
            ViewBag.h_vert_geom = _result.h_vert_geom;
            ViewBag.H_pot_vert = _result.H_pot_vert;
            ViewBag.F_bor = _result.F_bor;
            ViewBag.d_pr_bor = _result.d_pr_bor;
            ViewBag.T_sr_fume_bor = _result.T_sr_fume_bor;
            ViewBag.h_tr_bor = _result.h_tr_bor;
            ViewBag.h_pov_90_vert_to_rek = _result.h_pov_90_vert_to_rek;
            ViewBag.H_pot_vert_to_rek = _result.H_pot_vert_to_rek;
            ViewBag.h_mc_vh_rek = _result.h_mc_vh_rek;
            ViewBag.Wd = _result.Wd;
            ViewBag.h_rek_puchok = _result.h_rek_puchok;
            ViewBag.W0_fume = _result.W0_fume;
            ViewBag.h_mc_rek = _result.h_mc_rek;
            ViewBag.h_sum = _result.h_sum;
            ViewBag.H_rek = _result.H_rek;
            ViewBag.Td_rek_shib = _result.Td_rek_shib;
            ViewBag.H_tr = _result.H_tr;
            ViewBag.H_sum_pot = _result.H_sum_pot;

            // ! Save input data to Session
            Session["InputData"] = InputData;

            return View();
        }

        [Authorize] // Запрещены анонимные обращения к данной странице
        public ActionResult Excel() //Заменить на OpenXML
        {
            ViewBag.Result = "Файл успешно сохранен!";

            // ! Get input data from Session
            InputDataModel _inputData = (InputDataModel)Session["InputData"];

            DemoModel _rezult = new DemoModel(_inputData);

            try
            {
                string dataTimeNow = DateTime.Now.ToString("dd MMMM yyyy HH-mm-ss");
                ViewBag.Result = dataTimeNow;

                Excel.Application application = new Excel.Application();
                Excel.Workbook workBook = application.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet worksheet = workBook.ActiveSheet;

                worksheet.Cells[1, 1] = "Демонстрационный пример";
                worksheet.Cells[2, 1] = "Дата расчета: " + ViewBag.Result;

                worksheet.Cells[4, 1] = "Исходные данные";
                worksheet.Cells[5, 1] = "Количество продуктов горения, м³/ч";
                worksheet.Cells[5, 2] = _inputData.Kol_prod_gorenija.ToString();
                worksheet.Cells[6, 1] = "Скорость движения дыма в рекуператоре, м/с";
                worksheet.Cells[6, 2] = _inputData.W0_rek.ToString();

                worksheet.Cells[7, 1] = "Расчетные показатели";
                worksheet.Cells[8, 1] = "Общие потери энергии при движении продуктов горения от рабочего пространства до шибера";
                worksheet.Cells[8, 2] = _rezult.H_sum_pot.ToString();

                String excelFileName = Server.MapPath("~/Content") + "\\Demo.xlsx";

                if (System.IO.File.Exists(excelFileName))
                {
                    System.IO.File.Delete(excelFileName);
                }

                // ! Save path & filename
                workBook.SaveAs(excelFileName);

                workBook.Close(false, Type.Missing, Type.Missing);
                Marshal.ReleaseComObject(workBook);
                application.Quit();
                Marshal.FinalReleaseComObject(application);

                // ! Redirect to download file
                Response.RedirectPermanent("/Content/Demo.xlsx");
            }
            catch (Exception e)
            {
                ViewBag.Result = "Невозможно сохранить файл (" + e.Message + ").";
            }
            

            return View();
        }

        [Authorize] // Запрещены анонимные обращения к данной странице
        public ActionResult Cabinet()
        {
            ViewBag.Message = "Личная страница";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Расчёт потерь давления на газоходе";
            ViewBag.Assembly = "Версия " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Григорий Федотов";

            return View();
        }
    }
}