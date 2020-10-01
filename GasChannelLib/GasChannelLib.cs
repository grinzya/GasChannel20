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
        #endregion

        #region Рассчёты
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
