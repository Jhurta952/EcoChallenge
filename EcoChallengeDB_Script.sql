USE EcoChallengeDB;
GO

CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) UNIQUE NOT NULL,
    Contrasena NVARCHAR(100) NOT NULL,
    Rol NVARCHAR(20) NOT NULL CHECK (Rol IN ('Jugador', 'Administrador')),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Misiones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Puntos INT NOT NULL,
    Tipo NVARCHAR(50) NOT NULL,
    Activa BIT DEFAULT 1
);
GO

CREATE TABLE Progreso (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdMision INT NOT NULL,
    Completada BIT DEFAULT 0,
    FechaAsignacion DATETIME DEFAULT GETDATE(),
    FechaCompletada DATETIME NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
    FOREIGN KEY (IdMision) REFERENCES Misiones(Id)
);
GO

CREATE TABLE Recompensas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    PuntosNecesarios INT NOT NULL
);
GO

CREATE TABLE UsuariosRecompensas (
    IdUsuario INT NOT NULL,
    IdRecompensa INT NOT NULL,
    FechaOtorgada DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (IdUsuario, IdRecompensa),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
    FOREIGN KEY (IdRecompensa) REFERENCES Recompensas(Id)
);
GO
