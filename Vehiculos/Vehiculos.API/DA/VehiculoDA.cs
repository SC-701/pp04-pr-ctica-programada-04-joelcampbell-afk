using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class VehiculoDA : IVehiculoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public VehiculoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            string query = @"AgregarVehiculos";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new {
                id = Guid.NewGuid()
,
                idModelo = vehiculo.IdModelo
,
                Placa = vehiculo.Placa
,
                Color = vehiculo.Color
,
                Año = vehiculo.Año
,
                Precio = vehiculo.Precio
,
                CorreoPropietario = vehiculo.CorreoPropietario
,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid id, VehiculoRequest vehiculo)
        {
            await verificarVehiculoExiste(id);
            string query = @"EditarVehiculos";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id=id
,
                idModelo = vehiculo.IdModelo
,
                Placa = vehiculo.Placa
,
                Color = vehiculo.Color
,
                Año = vehiculo.Año
,
                Precio = vehiculo.Precio
,
                CorreoPropietario = vehiculo.CorreoPropietario
,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });
            return resultadoConsulta;
        }
        public async Task<Guid> Eliminar(Guid id)
        {
            await verificarVehiculoExiste(id);
            string query = @"EliminarVehiculos";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                id = id
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoResponse>(query);
            return resultadoConsulta;

        }

        public async Task<VehiculoDetalle> Obtener(Guid id)
        {
            string query = @"ObtenerVehiculo";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoDetalle>(query,new
                {id=id });
            return resultadoConsulta.FirstOrDefault();
        }
        private async Task verificarVehiculoExiste(Guid id)
        {
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(id);
            if (resultadoConsultaVehiculo == null)
                throw new Exception("El vehículo no existe.");
        }
    }
}
