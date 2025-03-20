using Microsoft.AspNetCore.Mvc;
using API_Gestion_Cuentas_Bancarias.Services;
using API_Gestion_Cuentas_Bancarias.Models;
using System;

namespace API_Gestion_Cuentas_Bancarias.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly CuentasService _service = new CuentasService();

        [HttpPost("crear")]
        public IActionResult CrearCuenta([FromBody] decimal saldoInicial)
        {
            try
            {
                var cuenta = _service.CrearCuenta(saldoInicial);
                return Ok(cuenta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{numeroCuenta}/saldo")]
        public IActionResult ConsultarSaldo(string numeroCuenta)
        {
            try
            {
                var saldo = _service.ConsultarSaldo(numeroCuenta);
                return Ok(new { Saldo = saldo });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{numeroCuenta}/depositar")]
        public IActionResult Depositar(string numeroCuenta, [FromBody] decimal monto)
        {
            try
            {
                _service.Depositar(numeroCuenta, monto);
                return Ok("Depósito realizado con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{numeroCuenta}/retirar")]
        public IActionResult Retirar(string numeroCuenta, [FromBody] decimal monto)
        {
            try
            {
                _service.Retirar(numeroCuenta, monto);
                return Ok("Retiro realizado con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{numeroCuenta}/transacciones")]
        public IActionResult ObtenerTransacciones(string numeroCuenta)
        {
            try
            {
                var transacciones = _service.ObtenerTransacciones(numeroCuenta);
                return Ok(transacciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

