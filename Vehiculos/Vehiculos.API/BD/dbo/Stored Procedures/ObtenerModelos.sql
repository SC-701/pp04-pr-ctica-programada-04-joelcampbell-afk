CREATE PROCEDURE [dbo].[ObtenerModelos]
	-- Add the parameters for the stored procedure here
	@IdMarca uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, idMarca, Nombre
	FROM Modelos
	WHERE (idMarca = @IdMarca)
END