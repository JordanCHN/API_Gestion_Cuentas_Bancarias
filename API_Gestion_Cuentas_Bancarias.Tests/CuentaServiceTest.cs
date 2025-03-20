using Xunit;
using API_Gestion_Cuentas_Bancarias.Services;
using API_Gestion_Cuentas_Bancarias.Models;

namespace API_Gestion_Cuentas_Bancarias.Tests
{
    public class CuentaServiceTest
    {
        private readonly CuentasService _cuentaService;

        public CuentaServiceTest()
        {
            _cuentaService = new CuentasService();
        }

        [Fact]
        public void CrearCuenta_DeberiaAsignarNumeroCuentaYSaldoInicial()
        {
            decimal saldoInicial = 1000m;

            var cuenta = _cuentaService.CrearCuenta(saldoInicial);

            Assert.NotNull(cuenta);
            Assert.Equal(saldoInicial, cuenta.Saldo);
            Assert.NotNull(cuenta.NumeroCuenta);
            Assert.Equal(9, cuenta.NumeroCuenta.Length);
        }

        [Fact]
        public void Depositar_DeberiaIncrementarSaldo()
        {

            var cuenta = _cuentaService.CrearCuenta(1000m);
            decimal montoDeposito = 500m;

            _cuentaService.Depositar(cuenta.NumeroCuenta, montoDeposito);

            Assert.Equal(1500m, cuenta.Saldo);
        }

        [Fact]
        public void Retirar_DeberiaReducirSaldoSiHayFondos()
        {
            var cuenta = _cuentaService.CrearCuenta(1000m);
            decimal montoRetiro = 200m;

            _cuentaService.Retirar(cuenta.NumeroCuenta, montoRetiro);

            Assert.Equal(800m, cuenta.Saldo); // Verifica que el saldo se redujo correctamente
        }

        [Fact]
        public void Retirar_NoDeberiaPermitirRetiroSiSaldoInsuficiente()
        {
            var cuenta = _cuentaService.CrearCuenta(1000m);
            decimal montoRetiro = 2000m; // Monto mayor al saldo disponible

                var excepcion = Assert.Throws<InvalidOperationException>(() =>
                _cuentaService.Retirar(cuenta.NumeroCuenta, montoRetiro));

            Assert.Equal("Fondos insuficientes.", excepcion.Message);
        }



        [Fact]
        public void CalculoSaldoFinal_DeberiaSerCorrecto()
        {
            var cuenta = _cuentaService.CrearCuenta(1000m);
            _cuentaService.Depositar(cuenta.NumeroCuenta, 500m);
            _cuentaService.Retirar(cuenta.NumeroCuenta, 200m);

            decimal saldoFinal = cuenta.Saldo;

            Assert.Equal(1300m, saldoFinal);
        }
    }
}

