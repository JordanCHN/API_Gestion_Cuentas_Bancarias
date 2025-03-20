using System;
using System.Collections.Generic;

namespace API_Gestion_Cuentas_Bancarias.Models
{
    public class CuentaBancaria
    {
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public List<Transaccion> Transacciones { get; set; } = new List<Transaccion>();

        public CuentaBancaria(decimal saldoInicial)
        {
            if (saldoInicial <= 0)
                throw new ArgumentException("El saldo inicial debe ser mayor a cero.");

            NumeroCuenta = GenerarNumeroCuenta();
            Saldo = saldoInicial;
        }

        private string GenerarNumeroCuenta()
        {
            Random random = new Random();
            return random.Next(100000000, 999999999).ToString();
        }
    }
}
