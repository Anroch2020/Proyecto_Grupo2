/* =========================================================================
   SISTEMA MEDICO - BASE DE DATOS (SQL SERVER)
   ========================================================================= */

IF DB_ID('SistemaMedico') IS NOT NULL
BEGIN
    ALTER DATABASE SistemaMedico SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SistemaMedico;
END
GO

CREATE DATABASE SistemaMedico;
GO
USE SistemaMedico;
GO

/* =========================================================================
   1. SEGURIDAD / CATALOGO DE USUARIOS (incluye login por huella)
   ========================================================================= */

CREATE TABLE Roles (
                       RolID        INT IDENTITY(1,1) PRIMARY KEY,
                       NombreRol    VARCHAR(50)  NOT NULL UNIQUE   -- Administrador, Doctor, Recepcion, Enfermeria, Farmacia
);
GO

CREATE TABLE Usuarios (
                          UsuarioID       INT IDENTITY(1,1) PRIMARY KEY,
                          NombreUsuario   VARCHAR(50)   NOT NULL UNIQUE,
                          Contrasena      VARCHAR(255)  NOT NULL,        -- hash de la contrasena (respaldo si falla la huella)
                          NombreCompleto  VARCHAR(150)  NOT NULL,
                          Correo          VARCHAR(100)  NULL,
                          RolID           INT           NOT NULL,
                          PlantillaHuella VARBINARY(MAX) NULL,           -- template capturado con DigitalPersona 4500 (formato del SDK, ej. FMD/ANSI-ISO)
                          Activo          BIT           NOT NULL DEFAULT 1,
                          FechaCreacion   DATETIME2     NOT NULL DEFAULT GETDATE(),
                          CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (RolID) REFERENCES Roles(RolID)
);
GO

-- Bitacora de accesos (registro de cada intento de login, por huella o por contrasena)
CREATE TABLE BitacoraAccesos (
                                 BitacoraID   INT IDENTITY(1,1) PRIMARY KEY,
                                 UsuarioID    INT          NULL,               -- puede ser NULL si la huella no fue reconocida
                                 FechaHora    DATETIME2    NOT NULL DEFAULT GETDATE(),
                                 TipoAcceso   VARCHAR(20)  NOT NULL CHECK (TipoAcceso IN ('Huella','Contrasena')),
                                 Resultado    VARCHAR(20)  NOT NULL CHECK (Resultado IN ('Exitoso','Fallido')),
                                 Observacion  VARCHAR(200) NULL,
                                 CONSTRAINT FK_Bitacora_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);
GO

/* =========================================================================
   2. CATALOGOS PRINCIPALES
   ========================================================================= */

