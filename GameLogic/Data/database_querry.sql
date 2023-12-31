DROP TABLE IF EXISTS Armor
DROP TABLE IF EXISTS Food
DROP TABLE IF EXISTS Keys
DROP TABLE IF EXISTS Potion
DROP TABLE IF EXISTS Weapon
DROP TABLE IF EXISTS Ally
DROP TABLE IF EXISTS Enemy

DROP TABLE IF EXISTS SAVE_Player
DROP TABLE IF EXISTS SAVE_Grid
DROP TABLE IF EXISTS SAVE_Inventory



CREATE TABLE [dbo].[Armor] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]   NCHAR (50) NULL,
    [Symbol] NCHAR (10) NULL,
    [Armor]  INT        NULL
);

CREATE TABLE [dbo].[Food] (
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


CREATE TABLE [dbo].[Potion] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]    NCHAR (50) NULL,
    [Symbol]  NCHAR (10) NULL,
    [HPRestore] INT        NULL
);

CREATE TABLE [dbo].[Weapon] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]   NCHAR (50) NULL,
    [Symbol] NCHAR (10) NULL,
    [Attack] INT        NULL,
);

CREATE TABLE [dbo].[Ally]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NULL,
	[Symbol] NCHAR(10) NULL,
    [Message] NCHAR(500) NULL, 
    [Bonus] INT NULL, 
    [Type] NCHAR(10) NULL 
);

CREATE TABLE [dbo].[Enemy]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NULL,
	[Symbol] NCHAR(10) NULL,
    [Health] INT NULL, 
    [Damage] INT NULL 
);

CREATE TABLE [dbo].[SAVE_Player] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NULL,
    [Coord_X] INT NULL,
    [Coord_Y] INT NULL,
    [Armor]  INT NULL,
    [HP] INT NULL,
    [Damage]  INT NULL,
    [Alive] BIT NULL,
    [DMT] BIT NULL
);
CREATE TABLE [dbo].[SAVE_Grid] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Coord_X] INT NULL,
    [Coord_Y] INT NULL,
    [Status] NCHAR(50) NULL,
    [Walkable] BIT NULL,
    [Visible] BIT NULL,
    [Interact_Type] NCHAR(50) NULL,
    [Interact_Id] INT NULL,

);

CREATE TABLE [dbo].[SAVE_Inventory] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Item_Name] NCHAR(50) NULL,
    [Item_Count] INT NULL
);


INSERT INTO dbo.Armor (Name, Symbol, Armor)
VALUES ('Gambeson', '$', 2),
('Boiled leather', '$', 4),
('Shell armor', '$', 6),
('Scale armor', '$', 8),
('Laminar armor', '$', 9),
('Plated mail armor', '$', 10),
('Mail armor', '$', 12),
('Brigandine armor', '$', 14),
('Plate armor', '$', 16)

INSERT INTO dbo.Weapon (Name, Symbol, Attack)
VALUES ('Ultimate weapon - stick with a poo at the en', '$', 500),
('Slightly rusted pan', '$', 2),
('Club (Welcome to the club)', '$', 3),
('Short sword (looks big in small hands)', '$', 4),
('Short axe', '$', 5),
('Loooong sword', '$', 6),
('Long axe', '$', 7),
('Hammer time', '$', 8),
('Claymore', '$', 9)

INSERT INTO dbo.Potion (Name, Symbol, HPRestore)
VALUES ('Tears of your enemies', '$', 10),
('Blood of your enemies', '$', 15),
('Gin & Tonic', '$', 5),
('N,N-Dimethyltryptamine', 'D', 100),
('Dungeon water', '$', 1)

INSERT INTO dbo.Food (Name, Symbol, HPRestore)
VALUES ('Dungeon chicken wings', '$', 10),
('Perfectly good steak found on the floor', '$', 20),
('Apple (an apple a day, keeps the doctor away)', '$', 2),
('Sushi mix set no.23 (I wonder who ordered it)', '$', 25),
('Cave food (hard to recognize what is it)', '$', 30)

INSERT INTO dbo.Keys (Name, Symbol)
VALUES ('Key', '$'),
('Diamond key', '$'),
('Golden key', '$')

INSERT INTO dbo.Enemy (Name, Symbol, Damage, Health)
VALUES ('Demon', 'E', 7, 20),
('Wolf', 'E', 8, 10)

INSERT INTO dbo.Ally (Name, Symbol, Message, Bonus, Type)
VALUES ('Merlin', 'W', 'Welcome to my house, I am merlin the wizard that will boost your health
You gained 20 bonus health', 20, 'Health'),
('David', 'W', 'Welcome to my house, I am David long time ago I was a warrior and now I can show you how to deal more damage to enemies
You gained 2 bonus damage', 2, 'Damage')