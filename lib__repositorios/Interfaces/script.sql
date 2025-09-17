CREATE DATABASE gymrat_db;
GO
USE gymrat_db;
GO

CREATE TABLE Clientes (
    Cedula INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    TipoUsuario NVARCHAR(20) NOT NULL CHECK (TipoUsuario IN ('Socio', 'VIP', 'Basico')),
    Activo BIT DEFAULT 1
);
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
CREATE TABLE Planes (
    Nit INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    TipoPlan NVARCHAR(20) NOT NULL CHECK (TipoPlan IN ('VIP', 'Basico', 'Incluido')),
    Indefinido BIT DEFAULT 0,
    Precio DECIMAL(10,2)
);
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
CREATE TABLE Sedes (
    IdSede INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Ubicacion NVARCHAR(150)
);
CREATE TABLE Clases (
    IdClase INT IDENTITY(1,1) PRIMARY KEY,
    NombreClase NVARCHAR(100),
    Horario TIME,
    CupoMaximo INT,
    SedeId INT,
    FOREIGN KEY (SedeId) REFERENCES Sedes(IdSede)
);
CREATE TABLE Coach (
    Cedula INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Especialidad NVARCHAR(100),
    HorarioTrabajo NVARCHAR(50)
);
CREATE TABLE Asignado (
    CedulaCoach INT NOT NULL,
    IdClase INT NOT NULL,
    PRIMARY KEY (CedulaCoach, IdClase),
    FOREIGN KEY (CedulaCoach) REFERENCES Coach(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);
CREATE TABLE Asistencia (
    IdAsistencia INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    IdClase INT NOT NULL,
    Fecha DATE NOT NULL,
    CONSTRAINT UQ_Asistencia UNIQUE (CedulaCliente, IdClase, Fecha),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);
CREATE TABLE Empleados (
    Cedula INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Rol NVARCHAR(30) CHECK (Rol IN ('Recepcion', 'Fisioterapeuta', 'JefeSede', 'Aseo', 'Asesor')),
    SedeId INT,
    FOREIGN KEY (SedeId) REFERENCES Sedes(IdSede)
);
CREATE TABLE Pagos (
    IdPago INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    FechaPago DATE,
    Monto DECIMAL(10,2),
    MetodoPago NVARCHAR(20) CHECK (MetodoPago IN ('Efectivo', 'Tarjeta', 'Transferencia')),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);
CREATE TABLE Reservas (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    IdClase INT NOT NULL,
    FechaReserva DATE,
    Estado NVARCHAR(20) DEFAULT 'Pendiente' CHECK (Estado IN ('Confirmada', 'Cancelada', 'Pendiente')),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);
CREATE TABLE UsuariosLogin (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Rol NVARCHAR(20) DEFAULT 'Cliente' CHECK (Rol IN ('Cliente', 'Empleado', 'Admin')),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);
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
CREATE TABLE HistorialFisico (
    IdHistorial INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    Fecha DATE,
    Peso DECIMAL(5,2),
    IMC DECIMAL(5,2),
    MasaMuscular DECIMAL(5,2),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);