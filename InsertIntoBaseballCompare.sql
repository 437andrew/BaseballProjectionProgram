USE [Baseball]
GO

INSERT INTO [dbo].[Batting2014ToCompare]
           ([PlayerID]
           ,[currentPlayerAtBats]
           ,[currentPlayerSingles]
           ,[currentPlayerDoubles]
           ,[currentPlayerTriples]
           ,[currentPlayerHomeruns]
           ,[currentPlayerWalks]
           ,[currentPlayerSteals]
           ,[currentPlayerRBIs]
           ,[currentPlayerRuns]
           ,[currentPlayerOBP]
           ,[currentPlayerSLG])
select 
playerID,
[AB],
[H]-[2B]-[3B]-[HR],
[2B],
[3B],
[HR],
[BB]+[HBP],
[SB],
[RBI],
[R],
(cast([H]+[BB]+[HBP] AS DECIMAL) / cast([AB]+[BB]+[HBP]+[SF] AS DECIMAL)),
(cast(1*([H]-[2B]-[3B]-[HR])+2*([2B])+3*([3B])+4*([HR]) AS DECIMAL) / cast([AB] AS DECIMAL))
from batting
where yearID = 2014 and ([AB]+[BB]+[HBP]+[SF])>0 and [AB]>0

     VALUES
           (<PlayerID, varchar(9),>
           ,<currentPlayerAtBats, int,>
           ,<currentPlayerSingles, int,>
           ,<currentPlayerDoubles, int,>
           ,<currentPlayerTriples, int,>
           ,<currentPlayerHomeruns, int,>
           ,<currentPlayerWalks, int,>
           ,<currentPlayerSteals, int,>
           ,<currentPlayerRBIs, int,>
           ,<currentPlayerRuns, int,>
           ,<currentPlayerOBP, decimal(18,10),>
           ,<currentPlayerSLG, decimal(18,10),>)
GO


