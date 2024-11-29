CREATE TABLE DoctorRegistrations
(
    Id INT IDENTITY(1,1) PRIMARY KEY,     -- Auto-incrementing ID
    Name NVARCHAR(100) NOT NULL,           -- Doctor's Name (Required)
    Surname NVARCHAR(100) NOT NULL,        -- Doctor's Surname (Required)
    IdNumber NVARCHAR(20),                 -- Optional: Doctor's ID number
    ContactDetails NVARCHAR(200) NOT NULL, -- Contact Details (Required)
    Email NVARCHAR(100) NOT NULL,          -- Email Address (Required)
    DoctorNumberId INT NOT NULL            -- Doctor Number (Required)
);