CREATE TABLE Especialidades (
                                EspecialidadID INT IDENTITY(1,1) PRIMARY KEY,
                                Nombre         VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Doctores (
                          DoctorID         INT IDENTITY(1,1) PRIMARY KEY,
                          Nombres          VARCHAR(100) NOT NULL,
                          Apellidos        VARCHAR(100) NOT NULL,
                          EspecialidadID   INT          NULL,
                          NumeroColegiado  VARCHAR(20)  NULL,
                          Telefono         VARCHAR(20)  NULL,
                          Correo           VARCHAR(100) NULL,
                          UsuarioID        INT          NULL,           -- login del doctor en el sistema
                          Activo           BIT          NOT NULL DEFAULT 1,
                          CONSTRAINT FK_Doctores_Especialidad FOREIGN KEY (EspecialidadID) REFERENCES Especialidades(EspecialidadID),
                          CONSTRAINT FK_Doctores_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);
GO

CREATE TABLE Pacientes (
                           PacienteID       INT IDENTITY(1,1) PRIMARY KEY,
                           Nombres          VARCHAR(100) NOT NULL,
                           Apellidos        VARCHAR(100) NOT NULL,
                           DPI              VARCHAR(20)  NULL UNIQUE,
                           FechaNacimiento  DATE         NULL,
                           Genero           CHAR(1)      NULL CHECK (Genero IN ('M','F')),
                           Direccion        VARCHAR(200) NULL,
                           Telefono         VARCHAR(20)  NULL,
                           Correo           VARCHAR(100) NULL,
                           TipoSangre       VARCHAR(5)   NULL,
                           FechaRegistro    DATETIME2    NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE Enfermedades (
                              EnfermedadID INT IDENTITY(1,1) PRIMARY KEY,
                              CodigoCIE    VARCHAR(10)  NULL,       -- codigo CIE-10 (opcional)
                              Nombre       VARCHAR(150) NOT NULL,
                              Descripcion  VARCHAR(300) NULL
);
GO

CREATE TABLE Examenes (
                          ExamenID     INT IDENTITY(1,1) PRIMARY KEY,
                          Nombre       VARCHAR(150)   NOT NULL,
                          Descripcion  VARCHAR(300)   NULL,
                          Costo        DECIMAL(10,2)  NOT NULL DEFAULT 0
);
GO

CREATE TABLE Proveedores (
                             ProveedorID   INT IDENTITY(1,1) PRIMARY KEY,
                             NombreEmpresa VARCHAR(150) NOT NULL,
                             Telefono      VARCHAR(20)  NULL,
                             Correo        VARCHAR(100) NULL,
                             Direccion     VARCHAR(200) NULL
);
GO

CREATE TABLE MedicamentosInsumos (
                                     ProductoID        INT IDENTITY(1,1) PRIMARY KEY,
                                     Nombre            VARCHAR(150)  NOT NULL,
                                     Tipo              VARCHAR(20)   NOT NULL CHECK (Tipo IN ('Medicamento','Insumo')),
                                     Presentacion      VARCHAR(50)   NULL,          -- tabletas, jarabe, caja, etc.
                                     Descripcion       VARCHAR(300)  NULL,
                                     PrecioUnitario    DECIMAL(10,2) NOT NULL DEFAULT 0,
                                     Stock             INT           NOT NULL DEFAULT 0,
                                     StockMinimo       INT           NOT NULL DEFAULT 5,
                                     FechaVencimiento  DATE          NULL,
                                     ProveedorID       INT           NULL,
                                     Activo            BIT           NOT NULL DEFAULT 1,
                                     CONSTRAINT FK_Productos_Proveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID)
);
GO

/* =========================================================================
   3. MODULO DE CONTROL DE CITAS
   ========================================================================= */

CREATE TABLE Citas (
                       CitaID         INT IDENTITY(1,1) PRIMARY KEY,
                       PacienteID     INT          NOT NULL,
                       DoctorID       INT          NOT NULL,
                       FechaCita      DATE         NOT NULL,
                       HoraCita       TIME         NOT NULL,
                       Motivo         VARCHAR(200) NULL,
                       Estado         VARCHAR(20)  NOT NULL DEFAULT 'Programada'
                           CHECK (Estado IN ('Programada','Atendida','Cancelada','No Asistio')),
                       UsuarioCreoID  INT          NULL,
                       FechaCreacion  DATETIME2    NOT NULL DEFAULT GETDATE(),
                       CONSTRAINT FK_Citas_Paciente FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID),
                       CONSTRAINT FK_Citas_Doctor   FOREIGN KEY (DoctorID)   REFERENCES Doctores(DoctorID),
                       CONSTRAINT FK_Citas_Usuario  FOREIGN KEY (UsuarioCreoID) REFERENCES Usuarios(UsuarioID)
);
GO

/* =========================================================================
   4. EXPEDIENTE CLINICO (consulta, diagnostico, receta, examenes)
   ========================================================================= */

