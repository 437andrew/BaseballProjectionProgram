select  B.[PlayerID] as PlayerID
	                               ,'Batter' as Position
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
                                   ,B.[RunsPerNonHomerunOrWalk] as RunsPerNonHomerunOrWalk
                                   ,Null as StrikeoutsPerBatterFaced
                                   ,Null as WalksPerBatterFaced
                                   ,Null as HitsPerBatterFaced
                                   ,Null as InningsPerGame
                                   ,Null as SavesPerInning
                                   ,Null as PercentageOfHitsThatAreHomeruns
                                   ,Null as ERPerInningPitched
                                   ,Null as StrikeoutsPerIPOut
                            from (select distinct playerID from Batting where yearID = 2014) A join [Baseball].[dbo].[BattingCards2013] B on A.playerID = B.playerID
                            UNION ALL
                            select  B.[PlayerID] as PlayerID
	                               ,cast(case when d.GS >0 then 'SP' else 'RP' end as varchar(2)) as Position
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
                                   ,NULL as RunsPerNonHomerunOrWalk
                                   ,B.[StrikeoutsPerBatterFaced] as StrikeoutsPerBatterFaced
                                   ,B.[WalksPerBatterFaced] as WalksPerBatterFaced
                                   ,B.[HitsPerBatterFaced] as HitsPerBatterFaced
                                   ,B.[InningsPerGame] as InningsPerGame
                                   ,B.[SavesPerInning] as SavesPerInning
                                   ,B.[PercentageOfHitsThatAreHomeruns] as PercentageOfHitsThatAreHomeruns
                                   ,B.[ERPerInningPitched] as ERPerInningPitched
                                   ,B.[StrikeoutsPerIPOut] as StrikeoutsPerIPOut 
                            from (select distinct playerID from Pitching where yearID = 2014) A join [Baseball].[dbo].[PitchingCards2013] B on A.playerID = B.playerID join (SELECT playerId as playerID, sum(GS) as GS, yearID as yearID
																																											  FROM [Baseball].[dbo].[Appearances]
																																											  group by playerID, yearID
																																											  having yearID = 2013) D on A.playerID = D.playerID