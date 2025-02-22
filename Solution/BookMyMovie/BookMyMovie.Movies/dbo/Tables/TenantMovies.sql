-- Tenant-Specific Movie Metadata
CREATE TABLE TenantMovies (
    TenantID INT NOT NULL,
    MovieID INT NOT NULL,
    CustomTitle NVARCHAR(255),
    CustomDescription NVARCHAR(MAX),
    Pricing DECIMAL(10,2),
    Available bit DEFAULT 1,
    CreatedBy NVARCHAR(255) NOT NULL,
    CreateDateTime DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(255),
    UpdateDateTime DATETIME,
    TransactionID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    PRIMARY KEY (TenantID, MovieID),
    FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID),
    FOREIGN KEY (MovieID) REFERENCES Movies(MovieID)
);
GO
-- Indexes for faster querying
CREATE INDEX IX_TenantMovies_TenantID ON TenantMovies(TenantID);