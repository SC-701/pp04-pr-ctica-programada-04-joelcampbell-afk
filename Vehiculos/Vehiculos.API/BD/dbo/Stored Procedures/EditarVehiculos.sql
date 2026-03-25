CREATE PROCEDURE EditarVehiculos
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
BEGIN TRANSACTION
UPDATE [dbo].[Vehiculo]
   SET [idModelo] = @idModelo
      ,[Placa] = @Placa
      ,[Color] = @Color
      ,[Año] = @Año
      ,[Precio] = @Precio
      ,[CorreoPropietario] = @CorreoPropietario
      ,[TelefonoPropietario] = @TelefonoPropietario
 WHERE id=@id
 select @id
 COMMIT TRANSACTION
END