CREATE TABLE Consultas (
                           ConsultaID      INT IDENTITY(1,1) PRIMARY KEY,
                           CitaID          INT          NULL,           -- puede venir de una cita o ser consulta directa
                           PacienteID      INT          NOT NULL,
                           DoctorID        INT          NOT NULL,
                           FechaConsulta   DATETIME2    NOT NULL DEFAULT GETDATE(),
                           MotivoConsulta  VARCHAR(300) NULL,
                           EnfermedadID    INT          NULL,
                           Diagnostico     VARCHAR(500) NULL,
                           Tratamiento     VARCHAR(500) NULL,
                           Observaciones   VARCHAR(500) NULL,
                           CONSTRAINT FK_Consultas_Cita       FOREIGN KEY (CitaID)       REFERENCES Citas(CitaID),
                           CONSTRAINT FK_Consultas_Paciente   FOREIGN KEY (PacienteID)   REFERENCES Pacientes(PacienteID),
                           CONSTRAINT FK_Consultas_Doctor     FOREIGN KEY (DoctorID)     REFERENCES Doctores(DoctorID),
                           CONSTRAINT FK_Consultas_Enfermedad FOREIGN KEY (EnfermedadID) REFERENCES Enfermedades(EnfermedadID)
);
GO

CREATE TABLE Recetas (
                         RecetaID     INT IDENTITY(1,1) PRIMARY KEY,
                         ConsultaID   INT       NOT NULL,
                         FechaReceta  DATETIME2 NOT NULL DEFAULT GETDATE(),
                         CONSTRAINT FK_Recetas_Consulta FOREIGN KEY (ConsultaID) REFERENCES Consultas(ConsultaID)
);
GO

CREATE TABLE DetalleReceta (
                               DetalleRecetaID INT IDENTITY(1,1) PRIMARY KEY,
                               RecetaID        INT           NOT NULL,
                               ProductoID      INT           NOT NULL,
                               Dosis           VARCHAR(100)  NULL,
                               Cantidad        INT           NOT NULL,
                               Indicaciones    VARCHAR(200)  NULL,
                               CONSTRAINT FK_DetReceta_Receta   FOREIGN KEY (RecetaID)   REFERENCES Recetas(RecetaID),
                               CONSTRAINT FK_DetReceta_Producto FOREIGN KEY (ProductoID) REFERENCES MedicamentosInsumos(ProductoID)
);
GO

CREATE TABLE ExamenesRealizados (
                                    ExamenRealizadoID INT IDENTITY(1,1) PRIMARY KEY,
                                    ConsultaID        INT          NOT NULL,
                                    ExamenID          INT          NOT NULL,
                                    FechaRealizado    DATETIME2    NOT NULL DEFAULT GETDATE(),
                                    Resultado         VARCHAR(500) NULL,
                                    Estado            VARCHAR(20)  NOT NULL DEFAULT 'Pendiente'
                                        CHECK (Estado IN ('Pendiente','Realizado','Entregado')),
                                    CONSTRAINT FK_ExamRealizado_Consulta FOREIGN KEY (ConsultaID) REFERENCES Consultas(ConsultaID),
                                    CONSTRAINT FK_ExamRealizado_Examen   FOREIGN KEY (ExamenID)   REFERENCES Examenes(ExamenID)
);
GO

/* =========================================================================
   5. MODULO DE FACTURACION E INVENTARIOS
   ========================================================================= */

CREATE TABLE Facturas (
                          FacturaID     INT IDENTITY(1,1) PRIMARY KEY,
                          PacienteID    INT           NOT NULL,
                          UsuarioID     INT           NOT NULL,        -- quien factura
                          FechaFactura  DATETIME2     NOT NULL DEFAULT GETDATE(),
                          Subtotal      DECIMAL(10,2) NOT NULL DEFAULT 0,
                          Impuesto      DECIMAL(10,2) NOT NULL DEFAULT 0,
                          Total         DECIMAL(10,2) NOT NULL DEFAULT 0,
                          Estado        VARCHAR(20)   NOT NULL DEFAULT 'Pagada'
                              CHECK (Estado IN ('Pagada','Anulada','Pendiente')),
                          CONSTRAINT FK_Facturas_Paciente FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID),
                          CONSTRAINT FK_Facturas_Usuario  FOREIGN KEY (UsuarioID)  REFERENCES Usuarios(UsuarioID)
);
GO

