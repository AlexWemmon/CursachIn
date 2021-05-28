using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursachInf.Domain.Entities
{
    public class Fisher
    {
        [Display(Name = "n")]
        public int n { get; set; }
        [Display(Name = "Средняя ошибка r")]
        public double m{ get; set; }
      
        [Display(Name = "α")]
        public double alpha { get; set; }
        [Display(Name = "v1")]
        public int v1 { get; set; }
        [Display(Name = "v2")]
        public int v2 { get; set; }
        public double sigmaFact { get; set; }
        public double sigmaOst { get; set; }
        public string уx { get; set; }
        public double F_table { get; set; }
        
        public double F_calc { get; set; }
        [Display(Name = "Вывод")]
        public string output { get; set; }
        
        public RegParams Equation { get; set; }
        [Display(Name = "Вид уравнения")]
        public string type { get; set; }
    }
}
