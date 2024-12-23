CREATE TABLE [dbo].[usersData] (
    [user_id]      INT           IDENTITY (1, 1) NOT NULL,
    [username]     VARCHAR (100) NOT NULL,
    [email]        VARCHAR (100) NOT NULL,
    [full_name]    VARCHAR (255) NOT NULL,
    [phone_number] VARCHAR (20)  NULL,
    [role]         VARCHAR (10)  DEFAULT ('User') NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);

