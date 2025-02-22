/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


-- Sample data for Tenants table
INSERT INTO Tenants (TenantName, CreatedBy, CreateDateTime, TransactionID)
VALUES 
('Tenant A', 'System', GETDATE(), NEWID()),
('Tenant B', 'System', GETDATE(), NEWID()),
('Tenant C', 'System', GETDATE(), NEWID());
GO


INSERT INTO Theaters (TenantID, Name, Location, Capacity, CreatedBy, CreateDateTime, TransactionID)
VALUES 
(1, 'Theater A1', 'Location A1', 3, 'System', GETDATE(), NEWID()),
(1, 'Theater A2', 'Location A2', 3, 'System', GETDATE(), NEWID()),
(2, 'Theater B1', 'Location B1', 2, 'System', GETDATE(), NEWID()),
(2, 'Theater B2', 'Location B2', 2, 'System', GETDATE(), NEWID()),
(3, 'Theater C1', 'Location C1', 2, 'System', GETDATE(), NEWID()),
(3, 'Theater C2', 'Location C2', 2, 'System', GETDATE(), NEWID());
GO

INSERT INTO Screens (TheaterID, Name, Capacity, CreatedBy, CreateDateTime, TransactionID)
VALUES 
(1, 'Screen 1', 50, 'System', GETDATE(), NEWID()),
(1, 'Screen 2', 60, 'System', GETDATE(), NEWID()),
(1, 'Screen 3', 40, 'System', GETDATE(), NEWID()),
(2, 'Screen 1', 50, 'System', GETDATE(), NEWID()),
(2, 'Screen 2', 70, 'System', GETDATE(), NEWID()),
(2, 'Screen 3', 80, 'System', GETDATE(), NEWID()),
(3, 'Screen 1', 60, 'System', GETDATE(), NEWID()),
(3, 'Screen 2', 70, 'System', GETDATE(), NEWID()),
(4, 'Screen 1', 55, 'System', GETDATE(), NEWID()),
(4, 'Screen 2', 65, 'System', GETDATE(), NEWID()),
(5, 'Screen 1', 45, 'System', GETDATE(), NEWID()),
(5, 'Screen 2', 55, 'System', GETDATE(), NEWID()),
(6, 'Screen 1', 75, 'System', GETDATE(), NEWID()),
(6, 'Screen 1', 85, 'System', GETDATE(), NEWID());
GO