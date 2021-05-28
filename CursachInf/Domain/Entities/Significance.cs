using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursachInf.Domain.Entities
{
    public class Significance
    {
        [Display(Name = "n")]
        public int n { get; set; }
        [Display(Name = "Средняя ошибка r")]
        public double AvgErrorR { get; set; }
        [Display(Name = "r")]
        public double r { get; set; }
        [Display(Name = "α")]

        public double alpha { get; set; }
        [Display(Name = "v")]
        public double v{ get; set; }
        
        public double t_table { get; set; }
        
        public double t_calc { get; set; }
        [Display(Name = "Вывод")]
        public string output { get; set; }
    }
}
