-- Screens Table
CREATE TABLE Screens (
    ScreenID INT IDENTITY(1,1) PRIMARY KEY,
    TheaterID INT NOT NULL,
    Name NVARCHAR(100),
    Capacity INT,
    CreatedBy NVARCHAR(255) NOT NULL,
    CreateDateTime DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(255),
    UpdateDateTime DATETIME,
    TransactionID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    FOREIGN KEY (TheaterID) REFERENCES Theaters(TheaterID)
);