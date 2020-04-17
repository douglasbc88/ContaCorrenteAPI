using System;
using System.ComponentModel.DataAnnotations;

namespace ContaCorrente.Entity
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; set; }
    }
}
