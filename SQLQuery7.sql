CREATE TABLE DoctorRegistrations (
    Id INT IDENTITY(1,1) PRIMARY KEY,           -- Auto-incrementing Id
    Name NVARCHAR(100) NOT NULL,                -- Required field for Name
    Surname NVARCHAR(100) NOT NULL,             -- Required field for Surname
    IdNumber NVARCHAR(20),                      -- Optional field for IdNumber
    ContactDetails NVARCHAR(255) NOT NULL,      -- Required field for ContactDetails
    Email NVARCHAR(255) NOT NULL,               -- Required field for Email
    DoctorNumberId INT,                         -- Optional field for DoctorNumberId
    PasswordHash NVARCHAR(255)                  -- Optional field for PasswordHash
);
