using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursachInf.Domain.Entities
{
    public class Koefficient
    {
        [Display(Name = "x")]
        public double X { get; set; }
        [Display(Name = "y")]
        public double Y { get; set; }
        public double SquareX { get; set; }
        public double SquareY { get; set; }
        [Display(Name = "xy")]
        public double XmultY { get; set; }
        /*5 базовых параметров для расчётов */
        [Display(Name = "Среднее значение x")]
        public double AvgX { get; set; }
        [Display(Name = "Среднее значение y")]
        public double AvgY { get; set; }
        public double AvgSqrX { get; set; }
        public double AvgSqrY { get; set; }
        [Display(Name = "Среднее значение xy")]
        public double AvgXmultY { get; set; }

        /*5 их средних значений */
        [Display(Name = "Сумма по x")]
        public double SumX { get; set; }
        [Display(Name = "Сумма по y")]
        public double SumY { get; set; }
        
        public double SumSqrX { get; set; }
        public double SumSqrY { get; set; }
        [Display(Name = "Сумма по x*y")]
        public double SumXmultY { get; set; }
        /*5 сумм этих параметров */
        [Display(Name = "r")]
        public double r { get; set; }
        [Display(Name = "Связь")]
        public string Connection { get; set; }
        public List<Koefficient>Koefficients { get; set; }
    }
}
