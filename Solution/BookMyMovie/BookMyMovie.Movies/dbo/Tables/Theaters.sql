-- Theaters Table
CREATE TABLE Theaters (
    TheaterID INT IDENTITY(1,1) PRIMARY KEY,
    TenantID INT NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Location NVARCHAR(255),
    Capacity INT,
    CreatedBy NVARCHAR(255) NOT NULL,
    CreateDateTime DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(255),
    UpdateDateTime DATETIME,
    TransactionID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
);
GO
CREATE INDEX IX_Theaters_TenantID ON Theaters(TenantID);