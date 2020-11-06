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
            GasChannelLib.GasChannelLib gcl = new GasChannelLib.GasChannelLib();

            #region --- Задать исходные данные по умолчанию

            gcl.Kol_prod_gorenija = 19165;
            gcl.Ro_0 = 1.28;
            gcl.Ro_v = 1.29;
            gcl.H_pechi = 3.55;
            gcl.L_pechi = 2.15;
            gcl.T_fume = 1223;
            gcl.T_fume_v = 1198;
            gcl.L_vert = 1;
            gcl.b_vert = 0.7;
            gcl.H_vert = 3;
            gcl.lambda_vert = 0.05;
            gcl.L_bor_vert_rek = 11;
            gcl.Td_rek_fume_bor = 1176;
            gcl.Tv_bor = 293;
            gcl.T_rek = 450;
            gcl.L_rek = 1.4;
            gcl.W_rek = 2.5;
            gcl.d_trub_rek = 57;
            gcl.T_rek_vh = 1176;
            gcl.W0_rek = 4;
            gcl.n_trub = 14;
            gcl.T_trub = 593;
            gcl.d_h_diag = 8;
            gcl.fi_s1 = 0.95;
            gcl.fi_s2 = 1;
            gcl.fi_d = 1.11;
            gcl.fi_t_st = 1.06;

            ViewBag.InputData = gcl;
            ViewBag.ID_Variant = new SelectList(_variants.All.Where(t => t.Owner.ID_User == _users.CurrentUser.ID_User), "ID_Variant", "NameVariant");


            #endregion --- Задать исходные данные по умолчанию
            return View();
        }

        [HttpPost]
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
            return View();
        }

        [HttpPost]
        [Authorize] // Запрещены анонимные обращения к данной странице
        public ActionResult ResultDemo(InputDataModel InputData)
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
        public ActionResult Excel()
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