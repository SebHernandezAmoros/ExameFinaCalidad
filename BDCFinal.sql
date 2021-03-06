USE ExamFinalCalidad

CREATE TABLE Cuenta(
	CuentaId int IDENTITY PRIMARY KEY NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Propio BIT NOT NULL,
	SaldoInicial FLOAT NOT NULL,
	Dolares BIT NOT NULL
);
CREATE TABLE Transaccion(
	TransaccionId int IDENTITY PRIMARY KEY NOT NULL,
	Cuenta VARCHAR(100) NOT NULL,
	Fecha DATETIME NOT NULL,
	Descripcion VARCHAR(300) NOT NULL,
	Monto FLOAT NOT NULL,
	Gasto BIT NOT NULL
);
CREATE TABLE TipoCambio(
	TipoCambioId int IDENTITY PRIMARY KEY NOT NULL,
	SolDolar FLOAT NOT NULL,
	DolarSol FLOAT NOT NULL
);