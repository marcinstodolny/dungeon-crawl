DROP TABLE IF EXISTS Armors
DROP TABLE IF EXISTS Foods
DROP TABLE IF EXISTS Keys
DROP TABLE IF EXISTS Potions
DROP TABLE IF EXISTS Weapons
DROP TABLE IF EXISTS Allies
DROP TABLE IF EXISTS Enemies


CREATE TABLE [dbo].[Armors] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]   NCHAR (50) NULL,
    [Symbol] NCHAR (10) NULL,
    [Armor]  INT        NULL
);

CREATE TABLE [dbo].[Foods] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]    NCHAR (50) NULL,
    [Symbol]  NCHAR (10) NULL,
    [HPRestore] INT        NULL
);

CREATE TABLE [dbo].[Keys] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]   NCHAR (50) NULL,
    [Symbol] NCHAR (10) NULL,
);


CREATE TABLE [dbo].[Potions] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]    NCHAR (50) NULL,
    [Symbol]  NCHAR (10) NULL,
    [HPRestore] INT        NULL
);

CREATE TABLE [dbo].[Weapons] (
    [id]     INT        NOT NULL IDENTITY,
    [Name]   NCHAR (50) NULL,
    [Symbol] NCHAR (10) NULL,
    [Attack] INT        NULL,
    CONSTRAINT [PK_Weapon] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Allies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NULL,
	[Symbol] NCHAR(10) NULL,
    [Message] NCHAR(500) NULL, 
    [Bonus] INT NULL, 
    [Type] NCHAR(10) NULL 
);

CREATE TABLE [dbo].[Enemies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NULL,
	[Symbol] NCHAR(10) NULL,
    [Health] INT NULL, 
    [Damage] INT NULL 
);


INSERT INTO dbo.Armors (Name, Symbol, Armor)
VALUES ('Gambeson', '$', 2),
('Boiled leather', '$', 4),
('Shell armor', '$', 6),
('Scale armor', '$', 8),
('Laminar armor', '$', 9),
('Plated mail armor', '$', 10),
('Mail armor', '$', 12),
('Brigandine armor', '$', 14),
('Plate armor', '$', 16)

INSERT INTO dbo.Weapons (Name, Symbol, Attack)
VALUES ('Ultimate weapon - stick with a poo at the en', '$', 500),
('Slightly rusted pan', '$', 2),
('Club (Welcome to the club)', '$', 3),
('Short sword (looks big in small hands)', '$', 4),
('Short axe', '$', 5),
('Loooong sword', '$', 6),
('Long axe', '$', 7),
('Hammer time', '$', 8),
('Claymore', '$', 9)

INSERT INTO dbo.Potions (Name, Symbol, HPRestore)
VALUES ('Tears of your enemies', '$', 10),
('Blood of your enemies', '$', 15),
('Gin & Tonic', '$', 5),
('Dimetylotryptamina', 'D', 100),
('Dungeon water', '$', 1)

INSERT INTO dbo.Foods (Name, Symbol, HPRestore)
VALUES ('Dungeon chicken wings', '$', 10),
('Perfectly good steak found on the floor', '$', 20),
('Apple (an apple a day, keeps the doctor away)', '$', 2),
('Sushi mix set no.23 (I wonder who ordered it)', '$', 25),
('Cave food (hard to recognize what is it)', '$', 30)

INSERT INTO dbo.Keys (Name, Symbol)
VALUES ('Key', '$'),
('Diamond key', '$'),
('Golden key', '$')

INSERT INTO dbo.Enemies (Name, Symbol, Health, Damage)
VALUES ('Demon', 'E', 7, 20),
('Wolf', 'E', 8, 10)

INSERT INTO dbo.Allies (Name, Symbol, Message, Bonus, Type)
VALUES ('Merlin', 'W', 'Welcome to my house, I am merlin the wizard that will boost your health \nYou gained 20 bonus health', 20, 'Health'),
('David', 'W', 2, 'Welcome to my house, I am David long time ago I was a warrior and now I can show you how to deal more damage to enemies \nYou gained 2 bonus damage', 'Damage')