select * from pitching where playerId like '%kimbr%'

truncate table pitchingCards2013
select * from pitchingCards2013 where playerId like 'kimbrcr01'
select * from pitchingCards2013 where playerId like 'kimbrcr01'

select sum(ipouts) from PitchingWeighted2013 where playerID like 'kershcl01'
--679
--14011
	--this gets number of games a player has started in 2014
update PitchingCards2013
set PitchingCards2013.GamesPitched = b.GamesPitched
from (select A.playerID as playerID, sum([G]) as GamesPitched from
	 (PitchingCards2013 A
	 inner join
	 Pitching B
	 on A.playerID = B.playerID)
	 group by A.playerID, yearID
	 having yearID = 2014) b
where PitchingCards2013.playerID = b.playerID



update PitchingCards2013
set GamesPitched = GamesPitched * 1000

insert into pitchingcards2013
select
t.playerID,
t.GamesPitched as GamesPitched,
t.StrikeoutsPerBatterFaced as [StrikeoutsPerBatterFaced],
walksperbatterfaced as [WalksPerBatterFaced],
hitsperbatterfaced as [HitsPerBatterFaced],
inningspergame as [InningsPerGame],
savesperinningpitched as [SavesPerInning],
PercentageOfHitsThatAreHomeruns as [PercentageOfHitsThatAreHomeruns],
ERPerInningPitched as [ERPerInningPitched],
StrikeoutsPerIPOut as [StrikeoutsPerIPOut]
from
(SELECT playerID
	   ,round(AVG([G]),0) as GamesPitched
       ,(cast(sum([SO]) AS DECIMAL) / sum([BFP])) AS StrikeoutsPerBatterFaced
	   ,(cast(sum([BB]) AS DECIMAL) / sum([BFP])) AS WalksPerBatterFaced
	   ,(cast(sum([H]) AS DECIMAL) / sum([BFP])) AS HitsPerBatterFaced
	   ,(cast(sum([IPouts]) as decimal) / sum([G])/3)  as InningsPerGame
	   ,(cast(sum([SV]) AS DECIMAL) / round(sum([IPouts])/3,0)) AS SavesPerInning
	   ,(cast(sum([HR]) AS DECIMAL) / sum([H])) AS PercentageOfHitsThatAreHomeruns
	   ,(cast(sum([ER]) AS DECIMAL) / round(sum([IPouts])/3,0)) AS ERPerInningPitched
	   ,(cast(sum([SO]) AS DECIMAL) / sum([IPouts])) AS StrikeoutsPerIPOut
FROM pitchingWeighted2013
GROUP BY playerID 
HAVING sum([BFP]) > 0 and sum([H]) > 0 and sum([IPouts]) > 0 and sum([G]) > 0 and round(sum([IPouts])/3,0)>0) t
JOIN
(SELECT playerID
,(cast(sum([SV]) AS DECIMAL) / round(sum([IPouts])/3,0)) AS SavesPerInningPitched
FROM ( select * from pitchingWeighted2013) as a 
GROUP BY playerID
HAVING sum([BFP]) > 0 and round(sum([IPouts])/3,0) > 0) r
on t.playerID = r.playerID

update PitchingCards2013
set InningsPerGame = 1
where InningsPerGame = 0

select * from pitching where playerId like '%kimbr%'

update pitchingCards
set savesperinning = SELECT playerID
,(cast(sum([SV]) AS DECIMAL) / round(sum([IPouts])/3,0)) AS SavesPerInningPitched
FROM ( select * from pitching where yearID > 2011) as a 
GROUP BY playerID
HAVING sum([BFP]) > 0 and round(sum([IPouts])/3,0) > 0