CREATE TABLE DetalleFactura (
                                DetalleFacturaID INT IDENTITY(1,1) PRIMARY KEY,
                                FacturaID        INT           NOT NULL,
                                TipoItem         VARCHAR(20)   NOT NULL CHECK (TipoItem IN ('Medicamento','Examen','Consulta')),
                                ProductoID       INT           NULL,          -- si TipoItem = Medicamento
                                ExamenID         INT           NULL,          -- si TipoItem = Examen
                                Descripcion      VARCHAR(200)  NOT NULL,       -- descripcion libre (util para 'Consulta medica')
                                Cantidad         INT           NOT NULL DEFAULT 1,
                                PrecioUnitario   DECIMAL(10,2) NOT NULL,
                                Subtotal         AS (Cantidad * PrecioUnitario) PERSISTED,
                                CONSTRAINT FK_DetFactura_Factura  FOREIGN KEY (FacturaID)  REFERENCES Facturas(FacturaID),
                                CONSTRAINT FK_DetFactura_Producto FOREIGN KEY (ProductoID) REFERENCES MedicamentosInsumos(ProductoID),
                                CONSTRAINT FK_DetFactura_Examen   FOREIGN KEY (ExamenID)   REFERENCES Examenes(ExamenID)
);
GO

-- Kardex simple de inventario (entradas/salidas)
CREATE TABLE MovimientosInventario (
                                       MovimientoID    INT IDENTITY(1,1) PRIMARY KEY,
                                       ProductoID      INT          NOT NULL,
                                       TipoMovimiento  VARCHAR(10)  NOT NULL CHECK (TipoMovimiento IN ('Entrada','Salida')),
                                       Cantidad        INT          NOT NULL,
                                       Motivo          VARCHAR(200) NULL,             -- 'Compra a proveedor', 'Receta #123', 'Venta directa', etc.
                                       FechaMovimiento DATETIME2    NOT NULL DEFAULT GETDATE(),
                                       UsuarioID       INT          NULL,
                                       CONSTRAINT FK_MovInv_Producto FOREIGN KEY (ProductoID) REFERENCES MedicamentosInsumos(ProductoID),
                                       CONSTRAINT FK_MovInv_Usuario  FOREIGN KEY (UsuarioID)  REFERENCES Usuarios(UsuarioID)
);
GO

/* =========================================================================
   6. INDICES DE APOYO (busquedas frecuentes / reportes)
   ========================================================================= */

CREATE INDEX IX_Citas_Fecha        ON Citas(FechaCita);
CREATE INDEX IX_Citas_Doctor       ON Citas(DoctorID, FechaCita);
CREATE INDEX IX_Consultas_Paciente ON Consultas(PacienteID, FechaConsulta);
CREATE INDEX IX_Facturas_Fecha     ON Facturas(FechaFactura);
CREATE INDEX IX_DetReceta_Producto ON DetalleReceta(ProductoID);
GO

/* =========================================================================
   7. TRIGGER SIMPLE: descontar stock cuando se receta un medicamento
   (ejemplo minimo, opcional para el alcance academico)
   ========================================================================= */

CREATE TRIGGER TR_DetalleReceta_DescontarStock
    ON DetalleReceta
    AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

UPDATE M
SET M.Stock = M.Stock - I.Cantidad
    FROM MedicamentosInsumos M
    INNER JOIN inserted I ON I.ProductoID = M.ProductoID;

INSERT INTO MovimientosInventario (ProductoID, TipoMovimiento, Cantidad, Motivo)
SELECT ProductoID, 'Salida', Cantidad, CONCAT('Receta detalle #', DetalleRecetaID)
FROM inserted;
END
GO

/* =========================================================================
   8. VISTAS PARA REPORTES / CONSULTAS
   ========================================================================= */

