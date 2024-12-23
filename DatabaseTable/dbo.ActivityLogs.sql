CREATE TABLE [dbo].[ActivityLogs] (
    [activity_id]   INT           IDENTITY (1, 1) NOT NULL,
    [user_id]       INT           NULL,
    [activity_type] VARCHAR (50)  NULL,
    [activity_date] DATETIME      DEFAULT (getdate()) NULL,
    [details]       VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([activity_id] ASC),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[usersData] ([user_id])
);

