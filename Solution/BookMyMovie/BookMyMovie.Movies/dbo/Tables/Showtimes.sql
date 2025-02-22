-- Showtimes Table
CREATE TABLE Showtimes (
    ShowtimeID INT IDENTITY(1,1) PRIMARY KEY,
    TenantID INT NOT NULL,
    MovieID INT NOT NULL,
    TheaterID INT NOT NULL,
    ScreenID INT NOT NULL,
    ShowDateTime DATETIME NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    AvailableSeats INT,
    CreatedBy NVARCHAR(255) NOT NULL,
    CreateDateTime DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(255),
    UpdateDateTime DATETIME,
    TransactionID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID),
    FOREIGN KEY (MovieID) REFERENCES Movies(MovieID),
    FOREIGN KEY (TheaterID) REFERENCES Theaters(TheaterID),
    FOREIGN KEY (ScreenID) REFERENCES Screens(ScreenID)
);
GO
CREATE INDEX IX_Showtimes_TenantID ON Showtimes(TenantID);