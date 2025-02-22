-- Movies Table (Shared across tenants)
CREATE TABLE Movies (
    MovieID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    ReleaseDate DATE,
    DurationMinutes INT,
    Genre NVARCHAR(100),
    CreatedBy NVARCHAR(255) NOT NULL,
    CreateDateTime DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(255),
    UpdateDateTime DATETIME,
    TransactionID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
);