CREATE TABLE Product (Id INTEGER IDENTITY(1000,500) PRIMARY KEY
                     ,Name VARCHAR(45) COLLATE Latin1_General_100_CI_AS_SC_UTF8 NOT NULL
                     ,Price DECIMAL NOT NULL)