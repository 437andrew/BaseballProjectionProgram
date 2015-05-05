select
cast(SUM(C.[IPDIff])as decimal(18,10))/501 as abdiff,
cast(SUM(C.[WalksGivenDIff])as decimal(18,10))/501 as singlesdiff,
cast(SUM(C.[HitsDIff])as decimal(18,10))/501 as doublesdiff,
cast(SUM(C.[SODIff])as decimal(18,10))/501 as triplesdiff,
cast(SUM(C.[HomerDiff])as decimal(18,10))/501 as homerunsdiff,
cast(SUM(C.[WalksDIff])as decimal(18,10))/501 as walksdiff,
cast(SUM(C.[StealsDIff])as decimal(18,10))/501 as stealsdiff,
cast(SUM(C.[RBIsDIff])as decimal(18,10))/501 as rbisdiff,
cast(SUM(C.[RunsDiff])as decimal(18,10))/501 as runsdiff,
cast(SUM(C.[OBPDIff])as decimal(18,10))/501 as obpdiff,
cast(SUM(C.[SLGDiff])as decimal(18,10))/501 as slgdiff,
cast(SUM(C.[WOBADiff])as decimal(18,10))/501 as wobadiff

from
(select
A.playerID,
case when b.currentPlayerIP = 0 then 0 else ABS((Cast(A.currentPlayerIP AS DECIMAL)-cast(b.currentPlayerIP AS DECIMAL))) end as IPDIff,
case when b.currentPlayerWalksGiven = 0 then 0 else ABS((Cast(A.currentPlayerWalksGiven AS DECIMAL)-cast(b.currentPlayerWalksGiven AS DECIMAL))) end as WalksGivenDiff,
case when b.currentPlayerHits = 0 then 0 else ABS((Cast(A.currentPlayerHits AS DECIMAL)-cast(b.currentPlayerHits AS DECIMAL))) end as HitsDiff,
case when b.currentPlayerStrikeouts = 0 then 0 else ABS((Cast(A.currentPlayerStrikeouts AS DECIMAL)-cast(b.currentPlayerStrikeouts AS DECIMAL))) end as SODiff,
case when b.currentPlayerER = 0 then 0 else ABS((Cast(A.currentPlayerER AS DECIMAL)-cast(b.currentPlayerER AS DECIMAL))) end as ERDiff,
case when b.currentPlayerSaves = 0 then 0 else ABS((Cast(A.currentPlayerSaves AS DECIMAL)-cast(b.currentPlayerSaves AS DECIMAL))) end as SavesDiff,
case when b.currentPlayerERA = 0 then 0 else ABS((Cast(A.currentPlayerERA AS DECIMAL)-cast(b.currentPlayerERA AS DECIMAL))) end as ERADiff,
case when b.currentPlayerWHIP = 0 then 0 else ABS((Cast(A.currentPlayerWHIP AS DECIMAL)-cast(b.currentPlayerWHIP AS DECIMAL))) end as WHIPDiff,
case when b.currentPlayerK9 = 0 then 0 else ABS((Cast(A.currentPlayerK9 AS DECIMAL)-cast(b.currentPlayerK9 AS DECIMAL))) end as K9Diff

from 
[Pitching2014ToCompare] A
join
[pitchingprojections2014-10000] B
on A.playerID = B.PlayerID) C

--deletedfrombattingcompare where era = 0, er=0, whip=0 k9=0