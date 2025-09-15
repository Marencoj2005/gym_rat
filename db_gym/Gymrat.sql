CREATE USER 'Marenco'@'2800:e2:1e7f:e3db::2' IDENTIFIED BY 'nvidia';

GRANT ALL PRIVILEGES ON gymrat.* TO 'Marenco'@'2800:e2:1e7f:e3db::2';
FLUSH PRIVILEGES;

USE gymrat;

-- Tabla de Clientes
CREATE TABLE Clientes (
    Cedula INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    TipoUsuario ENUM('Socio', 'VIP', 'Basico') NOT NULL,
    Activo BOOLEAN DEFAULT TRUE
);

-- Tabla de Datos Físicos
CREATE TABLE DatosFisicos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
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

-- Tabla de Planes
CREATE TABLE Planes (
    Nit INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    TipoPlan ENUM('VIP', 'Basico', 'Incluido') NOT NULL,
    Indefinido BOOLEAN DEFAULT FALSE,
    Precio DECIMAL(10,2)
);

-- Tabla de Membresías (relación Cliente-Plan)
CREATE TABLE Membresias (
    IdMembresia INT AUTO_INCREMENT PRIMARY KEY,
    CedulaCliente INT NOT NULL,
    NitPlan INT NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE,
    Estado ENUM('Activa', 'Vencida', 'Cancelada') DEFAULT 'Activa',
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (NitPlan) REFERENCES Planes(Nit)
);

-- Tabla de Clases
CREATE TABLE Clases (
    IdClase INT AUTO_INCREMENT PRIMARY KEY,
    NombreClase VARCHAR(100),
    Horario TIME,
    CupoMaximo INT,
    SedeId INT
);

-- Tabla de Coach
CREATE TABLE Coach (
    Cedula INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Especialidad VARCHAR(100),
    HorarioTrabajo VARCHAR(50)
);

-- Tabla de Asignación de Coach a Clase
CREATE TABLE Asignado (
    CedulaCoach INT,
    IdClase INT,
    PRIMARY KEY (CedulaCoach, IdClase),
    FOREIGN KEY (CedulaCoach) REFERENCES Coach(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);

-- Tabla de Asistencia a Clases
CREATE TABLE Asistencia (
    IdAsistencia INT AUTO_INCREMENT PRIMARY KEY,
    CedulaCliente INT,
    IdClase INT,
    Fecha DATE,
    UNIQUE(CedulaCliente, IdClase, Fecha),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);

-- Tabla de Empleados
CREATE TABLE Empleados (
    Cedula INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Rol ENUM('Recepcion', 'Fisioterapeuta', 'JefeSede', 'Aseo', 'Asesor') NOT NULL,
    SedeId INT
);

-- Tabla de Sedes
CREATE TABLE Sedes (
    IdSede INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Ubicacion VARCHAR(150)
);

-- Tabla de Pagos
CREATE TABLE Pagos (
    IdPago INT AUTO_INCREMENT PRIMARY KEY,
    CedulaCliente INT,
    FechaPago DATE,
    Monto DECIMAL(10,2),
    MetodoPago ENUM('Efectivo', 'Tarjeta', 'Transferencia'),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);

-- Tabla de Reservas
CREATE TABLE Reservas (
    IdReserva INT AUTO_INCREMENT PRIMARY KEY,
    CedulaCliente INT,
    IdClase INT,
    FechaReserva DATE,
    Estado ENUM('Confirmada', 'Cancelada', 'Pendiente') DEFAULT 'Pendiente',
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);

-- Tabla de UsuariosLogin (autenticación)
CREATE TABLE UsuariosLogin (
    IdUsuario INT AUTO_INCREMENT PRIMARY KEY,
    CedulaCliente INT UNIQUE,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Rol ENUM('Cliente', 'Empleado', 'Admin') DEFAULT 'Cliente',
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);

-- Tabla de Feedback
CREATE TABLE Feedback (
    IdFeedback INT AUTO_INCREMENT PRIMARY KEY,
    CedulaCliente INT,
    IdClase INT,
    Comentario TEXT,
    Calificacion INT CHECK (Calificacion BETWEEN 1 AND 5),
    Fecha DATE,
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);

-- Tabla de Historial Físico
CREATE TABLE HistorialFisico (
    IdHistorial INT AUTO_INCREMENT PRIMARY KEY,
    CedulaCliente INT,
    Fecha DATE,
    Peso DECIMAL(5,2),
    IMC DECIMAL(5,2),
    MasaMuscular DECIMAL(5,2),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);

