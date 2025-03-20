using System;

namespace API_Gestion_Cuentas_Bancarias.Models
{
    public class Transaccion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Tipo { get; set; } // "Depósito" o "Retiro"
        public decimal Monto { get; set; }
        public decimal SaldoPosterior { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}

