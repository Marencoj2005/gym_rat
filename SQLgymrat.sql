CREATE DATABASE gymrat_db;
GO
USE gymrat_db;
GO

-- Tabla de Clientes
CREATE TABLE Clientes (
    Cedula INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    TipoUsuario NVARCHAR(20) NOT NULL CHECK (TipoUsuario IN ('Socio', 'VIP', 'Basico')),
    Activo BIT DEFAULT 1
);
GO
-- Tabla de Datos Físicos
CREATE TABLE DatosFisicos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    FechaRegistro DATE NOT NULL,
    Altura DECIMAL(4,2),
    Peso DECIMAL(5,2),
    IMC DECIMAL(5,2),
    GrasaCorporal DECIMAL(5,2),
    MasaMuscular DECIMAL(5,2),
    Metabolismo INT,
    Agua DECIMAL(5,2),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);
GO
-- Tabla de Planes
CREATE TABLE Planes (
    Nit INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    TipoPlan NVARCHAR(20) NOT NULL CHECK (TipoPlan IN ('VIP', 'Basico', 'Incluido')),
    Indefinido BIT DEFAULT 0,
    Precio DECIMAL(10,2)
);
GO
-- Tabla de Membresías
CREATE TABLE Membresias (
    IdMembresia INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    NitPlan INT NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE,
    Estado NVARCHAR(20) DEFAULT 'Activa' CHECK (Estado IN ('Activa', 'Vencida', 'Cancelada')),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (NitPlan) REFERENCES Planes(Nit)
);
GO

