using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    
    public class ScoreSheet
    {
        private ScoreSheet(string value) { Value = value; }

        public string Value { get; set; }

        public static ScoreSheet LoveAll        { get { return new ScoreSheet("Love-All"); } }
        public static ScoreSheet FifteenAll     { get { return new ScoreSheet("Fifteen-All"); } }
        public static ScoreSheet ThirtyAll      { get { return new ScoreSheet("Thirty-All"); } }
        public static ScoreSheet Deuce          { get { return new ScoreSheet("Deuce"); } }
        public static ScoreSheet AdvantageP1    { get { return new ScoreSheet("Advantage player1"); } }
        public static ScoreSheet AdvantageP2    { get { return new ScoreSheet("Advantage player2"); } }
        public static ScoreSheet WinP1          { get { return new ScoreSheet("Win for player1"); } }
        public static ScoreSheet WinP2          { get { return new ScoreSheet("Win for player2"); } }
        public static ScoreSheet Love           { get { return new ScoreSheet("Love"); } }
        public static ScoreSheet Fifteen        { get { return new ScoreSheet("Fifteen"); } }
        public static ScoreSheet Thirty         { get { return new ScoreSheet("Thirty"); } }
        public static ScoreSheet Forty          { get { return new ScoreSheet("Forty"); } }
    }

    public class DrawScoreFactory
    {
        public static string CaluclateScore(int score)
        {
            switch (score)
                {
                    case 0:
                        return ScoreSheet.LoveAll.Value;
                    case 1:
                        return ScoreSheet.FifteenAll.Value;
                    case 2:
                        return ScoreSheet.ThirtyAll.Value;
                    default:
                        return ScoreSheet.Deuce.Value;
                }
        }
    }

    public class AdvantageWinScoreFactory
    {
        public static string CaluclateScore(int score)
        {
            if (score == 1)
            {
                return ScoreSheet.AdvantageP1.Value;
            }
            if (score == -1)
            {
                return ScoreSheet.AdvantageP2.Value;
            } 
            if (score >= 2)
            {
                return ScoreSheet.WinP1.Value;
            }
            return ScoreSheet.WinP2.Value;
        }
    }

    public class ClassicScoreFactory
    {
        public static string CaluclateScore(int score)
        {
            switch (score)
            {
                case 0:
                    return ScoreSheet.Love.Value;
                case 1:
                    return ScoreSheet.Fifteen.Value;
                case 2:
                    return ScoreSheet.Thirty.Value;
                case 3:
                    return ScoreSheet.Forty.Value;
                default:
                    return "";
            }
        }
    }
    
    
    public interface ITennisPlayer
    {
        void WonPoint();
        void ResetScore();

    }


    class TennisPlayer: ITennisPlayer
    {
        private string playerName; 
        private int m_score;
        
        public TennisPlayer(string playerName)
        {
            this.playerName = playerName;
            this.m_score = 0;
        }
        public void WonPoint()
        {
            this.m_score += 1;
        }

        public void ResetScore() {
            this.m_score = 0;
        }

        public int M_score
        {
            get { return m_score; }
        }

        public string getPlayerName() {
            return this.playerName;
        }
    }


    public interface ITennisGame1
    {
        void WonPoint(string playerName);
        string GetScore();
        void ResetPlayersScore();
    }


    public class TennisGame1 : ITennisGame1
    {
        private TennisPlayer player1;
        private TennisPlayer player2;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1 = new TennisPlayer(player1Name);
            this.player2 = new TennisPlayer(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1.getPlayerName()) {
                player1.WonPoint();
                return;
            }
            if (playerName == player2.getPlayerName())
            {
                player2.WonPoint();
                return;
            }
        }

        public string GetScore()
        {
            string score = "";
            if (player1.M_score == player2.M_score)
            {
                score = DrawScoreFactory.CaluclateScore(player1.M_score);
            }
            else if (player1.M_score >= 4 || player2.M_score >= 4)
            {
               score = AdvantageWinScoreFactory.CaluclateScore(player1.M_score - player2.M_score);
            }
            else
            {
                score += ClassicScoreFactory.CaluclateScore(player1.M_score) + "-" + ClassicScoreFactory.CaluclateScore(player2.M_score);
            }
            return score;
        }

        public void ResetPlayersScore()
        {
            player1.ResetScore();
            player2.ResetScore();
        }

        public int m_score1
        {
            get { return player1.M_score; }
        }
        
        public int m_score2
        {
            get { return player2.M_score; }
        }
    }
}
