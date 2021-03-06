BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'changes.Snapshot') AND name = N'UX_Snapshot_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Snapshot_Id ON [changes].[Snapshot]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

