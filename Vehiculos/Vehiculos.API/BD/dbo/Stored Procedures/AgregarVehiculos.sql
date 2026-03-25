CREATE PROCEDURE AgregarVehiculos
	-- Add the parameters for the stored procedure here
	@id AS uniqueidentifier,
	@idModelo AS uniqueidentifier,
	@Placa AS varchar(max),
	@Color AS varchar(max),   
	@Año As int,
	@Precio AS decimal(18,0),
	@CorreoPropietario AS varchar(max),
	@TelefonoPropietario AS varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Begin Transaction 
INSERT INTO [dbo].[Vehiculo]
           ([id]
           ,[idModelo]
           ,[Placa]
           ,[Color]
           ,[Año]
           ,[Precio]
           ,[CorreoPropietario]
           ,[TelefonoPropietario])
     VALUES
           (@id,
	@idModelo,
	@Placa,
@Color,  
@Año,
@Precio, 
@CorreoPropietario, 
@TelefonoPropietario)
commit Transaction
END