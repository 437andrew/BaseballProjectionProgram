select  B.[PlayerID] as PlayerID
	   ,A.[Position] as Position
	   ,A.[ActiveFlag] as ActiveFlag
       ,B.[GamesPlayed] as GamesPlayed
       ,B.[PercentageOfSeasonsPlayed] as PercentageOfSeasonsPlayed
       ,B.[SinglesPerAtBat] as SinglesPerAtBat
       ,B.[DoublesPerAtBat] as DoublesPerAtBat
       ,B.[TriplesPerAtBat] as TriplesPerAtBat
       ,B.[HomerunsPerAtBat] as HomerunsPerAtBat
       ,B.[WalksPerAtBat] as WalksPerAtBat
       ,B.[StolenBasesPerHitOrWalk] as StolenBasesPerHitOrWalk
       ,B.[RBIsPerHit] as RBIsPerHit
       ,B.[AtBatsPerGame] as AtBatsPerGame
       ,Null as StrikeoutsPerBatterFaced
       ,Null as WalksPerBatterFaced
       ,Null as HitsPerBatterFaced
       ,Null as InningsPerGame
       ,Null as SavesPerInning
       ,Null as PercentageOfHitsThatAreHomeruns
       ,Null as ERPerInningPitched
       ,Null as StrikeoutsPerIPOut
from [Baseball].[dbo].[Naturals] A join [Baseball].[dbo].[BattingCards] B on A.playerID = B.playerID and A.Position != 'RP' and A.Position != 'SP'
UNION ALL
select  B.[PlayerID] as PlayerID
	   ,A.[Position] as Position
	   ,A.[ActiveFlag] as ActiveFlag
       ,B.[GamesPitched] as GamesPlayed
       ,NUll as PercentageOfSeasonsPlayed
       ,NULL as SinglesPerAtBat
       ,NULL as DoublesPerAtBat
       ,NULL as TriplesPerAtBat
       ,NULL as HomerunsPerAtBat
       ,NULL as WalksPerAtBat
       ,NULL as StolenBasesPerHitOrWalk
       ,NULL as RBIsPerHit
       ,NULL as AtBatsPerGame
       ,B.[StrikeoutsPerBatterFaced] as StrikeoutsPerBatterFaced
       ,B.[WalksPerBatterFaced] as WalksPerBatterFaced
       ,B.[HitsPerBatterFaced] as HitsPerBatterFaced
       ,B.[InningsPerGame] as InningsPerGame
       ,B.[SavesPerInning] as SavesPerInning
       ,B.[PercentageOfHitsThatAreHomeruns] as PercentageOfHitsThatAreHomeruns
       ,B.[ERPerInningPitched] as ERPerInningPitched
       ,B.[StrikeoutsPerIPOut] as StrikeoutsPerIPOut 
from [Baseball].[dbo].[Naturals] A join [Baseball].[dbo].[PitchingCards] B on A.playerID = B.playerID and (A.Position = 'RP' or A.Position = 'SP')
