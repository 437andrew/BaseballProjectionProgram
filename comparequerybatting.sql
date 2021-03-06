select
cast(SUM(C.[ABDIff])as decimal(18,10))/501 as abdiff,
cast(SUM(C.[SinglesDIff])as decimal(18,10))/501 as singlesdiff,
cast(SUM(C.[DoublesDIff])as decimal(18,10))/501 as doublesdiff,
cast(SUM(C.[TriplesDIff])as decimal(18,10))/501 as triplesdiff,
cast(SUM(C.[HomerunsDiff])as decimal(18,10))/501 as homerunsdiff,
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
case when b.currentPlayerAtBats = 0 then 0 else ABS((Cast(A.currentPlayerAtBats AS DECIMAL)-cast(b.currentPlayerAtBats AS DECIMAL))) end as ABDIff,
case when b.currentPlayerSingles = 0 then 0 else ABS((Cast(A.currentPlayerSingles AS DECIMAL)-cast(b.currentPlayerSingles AS DECIMAL))) end as SinglesDiff,
case when b.currentPlayerDoubles = 0 then 0 else ABS((Cast(A.currentPlayerDoubles AS DECIMAL)-cast(b.currentPlayerDoubles AS DECIMAL))) end as DoublesDiff,
case when b.currentPlayerTriples = 0 then 0 else ABS((Cast(A.currentPlayerTriples AS DECIMAL)-cast(b.currentPlayerTriples AS DECIMAL))) end as TriplesDiff,
case when b.currentPlayerHomeruns = 0 then 0 else ABS((Cast(A.currentPlayerHomeruns AS DECIMAL)-cast(b.currentPlayerHomeruns AS DECIMAL))) end as HomerunsDiff,
case when b.currentPlayerWalks = 0 then 0 else ABS((Cast(A.currentPlayerWalks AS DECIMAL)-cast(b.currentPlayerWalks AS DECIMAL))) end as WalksDiff,
case when b.currentPlayerSteals = 0 then 0 else ABS((Cast(A.currentPlayerSteals AS DECIMAL)-cast(b.currentPlayerSteals AS DECIMAL))) end as StealsDiff,
case when b.currentPlayerRBIs = 0 then 0 else ABS((Cast(A.currentPlayerRBIs AS DECIMAL)-cast(b.currentPlayerRBIs AS DECIMAL))) end as RBIsDiff,
case when b.currentPlayerRuns = 0 then 0 else ABS((Cast(A.currentPlayerRuns AS DECIMAL)-cast(b.currentPlayerRuns AS DECIMAL))) end as RunsDiff,
case when b.currentPlayerOBP = 0 then 0 else ABS((Cast(A.currentPlayerOBP AS DECIMAL(18,10))-cast(b.currentPlayerOBP AS DECIMAL(18,10)))) end as OBPDiff,
case when b.currentPlayerSLG = 0 then 0 else ABS((Cast(A.currentPlayerSLG AS DECIMAL(18,10))-cast(b.currentPlayerSLG AS DECIMAL(18,10)))) end as SLGDiff,
case when b.currentPlayerAtBats = 0 then 0 else ABS((Cast((cast(A.currentPlayerWalks*.705 + A.currentPlayerSingles*.89 + A.currentPlayerDoubles * 1.28 + A.currentPlayerTriples *1.64 + A.currentPlayerHomeruns*2.14 as decimal)/cast(A.currentPlayerAtBats as decimal)) AS DECIMAL(18,10))-cast( (cast(B.currentPlayerWalks*.705 + B.currentPlayerSingles*.89 + B.currentPlayerDoubles * 1.28 + B.currentPlayerTriples *1.64 + B.currentPlayerHomeruns*2.14 as decimal)/cast(B.currentPlayerAtBats as decimal)) AS DECIMAL(18,10)))) end as WOBADiff
from 
[Batting2014ToCompare] A
join
[battingprojections2014-10000] B
on A.playerID = B.PlayerID) C

--deletedfrombattingcompare where slg =0, obp = 0, and less than 50 at bats
