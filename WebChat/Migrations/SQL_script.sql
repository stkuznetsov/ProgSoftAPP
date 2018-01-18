CREATE TABLE [dbo].[TablePoster] (
    [ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50)  NULL,
    [Advert] VARCHAR (250) NULL,
    [Email] VARCHAR(250) NULL, 
    [PhoneNumber] VARCHAR(25) NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC)
);