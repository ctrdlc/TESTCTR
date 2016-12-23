USE [TEST]
GO

/****** Object:  StoredProcedure [dbo].[sp_VentasContactosCUD]    Script Date: 23/12/2016 7:46:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cornelio Trujillo 
-- Create date: 20/12/2016
-- Description:	Gestion de Contactos
-- =============================================
CREATE PROCEDURE [dbo].[sp_VentasContactosCUD]
			@ID_Contacto AS INT,
			@Apellido_paterno AS varchar(30),
			@Apellido_materno AS varchar(30),
			@Nombres AS varchar(50),
			@Correo_electronico AS varchar(100),
			@Direccion AS varchar(100),
			@Telefono_movil AS varchar(15),
			@Telefono_fijo AS varchar(15),
			--@Fecha_registro AS DATETIME,
			@ID_ContactoOUT AS INT OUTPUT

AS
BEGIN
	SET NOCOUNT ON;
		DECLARE @mensaje VARCHAR(500) = ''


		IF NOT EXISTS(SELECT ID_Contacto FROM dbo.Ventas_Contactos WHERE ID_Contacto= @ID_Contacto)
			BEGIN 
				BEGIN TRY
					BEGIN TRANSACTION
						INSERT INTO dbo.Ventas_Contactos(Apellido_paterno,Apellido_materno,Nombres,Correo_electronico,Direccion,Telefono_movil,Telefono_fijo,Fecha_registro)
											VALUES	( @Apellido_paterno,@Apellido_materno,@Nombres,@Correo_electronico,@Direccion,@Telefono_movil,@Telefono_fijo,GETDATE())
											SET @ID_ContactoOUT =@@IDENTITY
					COMMIT TRAN
					END TRY
				BEGIN CATCH
					ROLLBACK  TRAN
					SET @MENSAJE = ERROR_MESSAGE()
					RAISERROR(@MENSAJE,16,1)
				END CATCH

			END
		ELSE 
			BEGIN 
				BEGIN TRY
					BEGIN TRANSACTION
						UPDATE dbo.Ventas_Contactos SET Apellido_paterno=@Apellido_paterno,Apellido_materno=@Apellido_materno,Nombres=@Nombres,Correo_electronico=@Correo_electronico,Direccion=@Direccion,Telefono_movil=@Telefono_movil,Telefono_fijo=@Telefono_fijo
						WHERE ID_Contacto=@ID_Contacto
						SET @ID_ContactoOUT =@ID_Contacto
					COMMIT TRAN	
				END TRY
				BEGIN CATCH
					ROLLBACK  TRAN
					SET @MENSAJE = ERROR_MESSAGE()
					RAISERROR(@MENSAJE,16,1)
				END CATCH
			END	
	END 

GO

/****** Object:  StoredProcedure [dbo].[sp_VentasContactosBorrar]    Script Date: 23/12/2016 7:46:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cornelio Trujillo
-- Create date: 20/12/2016
-- Description:	Borrar Contacto
-- =============================================
CREATE PROCEDURE [dbo].[sp_VentasContactosBorrar]
		@ID_Contacto INT
AS
BEGIN
	SET NOCOUNT ON;
		DECLARE @mensaje VARCHAR(500) = ''
		
		BEGIN TRY
			BEGIN TRANSACTION
				DELETE FROM dbo.Ventas_Contactos WHERE ID_Contacto=@ID_Contacto
			COMMIT TRAN	
		END TRY
		BEGIN CATCH
			ROLLBACK  TRAN
			SET @MENSAJE = ERROR_MESSAGE()
			RAISERROR(@MENSAJE,16,1)
		END CATCH
			

END

GO

/****** Object:  StoredProcedure [dbo].[sp_VentasClientesCUD]    Script Date: 23/12/2016 7:46:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cornelio Trujillo Rojas
-- Create date: 20/12/2016
-- Description:	Gestiona CU Tabla Ventas Clientes
-- =============================================
CREATE PROCEDURE [dbo].[sp_VentasClientesCUD]
				@ID_Cliente AS INT,
				@NombreCliente AS VARCHAR(50),
				@ID_Contacto AS INT,
				@Direccion AS VARCHAR(60),
				@Ciudad AS VARCHAR(50),
				@Region AS VARCHAR(50),
				@CodigoPostal AS VARCHAR(50),
				@Pais AS VARCHAR(50),
				@Telefono AS VARCHAR(50),
				@email AS VARCHAR(50),
				@ID_ClienteOUT AS INT OUTPUT	
				
		
	
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @mensaje VARCHAR(500) = ''

		BEGIN 
			IF NOT EXISTS(SELECT ID_Cliente FROM dbo.Ventas_Clientes WHERE ID_Cliente= @ID_Cliente)
				BEGIN 
					BEGIN TRY
						BEGIN TRANSACTION
							INSERT INTO dbo.Ventas_Clientes( NombreCliente,ID_Contacto,Direccion,Ciudad,Region,CodigoPostal,Pais,Telefono,email)
										VALUES	( @NombreCliente,@ID_Contacto,@Direccion,@Ciudad,@Region,@CodigoPostal,@Pais,@Telefono,@email)
										SET @ID_ClienteOUT =@@IDENTITY
						COMMIT TRAN
						END TRY
					BEGIN CATCH
						ROLLBACK  TRAN
						SET @MENSAJE = ERROR_MESSAGE()
						RAISERROR(@MENSAJE,16,1)
					END CATCH

				END
			ELSE 
				BEGIN 
					BEGIN TRY
						BEGIN TRANSACTION
							UPDATE dbo.Ventas_Clientes SET NombreCliente=@NombreCliente,ID_Contacto=@ID_Contacto,Direccion=@Direccion,Ciudad=@Ciudad,Region=@Region,CodigoPostal=@CodigoPostal,Pais=@Pais,Telefono=@Telefono,email=@email
							 WHERE ID_Cliente = @ID_Cliente
							 SET @ID_ClienteOUT =@ID_Cliente
						COMMIT TRAN	
					END TRY
					BEGIN CATCH
						ROLLBACK  TRAN
						SET @MENSAJE = ERROR_MESSAGE()
						RAISERROR(@MENSAJE,16,1)
					END CATCH
				END	
		END 
	

END

GO

/****** Object:  StoredProcedure [dbo].[sp_VentasClientesBorrar]    Script Date: 23/12/2016 7:46:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cornelio Trujillo
-- Create date: 20/12/2016
-- Description:	Borrar Cliente
-- =============================================
CREATE PROCEDURE [dbo].[sp_VentasClientesBorrar]
		@ID_Cliente INT
AS
BEGIN
	SET NOCOUNT ON;
		DECLARE @mensaje VARCHAR(500) = ''
		
		BEGIN TRY
			BEGIN TRANSACTION
				DELETE FROM dbo.Ventas_Clientes WHERE ID_cliente = @ID_Cliente
			COMMIT TRAN	
		END TRY
		BEGIN CATCH
			ROLLBACK  TRAN
			SET @MENSAJE = ERROR_MESSAGE()
			RAISERROR(@MENSAJE,16,1)
		END CATCH
			

END

GO


