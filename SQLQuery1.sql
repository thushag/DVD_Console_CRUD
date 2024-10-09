CREATE DATABASE MovieRentalManagement;
Use MovieRentalManagement;

CREATE TABLE Movies (
    MovieId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100),
    Director NVARCHAR(100),
    RentalPrice DECIMAL(18, 2)
);

INSERT INTO Movies (Title, Director, RentalPrice) VALUES ('Jeans', 'Shankar', 1.00);

select * From Movies;



