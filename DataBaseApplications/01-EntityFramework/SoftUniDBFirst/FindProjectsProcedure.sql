﻿IF (Object_id ('usp_FindCountProjectsForEmployee') IS NOT NULL)
   DROP PROCEDURE usp_FindCountProjectsForEmployee
GO

CREATE PROCEDURE usp_FindCountProjectsForEmployee(@FirstName NVARCHAR(50), @LastName NVARCHAR(50))
AS
	SELECT COUNT(p.ProjectID)
	FROM Employees e
		JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects p ON ep.ProjectID = p.ProjectID
		WHERE e.FirstName = @FirstName AND e.LastName = @LastName
GO