using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private static uint m_w  = 521288629;
        private static uint m_z  = 362436069;

        int Runner1 = 0;
        int Runner2 = 0;
        int Runner3 = 0;
        int CurrentPlayerBase = 0;
        int Outs = 0;

        int totalTeamAtBats = 0;
        int totalTeamSingles = 0;
        int totalTeamDoubles = 0;
        int totalTeamTriples = 0;
        int totalTeamHomeruns = 0;
        int totalTeamWalks = 0;
        int totalTeamSteals = 0;
        int totalTeamRBIs = 0;
        int totalTeamRuns = 0;
        double teamOBP = 0;
        double teamSLG = 0;

        int currentSimAtBats = 0;
        int currentSimSingles = 0;
        int currentSimDoubles = 0;
        int currentSimTriples = 0;
        int currentSimHomeruns = 0;
        int currentSimWalks = 0;
        int currentSimSteals = 0;
        int currentSimRBIs = 0;
        int currentSimRuns = 0;
        double currentSimOBP = 0;
        double currentSimSLG = 0;

        int currentSimIP = 0;
        int currentSimWalksGiven = 0;
        int currentSimHits = 0;
        int currentSimStrikeouts = 0;
        int currentSimER = 0;
        int currentSimSaves = 0;
        int currentSimQS = 0;
        double currentSimERA = 0;
        double currentSimWHIP = 0;
        double currentSimK9 = 0;

        int totalTeamIP = 0;
        int totalTeamWalksGiven = 0;
        int totalTeamHits = 0;
        int totalTeamStrikeouts = 0;
        int totalTeamER = 0;
        int totalTeamSaves = 0;
        int totalTeamQS = 0;
        double totalTeamERA = 0;
        double totalTeamWHIP = 0;

        int currentPlayerIP = 0;
        int currentPlayerWalksGiven = 0;
        int currentPlayerHits = 0;
        int currentPlayerStrikeouts = 0;
        int currentPlayerER = 0;
        int currentPlayerSaves = 0;
        int currentPlayerQS = 0;
        double currentPlayerERA = 0;
        double currentPlayerWHIP = 0;
        
        int currentPlayerAtBats = 0;
        int currentPlayerSingles = 0;
        int currentPlayerDoubles = 0;
        int currentPlayerTriples = 0;
        int currentPlayerHomeruns = 0;
        int currentPlayerWalks = 0;
        int currentPlayerSteals = 0;
        int currentPlayerRBIs = 0;
        int currentPlayerRuns = 0;
        double currentPlayerOBP = 0;
        double currentPlayerSLG = 0;
        double currentPlayerK9 = 0;


        double homerunPerHit = 0.0746516587;
        double doublePerHit = 0.0351226783;
        double singlePerHit = 0.7214796113;
        double triplePerHit = 0.1687460517;
        /*
        int currentPlayerMinAtBats = 1000000;
        int currentPlayerMinSingles = 1000000;
        int currentPlayerMinDoubles = 1000000;
        int currentPlayerMinTriples = 1000000;
        int currentPlayerMinHomeruns = 1000000;
        int currentPlayerMinWalks = 1000000;
        int currentPlayerMinSteals = 1000000;
        int currentPlayerMinRBIs = 1000000;
        int currentPlayerMinRuns = 1000000;

        int currentPlayerMaxAtBats = -1;
        int currentPlayerMaxSingles = -1;
        int currentPlayerMaxDoubles = -1;
        int currentPlayerMaxTriples = -1;
        int currentPlayerMaxHomeruns = -1;
        int currentPlayerMaxWalks = -1;
        int currentPlayerMaxSteals = -1;
        int currentPlayerMaxRBIs = -1;
        int currentPlayerMaxRuns = -1;

        int minimumTeamAtBats = 0;
        int minimumTeamSingles = 0;
        int minimumTeamDoubles = 0;
        int minimumTeamTriples = 0;
        int minimumTeamHomeruns = 0;
        int minimumTeamWalks = 0;
        int minimumTeamSteals = 0;
        int minimumTeamRBIs = 0;
        int minimumTeamRuns = 0;
        double minimumOBP = 0;
        double minimumSLG = 0;

        int maximumTeamAtBats = 0;
        int maximumTeamSingles = 0;
        int maximumTeamDoubles = 0;
        int maximumTeamTriples = 0;
        int maximumTeamHomeruns = 0;
        int maximumTeamWalks = 0;
        int maximumTeamSteals = 0;
        int maximumTeamRBIs = 0;
        int maximumTeamRuns = 0;
        double maximumOBP = 0;
        double maximumSLG = 0;*/


        public Form1()
        {
            InitializeComponent();

            SqlConnection myConnection = new SqlConnection("server=ACWilson-PC;Integrated Security = true;" +
                                       "Trusted_Connection=yes;" +
                                       "database=Baseball; " +
                                       "connection timeout=30");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            //PUT THIS BACK IF DOING TEAM SIMULATIONS
            //SqlCommand myCmd1 = new SqlCommand(@"Truncate Table [dbo].[ConfidentProjs2015]", myConnection);
            //myCmd1.ExecuteNonQuery();

            //SqlCommand myCommand = new SqlCommand("select * from [Baseball].[dbo].[Naturals] A join [Baseball].[dbo].[BattingCards2013] B on A.playerID = B.playerID where A.playerID like 'goldspa01'", myConnection);
            //SqlCommand myCommand = new SqlCommand("select * from [Baseball].[dbo].[Naturals] A join [Baseball].[dbo].[PitchingCards2013] B on A.playerID = B.playerID where A.playerID like 'kimbrcr01'", myConnection);
            SqlCommand myCommand = new SqlCommand(@"select  B.[PlayerID] as PlayerID
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
																																											  having yearID = 2013) D on A.playerID = D.playerID", myConnection);

            //seed for poisson
            Random rand1 = new Random();
            m_z = (uint)rand1.Next();
            m_w = (uint)rand1.Next();

            for (int simNum = 0; simNum < 1; simNum++)
            {

                

                currentSimIP = 0;
                currentSimWalksGiven = 0;
                currentSimHits = 0;
                currentSimStrikeouts = 0;
                currentSimER = 0;
                currentSimSaves = 0;
                currentSimQS = 0;

                currentSimAtBats = 0;
                currentSimSingles = 0;
                currentSimDoubles = 0;
                currentSimTriples = 0;
                currentSimHomeruns = 0;
                currentSimWalks = 0;
                currentSimSteals = 0;
                currentSimRBIs = 0;
                currentSimRuns = 0;

            using (SqlDataReader reader = myCommand.ExecuteReader()) {
                while (reader.Read()) {
                    currentPlayerIP = 0;
                    currentPlayerWalksGiven = 0;
                    currentPlayerHits = 0;
                    currentPlayerStrikeouts = 0;
                    currentPlayerER = 0;
                    currentPlayerSaves = 0;
                    currentPlayerQS = 0;

                    currentPlayerAtBats = 0;
                    currentPlayerSingles = 0;
                    currentPlayerDoubles = 0;
                    currentPlayerTriples = 0;
                    currentPlayerHomeruns = 0;
                    currentPlayerWalks = 0;
                    currentPlayerSteals = 0;
                    currentPlayerRBIs = 0;
                    currentPlayerRuns = 0;

                    string Position = String.Format("{0}", reader["Position"]);
                    string playerID = String.Format("{0}", reader["PlayerID"]);
                    //string ActiveFlag = String.Format("{0}", reader["ActiveFlag"]);

                    string GamesPlayed = String.Format("{0}", reader["GamesPlayed"]);
                    double games1 = Convert.ToDouble(GamesPlayed);
                    int games = (int)games1;

                    Random random = new Random();
                    double rand;

                    if (Position != "SP" && Position != "RP")
                    {
                       
                        double PercentageOfSeasonsPlayed = Convert.ToDouble(reader["PercentageOfSeasonsPlayed"]);
                        double SinglesPerAtBat = Convert.ToDouble(reader["SinglesPerAtBat"]);
                        double DoublesPerAtBat = Convert.ToDouble(reader["DoublesPerAtBat"]);
                        double TriplesPerAtBat = Convert.ToDouble(reader["TriplesPerAtBat"]);
                        double HomerunsPerAtBat = Convert.ToDouble(reader["HomerunsPerAtBat"]);
                        double WalksPerAtBat = Convert.ToDouble(reader["WalksPerAtBat"]);
                        double StolenBasesPerHitOrWalk = Convert.ToDouble(reader["StolenBasesPerHitOrWalk"]);
                        double AtBatsPerGame = Convert.ToDouble(reader["AtBatsPerGame"]);
                        double RBIsPerHit = Convert.ToDouble(reader["RBIsPerHit"]);
                        double RunsPerNonHomerunOrWalk = Convert.ToDouble(reader["RunsPerNonHomerunOrWalk"]);

                            for (int d = 0; d < games; d++) //number of games
                            {
                                rand = random.NextDouble();
                                if (rand <= 1 /*PercentageOfSeasonsPlayed*/)
                                {
                                    for (int i = 0; i <AtBatsPerGame; i++)
                                    {
                                        totalTeamAtBats++;
                                        currentSimAtBats++;
                                        currentPlayerAtBats++;

                                        rand = random.NextDouble();

                                        if ((rand >= 0) && (rand <= SinglesPerAtBat))
                                        {   //a single
                                            totalTeamSingles++;
                                            currentSimSingles++;
                                            currentPlayerSingles++;

                                            CurrentPlayerBase = 1;

                                            randomBaseOutSituation();
                                            rand = random.NextDouble();
                                            if (rand <= RBIsPerHit)
                                            {
                                                totalTeamRBIs++;
                                                currentSimRBIs++;
                                                currentPlayerRBIs++;
                                            }


                                            //simulate a steal
                                            rand = random.NextDouble();
                                            SimulateSteal(rand, StolenBasesPerHitOrWalk);

                                            if (CurrentPlayerBase < 4)
                                            {
                                                rand = random.NextDouble();
                                                if (rand <= RunsPerNonHomerunOrWalk)
                                                {
                                                    totalTeamRuns++;
                                                    currentSimRuns++;
                                                    currentPlayerRuns++;
                                                }
                                            }


                                        }
                                        else if ((rand >= SinglesPerAtBat) && (rand <= SinglesPerAtBat + DoublesPerAtBat))
                                        {//a double
                                            totalTeamDoubles++;
                                            currentSimDoubles++;
                                            currentPlayerDoubles++;


                                            CurrentPlayerBase = 2;

                                            randomBaseOutSituation();
                                            //Runner1+=2;
                                            //Runner2+=2;
                                            //Runner3+=2;

                                            rand = random.NextDouble();
                                            if (rand <= RBIsPerHit)
                                            {
                                                totalTeamRBIs++;
                                                currentSimRBIs++;
                                                currentPlayerRBIs++;
                                            }

                                            //simulate a steal
                                            rand = random.NextDouble();
                                            SimulateSteal(rand, StolenBasesPerHitOrWalk);

                                            if (CurrentPlayerBase < 4)
                                            {
                                                rand = random.NextDouble();
                                                if (rand <= RunsPerNonHomerunOrWalk)
                                                {
                                                    totalTeamRuns++;
                                                    currentSimRuns++;
                                                    currentPlayerRuns++;
                                                }
                                            }

                                        }
                                        else if ((rand >= SinglesPerAtBat + DoublesPerAtBat) && (rand <= SinglesPerAtBat + DoublesPerAtBat + TriplesPerAtBat))
                                        {//a triple
                                            totalTeamTriples++;
                                            currentSimTriples++;
                                            currentPlayerTriples++;

                                            CurrentPlayerBase = 3;

                                            randomBaseOutSituation();
                                            //Runner1 += 3;
                                            //Runner2 += 3;
                                            //Runner3 += 3;

                                            rand = random.NextDouble();
                                            if (rand <= RBIsPerHit)
                                            {
                                                totalTeamRBIs++;
                                                currentSimRBIs++;
                                                currentPlayerRBIs++;
                                            }

                                            //simulate a steal
                                            rand = random.NextDouble();
                                            SimulateSteal(rand, StolenBasesPerHitOrWalk);

                                            if (CurrentPlayerBase < 4)
                                            {
                                                rand = random.NextDouble();
                                                if (rand <= RunsPerNonHomerunOrWalk)
                                                {
                                                    totalTeamRuns++;
                                                    currentSimRuns++;
                                                    currentPlayerRuns++;
                                                }
                                            }
                                        }
                                        else if ((rand >= SinglesPerAtBat + DoublesPerAtBat + TriplesPerAtBat) && (rand <= SinglesPerAtBat + DoublesPerAtBat + TriplesPerAtBat + HomerunsPerAtBat))
                                        {//a homerun

                                            totalTeamHomeruns++;
                                            currentSimHomeruns++;
                                            currentPlayerHomeruns++;

                                            totalTeamRuns++;
                                            currentSimRuns++;
                                            currentPlayerRuns++;

                                            CurrentPlayerBase = 4;

                                            randomBaseOutSituation();
                                            //Runner1 += 3;
                                            //Runner2 += 3;
                                            //Runner3 += 3;

                                            rand = random.NextDouble();
                                            if (rand <= RBIsPerHit)
                                            {
                                                totalTeamRBIs++;
                                                currentSimRBIs++;
                                                currentPlayerRBIs++;
                                            }

                                        }
                                        else if ((rand >= SinglesPerAtBat + DoublesPerAtBat + TriplesPerAtBat + HomerunsPerAtBat) && (rand <= SinglesPerAtBat + DoublesPerAtBat + TriplesPerAtBat + HomerunsPerAtBat + WalksPerAtBat))
                                        {//a walk
                                            //a triple
                                            totalTeamWalks++;
                                            currentSimWalks++;
                                            currentPlayerWalks++;

                                            CurrentPlayerBase = 1;

                                            randomBaseOutSituation();
                                            //Runner1 += 1;
                                            //Runner2 += 1;
                                            //Runner3 += 1;

                                            //simulate a steal
                                            rand = random.NextDouble();
                                            SimulateSteal(rand, StolenBasesPerHitOrWalk);

                                            if (CurrentPlayerBase < 4)
                                            {
                                                rand = random.NextDouble();
                                                if (rand <= RunsPerNonHomerunOrWalk)
                                                {
                                                    totalTeamRuns++;
                                                    currentSimRuns++;
                                                    currentPlayerRuns++;
                                                }
                                            }
                                        }
                                        else
                                        {//the player got out

                                        }
                                    }
                                }
                            }

                    }//
                    else
                    { //now to simulate pitchers
                        


                        double StrikeoutsPerBatterFaced = Convert.ToDouble(reader["StrikeoutsPerBatterFaced"]);
                        double WalksPerBatterFaced = Convert.ToDouble(reader["WalksPerBatterFaced"]);
                        double HitsPerBatterFaced = Convert.ToDouble(reader["HitsPerBatterFaced"]);
                        double InningsPerGame = Convert.ToDouble(reader["InningsPerGame"]);
                        double SavesPerInning = Convert.ToDouble(reader["SavesPerInning"]);
                        double PercentageOfHitsThatAreHomeruns = Convert.ToDouble(reader["PercentageOfHitsThatAreHomeruns"]);
                        double ERPerInningPitched = Convert.ToDouble(reader["ERPerInningPitched"]);
                        double StrikeoutsPerIPOut = Convert.ToDouble(reader["StrikeoutsPerIPOut"]);


                            for (int p = 0; p < games; p++)
                            {
                                int currentGameER = 0;
                                //int innings = GetPoisson(InningsPerGame);

                                for (int x = 0; x < Math.Round(InningsPerGame,0); x++)
                                {
                                    currentSimIP++;
                                    totalTeamIP++;
                                    currentPlayerIP++;

                                    int outs = 0;
                                    while (outs < 3)
                                    {
                                        rand = random.NextDouble();

                                        if (rand <= HitsPerBatterFaced)
                                        {//hit
                                            currentSimHits++;
                                            totalTeamHits++;
                                            currentPlayerHits++;
                                        }
                                        else if ((rand > HitsPerBatterFaced) && (rand <= HitsPerBatterFaced + WalksPerBatterFaced))
                                        {//walk
                                            currentSimWalksGiven++;
                                            totalTeamWalksGiven++;
                                            currentPlayerWalksGiven++;
                                        }
                                        else if ((rand > HitsPerBatterFaced + WalksPerBatterFaced) && (rand <= HitsPerBatterFaced + WalksPerBatterFaced + StrikeoutsPerBatterFaced))
                                        {//strikeout
                                            currentSimStrikeouts++;
                                            totalTeamStrikeouts++;
                                            currentPlayerStrikeouts++;
                                            outs++;
                                        }
                                        else
                                        {//batter out
                                            outs++;
                                        }
                                    }

                                        //simulate earned run
                                        rand = random.NextDouble();

                                        if(rand < ERPerInningPitched)
                                        {
                                            currentSimER++;
                                            totalTeamER++;
                                            currentPlayerER++;
                                            currentGameER++;
                                        }

                                        rand = random.NextDouble();

                                        if (Position == "RP")
                                        {
                                            if (rand < SavesPerInning)
                                            {
                                                currentPlayerSaves++;
                                                currentSimSaves++;
                                                totalTeamSaves++;
                                            }
                                        }
                                }

                                if ((Math.Round(InningsPerGame, 0) >= 6) && (currentGameER <= 3))
                                {
                                    currentSimQS++;
                                    totalTeamQS++;
                                    currentPlayerQS++;
                                }
                                
                            }

                        
                    }
                    currentPlayerERA = ERA(currentPlayerER, currentPlayerIP);
                    currentPlayerWHIP = WHIP(currentPlayerWalksGiven, currentPlayerHits, currentPlayerIP);

                    currentPlayerSLG = SLG(currentPlayerSingles, currentPlayerDoubles, currentPlayerTriples, currentPlayerHomeruns, currentPlayerAtBats);
                    currentPlayerOBP = OBP(currentPlayerSingles + currentPlayerDoubles + currentPlayerTriples + currentPlayerHomeruns, currentPlayerWalks, currentPlayerAtBats);
                    currentPlayerK9 = ((double)(currentPlayerStrikeouts)) / ((double)(currentPlayerIP)) * ((double)9);

                    if(Position!="RP" && Position!="SP")
                    {
                        using(var conn1 = new SqlConnection("server=ACWilson-PC;Integrated Security = true;" +
                                       "Trusted_Connection=yes;" +
                                       "database=Baseball; " +
                                       "connection timeout=30"))
                        {
                            if (!double.IsNaN(currentPlayerSLG) && !double.IsNaN(currentPlayerOBP))
                            {
                                SqlCommand myCmd22 = new SqlCommand(@"INSERT INTO [dbo].[BattingProjections2014-1000]
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
                                                             VALUES
                                                                   ('" + playerID + @"'
                                                                   ," + (int)Math.Round(((double)currentPlayerAtBats / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerSingles / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerDoubles / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerTriples / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerHomeruns / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerWalks / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerSteals / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerRBIs / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerRuns / (double)(1000)), 0) + @"
                                                                   ," + currentPlayerOBP + @"
                                                                   ," + currentPlayerSLG + @")", conn1);

                                conn1.Open();
                                myCmd22.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        using (var conn2 = new SqlConnection("server=ACWilson-PC;Integrated Security = true;" +
                                       "Trusted_Connection=yes;" +
                                       "database=Baseball; " +
                                       "connection timeout=30"))
                        {
                            if (!double.IsNaN(currentPlayerERA) && !double.IsNaN(currentPlayerWHIP) && !double.IsNaN(currentPlayerK9))
                            {
                                SqlCommand myCmd11 = new SqlCommand(@"INSERT INTO [dbo].[PitchingProjections2014-1000]
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
                                                             VALUES
                                                                   ('" + playerID + @"'
                                                                   ," + (int)Math.Round(((double)currentPlayerIP / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerWalksGiven / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerHits / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerStrikeouts / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerER / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerSaves / (double)(1000)), 0) + @"
                                                                   ," + (int)Math.Round(((double)currentPlayerQS / (double)(1000)), 0) + @"
                                                                   ," + currentPlayerERA + @"
                                                                   ," + currentPlayerWHIP + @"
                                                                   ," + currentPlayerK9 + @")", conn2);
                                conn2.Open();
                                myCmd11.ExecuteNonQuery();
                            }
                        }
                    }

                } //END OF CURRENT PLAYER
            }
            currentSimERA = ERA(currentSimER, currentSimIP);
            currentSimWHIP = WHIP(currentSimWalksGiven, currentSimHits, currentSimIP);

            currentSimSLG = SLG(currentSimSingles, currentSimDoubles, currentSimTriples, currentSimHomeruns, currentSimAtBats);
            currentSimOBP = OBP(currentSimSingles + currentSimDoubles + currentSimTriples + currentSimHomeruns, currentSimWalks, currentSimAtBats);
            currentSimK9 = ((double)(currentSimStrikeouts)) / ((double)(currentSimIP)) * ((double)9);

            if (!double.IsNaN(currentSimSLG) && !double.IsNaN(currentSimOBP))
            {
                SqlCommand myCmd = new SqlCommand(@"INSERT INTO [dbo].[ConfidentProjs2015]
                                               ([teamname]
                                               ,[Runs]
                                               ,[RBI]
                                               ,[Homeruns]
                                               ,[Steals]
                                               ,[OBP]
                                               ,[SLG]
                                               ,[IP]
                                               ,[QS]
                                               ,[SV]
                                               ,[ERA]
                                               ,[WHIP]
                                               ,[K/9])
                                         VALUES
                                               ('TeamConfident'
                                               ," + currentSimRuns + @"
                                               ," + currentSimRBIs + @"
                                               ," + currentSimHomeruns + @"
                                               ," + currentSimSteals + @"
                                               ," + currentSimOBP + @"
                                               ," + currentSimSLG + @"
                                               ," + currentSimIP + @"
                                               ," + currentSimQS + @"
                                               ," + currentSimSaves + @"
                                               ," + currentSimERA + @"
                                               ," + currentSimWHIP + @"
                                               ," + currentSimK9 + @" )", myConnection);
                myCmd.ExecuteNonQuery();
            }
        }//end of added for loop
            totalTeamERA = ERA(totalTeamER, totalTeamIP);
            totalTeamWHIP = WHIP(totalTeamWalksGiven, totalTeamHits, totalTeamIP);

            teamSLG = SLG(totalTeamSingles, totalTeamDoubles, totalTeamTriples, totalTeamHomeruns, totalTeamAtBats);
            teamOBP = OBP(totalTeamSingles+totalTeamDoubles+totalTeamTriples+totalTeamHomeruns, totalTeamWalks, totalTeamAtBats);
            /*
            minimumSLG = SLG(minimumTeamSingles, minimumTeamDoubles, minimumTeamTriples, minimumTeamHomeruns, minimumTeamAtBats);
            minimumOBP = OBP(minimumTeamSingles + minimumTeamDoubles + minimumTeamTriples + minimumTeamHomeruns, minimumTeamWalks, minimumTeamAtBats);

            maximumSLG = SLG(maximumTeamSingles, maximumTeamDoubles, maximumTeamTriples, maximumTeamHomeruns, maximumTeamAtBats);
            maximumOBP = OBP(maximumTeamSingles + maximumTeamDoubles + maximumTeamTriples + maximumTeamHomeruns, maximumTeamWalks, maximumTeamAtBats);*/

            int t = 9;
            //MessageBox.Show(SLG(70,46,3,51,540).ToString());
            //MessageBox.Show(OBP(152,68,434).ToString());
        }

        public double SLG(int singles, int doubles, int triples, int homeruns, int atBats)
        {
            double SLG = ((double)(singles + (2*(doubles)) + (3*(triples)) + (4*(homeruns)))/(double)(atBats));
            return SLG;
        }

        public double OBP(int hits, int walks, int atBats)
        {
            double OBP = ((double)(hits + walks) / (double)(atBats + walks));
            return OBP;
        }

        public double ERA(int runs, int innings)
        {
            double ERA = (((double)(runs)/(double)(innings))*(double)9);
            return ERA;
        }

        public double WHIP(int walks, int hits, int innings)
        {
            double WHIP = (((double)(walks+hits)/(double)(innings)));
            return WHIP;
        }

        public void randomBaseOutSituation(){

            Runner1 = 0;
            Runner2 = 0;
            Runner3 = 0;
            Outs = 0;
            
            
            //1621812 is the total number of situations tallied
            //variables named in form eeen mean 1st is empty, 2nd is empty, 3rd is empty, no outs
            double EEEN = (((double)(377390)) / ((double)(1621812)));
            double FEEN = (((double)(97684)) / ((double)(1621812)));
            double EFEN = (((double)(29342)) / ((double)(1621812)));
            double FFEN = (((double)(21978)) / ((double)(1621812)));
            double EEFN = (((double)(5360)) / ((double)(1621812)));
            double FEFN = (((double)(9845)) / ((double)(1621812)));
            double EFFN = (((double)(5571)) / ((double)(1621812)));
            double FFFN = (((double)(5233)) / ((double)(1621812)));
            double EEEO = (((double)(270279)) / ((double)(1621812)));
            double FEEO = (((double)(112521)) / ((double)(1621812)));
            double EFEO = (((double)(52502)) / ((double)(1621812)));
            double FFEO = (((double)(39375)) / ((double)(1621812)));
            double EEFO = (((double)(18798)) / ((double)(1621812)));
            double FEFO = (((double)(19988)) / ((double)(1621812)));
            double EFFO = (((double)(14152)) / ((double)(1621812)));
            double FFFO = (((double)(13474)) / ((double)(1621812)));
            double EEET = (((double)(215735)) / ((double)(1621812)));
            double FEET = (((double)(113013)) / ((double)(1621812)));
            double EFET = (((double)(64639)) / ((double)(1621812)));
            double FFET = (((double)(50463)) / ((double)(1621812)));
            double EEFT = (((double)(27006)) / ((double)(1621812)));
            double FEFT = (((double)(25826)) / ((double)(1621812)));
            double EFFT = (((double)(15357)) / ((double)(1621812)));
            double FFFT = (((double)(16281)) / ((double)(1621812)));

            double[] BaseOutSituations = new double[] {EEEN, FEEN, EFEN, FFEN, EEFN, FEFN, EFFN, FFFN, EEEO, FEEO, EFEO, FFEO, EEFO, FEFO, EFFO, FFFO, EEET, FEET, EFET, FFET, EEFT, FEFT, EFFT, FFFT};
            String[] BaseOutSituationsStrings = new String[] { "EEEN", "FEEN", "EFEN", "FFEN", "EEFN", "FEFN", "EFFN", "FFFN", "EEEO", "FEEO", "EFEO", "FFEO", "EEFO", "FEFO", "EFFO", "FFFO", "EEET", "FEET", "EFET", "FFET", "EEFT", "FEFT", "EFFT", "FFFT"};

            String BaseOutSituation = "";

            Random random = new Random();
            double rand = random.NextDouble();

            double first = 0;
            double second;

            for(int i = 0; i < BaseOutSituations.Length; i++)
            {
                second = BaseOutSituations[i] + first;

                if((rand >= first) && (rand <= second))
                {
                    //MessageBox.Show(BaseOutSituationsStrings[i]);
                    BaseOutSituation = BaseOutSituationsStrings[i];
                }

                first = BaseOutSituations[i] + first;
            }
            /*
            if (BaseOutSituation[0].ToString() == "F")
            {
                Runner1 = 1;
            }
            if(BaseOutSituation[1].ToString()=="F")
            {
                Runner2 = 2;
            }
            if (BaseOutSituation[2].ToString() == "F")
            {
                Runner3 = 3;
            }*/

            if (BaseOutSituation[3].ToString() == "O")
            {
                Outs = 1;
            }
            else if (BaseOutSituation[3].ToString() == "T")
            {
                Outs = 2;
            }
            else
            {
                Outs = 0;
            }
            
        }

        public Boolean SimulateSteal(double rand, double stealsPerAtBatOrWalk)
        {   
            //don't steal if a player is in front of you
            if ((CurrentPlayerBase == 3) || ((CurrentPlayerBase + 1 != Runner1) 
                                             && (CurrentPlayerBase + 1 != Runner2) 
                                             && (CurrentPlayerBase + 1 != Runner3)))
            {
                //simulate the steal
                if((rand>0)&&(rand<stealsPerAtBatOrWalk))
                {
                    totalTeamSteals++;
                    currentSimSteals++;
                    currentPlayerSteals++;

                    CurrentPlayerBase++;

                    if(CurrentPlayerBase >= 4)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;
                        currentPlayerRuns++;

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void SimulateRun(double rand)
        {
            double FBaseNoOuts = .441;
            double SBaseNoOuts = .637;
            double TBaseNoOuts = .853;
            double FBaseOneOuts = .284;
            double SBaseOneOuts = .418;
            double TBaseOneOuts = .674;
            double FBaseTwoOuts = .135;
            double SBaseTwoOuts = .230;
            double TBaseTwoOuts = .270;

            if(Outs == 0)
            {
                if(CurrentPlayerBase == 1)
                {
                    if (rand <= FBaseNoOuts)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;
                        currentPlayerRuns++;
                        CurrentPlayerBase = 0;
                    }
                }
                else if (CurrentPlayerBase == 2)
                {
                    if (rand <= SBaseNoOuts)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;
                        currentPlayerRuns++;
                        CurrentPlayerBase = 0;
                    }
                }
                else
                {
                    if (rand <= TBaseNoOuts)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;

                        currentPlayerRuns++;
                        CurrentPlayerBase = 0;
                    }
                }
            }
            else if(Outs == 1)
            {
                if (CurrentPlayerBase == 1)
                {
                    if (rand <= FBaseOneOuts)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;

                        currentPlayerRuns++;
                        CurrentPlayerBase = 0;
                    }
                }
                else if (CurrentPlayerBase == 2)
                {
                    if (rand <= SBaseOneOuts)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;

                        currentPlayerRuns++;
                        CurrentPlayerBase = 0;
                    }
                }
                else
                {
                    if (rand <= TBaseOneOuts)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;

                        currentPlayerRuns++;
                        CurrentPlayerBase = 0;
                    }
                }
            }
            else if( Outs == 2)
            {
                if (CurrentPlayerBase == 1)
                {
                    if (rand <= FBaseTwoOuts)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;

                        currentPlayerRuns++;
                        CurrentPlayerBase = 0;
                    }
                }
                else if (CurrentPlayerBase == 2)
                {
                    if (rand <= SBaseTwoOuts)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;

                        currentPlayerRuns++;
                        CurrentPlayerBase = 0;
                    }
                }
                else
                {
                    if (rand <= TBaseTwoOuts)
                    {
                        totalTeamRuns++;
                        currentSimRuns++;

                        currentPlayerRuns++;
                        CurrentPlayerBase = 0;
                    }
                }
            }
        }

        public void checkMinandMax()
        {
            //if (currentPlayerMinAtBats != 1000000)
            //{

                //check for new min
                /*if (currentSimAtBats < currentPlayerMinAtBats)
                {
                    currentPlayerMinAtBats = currentSimAtBats;
                }
                if (currentSimSingles < currentPlayerMinSingles)
                {
                    currentPlayerMinSingles = currentSimSingles;
                }
                if (currentSimDoubles < currentPlayerMinDoubles)
                {
                    currentPlayerMinDoubles = currentSimDoubles;
                }
                if (currentSimTriples < currentPlayerMinTriples)
                {
                    currentPlayerMinTriples = currentSimTriples;
                }
                if (currentSimHomeruns < currentPlayerMinHomeruns)
                {
                    currentPlayerMinHomeruns = currentSimHomeruns;
                }
                if (currentSimWalks < currentPlayerMinWalks)
                {
                    currentPlayerMinWalks = currentSimWalks;
                }
                if (currentSimSteals < currentPlayerMinSteals)
                {
                    currentPlayerMinSteals = currentSimSteals;
                }
                if (currentSimRBIs < currentPlayerMinRBIs)
                {
                    currentPlayerMinRBIs = currentSimRBIs;
                }
                if (currentSimRuns < currentPlayerMinRuns)
                {
                    currentPlayerMinRuns = currentSimRuns;
                }
            //}

            //check for new max
            //if (currentPlayerMaxAtBats > 0)
            //{
                if (currentSimAtBats > currentPlayerMaxAtBats)
                {
                    currentPlayerMaxAtBats = currentSimAtBats;
                }
                if (currentSimSingles > currentPlayerMaxSingles)
                {
                    currentPlayerMaxSingles = currentSimSingles;
                }
                if (currentSimDoubles > currentPlayerMaxDoubles)
                {
                    currentPlayerMaxDoubles = currentSimDoubles;
                }
                if (currentSimTriples > currentPlayerMaxTriples)
                {
                    currentPlayerMaxTriples = currentSimTriples;
                }
                if (currentSimHomeruns > currentPlayerMaxHomeruns)
                {
                    currentPlayerMaxHomeruns = currentSimHomeruns;
                }
                if (currentSimWalks > currentPlayerMaxWalks)
                {
                    currentPlayerMaxWalks = currentSimWalks;
                }
                if (currentSimSteals > currentPlayerMaxSteals)
                {
                    currentPlayerMaxSteals = currentSimSteals;
                }
                if (currentSimRBIs > currentPlayerMaxRBIs)
                {
                    currentPlayerMaxRBIs = currentSimRBIs;
                }
                if (currentSimRuns > currentPlayerMaxRuns)
                {
                    currentPlayerMaxRuns = currentSimRuns;
                }*/
            //}

        }

        private static uint GetUint()
        {
            m_z = 36969 * (m_z & 65535) + (m_z >> 16);
            m_w = 18000 * (m_w & 65535) + (m_w >> 16);
            return (m_z << 16) + m_w;
        }

        public static double GetUniform()
        {
            // 0 <= u < 2^32
            uint u = GetUint();
            // The magic number below is 1/(2^32 + 2).
            // The result is strictly between 0 and 1.
            return (u + 1.0) * 2.328306435454494e-10;
        }

        public static int GetPoisson(double lambda)
        {
            return (lambda < 30.0) ? PoissonSmall(lambda) : PoissonLarge(lambda);
        }

        private static int PoissonSmall(double lambda)
        {
            // Algorithm due to Donald Knuth, 1969.
            double p = 1.0, L = Math.Exp(-lambda);
            int k = 0;
            do
            {
                k++;
                p *= GetUniform();
            }
            while (p > L);
            return k - 1;
        }

        private static int PoissonLarge(double lambda)
        {
            // "Rejection method PA" from "The Computer Generation of 
            // Poisson Random Variables" by A. C. Atkinson,
            // Journal of the Royal Statistical Society Series C 
            // (Applied Statistics) Vol. 28, No. 1. (1979)
            // The article is on pages 29-35. 
            // The algorithm given here is on page 32.

            double c = 0.767 - 3.36 / lambda;
            double beta = Math.PI / Math.Sqrt(3.0 * lambda);
            double alpha = beta * lambda;
            double k = Math.Log(c) - lambda - Math.Log(beta);

            for (; ; )
            {
                double u = GetUniform();
                double x = (alpha - Math.Log((1.0 - u) / u)) / beta;
                int n = (int)Math.Floor(x + 0.5);
                if (n < 0)
                    continue;
                double v = GetUniform();
                double y = alpha - beta * x;
                double temp = 1.0 + Math.Exp(y);
                double lhs = y + Math.Log(v / (temp * temp));
                double rhs = k + n * Math.Log(lambda) - LogFactorial(n);
                if (lhs <= rhs)
                    return n;
            }
        }

 
        static double LogFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (n > 254)
            {
                double x = n + 1;
                return (x - 0.5)*Math.Log(x) - x + 0.5*Math.Log(2*Math.PI) + 1.0/(12.0*x);
            }
            else
            {
                double[] lf = 
                {
                    0.000000000000000,
                    0.000000000000000,
                    0.693147180559945,
                    1.791759469228055,
                    3.178053830347946,
                    4.787491742782046,
                    6.579251212010101,
                    8.525161361065415,
                    10.604602902745251,
                    12.801827480081469,
                    15.104412573075516,
                    17.502307845873887,
                    19.987214495661885,
                    22.552163853123421,
                    25.191221182738683,
                    27.899271383840894,
                    30.671860106080675,
                    33.505073450136891,
                    36.395445208033053,
                    39.339884187199495,
                    42.335616460753485,
                    45.380138898476908,
                    48.471181351835227,
                    51.606675567764377,
                    54.784729398112319,
                    58.003605222980518,
                    61.261701761002001,
                    64.557538627006323,
                    67.889743137181526,
                    71.257038967168000,
                    74.658236348830158,
                    78.092223553315307,
                    81.557959456115029,
                    85.054467017581516,
                    88.580827542197682,
                    92.136175603687079,
                    95.719694542143202,
                    99.330612454787428,
                    102.968198614513810,
                    106.631760260643450,
                    110.320639714757390,
                    114.034211781461690,
                    117.771881399745060,
                    121.533081515438640,
                    125.317271149356880,
                    129.123933639127240,
                    132.952575035616290,
                    136.802722637326350,
                    140.673923648234250,
                    144.565743946344900,
                    148.477766951773020,
                    152.409592584497350,
                    156.360836303078800,
                    160.331128216630930,
                    164.320112263195170,
                    168.327445448427650,
                    172.352797139162820,
                    176.395848406997370,
                    180.456291417543780,
                    184.533828861449510,
                    188.628173423671600,
                    192.739047287844900,
                    196.866181672889980,
                    201.009316399281570,
                    205.168199482641200,
                    209.342586752536820,
                    213.532241494563270,
                    217.736934113954250,
                    221.956441819130360,
                    226.190548323727570,
                    230.439043565776930,
                    234.701723442818260,
                    238.978389561834350,
                    243.268849002982730,
                    247.572914096186910,
                    251.890402209723190,
                    256.221135550009480,
                    260.564940971863220,
                    264.921649798552780,
                    269.291097651019810,
                    273.673124285693690,
                    278.067573440366120,
                    282.474292687630400,
                    286.893133295426990,
                    291.323950094270290,
                    295.766601350760600,
                    300.220948647014100,
                    304.686856765668720,
                    309.164193580146900,
                    313.652829949878990,
                    318.152639620209300,
                    322.663499126726210,
                    327.185287703775200,
                    331.717887196928470,
                    336.261181979198450,
                    340.815058870798960,
                    345.379407062266860,
                    349.954118040770250,
                    354.539085519440790,
                    359.134205369575340,
                    363.739375555563470,
                    368.354496072404690,
                    372.979468885689020,
                    377.614197873918670,
                    382.258588773060010,
                    386.912549123217560,
                    391.575988217329610,
                    396.248817051791490,
                    400.930948278915760,
                    405.622296161144900,
                    410.322776526937280,
                    415.032306728249580,
                    419.750805599544780,
                    424.478193418257090,
                    429.214391866651570,
                    433.959323995014870,
                    438.712914186121170,
                    443.475088120918940,
                    448.245772745384610,
                    453.024896238496130,
                    457.812387981278110,
                    462.608178526874890,
                    467.412199571608080,
                    472.224383926980520,
                    477.044665492585580,
                    481.872979229887900,
                    486.709261136839360,
                    491.553448223298010,
                    496.405478487217580,
                    501.265290891579240,
                    506.132825342034830,
                    511.008022665236070,
                    515.890824587822520,
                    520.781173716044240,
                    525.679013515995050,
                    530.584288294433580,
                    535.496943180169520,
                    540.416924105997740,
                    545.344177791154950,
                    550.278651724285620,
                    555.220294146894960,
                    560.169054037273100,
                    565.124881094874350,
                    570.087725725134190,
                    575.057539024710200,
                    580.034272767130800,
                    585.017879388839220,
                    590.008311975617860,
                    595.005524249382010,
                    600.009470555327430,
                    605.020105849423770,
                    610.037385686238740,
                    615.061266207084940,
                    620.091704128477430,
                    625.128656730891070,
                    630.172081847810200,
                    635.221937855059760,
                    640.278183660408100,
                    645.340778693435030,
                    650.409682895655240,
                    655.484856710889060,
                    660.566261075873510,
                    665.653857411105950,
                    670.747607611912710,
                    675.847474039736880,
                    680.953419513637530,
                    686.065407301994010,
                    691.183401114410800,
                    696.307365093814040,
                    701.437263808737160,
                    706.573062245787470,
                    711.714725802289990,
                    716.862220279103440,
                    722.015511873601330,
                    727.174567172815840,
                    732.339353146739310,
                    737.509837141777440,
                    742.685986874351220,
                    747.867770424643370,
                    753.055156230484160,
                    758.248113081374300,
                    763.446610112640200,
                    768.650616799717000,
                    773.860102952558460,
                    779.075038710167410,
                    784.295394535245690,
                    789.521141208958970,
                    794.752249825813460,
                    799.988691788643450,
                    805.230438803703120,
                    810.477462875863580,
                    815.729736303910160,
                    820.987231675937890,
                    826.249921864842800,
                    831.517780023906310,
                    836.790779582469900,
                    842.068894241700490,
                    847.352097970438420,
                    852.640365001133090,
                    857.933669825857460,
                    863.231987192405430,
                    868.535292100464630,
                    873.843559797865740,
                    879.156765776907600,
                    884.474885770751830,
                    889.797895749890240,
                    895.125771918679900,
                    900.458490711945270,
                    905.796028791646340,
                    911.138363043611210,
                    916.485470574328820,
                    921.837328707804890,
                    927.193914982476710,
                    932.555207148186240,
                    937.921183163208070,
                    943.291821191335660,
                    948.667099599019820,
                    954.046996952560450,
                    959.431492015349480,
                    964.820563745165940,
                    970.214191291518320,
                    975.612353993036210,
                    981.015031374908400,
                    986.422203146368590,
                    991.833849198223450,
                    997.249949600427840,
                    1002.670484599700300,
                    1008.095434617181700,
                    1013.524780246136200,
                    1018.958502249690200,
                    1024.396581558613400,
                    1029.838999269135500,
                    1035.285736640801600,
                    1040.736775094367400,
                    1046.192096209724900,
                    1051.651681723869200,
                    1057.115513528895000,
                    1062.583573670030100,
                    1068.055844343701400,
                    1073.532307895632800,
                    1079.012946818975000,
                    1084.497743752465600,
                    1089.986681478622400,
                    1095.479742921962700,
                    1100.976911147256000,
                    1106.478169357800900,
                    1111.983500893733000,
                    1117.492889230361000,
                    1123.006317976526100,
                    1128.523770872990800,
                    1134.045231790853000,
                    1139.570684729984800,
                    1145.100113817496100,
                    1150.633503306223700,
                    1156.170837573242400,
                };
                return lf[n];
            }
        }


    }
}
