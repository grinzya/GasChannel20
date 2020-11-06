using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GasChannelWebApp.Domain
{
    public class InputDataVariants
    {
        /// <summary>
        /// ID набора исходных данных варианта расчета пользователя
        /// </summary>
        [Key]
        public int ID_InputDataVariant { get; set; }

        /// <summary>
        /// ID варианта расчета
        /// </summary>
        public int ID_Variant { get; set; }

        public Variants Variants { get; set; }


        /// <summary>
        /// Количество продуктов горения, м³/ч
        /// </summary>
        [Display(Name = "Kol_prod_gorenija")]
        public double Kol_prod_gorenija { get; set; }


        /// <summary>
        /// Плотность дымовых газов, кг/м³
        /// </summary>
        [Display(Name = "Ro_0")]
        public double Ro_0 { get; set; }


        /// <summary>
        /// Плотность воздуха при Т=273°К, ρв, кг/м³
        /// </summary>
        [Display(Name = "Ro_v")]
        public double Ro_v { get; set; }


        /// <summary>
        /// Высота рабочего пространства в конце печи, м
        /// </summary>
        [Display(Name = "H_pechi")]
        public double H_pechi { get; set; }


        /// <summary>
        /// Ширина рабочего пространства в конце печи, м
        /// </summary>
        /// 
        [Display(Name = "L_pechi")]
        public double L_pechi { get; set; }


        /// <summary>
        /// Температура дыма в конце печи, К
        /// </summary>
        /// 
        [Display(Name = "T_fume")]
        public double T_fume { get; set; }


        /// <summary>
        /// Температура дыма в вертикальных каналах, К
        /// </summary>
        /// 
        [Display(Name = "T_fume_v")]
        public double T_fume_v { get; set; }


        /// <summary>
        /// длина вертикальных каналов, м
        /// </summary>
        /// 
        [Display(Name = "L_vert")]
        public double L_vert { get; set; }


        /// <summary>
        /// Ширина?, м
        /// </summary>
        /// 
        [Display(Name = "b_vert")]
        public double b_vert { get; set; }

        /// <summary>
        /// Высота вертикальных каналов, м
        /// </summary>
        /// 
        [Display(Name = "H_vert")]
        public double H_vert { get; set; }

        [Display(Name = "lambda_vert")]
        public double lambda_vert { get; set; }


        /// <summary>
        /// Длина борова от вертикальных каналов до рекуператора, м
        /// </summary>
        /// 
        [Display(Name = "L_bor_vert_rek")]
        public double L_bor_vert_rek { get; set; }


        /// <summary>
        /// Температура дыма перед рекуператором, Tд рек
        /// </summary>
        /// 
        [Display(Name = "Td_rek_fume_bor")]
        public double Td_rek_fume_bor { get; set; }


        /// <summary>
        /// Температура окружающего воздуха, Тв, К
        /// </summary>
        /// 
        [Display(Name = "Tv_bor")]
        public double Tv_bor { get; set; }


        /// <summary>
        /// Высота борова, м
        /// </summary>
        /// 
        [Display(Name = "H_bor")]
        public double H_bor { get; set; }

        /// <summary>
        /// Длина борова, м
        /// </summary>
        /// 
        [Display(Name = "L_bor")]
        public double L_bor { get; set; }


        /// <summary>
        ///  Падение температуры дыма в рекуператоре, к
        /// </summary>
        /// 
        [Display(Name = "T_rek")]
        public double T_rek { get; set; }

        /// <summary>
        /// Длина камеры для установки рекуператора, м
        /// </summary>
        /// 
        [Display(Name = "L_rek")]
        public double L_rek { get; set; }


        /// <summary>
        /// Ширина камеры для установки рекуператора, м
        /// </summary>
        /// 
        [Display(Name = "W_rek")]
        public double W_rek { get; set; }


        /// <summary>
        /// Диаметр труб, мм
        /// </summary>
        /// 
        [Display(Name = "d_trub_rek")]
        public double d_trub_rek { get; set; }


        /// <summary>
        /// Температура дыма на входе в рекуператор, Тр, К
        /// </summary>
        /// 
        [Display(Name = "T_rek_vh")]
        public double T_rek_vh { get; set; }


        /// <summary>
        /// Скорость движения дыма в рекуператоре, м/с
        /// </summary>
        /// 
        [Display(Name = "W0_rek")]
        public double W0_rek { get; set; }

        /// <summary>
        /// Число рядов труб по глубине пучка
        /// </summary>
        [Display(Name = "n_trub")]
        public int n_trub { get; set; }

        /// <summary>
        /// Средняя температура стен труб
        /// </summary>
         [Display(Name = "T_trub")]
        public double T_trub { get; set; }

        /// <summary>
        /// Δh, по диаграмме
        /// </summary>
        [Display(Name = "d_h_diag")]
        public double d_h_diag { get; set; }

        [Display(Name = "fi_s1")]
        public double fi_s1 { get; set; }

        [Display(Name = "fi_s2")]
        public double fi_s2 { get; set; }

        [Display(Name = "fi_d")]
        public double fi_d { get; set; }

        [Display(Name = "fi_t_st")]
        public double fi_t_st { get; set; }

        public UserProfile Owner { get; set; }
    }
}