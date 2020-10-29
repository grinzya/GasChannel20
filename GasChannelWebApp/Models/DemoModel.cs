using System;
using GasChannelLib;

namespace GasChannelWebApp.Models
{
    public class DemoModel
    {
        private GasChannelLib.GasChannelLib gcl = new GasChannelLib.GasChannelLib();
        private InputDataModel InDat = new InputDataModel();

        public DemoModel() { }

        public DemoModel(InputDataModel InputData)
        {
            InDat = InputData;
            #region Передать исходные данные в экземпляр библиотеки
            gcl.Kol_prod_gorenija = InDat.Kol_prod_gorenija;
            gcl.Ro_0 = InDat.Ro_0;
            gcl.Ro_v = InDat.Ro_v;
            gcl.H_pechi = InDat.H_pechi;
            gcl.L_pechi = InDat.L_pechi;
            gcl.T_fume = InDat.T_fume;
            gcl.T_fume_v = InDat.T_fume_v;
            gcl.L_vert = InDat.L_vert;
            gcl.b_vert = InDat.b_vert;
            gcl.H_vert = InDat.H_vert;
            gcl.lambda_vert = InDat.lambda_vert;
            gcl.L_bor_vert_rek = InDat.L_bor_vert_rek;
            gcl.Td_rek_fume_bor = InDat.Td_rek_fume_bor;
            gcl.Tv_bor = InDat.Tv_bor;
            gcl.H_bor = InDat.H_bor;
            gcl.L_bor = InDat.L_bor;
            gcl.T_rek = InDat.T_rek;
            gcl.L_rek = InDat.L_rek;
            gcl.W_rek = InDat.W_rek;
            gcl.d_trub_rek = InDat.d_trub_rek;
            gcl.T_rek_vh = InDat.T_rek_vh;
            gcl.W0_rek = InDat.W0_rek;
            gcl.n_trub = InDat.n_trub;
            gcl.T_trub = InDat.T_trub;
            gcl.d_h_diag = InDat.d_h_diag;
            gcl.fi_s1 = InDat.fi_s1;
            gcl.fi_s2 = InDat.fi_s2;
            gcl.fi_d = InDat.fi_d;
            gcl.fi_t_st = InDat.fi_t_st;
            #endregion


        }
        #region --- Получить расчетные показатели

        /// <summary>
        /// Сумма двух чисел
        /// </summary>          
        public double s1
        {
            get { return gcl.s1; }
        }
        public double T_rek_vyh
        {
            get { return gcl.T_rek_vyh; }
        }
        public double T_rek_sr
        {
            get { return gcl.T_rek_sr; }
        }
        public double W0
        {
            get { return gcl.W0; }
        }
        public double W_vert0
        {
            get { return gcl.W_vert0; }
        }
        public double F_kan
        {
            get { return gcl.F_kan; }
        }
        public double F_kazhd_kan
        {
            get { return gcl.F_kazhd_kan; }
        }
        public double d_vert_pr
        {
            get { return gcl.d_vert_pr; }
        }
        public double h_vert_tr
        {
            get { return gcl.h_vert_tr; }
        }
        public double h_vert_pov90
        {
            get { return gcl.h_vert_pov90; }
        }
        public double h_vert_suzh
        {
            get { return gcl.h_vert_suzh; }
        }
        public double h_vert_local
        {
            get { return gcl.h_vert_local; }
        }
        public double h_vert_geom
        {
            get { return gcl.h_vert_geom; }
        }
        public double H_pot_vert
        {
            get { return gcl.H_pot_vert; }
        }
        public double F_bor
        {
            get { return gcl.F_bor; }
        }
        public double d_pr_bor
        {
            get { return gcl.d_pr_bor; }
        }
        public double T_sr_fume_bor
        {
            get { return gcl.T_sr_fume_bor; }
        }
        public double h_tr_bor
        {
            get { return gcl.h_tr_bor; }
        }
        public double h_pov_90_vert_to_rek
        {
            get { return gcl.h_pov_90_vert_to_rek; }
        }
        public double H_pot_vert_to_rek
        {
            get { return gcl.H_pot_vert_to_rek; }
        }
        public double h_mc_vh_rek
        {
            get { return gcl.h_mc_vh_rek; }
        }
        public double Wd
        {
            get { return gcl.Wd; }
        }
        public double h_rek_puchok
        {
            get { return gcl.h_rek_puchok; }
        }
        public double W0_fume
        {
            get { return gcl.W0_fume; }
        }
        public double h_mc_rek
        {
            get { return gcl.h_mc_rek; }
        }
        public double h_mc_vh_sumh_rek
        {
            get { return gcl.h_sum; }
        }
        public double H_rek
        {
            get { return gcl.H_rek; }
        }
        public double Td_rek_shib
        {
            get { return gcl.h_mc_vh_rek; }
        }
        public double H_tr
        {
            get { return gcl.H_tr; }
        }
        public double H_sum_pot
        {
            get { return gcl.H_sum_pot; }
        }
        #endregion --- Получить расчетные показатели

    }
}