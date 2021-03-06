update dbo.battingCards2013
   set [SinglesPerAtBat] = [SinglesPerAtBat] * reg
      ,[DoublesPerAtBat] = [DoublesPerAtBat] * reg
      ,[TriplesPerAtBat] = [TriplesPerAtBat] * reg
      ,[HomerunsPerAtBat] = [HomerunsPerAtBat] * reg 
      ,[WalksPerAtBat] = [WalksPerAtBat] * reg
      ,[StolenBasesPerHitOrWalk] = [StolenBasesPerHitOrWalk] * reg
      ,[RBIsPerHit] = [RBIsPerHit] * reg
      ,[RunsPerNonHomerunOrWalk] = [RunsPerNonHomerunOrWalk] * reg
from 
dbo.battingCards2013 B
inner join
(select playerid as PlayerID, cast(sum(ab) as decimal)/(cast(sum(ab) as decimal) + 1200) as reg
from [Baseball].[dbo].[BattingForRegression]
where (yearid = 2013 or yearid = 2012 or yearid = 2011)
group by playerid) A
on B.playerID = A.PlayerID

update dbo.pitchingCards2013
set    [StrikeoutsPerBatterFaced] = ((([StrikeoutsPerBatterFaced] * sumip) + (strikeoutsperbatter *1200))/(sumip+1200))
      ,[WalksPerBatterFaced] = ((([WalksPerBatterFaced] * sumip) + (walks *1200))/(sumip+1200))
      ,[HitsPerBatterFaced] = ((([HitsPerBatterFaced] * sumip) + (hits *1200))/(sumip+1200))
      ,[SavesPerInning] = ((([SavesPerInning] * sumip) + (saves *1200))/(sumip+1200))
      ,[PercentageOfHitsThatAreHomeruns] = ((([PercentageOfHitsThatAreHomeruns] * sumip) + (percentage *1200))/(sumip+1200))
      ,[ERPerInningPitched] = ((([ERPerInningPitched] * sumip) + (er *1200))/(sumip+1200))
      ,[StrikeoutsPerIPOut] = ((([StrikeoutsPerIPOut] * sumip) + (strikeoutsperipout1 *1200))/(sumip+1200))
from 
dbo.pitchingCards2013 B
inner join
(select playerid as PlayerID,sum(ipouts) as sumip, cast(sum(ipouts) as decimal)/(cast(sum(ipouts) as decimal) + 1200) as reg
from [Baseball].[dbo].[PitchingForRegression]
where (yearid = 2013 or yearid = 2012 or yearid = 2011)
group by playerid) A
on B.playerID = A.PlayerID,
(SELECT 
       AVG([StrikeoutsPerBatterFaced]) AS strikeoutsperbatter
      ,AVG([WalksPerBatterFaced]) AS walks
      ,AVG([HitsPerBatterFaced]) as hits
      ,AVG([InningsPerGame]) as innings
      ,AVG([SavesPerInning]) as saves
      ,AVG([PercentageOfHitsThatAreHomeruns]) as percentage
      ,AVG([ERPerInningPitched]) as er
      ,AVG([StrikeoutsPerIPOut]) as strikeoutsperipout1
  FROM [Baseball].[dbo].[PitchingCards2013-original]) D


update battingcards2013
set    [StrikeoutsPerBatterFaced] = [StrikeoutsPerBatterFaced] *1.054
      ,[WalksPerBatterFaced] = [WalksPerBatterFaced]
      ,[HitsPerBatterFaced] = [HitsPerBatterFaced]*(1-*1.054)
      ,[SavesPerInning] = [SavesPerInning]*1.054
      ,[PercentageOfHitsThatAreHomeruns] = [PercentageOfHitsThatAreHomeruns]*(1-*1.054)
      ,[ERPerInningPitched] = [ERPerInningPitched]*(1-*1.054)
      ,[StrikeoutsPerIPOut] = [StrikeoutsPerIPOut] *1.054
from 
pitchingCards2013 A
join 
[pitching2014ToCompare-MARCEL2] B
on a.playerID = b.PlayerID
where b.[year] = 2013 and b.Age = 20

update battingcards2013
set
       [SinglesPerAtBat] = (((SinglesPerAtBat * sumAB) + (singles *1200))/(sumAB+1200))
      ,[DoublesPerAtBat] = ((([DoublesPerAtBat] * sumAB) + (doubles *1200))/(sumAB+1200))
      ,[TriplesPerAtBat] = ((([TriplesPerAtBat] * sumAB) + (triples *1200))/(sumAB+1200))
      ,[HomerunsPerAtBat] = ((([HomerunsPerAtBat] * sumAB) + (homeruns *1200))/(sumAB+1200))
      ,[WalksPerAtBat] = ((([WalksPerAtBat] * sumAB) + (walks *1200))/(sumAB+1200))
      ,[StolenBasesPerHitOrWalk] = ((([StolenBasesPerHitOrWalk] * sumAB) + (stolen *1200))/(sumAB+1200))
      ,[RBIsPerHit] = ((([RBIsPerHit] * sumAB) + (rbi *1200))/(sumAB+1200))
      ,[RunsPerNonHomerunOrWalk] = ((([RunsPerNonHomerunOrWalk] * sumAB) + (runs *1200))/(sumAB+1200))
from 
dbo.battingCards2013 B
inner join
(select playerid as PlayerID, sum(ab) as sumAB, cast(sum(ab) as decimal)/(cast(sum(ab) as decimal) + 1200) as reg
from [Baseball].[dbo].[BattingForRegression]
where (yearid = 2013 or yearid = 2012 or yearid = 2011)
group by playerid) A
on B.playerID = A.PlayerID,
(SELECT 
       AVG([GamesPlayed]) as games
      ,AVG([PercentageOfSeasonsPlayed]) as percentage
      ,AVG([SinglesPerAtBat]) as singles
      ,AVG([DoublesPerAtBat]) as doubles
      ,AVG([TriplesPerAtBat]) as triples
      ,AVG([HomerunsPerAtBat]) as homeruns
      ,AVG([WalksPerAtBat]) as walks
      ,AVG([StolenBasesPerHitOrWalk]) as stolen
      ,AVG([RBIsPerHit]) as rbi
      ,AVG([AtBatsPerGame]) as atbats
      ,AVG([RunsPerNonHomerunOrWalk]) as runs
  FROM [Baseball].[dbo].[BattingCards2013-Original]) D