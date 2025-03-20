using API_Gestion_Cuentas_Bancarias.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_Gestion_Cuentas_Bancarias.Services
{
    public class CuentasService
    {
        private static List<CuentaBancaria> cuentas = new List<CuentaBancaria>();

        public CuentaBancaria CrearCuenta(decimal saldoInicial)
        {
            var nuevaCuenta = new CuentaBancaria(saldoInicial);
            cuentas.Add(nuevaCuenta);
            return nuevaCuenta;
        }

        public CuentaBancaria ObtenerCuenta(string numeroCuenta)
        {
            return cuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuenta);
        }

        public decimal ConsultarSaldo(string numeroCuenta)
        {
            var cuenta = ObtenerCuenta(numeroCuenta);
            if (cuenta == null)
                throw new ArgumentException("Cuenta no encontrada.");
            return cuenta.Saldo;
        }

        public void Depositar(string numeroCuenta, decimal monto)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.");

            var cuenta = ObtenerCuenta(numeroCuenta);
            if (cuenta == null)
                throw new ArgumentException("Cuenta no encontrada.");

            cuenta.Saldo += monto;
            cuenta.Transacciones.Add(new Transaccion
            {
                Tipo = "Depósito",
                Monto = monto,
                SaldoPosterior = cuenta.Saldo
            });
        }

        public void Retirar(string numeroCuenta, decimal monto)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.");

            var cuenta = ObtenerCuenta(numeroCuenta);
            if (cuenta == null)
                throw new ArgumentException("Cuenta no encontrada.");

            if (cuenta.Saldo < monto)
                throw new InvalidOperationException("Fondos insuficientes.");

            cuenta.Saldo -= monto;
            cuenta.Transacciones.Add(new Transaccion
            {
                Tipo = "Retiro",
                Monto = monto,
                SaldoPosterior = cuenta.Saldo
            });
        }

        public List<Transaccion> ObtenerTransacciones(string numeroCuenta)
        {
            var cuenta = ObtenerCuenta(numeroCuenta);
            if (cuenta == null)
                throw new ArgumentException("Cuenta no encontrada.");

            return cuenta.Transacciones;
        }
    }
}

