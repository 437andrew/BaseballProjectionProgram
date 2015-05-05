declare @total_points int 
declare @intercept DECIMAL(38, 10)
declare @slope DECIMAL(38, 10)
declare @r_squared DECIMAL(38, 10)
declare @standard_estimate_error DECIMAL(38, 10)
declare @correlation_coefficient DECIMAL(38, 10)
declare @average_x  DECIMAL(38, 10)
declare @average_y  DECIMAL(38, 10)
declare @sumX DECIMAL(38, 10)
declare @sumY DECIMAL(38, 10)
declare @sumXX DECIMAL(38, 10)
declare @sumYY DECIMAL(38, 10)
declare @sumXY DECIMAL(38, 10)
declare @Sxx DECIMAL(38, 10)
declare @Syy DECIMAL(38, 10)
declare @Sxy DECIMAL(38, 10)

Select 
@total_points = count(*),
@average_x = avg(A.currentplayerk9),
@average_y = avg(B.currentplayerk9),
@sumX = sum(A.currentplayerk9),
@sumY = sum(B.currentplayerk9),
@sumXX = sum(A.currentplayerk9*A.currentplayerk9),
@sumYY = sum(b.currentplayerk9*b.currentplayerk9),
@sumXY = sum(a.currentplayerk9*b.currentplayerk9)
From [pitching2014ToCompare] A
join
[pitchingProjections2014-1000] B
on A.playerID = B.PlayerID

set @Sxx = @sumXX - (@sumX * @sumX) / @total_points
set @Syy = @sumYY - (@sumY * @sumY) / @total_points
set @Sxy = @sumXY - (@sumX * @sumY) / @total_points

set @correlation_coefficient = @Sxy / SQRT(@Sxx * @Syy) 
set @slope = (@total_points * @sumXY - @sumX * @sumY) / (@total_points * @sumXX - power(@sumX,2))
set @intercept = @average_y - (@total_points * @sumXY - @sumX * @sumY) / (@total_points * @sumXX - power(@sumX,2)) * @average_x
set @r_squared = (@intercept * @sumY + @slope * @sumXY - power(@sumY,2) / @total_points) / (@sumYY - power(@sumY,2) / @total_points)

-- calculate standard_estimate_error (standard deviation)
Select
@standard_estimate_error = sqrt(sum(power(b.currentplayerk9 - (@slope * a.currentplayerk9 + @intercept),2)) / @total_points)
From [pitchingprojections2014-1000] A
join
[pitching2014ToCompare] B
on A.playerID = B.PlayerID

select @r_squared

--comparint batting2014tocompare with battingprojections2014-10000
--deletedfrombattingcompare where slg =0, obp = 0, and less than 50 at bats
--current at bats r_squared = 0.7554730000 --new0.7387180000
--current player singles = 0.7439490000 --new0.6831160000
--currentPlayerdoubles1 = 0.5741180000 --new 0.7043760000
--currentPlayertriples1 = 0.1288230000 --new 0.4158320000
--currentPlayerhomeruns1 = 0.5647900000 --0.5983970000
--currentPlayerwalks1 = 0.6895680000 --0.6704450000
--currentPlayersteals1 = 0.7214590000 --0.7258640000
--currentPlayerrbis = 0.6631940000 --0.7183420000
--currentplayerruns1 = 0.7018130000 --0.7123600000
--currentPlayerobp = 0.3827180000 --0.3097210000
--currentplayerslg = 0.3656210000 --0.3381680000

--rsquaredfor 2014pitching
--deletedfrombattingcompare where era = 0, er=0, whip=0 k9=0
-- ip = 0.5893740000 --0.6057050000
--walksgiven = 0.4382950000  --0.4784730000
--hits = 0.5192970000 --0.5565360000
--strikeouts = 0.5953370000 --0.6240720000
--ER = 0.4274710000 --0.4758530000
--saves = 0.4109840000 --0.3830960000
--era = 0.0011960000 --0.0479220000
--whip = 0.0353730000 --0.0547620000
--k9 = 0.3070570000 --0.2621050000

--rsquaredfor 2014pitching
--deletedfrombattingcompare where era = 0, er=0, whip=0 k9=0, where currentPlayerK9 <=15
-- ip = 0.5085820000
-- walksgiven = 0.3484910000
--hits = 0.4462400000
--strikeouts = 0.5372320000
--ER = 0.3599130000
----

--rsquared for 2014 pitching --no changes unless innings pitched = 0
--ip = 0.6100950000
--walksgiven = 0.4587600000
--hits 0.5369800000
--strikeouts 0.6325350000
--er = 0.4487410000
--saves = 0.4141900000
--ERA = 0.0171210000
--WHIP = 0.0165630000
--K9 = 0.2666600000













