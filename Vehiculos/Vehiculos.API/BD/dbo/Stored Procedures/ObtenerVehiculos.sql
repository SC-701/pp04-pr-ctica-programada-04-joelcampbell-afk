CREATE PROCEDURE ObtenerVehiculos
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT        Vehiculo.idModelo, Vehiculo.Placa, Vehiculo.Color, Vehiculo.Año, Vehiculo.Precio, Vehiculo.CorreoPropietario, Vehiculo.TelefonoPropietario, Marcas.Nombre AS Marca, Modelos.Nombre AS Modelo, Vehiculo.id
FROM            Vehiculo INNER JOIN
                         Modelos ON Vehiculo.idModelo = Modelos.id INNER JOIN
                         Marcas ON Modelos.idMarca = Marcas.id
END