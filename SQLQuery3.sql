CREATE TABLE [dbo].[usersTable] (
    [UserId]        INT           IDENTITY (1, 1) NOT NULL,
    [userName]      NVARCHAR (50) NOT NULL,
    [password]      NVARCHAR (50) NOT NULL,
    [firstName]     NVARCHAR (50) COLLATE Hebrew_CI_AS NOT NULL,
    [lastName]      NVARCHAR (50) COLLATE Hebrew_CI_AS NOT NULL,
    [gender]        NVARCHAR (50) COLLATE Hebrew_CI_AS NOT NULL,
    [phoneAreaCode] NVARCHAR (3)  NULL,
    [phone]         NVARCHAR (10) NULL,
    [email]         NVARCHAR (50) NOT NULL,
    [admin]         BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([userName] ASC),
    UNIQUE NONCLUSTERED ([userName] ASC),
    UNIQUE NONCLUSTERED ([userName] ASC)
);