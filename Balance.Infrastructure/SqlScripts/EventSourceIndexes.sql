CREATE INDEX Idx_Events_AggregateId
ON  [dbo].[EventSourcing] ([AggregateId])
GO

CREATE INDEX Idx_Events_Dispatched
ON [dbo].[EventSourcing]([Dispatched])
GO