-- a) Reporte de Citas
CREATE VIEW vw_ReporteCitas AS
SELECT
    c.CitaID,
    c.FechaCita,
    c.HoraCita,
    p.PacienteID,
    CONCAT(p.Nombres, ' ', p.Apellidos) AS Paciente,
    d.DoctorID,
    CONCAT(d.Nombres, ' ', d.Apellidos) AS Doctor,
    e.Nombre AS Especialidad,
    c.Motivo,
    c.Estado
FROM Citas c
         INNER JOIN Pacientes p ON p.PacienteID = c.PacienteID
         INNER JOIN Doctores d  ON d.DoctorID   = c.DoctorID
         LEFT  JOIN Especialidades e ON e.EspecialidadID = d.EspecialidadID;
GO

-- b) Citas por Doctor (resumen)
CREATE VIEW vw_CitasPorDoctor AS
SELECT
    d.DoctorID,
    CONCAT(d.Nombres, ' ', d.Apellidos) AS Doctor,
    e.Nombre AS Especialidad,
    c.Estado,
    COUNT(*) AS TotalCitas
FROM Citas c
         INNER JOIN Doctores d ON d.DoctorID = c.DoctorID
         LEFT  JOIN Especialidades e ON e.EspecialidadID = d.EspecialidadID
GROUP BY d.DoctorID, d.Nombres, d.Apellidos, e.Nombre, c.Estado;
GO

-- c) Medicamentos recetados
CREATE VIEW vw_MedicamentosRecetados AS
SELECT
    r.RecetaID,
    r.FechaReceta,
    co.PacienteID,
    CONCAT(p.Nombres, ' ', p.Apellidos) AS Paciente,
    co.DoctorID,
    CONCAT(dr.Nombres, ' ', dr.Apellidos) AS Doctor,
    dr2.ProductoID,
    m.Nombre AS Medicamento,
    dr2.Dosis,
    dr2.Cantidad,
    dr2.Indicaciones
FROM DetalleReceta dr2
         INNER JOIN Recetas r      ON r.RecetaID      = dr2.RecetaID
         INNER JOIN Consultas co   ON co.ConsultaID   = r.ConsultaID
         INNER JOIN Pacientes p    ON p.PacienteID    = co.PacienteID
         INNER JOIN Doctores dr    ON dr.DoctorID     = co.DoctorID
         INNER JOIN MedicamentosInsumos m ON m.ProductoID = dr2.ProductoID;
GO

-- d) Expediente clinico (historial completo por paciente)
CREATE VIEW vw_ExpedienteClinico AS
SELECT
    co.ConsultaID,
    co.FechaConsulta,
    p.PacienteID,
    CONCAT(p.Nombres, ' ', p.Apellidos) AS Paciente,
    CONCAT(d.Nombres, ' ', d.Apellidos) AS Doctor,
    en.Nombre AS Enfermedad,
    co.Diagnostico,
    co.Tratamiento,
    co.Observaciones
FROM Consultas co
         INNER JOIN Pacientes p ON p.PacienteID = co.PacienteID
         INNER JOIN Doctores d  ON d.DoctorID   = co.DoctorID
         LEFT  JOIN Enfermedades en ON en.EnfermedadID = co.EnfermedadID;
GO

/* =========================================================================
   9. PROCEDIMIENTOS ALMACENADOS PARA LOS REPORTES SOLICITADOS
   ========================================================================= */

CREATE PROCEDURE sp_ReporteCitas
    @FechaInicio DATE = NULL,
    @FechaFin    DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM vw_ReporteCitas
WHERE (@FechaInicio IS NULL OR FechaCita >= @FechaInicio)
  AND (@FechaFin    IS NULL OR FechaCita <= @FechaFin)
ORDER BY FechaCita, HoraCita;
END
GO

CREATE PROCEDURE sp_CitasPorDoctor
    @DoctorID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM vw_CitasPorDoctor
WHERE (@DoctorID IS NULL OR DoctorID = @DoctorID)
ORDER BY Doctor;
END
GO

