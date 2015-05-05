select (cast(sum([G]) AS DECIMAL)/cast((162*(select count(*) from batting where playerID like 'aaronha01')) AS DECIMAL)) AS PercentageOfSeasonsPlayed from batting where playerID like 'aaronha01' order by yearID limit (select count(*)-1 from batting where playerID like 'aaronha01')

select * from battingCards2013 where playerID like 'gonzaca%'

update BattingCards2013
set BattingCards2013.GamesPlayed = b.GamesPlayed
from (select A.playerID as playerID, sum([G]) as GamesPlayed from
	 (BattingCards2013 A
	 inner join
	 Batting B
	 on A.playerID = B.playerID)
	 group by A.playerID, yearID
	 having yearID = 2014) b
where BattingCards2013.playerID = b.playerID

update battingcards2013
set GamesPlayed = GamesPlayed *1000

select * from batting where playerID like 'goldspa%' and row
select * from batting where playerID 
select *, ROW_NUMBER() OVER(Partition By playerID order by yearID) AS RW from batting where playerID like 'goldspa%'

select * from batting

truncate table battingCards2013

insert into battingCards2013
SELECT playerID
	   ,(round(AVG([G]),0)) as GamesPlayed
	   ,(Cast(sum([G]) AS DECIMAL)/cast((162*(count(*))) AS DECIMAL)) AS PercentageOfSeasonsPlayed
       ,(cast(sum([H] - [2B] - [3B] - [HR]) AS DECIMAL) / sum([AB])) AS SinglesPerAtBat
       ,(cast(sum([2B]) AS DECIMAL) / sum([AB])) AS DoublesPerAtBat
       ,(cast(sum([3B]) AS DECIMAL) / sum([AB])) AS TriplesPerAtBat
       ,(cast(sum([HR]) AS DECIMAL) / sum([AB])) AS HomerunsPerAtBat   
	   ,(cast(sum([BB] + [HBP]) AS DECIMAL) / sum([AB])) AS WalksPerAtBat
	   ,(cast(sum([SB]) AS DECIMAL) / sum([H]+[BB] + [HBP])) AS StolenBasesPerHitOrWalk
	   ,(cast(sum([RBI]) AS DECIMAL) / sum([H])) AS RBIsPerHit
	   ,round((cast(sum([AB]) AS DECIMAL) / sum([G])),0) AS AtBatsPerGame
	   ,(cast(sum([R]-[HR]) AS DECIMAL) / sum([H]+[BB] + [HBP]-[HR])) AS RunsPerNonHomerunOrWalk
FROM   (select * from (select *, ROW_NUMBER() OVER(Partition By playerID order by yearID) AS RW from BattingWeighted2013) A where RW !=1) B
GROUP BY playerID HAVING sum([AB]) > 0 and sum([G])>0 and sum([H]) > 0 and sum([H]+[BB] + [HBP]-[HR])>0


insert into AVGHit
select cast(sum([HR]) as decimal)/ sum([H]) as 'hrperhit'
      ,cast(sum([2B]) as decimal)/ sum([H]) as '2bperhit'
	  ,cast(sum([3B]) as decimal)/ sum([H]) as '3bperhit'
	  ,cast(sum([H] - [2B] - [3B] - [HR] ) as decimal)/ sum([H]) as '1bperhit'
from batting

select 0.07393955199 + 0.16813353973 + 0.03548381883 + 0.72244308944

select * from batting where playerId like 'janse%'

Insert into batting