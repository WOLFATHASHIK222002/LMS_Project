CREATE TABLE [dbo].[books] (
    [book_id]        INT           IDENTITY (1, 1) NOT NULL,
    [BookName]          VARCHAR (255) NOT NULL,
    [Author]         VARCHAR (255) NOT NULL,
    [Year] INT           NULL,
    [ISBN]          INT NULL,
    [total_copies]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([book_id] ASC)
);

