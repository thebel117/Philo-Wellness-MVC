-- Insert sample data into the User table
INSERT INTO [User] (Name, UserType) VALUES ('John Doe', 'Student');
INSERT INTO [User] (Name, UserType) VALUES ('Jane Smith', 'Faculty');
INSERT INTO [User] (Name, UserType) VALUES ('Alice Johnson', 'Student');
INSERT INTO [User] (Name, UserType) VALUES ('Bob Brown', 'Student');
INSERT INTO [User] (Name, UserType) VALUES ('Charlie Davis', 'Student');
INSERT INTO [User] (Name, UserType) VALUES ('Daisy Evans', 'Student');
INSERT INTO [User] (Name, UserType) VALUES ('Ethan Foster', 'Student');
INSERT INTO [User] (Name, UserType) VALUES ('Fiona Green', 'Student');
INSERT INTO [User] (Name, UserType) VALUES ('George Harris', 'Faculty');
INSERT INTO [User] (Name, UserType) VALUES ('Hannah White', 'Faculty');

-- Insert sample data into the StudentProfile table
INSERT INTO StudentProfile (UserId, Grade, StudentIdNumber) VALUES (1, 10, 'S12345');
INSERT INTO StudentProfile (UserId, Grade, StudentIdNumber) VALUES (3, 9, 'S12346');
INSERT INTO StudentProfile (UserId, Grade, StudentIdNumber) VALUES (4, 11, 'S12347');
INSERT INTO StudentProfile (UserId, Grade, StudentIdNumber) VALUES (5, 12, 'S12348');
INSERT INTO StudentProfile (UserId, Grade, StudentIdNumber) VALUES (6, 10, 'S12349');
INSERT INTO StudentProfile (UserId, Grade, StudentIdNumber) VALUES (7, 8, 'S12350');
INSERT INTO StudentProfile (UserId, Grade, StudentIdNumber) VALUES (8, 9, 'S12351');

-- Insert sample data into the Visit table
INSERT INTO Visit (UserId, VisitDate, ReasonForVisit, DetailedReason) VALUES (1, '2024-08-07 10:00:00', 'Injury', 'Sprained ankle during soccer practice');
INSERT INTO Visit (UserId, VisitDate, ReasonForVisit, DetailedReason) VALUES (1, '2024-08-08 14:30:00', 'Illness', 'Fever and headache');
INSERT INTO Visit (UserId, VisitDate, ReasonForVisit, DetailedReason) VALUES (3, '2024-08-06 09:15:00', 'Illness', 'Stomach ache');
INSERT INTO Visit (UserId, VisitDate, ReasonForVisit, DetailedReason) VALUES (4, '2024-08-05 11:20:00', 'Injury', 'Cut fingers in woodworking class');
INSERT INTO Visit (UserId, VisitDate, ReasonForVisit, DetailedReason) VALUES (5, '2024-08-09 13:45:00', 'Illness', 'Dizziness and nausea');
INSERT INTO Visit (UserId, VisitDate, ReasonForVisit, DetailedReason) VALUES (6, '2024-08-07 08:30:00', 'Injury', 'Bruised knees from fall');
INSERT INTO Visit (UserId, VisitDate, ReasonForVisit, DetailedReason) VALUES (7, '2024-08-10 10:00:00', 'Illness', 'Sore throat and coughing fits');
INSERT INTO Visit (UserId, VisitDate, ReasonForVisit, DetailedReason) VALUES (8, '2024-08-11 14:30:00', 'Injury', 'Twisted left wrist in PE class');

-- Insert sample data into the Wellness table
INSERT INTO Wellness (UserId, SelfRating, FacultyRating, Incidents, Date) VALUES (1, 15, 17, 'Previous incident with anxiety', '2024-08-07');
INSERT INTO Wellness (UserId, SelfRating, FacultyRating, Incidents, Date) VALUES (1, 18, 19, 'No incidents', '2024-08-08');
INSERT INTO Wellness (UserId, SelfRating, FacultyRating, Incidents, Date) VALUES (3, 12, 14, 'None', '2024-08-06');
INSERT INTO Wellness (UserId, SelfRating, FacultyRating, Incidents, Date) VALUES (4, 16, 18, 'None', '2024-08-05');
INSERT INTO Wellness (UserId, SelfRating, FacultyRating, Incidents, Date) VALUES (5, 10, 12, 'History of migraines', '2024-08-09');
INSERT INTO Wellness (UserId, SelfRating, FacultyRating, Incidents, Date) VALUES (6, 14, 16, 'None', '2024-08-07');
INSERT INTO Wellness (UserId, SelfRating, FacultyRating, Incidents, Date) VALUES (7, 13, 15, 'Seasonal allergies', '2024-08-10');
INSERT INTO Wellness (UserId, SelfRating, FacultyRating, Incidents, Date) VALUES (8, 17, 19, 'None', '2024-08-11');
