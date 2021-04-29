using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursachInf.Domain.Entities
{
    public class SpearmanKoeff
    {
        [Display(Name = "x")]
        public double X { get; set; }
        [Display(Name = "y")]
        public double Y { get; set; }
        [Display(Name = "Ранг Nx")]
        public double Nx { get; set; }
        [Display(Name = "Ранг Ny")]
        public double Ny { get; set; }
        [Display(Name = "Разность рангов\n d = Nx-Ny")]
        public double Sub { get; set; }
        
        public double Squared { get; set; }

        public double SummaSqrD { get; set; }

        public double KoefSpearman { get; set; }
    }
}
