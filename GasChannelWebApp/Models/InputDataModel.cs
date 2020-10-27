using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GasChannelLib;

namespace GasChannelWebApp.Models
{
    [Serializable]
    public class InputDataModel
    {
        private GasChannelLib.GasChannelLib gcl = new GasChannelLib.GasChannelLib();

        public InputDataModel() {}

        #region Входные данные
        #region Печь
        /// <summary>
        /// Количество продуктов горения, м³/ч
        /// </summary>
        public double Kol_prod_gorenija
        {
            get { return gcl.Kol_prod_gorenija; }
            set { gcl.Kol_prod_gorenija = value; }
        }

        /// <summary>
        /// Плотность дымовых газов, кг/м³
        /// </summary>
        public double Ro_0
        {
            get { return gcl.Ro_0; }
            set { gcl.Ro_0 = value; }
        }

        /// <summary>
        /// Плотность воздуха при Т=273°К, ρв, кг/м³
        /// </summary>
        public double Ro_v
        {
            get { return gcl.Ro_v; }
            set { gcl.Ro_v = value; }
        }
        /// <summary>
        /// Высота рабочего пространства в конце печи, м
        /// </summary>
        public double H_pechi
        {
            get { return gcl.H_pechi; }
            set { gcl.H_pechi = value; }
        }
        /// <summary>
        /// Ширина рабочего пространства в конце печи, м
        /// </summary>
        public double L_pechi
        {
            get { return gcl.L_pechi; }
            set { gcl.L_pechi = value; }
        }
        /// <summary>
        /// Температура дыма в конце печи, К
        /// </summary>
        public double T_fume
        {
            get { return gcl.T_fume; }
            set { gcl.T_fume = value; }
        }
        #endregion
        #region Вертикальные каналы
        /// <summary>
        /// Температура дыма в вертикальных каналах, К
        /// </summary>
        public double T_fume_v
        {
            get { return gcl.T_fume_v; }
            set { gcl.T_fume_v = value; }
        }
        /// <summary>
        /// длина вертикальных каналов, м
        /// </summary>
        public double L_vert
        {
            get { return gcl.L_vert; }
            set { gcl.L_vert = value; }
        }
        /// <summary>
        /// Ширина, м
        /// </summary>
        public double b_vert
        {
            get { return gcl.b_vert; }
            set { gcl.b_vert = value; }
        }
        /// <summary>
        /// Высота вертикальных каналов, м
        /// </summary>
        public double H_vert
        {
            get { return gcl.H_vert; }
            set { gcl.H_vert = value; }
        }
        public double lambda_vert
        {
            get { return gcl.lambda_vert; }
            set { gcl.lambda_vert = value; }
        }
        #endregion
        #region Боров
        /// <summary>
        /// Длина борова от вертикальных каналов до рекуператора, м
        /// </summary>
        public double L_bor_vert_rek
        {
            get { return gcl.L_bor_vert_rek; }
            set { gcl.L_bor_vert_rek = value; }
        }
        /// <summary>
        /// Температура дыма перед рекуператором, Tд рек
        /// </summary>
        public double Td_rek_fume_bor
        {
            get { return gcl.Td_rek_fume_bor; }
            set { gcl.Td_rek_fume_bor = value; }
        }
        /// <summary>
        /// Температура окружающего воздуха, Тв, К
        /// </summary>
        public double Tv_bor
        {
            get { return gcl.Tv_bor; }
            set { gcl.Tv_bor = value; }
        }
        /// <summary>
        /// Высота борова, м
        /// </summary>
        public double H_bor
        {
            get { return gcl.H_bor; }
            set { gcl.H_bor = value; }
        }
        /// <summary>
        /// Длина борова, м
        /// </summary>
        public double L_bor
        {
            get { return gcl.L_bor; }
            set { gcl.L_bor = value; }
        }
       
        #endregion
        #region Рекуператор
        /// <summary>
        ///  Падение температуры дыма в рекуператоре, к
        /// </summary>
        public double T_rek
        {
            get { return gcl.T_rek; }
            set { gcl.T_rek = value; }
        }
        /// <summary>
        /// Длина камеры для установки рекуператора, м
        /// </summary>
        public double L_rek
        {
            get { return gcl.L_rek; }
            set { gcl.L_rek = value; }
        }
        /// <summary>
        /// Ширина камеры для установки рекуператора, м
        /// </summary>
        public double W_rek
        {
            get { return gcl.W_rek; }
            set { gcl.W_rek = value; }
        }
        /// <summary>
        /// Диаметр труб, мм
        /// </summary>
        public double d_trub_rek
        {
            get { return gcl.d_trub_rek; }
            set { gcl.d_trub_rek = value; }
        }
        /// <summary>
        /// Температура дыма на входе в рекуператор, Тр, К
        /// </summary>
        public double T_rek_vh
        {
            get { return gcl.T_rek_vh; }
            set { gcl.T_rek_vh = value; }
        }
        /// <summary>
        /// Скорость движения дыма в рекуператоре, м/с
        /// </summary>
        public double W0_rek
        {
            get { return gcl.W0_rek; }
            set { gcl.W0_rek = value; }
        }
        /// <summary>
        /// Число рядов труб по глубине пучка
        /// </summary>
        public int n_trub
        {
            get { return gcl.n_trub; }
            set { gcl.n_trub = value; }
        }
        /// <summary>
        /// Средняя температура стен труб
        /// </summary>
        public double T_trub
        {
            get { return gcl.T_trub; }
            set { gcl.T_trub = value; }
        }
        /// <summary>
        /// Δh, по диаграмме
        /// </summary>
        public double d_h_diag
        {
            get { return gcl.d_h_diag; }
            set { gcl.d_h_diag = value; }
        }
        public double fi_s1
        {
            get { return gcl.fi_s1; }
            set { gcl.fi_s1 = value; }
        }
        public double fi_s2
        {
            get { return gcl.fi_s2; }
            set { gcl.fi_s2 = value; }
        }
        public double fi_d
        {
            get { return gcl.fi_d; }
            set { gcl.fi_d = value; }
        }
        public double fi_t_st
        {
            get { return gcl.fi_t_st; }
            set { gcl.fi_t_st = value; }
        }
        #endregion
        #endregion
    }
}