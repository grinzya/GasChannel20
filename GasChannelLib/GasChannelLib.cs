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
        public const double T0 = 273;
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

        /// <summary>
        /// Скорость движения дыма в рекуператоре, м/с
        /// </summary>
        public double W0_rek = 4;

        /// <summary>
        /// Число рядов труб по глубине пучка
        /// </summary>
        public int n_trub = 14;

        /// <summary>
        /// Средняя температура стен труб
        /// </summary>
        public double T_trub = 593;

        /// <summary>
        /// Δh, по диаграмме
        /// </summary>
        public double d_h_diag = 8;

        public double fi_s1 = 0.95;

        public double fi_s2 = 1;

        public double fi_d = 1.11;

        public double fi_t_st = 1.06;
        #endregion
        #endregion

        #region Рассчёты
        /// <summary>
        /// Двойной диаметр труб, мм
        /// </summary>
        public double s1 => 2 * d_trub_rek;

        /// <summary>
        /// Температура дыма на выходе в рекуператор, Тр1, К
        /// </summary>
        public double T_rek_vyh => T_rek_vh - T_rek;

        /// <summary>
        /// Средняя температура в рекуператоре, К
        /// </summary>
        public double T_rek_sr => (T_rek_vh + T_rek_vyh) / 2;

        /// <summary>
        /// Скорость движения дымовых газов в конце печи с учетом сечения рабочего пространства печи за счет нагревающихся заготовок толщиной 0,15 мм
        /// </summary>
        public double W0 => Kol_prod_gorenija / (3600 * H_pechi * (L_pechi - 0.15));
        
        /// <summary>
        /// Скорость движения в 3 вертикальных каналах, м/с
        /// </summary>
        public double W_vert0 => 3 * W0;

        /// <summary>
        /// Сечение каналов, м2
        /// </summary>
        public double F_kan => Kol_prod_gorenija / (3600 * W_vert0);

        /// <summary>
        /// Сечение каждого канала, м2
        /// </summary>
        public double F_kazhd_kan => F_kan / 3;

        /// <summary>
        /// Приведённый диаметр вертикальных каналов, м
        /// </summary>
        public double d_vert_pr => (4 * L_vert * b_vert) / (2 * (L_vert + b_vert));

        /// <summary>
        /// Потеря энергии на трение в вертикальных каналах Н/м2
        /// </summary>
        public double h_vert_tr => (lambda_vert * H_vert * Ro_0 * Math.Pow(W_vert0, 2) * T_fume_v) / (d_vert_pr * 2 * T0);

        /// <summary>
        /// (проверить!)Потери энергии при повороте на 90 градусов (вертикальные каналы), Н/м2
        /// </summary>
        public double h_vert_pov90 => (2 * T_fume * Ro_0 * Math.Pow(W0, 2)) / (2 * T0);

        /// <summary>
        /// (проверить!) Потери энергии при сужении канала, вертикальные каналы, Н/м2
        /// </summary>
        public double h_vert_suzh => (0.43 * Ro_0 * Math.Pow(W0, 2));

        /// <summary>
        /// Потери на местных сопротивлениях (вертикаьные каналы), Н/м2
        /// </summary>
        public double h_vert_local => h_vert_pov90 + h_vert_suzh;

        /// <summary>
        /// Потери энергии на преодолении геометрического напора (верт), Н/м2
        /// </summary>
        public double h_vert_geom => 9.81 * H_vert * (Ro_v * (T0 / Tv_bor) - Ro_0 * (T0 / T_fume_v));

        /// <summary>
        /// Суммарные потери в вертикальном канале
        /// </summary>
        public double H_pot_vert => h_vert_tr + h_vert_pov90 + h_vert_suzh + h_vert_geom;

        /// <summary>
        /// Сечение борова, м
        /// </summary>
        public double F_bor => Kol_prod_gorenija / (3600 * W_vert0);

        /// <summary>
        /// Приведенный диаметр борова
        /// </summary>
        public double d_pr_bor => (2 * H_bor) / (L_vert + H_bor);

        /// <summary>
        /// Средняя температура дыма на борове
        /// </summary>
        public double T_sr_fume_bor => (T_fume_v + Td_rek_fume_bor) / 2;

        /// <summary>
        /// Потеря энергии на трение от вертикальных каналов до рекуператора
        /// </summary>
        public double h_tr_bor => (lambda_vert * L_bor_vert_rek * Ro_0 * Math.Pow(W_vert0, 2) * T_sr_fume_bor) / (2 * d_pr_bor * T0);

        /// <summary>
        /// Потери энергии при двух поворотах на 90° на пути от вертикальных каналов до рекуператора
        /// </summary>
        public double h_pov_90_vert_to_rek => (2.5d * Ro_0 * Math.Pow(W_vert0, 2) * T_sr_fume_bor) / (2 * T0);

        /// <summary>
        /// Суммарные потери энергии на учатске от вертикальных каналов до рекуператора
        /// </summary>
        public double H_pot_vert_to_rek => h_tr_bor + h_pov_90_vert_to_rek;

        /// <summary>
        /// Потери энергии при внезапном расширении при входе в рекуператор, Н/м2
        /// </summary>
        public double h_mc_vh_rek =>(0.16 * Ro_0 * Math.Pow(W_vert0, 2) * T_rek_vh) / (2 * T0);

        /// <summary>
        /// Действительная скорость движения дыма, м/с
        /// </summary>
        public double Wd => W0_rek * T_rek_sr / T0;

        /// <summary>
        /// Потери при поперечном омывании дымом шахматного пучка труб, Н/м2
        /// </summary>
        public double h_rek_puchok => (n_trub + 1) * d_h_diag * fi_s1 * fi_s2 * fi_d * fi_t_st;

        /// <summary>
        /// Скорость движения дыма в камере рекуператора за трубами, м/с
        /// </summary>
        public double W0_fume => Kol_prod_gorenija / (L_rek * W_rek * 3600);

        /// <summary>
        /// Потери энергии при внезапном расширении при выходе из рекуператора, Н/м2
        /// </summary>
        public double h_mc_rek => (0.26 * Math.Pow(W0_fume, 2) * Ro_0 * T_rek_vyh) / (2 * T0);

        /// <summary>
        /// Суммарные потери на местных сопротивлениях
        /// </summary>
        public double h_sum => h_mc_rek + h_mc_vh_rek;

        /// <summary>
        /// Потери энергии в рекуператоре
        /// </summary>
        public double H_rek => h_mc_vh_rek + h_rek_puchok + h_mc_rek;

        /// <summary>
        /// Средняя температура дыма на этом участке
        /// </summary>
        public double Td_rek_shib => (T_rek_vyh + (T_rek_vyh - (1.5 * L_bor))) / 2;

        /// <summary>
        /// Потери на трение
        /// </summary>
        public double H_tr => (lambda_vert * L_bor * Ro_0 * Math.Pow(L_rek, 2) * Td_rek_shib) / (d_pr_bor * 2 * T0);

        /// <summary>
        /// Общие потери энергии при движении продуктов горения от рабочего пространства до шибера
        /// </summary>
        public double H_sum_pot => (H_pot_vert + H_pot_vert_to_rek + H_rek + H_tr);
        #endregion
    }
}
