CREATE TABLE [dbo].[issue_books] (
    [issue_id]    INT          IDENTITY (1, 1) NOT NULL,
    [book_id]     INT          NOT NULL,
    [user_id]     INT          NOT NULL,
    [issue_date]  DATE         NOT NULL,
    [due_date]    DATE         NOT NULL,
    [return_date] DATE         NULL,
    [status]      VARCHAR (10) DEFAULT ('Issued') NULL,
    [created_at]  DATETIME     DEFAULT (getdate()) NULL,
    [updated_at]  DATETIME     DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([issue_id] ASC),
    FOREIGN KEY ([book_id]) REFERENCES [dbo].[books] ([book_id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[usersData] ([user_id])
);

