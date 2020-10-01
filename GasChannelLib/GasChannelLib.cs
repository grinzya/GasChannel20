using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasChannelLib
{
    public class GasChannelLib
    {
        #region Входные данные
        #region Печь
        /// <summary>
        /// Количество продуктов горения, м³/ч
        /// </summary>
        public double Kol_prod_gorenija = 19165;

        /// <summary>
        /// Плотность дымовых газов, кг/м³
        /// </summary>
        public double Ro_0 = 1.28;

        /// <summary>
        /// Плотность воздуха при Т=273°К, ρв, кг/м³
        /// </summary>
        public double Ro_v = 1.29;

        /// <summary>
        /// Высота рабочего пространства в конце печи, м
        /// </summary>
        public double H_pechi = 3.55;

        /// <summary>
        /// Ширина рабочего пространства в конце печи, м
        /// </summary>
        public double L_pechi = 2.15;

        /// <summary>
        /// Температура дыма в конце печи, К
        /// </summary>
        public double T_fume = 1223;
        #endregion
        #region Вертикальные каналы
        /// <summary>
        /// Температура дыма в вертикальных каналах, К
        /// </summary>
        public double T_fume_v = 1198;

        /// <summary>
        /// длина вертикальных каналов, м
        /// </summary>
        public double L_vert = 1;

        /// <summary>
        /// Ширина?, м
        /// </summary>
        public double b_vert = 0.7;

        /// <summary>
        /// Высота вертикальных каналов, м
        /// </summary>
        public double H_vert = 3;

        public double lambda_vert = 0.05;
        #endregion
        #region Боров
        /// <summary>
        /// Длина борова от вертикальных каналов до рекуператора, м
        /// </summary>
        public double L_bor_vert_rek = 11;

        /// <summary>
        /// Температура дыма перед рекуператором, Tд рек
        /// </summary>
        public double Td_rek_fume_bor = 1176;

        /// <summary>
        /// Температура окружающего воздуха, Тв, К
        /// </summary>
        public double Tv_bor = 293;

        /// <summary>
        /// Высота борова, м
        /// </summary>
        public double H_bor = 2.15;

        /// <summary>
        /// Длина борова, м
        /// </summary>
        public double L_bor = 6;

        /// <summary>
        /// 0 градусов цельсия
        /// </summary>
        public double T0 = 273;
        #endregion
        #region Рекуператор
        /// <summary>
        ///  Падение температуры дыма в рекуператоре, к
        /// </summary>
        public double T_rek = 450;

        /// <summary>
        /// Длина камеры для установки рекуператора, м
        /// </summary>
        public double L_rek = 1.4;

        /// <summary>
        /// Ширина камеры для установки рекуператора, м
        /// </summary>
        public double W_rek = 2.5;

        /// <summary>
        /// Диаметр труб, мм
        /// </summary>
        public double d_trub_rek = 57;

        /// <summary>
        /// Температура дыма на входе в рекуператор, Тр, К
        /// </summary>
        public double T_rek_vh = 1176;

        #endregion
        #endregion

        #region Рассчёты
        public double s1 => 2 * d_trub_rek;

        /// <summary>
        /// Суммарные потери в вертикальном канале
        /// </summary>
        public double H_pot_vert => 0;

        /// <summary>
        /// Суммарные потери энергии на учатске от вертикальных каналов до рекуператора
        /// </summary>
        public double H_pot_vert_to_rek => 0;

        /// <summary>
        /// Потери энергии в рекуператоре
        /// </summary>
        public double H_rek => 0;

        /// <summary>
        /// Потери на трение
        /// </summary>
        public double H_tr => 0;

        /// <summary>
        /// Общие потери энергии при движении продуктов горения от рабочего пространства до шибера
        /// </summary>
        public double H_sum_pot => (H_pot_vert + H_pot_vert_to_rek + H_rek + H_tr);
        #endregion
    }
}
