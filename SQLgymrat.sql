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

-- Clientes
INSERT INTO Clientes (Cedula, Nombre, Email, TipoUsuario, Activo)
VALUES
(12345, 'Juan Perez', 'juan.perez@example.com', 'Socio', 1),
(67890, 'Maria Lopez', 'maria.lopez@example.com', 'VIP', 1),
(13579, 'Luis Torres', 'luis.torres@example.com', 'Basico', 1),
(24680, 'Ana Mejía', 'ana.mejia@example.com', 'VIP', 1),
(11223, 'Camilo Ríos', 'camilo.rios@example.com', 'Socio', 1);
GO

-- Datos Físicos
INSERT INTO DatosFisicos (CedulaCliente, FechaRegistro, Altura, Peso, IMC, GrasaCorporal, MasaMuscular, Metabolismo, Agua)
VALUES
(12345, '2025-09-18', 1.75, 70.50, 22.9, 18.5, 31.2, 1500, 60.0),
(67890, '2025-09-18', 1.65, 60.00, 22.0, 20.0, 29.5, 1600, 58.0),
(13579, '2025-09-18', 1.80, 75.00, 23.1, 19.0, 32.0, 1550, 61.0),
(24680, '2025-09-18', 1.70, 65.00, 22.5, 21.0, 30.0, 1580, 59.0),
(11223, '2025-09-18', 1.68, 62.00, 21.9, 20.5, 28.5, 1520, 57.5);
GO

-- Planes
INSERT INTO Planes (Nit, Nombre, TipoPlan, Indefinido, Precio)
VALUES
(1001, 'Plan Básico', 'Basico', 0, 29.99),
(1002, 'Plan VIP', 'VIP', 0, 59.99),
(1003, 'Plan Socio', 'Socio', 0, 39.99),
(1004, 'Plan Premium', 'VIP', 1, 79.99),
(1005, 'Plan Express', 'Basico', 0, 19.99);
GO

-- Membresías
INSERT INTO Membresias (CedulaCliente, NitPlan, FechaInicio, FechaFin, Estado)
VALUES
(12345, 1001, '2025-01-01', '2025-12-31', 'Activa'),
(67890, 1002, '2025-03-01', NULL, 'Activa'),
(13579, 1003, '2025-04-01', '2025-12-31', 'Activa'),
(24680, 1004, '2025-05-01', NULL, 'Activa'),
(11223, 1005, '2025-06-01', '2025-09-30', 'Vencida');
GO

-- Sedes
INSERT INTO Sedes (Nombre, Ubicacion)
VALUES
('Sede Principal', 'Calle 123, Ciudad, País'),
('Sede Secundaria', 'Calle 456, Ciudad, País'),
('Sede Norte', 'Avenida 789, Ciudad, País'),
('Sede Sur', 'Carrera 321, Ciudad, País'),
('Sede Centro', 'Diagonal 654, Ciudad, País');
GO

-- Clases
INSERT INTO Clases (NombreClase, Horario, CupoMaximo, SedeId)
VALUES
('Zumba', '08:00', 20, 1),
('Yoga', '09:30', 15, 2),
('CrossFit', '10:30', 25, 3),
('Pilates', '11:00', 12, 4),
('Funcional', '12:30', 18, 5);
GO

-- Coach
INSERT INTO Coach (Cedula, Nombre, Especialidad, HorarioTrabajo)
VALUES
(11111, 'Carlos Gómez', 'Entrenador Personal', '08:00 - 16:00'),
(22222, 'Laura Ruiz', 'Yoga', '09:00 - 17:00'),
(33333, 'Esteban Díaz', 'CrossFit', '10:00 - 18:00'),
(44444, 'Natalia Gómez', 'Pilates', '11:00 - 19:00'),
(55555, 'Andrés Mora', 'Funcional', '12:00 - 20:00');
GO

-- Asignado
INSERT INTO Asignado (CedulaCoach, IdClase)
VALUES
(11111, 1),
(22222, 2),
(33333, 3),
(44444, 4),
(55555, 5);
GO

