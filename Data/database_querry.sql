DROP TABLE IF EXISTS Armors
DROP TABLE IF EXISTS Foods
DROP TABLE IF EXISTS Keys
DROP TABLE IF EXISTS Potions
DROP TABLE IF EXISTS Weapons
DROP TABLE IF EXISTS Allies
DROP TABLE IF EXISTS Enemies

DROP TABLE IF EXISTS SAVE_Player
DROP TABLE IF EXISTS SAVE_Room
DROP TABLE IF EXISTS SAVE_RoomCorners
DROP TABLE IF EXISTS SAVE_Doors
DROP TABLE IF EXISTS SAVE_MapItems
DROP TABLE IF EXISTS SAVE_Inventory
DROP TABLE IF EXISTS SAVE_Monsters


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
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]   NCHAR (50) NULL,
    [Symbol] NCHAR (10) NULL,
    [Attack] INT        NULL,
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

CREATE TABLE [dbo].[SAVE_Player] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NULL,
    [Coord_X] INT NULL,
    [Coord_Y] INT NULL,
    [Armor]  INT NULL,
    [HP] INT NULL,
    [Damage]  INT NULL,
    [Alive] BIT NULL,
    [DMT] BIT NULL,
);
CREATE TABLE [dbo].[SAVE_Room] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Corner_NW_id] INT NULL,
    [Corner_NE_id] INT NULL,
    [Corner_SW_id] INT NULL,
    [Corner_SE_id] INT NULL,
    [Visibility] BIT NULL,
);
CREATE TABLE [dbo].[SAVE_RoomCorners] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Room_id] INT NULL,
    [Coord_X] INT NULL,
    [Coord_Y] INT NULL,
);
CREATE TABLE [dbo].[SAVE_Doors] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Room_id] INT NULL,
    [Coord_X] INT NULL,
    [Coord_Y] INT NULL,
    [Opened] BIT NULL,
);
CREATE TABLE [dbo].[SAVE_MapItems] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Item_Id] INT NULL,
    [Coord_X] INT NULL,
    [Coord_Y] INT NULL,
);
CREATE TABLE [dbo].[SAVE_Monsters] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Monster_Id] INT NULL,
    [Coord_X] INT NULL,
    [Coord_Y] INT NULL,
);

CREATE TABLE [dbo].[SAVE_Inventory] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Item_Type] NCHAR(10) NULL,
    [Item_Id] INT NULL,
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
VALUES ('Merlin', 'W', 'Welcome to my house, I am merlin the wizard that will boost your health
You gained 20 bonus health', 20, 'Health'),
('David', 'W', 'Welcome to my house, I am David long time ago I was a warrior and now I can show you how to deal more damage to enemies
You gained 2 bonus damage', 2, 'Damage')