CREATE TABLE [dbo].[ReturnBooks] (
    [return_id]   INT          IDENTITY (1, 1) NOT NULL,
    [issue_id]    INT          NULL,
    [return_date] DATETIME     DEFAULT (getdate()) NULL,
    [condition]   VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([return_id] ASC),
    FOREIGN KEY ([issue_id]) REFERENCES [dbo].[issue_books] ([issue_id])
);