CREATE PROCEDURE sp_MedicamentosRecetados
    @FechaInicio DATE = NULL,
    @FechaFin    DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM vw_MedicamentosRecetados
WHERE (@FechaInicio IS NULL OR FechaReceta >= @FechaInicio)
  AND (@FechaFin    IS NULL OR FechaReceta <= @FechaFin)
ORDER BY FechaReceta DESC;
END
GO

CREATE PROCEDURE sp_ExpedienteClinico
    @PacienteID INT
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM vw_ExpedienteClinico
WHERE PacienteID = @PacienteID
ORDER BY FechaConsulta DESC;
END
GO

/* =========================================================================
   10. BUSINESS INTELLIGENCE
   Vistas de resumen listas para conectar a Power BI / SSRS o para poblar
   un pequeno data mart (Dim/Fact) si el curso lo requiere.
   ========================================================================= */

-- Citas por mes y estado (tendencias de la clinica)
CREATE VIEW vw_BI_CitasPorMes AS
SELECT
        YEAR(FechaCita)  AS Anio,
        MONTH(FechaCita) AS Mes,
        Estado,
        COUNT(*) AS TotalCitas
        FROM Citas
        GROUP BY YEAR(FechaCita), MONTH(FechaCita), Estado;
GO

-- Ingresos por mes (facturacion)
CREATE VIEW vw_BI_IngresosPorMes AS
SELECT
        YEAR(FechaFactura)  AS Anio,
        MONTH(FechaFactura) AS Mes,
        SUM(Total) AS TotalIngresos,
        COUNT(*)   AS TotalFacturas
        FROM Facturas
        WHERE Estado = 'Pagada'
        GROUP BY YEAR(FechaFactura), MONTH(FechaFactura);
GO

-- Enfermedades mas frecuentes
CREATE VIEW vw_BI_EnfermedadesFrecuentes AS
SELECT
    en.EnfermedadID,
    en.Nombre AS Enfermedad,
    COUNT(*) AS TotalCasos
FROM Consultas co
         INNER JOIN Enfermedades en ON en.EnfermedadID = co.EnfermedadID
GROUP BY en.EnfermedadID, en.Nombre;
GO

-- Productividad por doctor (consultas atendidas)
CREATE VIEW vw_BI_ProductividadDoctor AS
SELECT
    d.DoctorID,
    CONCAT(d.Nombres, ' ', d.Apellidos) AS Doctor,
    e.Nombre AS Especialidad,
    COUNT(co.ConsultaID) AS TotalConsultas
FROM Doctores d
         LEFT JOIN Consultas co ON co.DoctorID = d.DoctorID
         LEFT JOIN Especialidades e ON e.EspecialidadID = d.EspecialidadID
GROUP BY d.DoctorID, d.Nombres, d.Apellidos, e.Nombre;
GO

-- Medicamentos con stock bajo (alerta de inventario)
CREATE VIEW vw_BI_StockBajo AS
SELECT ProductoID, Nombre, Tipo, Stock, StockMinimo
FROM MedicamentosInsumos
WHERE Stock <= StockMinimo AND Activo = 1;
GO

/* =========================================================================
   11. DATOS SEMILLA MINIMOS (catalogos base)
   ========================================================================= */

INSERT INTO Roles (NombreRol) VALUES ('Administrador'), ('Doctor'), ('Recepcion'), ('Farmacia');
GO

INSERT INTO Especialidades (Nombre) VALUES
('Medicina General'), ('Pediatria'), ('Ginecologia'), ('Cardiologia'), ('Dermatologia');
GO

INSERT INTO Enfermedades (CodigoCIE, Nombre, Descripcion) VALUES
('J00', 'Resfriado comun', 'Infeccion viral leve de las vias respiratorias altas'),
('E11', 'Diabetes tipo 2', 'Trastorno metabolico cronico'),
('I10', 'Hipertension arterial', 'Presion arterial elevada de forma sostenida');
GO

PRINT 'Base de datos SistemaMedico creada correctamente.';
GO