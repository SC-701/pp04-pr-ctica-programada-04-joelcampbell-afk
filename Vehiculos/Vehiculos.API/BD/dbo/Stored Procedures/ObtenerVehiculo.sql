CREATE   PROCEDURE dbo.ObtenerVehiculo
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  
        Vehiculo.idModelo,
        Vehiculo.Placa,
        Vehiculo.Color,
        Vehiculo.Año,
        Vehiculo.Precio,
        Vehiculo.CorreoPropietario,
        Vehiculo.TelefonoPropietario,
        Marcas.Nombre AS Marca,
        Modelos.Nombre AS Modelo,
        Vehiculo.id
    FROM Vehiculo
    INNER JOIN Modelos ON Vehiculo.idModelo = Modelos.id
    INNER JOIN Marcas ON Modelos.idMarca = Marcas.id
    WHERE Vehiculo.id = @Id;
END