-- Create the User table, all this AFTER creating and using DB!
CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    UserType VARCHAR(50) NOT NULL -- "Student" or "Faculty"
);

-- Create the StudentProfile table
CREATE TABLE StudentProfile (
    StudentProfileId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    Grade INT,
    StudentIdNumber VARCHAR(50),
    FOREIGN KEY (UserId) REFERENCES [User](UserId) ON DELETE CASCADE
);

-- Create the Visit table
CREATE TABLE Visit (
    VisitId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    VisitDate DATETIME NOT NULL,
    ReasonForVisit VARCHAR(255) NOT NULL,
    DetailedReason VARCHAR(255),
    FOREIGN KEY (UserId) REFERENCES [User](UserId) ON DELETE CASCADE
);

-- Create the Wellness table
CREATE TABLE Wellness (
    WellnessId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    SelfRating INT NOT NULL, -- 1-20 scale
    FacultyRating INT NOT NULL, -- 1-20 scale
    Incidents TEXT,
    Date DATETIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId) ON DELETE CASCADE
);