-- Asistencia
INSERT INTO Asistencia (CedulaCliente, IdClase, Fecha)
VALUES
(12345, 1, '2025-09-18'),
(67890, 2, '2025-09-18'),
(13579, 3, '2025-09-18'),
(24680, 4, '2025-09-18'),
(11223, 5, '2025-09-18');
GO

-- Empleados
INSERT INTO Empleados (Cedula, Nombre, Rol, SedeId)
VALUES
(33333, 'Pedro González', 'Recepcion', 1),
(44444, 'Sofia Martínez', 'Fisioterapeuta', 2),
(55556, 'Daniela Pineda', 'JefeSede', 3),
(66667, 'Jorge Ramírez', 'Aseo', 4),
(77778, 'Valentina Cruz', 'Asesor', 5);
GO

-- Pagos
INSERT INTO Pagos (CedulaCliente, FechaPago, Monto, MetodoPago)
VALUES
(12345, '2025-09-15', 29.99, 'Tarjeta'),
(67890, '2025-09-15', 59.99, 'Transferencia'),
(13579, '2025-09-16', 39.99, 'Efectivo'),
(24680, '2025-09-16', 79.99, 'Tarjeta'),
(11223, '2025-09-16', 19.99, 'Transferencia');
GO

-- Reservas
INSERT INTO Reservas (CedulaCliente, IdClase, FechaReserva, Estado)
VALUES
(12345, 1, '2025-09-18', 'Confirmada'),
(67890, 2, '2025-09-18', 'Pendiente'),
(13579, 3, '2025-09-18', 'Confirmada'),
(24680, 4, '2025-09-18', 'Pendiente'),
(11223, 5, '2025-09-18', 'Cancelada');
GO

-- UsuariosLogin
INSERT INTO UsuariosLogin (CedulaCliente, Email, PasswordHash, Rol)
VALUES
(12345, 'juan.perez@example.com', 'hashedpassword123', 'Cliente'),
(67890, 'maria.lopez@example.com', 'hashedpassword456', 'Cliente'),
(13579, 'luis.torres@example.com', 'hashedpassword789', 'Cliente'),
(24680, 'ana.mejia@example.com', 'hashedpassword101', 'Cliente'),
(11223, 'camilo.rios@example.com', 'hashedpassword202', 'Cliente');
GO

-- Feedback
INSERT INTO Feedback (CedulaCliente, IdClase, Comentario, Calificacion, Fecha)
VALUES
(12345, 1, 'Muy buena clase, me siento más enérgico.', 5, '2025-09-18'),
(67890, 2, 'Clase relajante y muy útil para mi flexibilidad.', 4, '2025-09-18'),
(13579, 3, 'Clase intensa, me encantó.', 5, '2025-09-18'),
(24680, 4, 'Muy buena técnica de respiración.', 4, '2025-09-18'),
(11223, 5, 'Me gustaría más variedad de ejercicios.', 3, '2025-09-18');
GO

-- Historial Físico
INSERT INTO HistorialFisico (CedulaCliente, Fecha, Peso, IMC, MasaMuscular)
VALUES
(12345, '2025-09-18', 70.50, 22.9, 31.2),
(67890, '2025-09-18', 60.00, 22.0, 29.5),
(13579, '2025-09-18', 75.00, 23.1, 32.0),
(24680, '2025-09-18', 65.00, 22.


-- Clientes
SELECT * FROM Clientes;

-- Datos Físicos
SELECT * FROM DatosFisicos;

-- Planes
SELECT * FROM Planes;

-- Membresías
SELECT * FROM Membresias;

-- Sedes
SELECT * FROM Sedes;

-- Clases
SELECT * FROM Clases;

-- Coach
SELECT * FROM Coach;

-- Asignado
SELECT * FROM Asignado;

-- Asistencia
SELECT * FROM Asistencia;

-- Empleados
SELECT * FROM Empleados;

-- Pagos
SELECT * FROM Pagos;

-- Reservas
SELECT * FROM Reservas;

-- UsuariosLogin
SELECT * FROM UsuariosLogin;

-- Feedback
SELECT * FROM Feedback;

-- Historial Físico
SELECT * FROM HistorialFisico;