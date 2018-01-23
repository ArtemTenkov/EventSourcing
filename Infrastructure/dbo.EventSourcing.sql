USE [Db]
GO

/****** Object: Table [dbo].[EventSourcing] Script Date: 1/21/2018 12:53:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventSourcing] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [AggregateType] NVARCHAR (100)   NOT NULL,
    [AggregateId]   UNIQUEIDENTIFIER NOT NULL,
    [Version]       INT              NOT NULL,
    [Event]         NVARCHAR (MAX)   NOT NULL,
    [Metadata]      NVARCHAR (MAX)   NOT NULL,
    [Dispatched]    BIT              NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [Idx_Events_AggregateId]
    ON [dbo].[EventSourcing]([AggregateId] ASC);


GO
CREATE NONCLUSTERED INDEX [Idx_Events_Dispatched]
    ON [dbo].[EventSourcing]([Dispatched] ASC);


