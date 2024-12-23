CREATE TABLE [dbo].[Notifications] (
    [notification_id]   INT           IDENTITY (1, 1) NOT NULL,
    [user_id]           INT           NULL,
    [notification_type] VARCHAR (50)  NULL,
    [notification_date] DATETIME      DEFAULT (getdate()) NULL,
    [message]           VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([notification_id] ASC),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[usersData] ([user_id])
);

