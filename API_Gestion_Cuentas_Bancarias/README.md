# API_Gestion_Cuentas_Bancarias

## Descripción
Este proyecto es una API para la gestión de cuentas bancarias, permitiendo la creación de
cuentas con un saldo inicial, la consulta de saldo, la realización de depósitos y retiros,
y la obtención de un resumen de transacciones que incluye el monto total final.

## Requisitos Previos
Para ejecutar el proyecto, es necesario contar con los siguientes componentes instalados:

- .NET 8 SDK
- Visual Studio 2022 o posterior
- Git (opcional, para clonar el repositorio)

## Instalación y Ejecución
Clonar el Repositorio
Para obtener el código fuente del proyecto, se debe clonar el repositorio ejecutando el 
siguiente comando en la terminal:

git clone https://github.com/JordanCHN/API_Gestion_Cuentas_Bancarias
cd API_Gestion_Cuentas_Bancarias

## Restaurar Dependencias
Ejecutar el siguiente comando para restaurar los paquetes necesarios:

dotnet restore

## Iniciar la API
Para ejecutar la API, se debe usar el siguiente comando:

dotnet run --project API_Gestion_Cuentas_Bancarias

## Uso de la API
1. Crear una Cuenta
Endpoint:

POST /api/cuentas

Cuerpo de la Petición:

{
    "saldoInicial": 1000
}

Ejemplo de Respuesta:

{
    "numeroCuenta": "123456789",
    "saldo": 1000
}

2. Consultar Saldo
Endpoint:

GET /api/cuentas/{numeroCuenta}

Ejemplo de Respuesta:

{
    "numeroCuenta": "123456789",
    "saldo": 1000
}

3. Realizar un Depósito
Endpoint:

POST /api/cuentas/{numeroCuenta}/depositar

Cuerpo de la Petición:

{
    "monto": 500
}

Ejemplo de Respuesta:

{
    "mensaje": "Depósito realizado con éxito.",
}

4. Realizar un Retiro
Endpoint:

POST /api/cuentas/{numeroCuenta}/retirar

Cuerpo de la Petición:

{
    "monto": 200
}

Ejemplo de Respuesta:

{
    "mensaje": "Retiro realizado con éxito.",
}

Si el saldo es insuficiente, la API devolverá:

{
    "mensaje": "Fondos insuficientes."
}

5. Obtener Resumen de Transacciones
Endpoint:

GET /api/cuentas/{numeroCuenta}/resumen

Ejemplo de Respuesta:

{
    "transacciones": [
        {
            "id": 1,
            "tipo": "Depósito",
            "monto": 500,
            "saldoDespues": 1500
        },
        {
            "id": 2,
            "tipo": "Retiro",
            "monto": 200,
            "saldoDespues": 1300
        }
    ],
    "montoTotalFinal": 1300
}

## Ejecución de Pruebas Unitarias  
Acceder al Proyecto de Pruebas

cd API_Gestion_Cuentas_Bancarias.Tests

Ejecutar las Pruebas
Para ejecutar las pruebas unitarias, se debe ejecutar el siguiente comando en la terminal:

dotnet test

Si todas las pruebas pasan correctamente, la salida esperada será similar a la siguiente:

Passed! - 5 tests passed in 4.1s

Licencia
Este proyecto se distribuye bajo la licencia MIT.

Autor
Jordan Chavarría.