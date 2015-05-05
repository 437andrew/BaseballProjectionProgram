

USE [Baseball]
GO

INSERT INTO [dbo].[Pitching2014ToCompare]
           ([PlayerID]
           ,[currentPlayerIP]
           ,[currentPlayerWalksGiven]
           ,[currentPlayerHits]
           ,[currentPlayerStrikeouts]
           ,[currentPlayerER]
           ,[currentPlayerSaves]
           ,[currentPlayerQS]
           ,[currentPlayerERA]
           ,[currentPlayerWHIP]
           ,[currentPlayerK9])
select
playerID,
round((cast([IPouts] as decimal)/3),0),
[BB]+[HBP],
[H],
[SO],
[ER],
[SV],
0,
cast([ER] * 9 as decimal(18,10))/round((cast([IPouts] as decimal)/3),0),
cast([H]+[BB]+[HBP] as decimal(18,10))/round((cast([IPouts] as decimal)/3),0),
(cast([SO] as decimal(18,10))/round((cast([IPouts] as decimal)/3),0))*9
from Pitching
where yearID = 2014 and round((cast([IPouts] as decimal)/3),0)>0 
GO