-- Tabla de Sedes
CREATE TABLE Sedes (
    IdSede INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Ubicacion NVARCHAR(150)
);
GO
-- Tabla de Clases
CREATE TABLE Clases (
    IdClase INT IDENTITY(1,1) PRIMARY KEY,
    NombreClase NVARCHAR(100),
    Horario TIME,
    CupoMaximo INT,
    SedeId INT,
    FOREIGN KEY (SedeId) REFERENCES Sedes(IdSede)
);
GO
-- Tabla de Coach
CREATE TABLE Coach (
    Cedula INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Especialidad NVARCHAR(100),
    HorarioTrabajo NVARCHAR(50)
);
GO
-- Tabla de Asignación Coach–Clase
CREATE TABLE Asignado (
    CedulaCoach INT NOT NULL,
    IdClase INT NOT NULL,
    PRIMARY KEY (CedulaCoach, IdClase),
    FOREIGN KEY (CedulaCoach) REFERENCES Coach(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);
GO
-- Tabla de Asistencia
CREATE TABLE Asistencia (
    IdAsistencia INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    IdClase INT NOT NULL,
    Fecha DATE NOT NULL,
    CONSTRAINT UQ_Asistencia UNIQUE (CedulaCliente, IdClase, Fecha),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);
GO
-- Tabla de Empleados
CREATE TABLE Empleados (
    Cedula INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Rol NVARCHAR(30) CHECK (Rol IN ('Recepcion', 'Fisioterapeuta', 'JefeSede', 'Aseo', 'Asesor')),
    SedeId INT,
    FOREIGN KEY (SedeId) REFERENCES Sedes(IdSede)
);
GO
-- Tabla de Pagos
CREATE TABLE Pagos (
    IdPago INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    FechaPago DATE,
    Monto DECIMAL(10,2),
    MetodoPago NVARCHAR(20) CHECK (MetodoPago IN ('Efectivo', 'Tarjeta', 'Transferencia')),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);
GO
-- Tabla de Reservas
CREATE TABLE Reservas (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    IdClase INT NOT NULL,
    FechaReserva DATE,
    Estado NVARCHAR(20) DEFAULT 'Pendiente' CHECK (Estado IN ('Confirmada', 'Cancelada', 'Pendiente')),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);
GO
-- Tabla de UsuariosLogin
CREATE TABLE UsuariosLogin (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Rol NVARCHAR(20) DEFAULT 'Cliente' CHECK (Rol IN ('Cliente', 'Empleado', 'Admin')),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);
GO
-- Tabla de Feedback
CREATE TABLE Feedback (
    IdFeedback INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    IdClase INT NOT NULL,
    Comentario NVARCHAR(MAX),
    Calificacion INT CHECK (Calificacion BETWEEN 1 AND 5),
    Fecha DATE,
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);
GO
-- Tabla de Historial Físico
CREATE TABLE HistorialFisico (
    IdHistorial INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    Fecha DATE,
    Peso DECIMAL(5,2),
    IMC DECIMAL(5,2),
    MasaMuscular DECIMAL(5,2),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);
GO

INSERT INTO Clientes (Cedula, Nombre, Email, TipoUsuario, Activo) 
VALUES 
(12345, 'Juan Perez', 'juan.perez@example.com', 'Socio', 1),
(67890, 'Maria Lopez', 'maria.lopez@example.com', 'VIP', 1);
GO

INSERT INTO DatosFisicos (CedulaCliente, FechaRegistro, Altura, Peso, IMC, GrasaCorporal, MasaMuscular, Metabolismo, Agua) 
VALUES 
(12345, '2025-09-18', 1.75, 70.50, 22.9, 18.5, 31.2, 1500, 60.0),
(67890, '2025-09-18', 1.65, 60.00, 22.0, 20.0, 29.5, 1600, 58.0);
GO

INSERT INTO Planes (Nit, Nombre, TipoPlan, Indefinido, Precio) 
VALUES 
(1001, 'Plan Básico', 'Basico', 0, 29.99),
(1002, 'Plan VIP', 'VIP', 0, 59.99);
GO

INSERT INTO Membresias (CedulaCliente, NitPlan, FechaInicio, FechaFin, Estado) 
VALUES 
(12345, 1001, '2025-01-01', '2025-12-31', 'Activa'),
(67890, 1002, '2025-03-01', NULL, 'Activa');
GO

INSERT INTO Sedes (Nombre, Ubicacion) 
VALUES 
('Sede Principal', 'Calle 123, Ciudad, País'),
('Sede Secundaria', 'Calle 456, Ciudad, País');
GO

INSERT INTO Clases (NombreClase, Horario, CupoMaximo, SedeId) 
VALUES 
('Zumba', '08:00', 20, 1),
('Yoga', '09:30', 15, 2);
GO

INSERT INTO Coach (Cedula, Nombre, Especialidad, HorarioTrabajo) 
VALUES 
(11111, 'Carlos Gómez', 'Entrenador Personal', '08:00 - 16:00'),
(22222, 'Laura Ruiz', 'Yoga', '09:00 - 17:00');
GO

INSERT INTO Asignado (CedulaCoach, IdClase) 
VALUES 
(11111, 1),
(22222, 2);
GO

INSERT INTO Asistencia (CedulaCliente, IdClase, Fecha) 
VALUES 
(12345, 1, '2025-09-18'),
(67890, 2, '2025-09-18');
GO

INSERT INTO Empleados (Cedula, Nombre, Rol, SedeId) 
VALUES 
(33333, 'Pedro González', 'Recepcion', 1),
(44444, 'Sofia Martínez', 'Fisioterapeuta', 2);
GO

INSERT INTO Pagos (CedulaCliente, FechaPago, Monto, MetodoPago) 
VALUES 
(12345, '2025-09-15', 29.99, 'Tarjeta'),
(67890, '2025-09-15', 59.99, 'Transferencia');
GO

INSERT INTO Reservas (CedulaCliente, IdClase, FechaReserva, Estado) 
VALUES 
(12345, 1, '2025-09-18', 'Confirmada'),
(67890, 2, '2025-09-18', 'Pendiente');
GO

INSERT INTO UsuariosLogin (CedulaCliente, Email, PasswordHash, Rol) 
VALUES 
(12345, 'juan.perez@example.com', 'hashedpassword123', 'Cliente'),
(67890, 'maria.lopez@example.com', 'hashedpassword456', 'Cliente');
GO

INSERT INTO Feedback (CedulaCliente, IdClase, Comentario, Calificacion, Fecha) 
VALUES 
(12345, 1, 'Muy buena clase, me siento más enérgico.', 5, '2025-09-18'),
(67890, 2, 'Clase relajante y muy útil para mi flexibilidad.', 4, '2025-09-18');
GO

INSERT INTO HistorialFisico (CedulaCliente, Fecha, Peso, IMC, MasaMuscular) 
VALUES 
(12345, '2025-09-18', 70.50, 22.9, 31.2),
(67890, '2025-09-18', 60.00, 22.0, 29.5);
GO
