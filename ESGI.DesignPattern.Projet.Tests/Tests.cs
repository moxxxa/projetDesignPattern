using System;
using System.Collections.Generic;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        [Fact]
        public void Game()
        {
            var player1Name = "Mouna";
            var player2Name = "Mohamed";
            TennisGame1 game = new TennisGame1(player1Name, player2Name);
            Assert.NotNull(game);

        }
        [Fact]
        public void WonPointTest()
        {
            String player1Name = "Mouna";
            String player2Name = "Mohamed";

            TennisGame1 game = new TennisGame1(player1Name, player2Name);

            game.WonPoint("Mouna");
            Assert.Equal(1, game.m_score1);
            Assert.Equal(0, game.m_score2);


        }

        [Fact]
        public void GetScoreTest()
        {
            var player1Name = "Mouna";
            var player2Name = "Mohamed";
            TennisGame1 game = new TennisGame1(player1Name, player2Name);

            // Scénario 1
            Assert.Equal("Love-All", game.GetScore());
            
            
            // Scénario 2
            game.WonPoint("Mouna");
            game.WonPoint("Mohamed");
            Assert.Equal("Fifteen-All", game.GetScore());
            
            
            // Scénario 3
            for (int i = 0; i < 2; i++) { game.WonPoint("Mouna"); game.WonPoint("Mohamed");}
            Assert.Equal("Thirty-All", game.GetScore());
            
            
            // Scénario 4
            for (int i = 0; i < 3; i++) { game.WonPoint("Mouna"); game.WonPoint("Mohamed");}
            Assert.Equal("Deuce", game.GetScore());
            

            game.ResetPlayersScore();
            
            // Scénario 5 
            for (int i = 0; i < 4; i++) { game.WonPoint("Mouna"); }
            for (int i = 0; i < 2; i++) { game.WonPoint("Mohamed"); }
            Assert.Equal("Win for player1", game.GetScore());
            
            
            game.ResetPlayersScore();

            // Scénario 6
            for (int i = 0; i < 3; i++) { game.WonPoint("Mouna"); }
            for (int i = 0; i < 4; i++) { game.WonPoint("Mohamed"); }
            Assert.Equal("Advantage player2", game.GetScore());
            

            game.ResetPlayersScore();
            
            // Scénario 7
            for (int i = 0; i < 5; i++) { game.WonPoint("Mouna"); }
            for (int i = 0; i < 4; i++) { game.WonPoint("Mohamed"); }
            Assert.Equal("Advantage player1", game.GetScore());
            
            
            game.ResetPlayersScore();

            // Scénario 8
            for (int i = 0; i < 4; i++) { game.WonPoint("Mouna"); }
            for (int i = 0; i < 8; i++) { game.WonPoint("Mohamed"); }
            Assert.Equal("Win for player2", game.GetScore());
            
            
            game.ResetPlayersScore();

            // Scénario 9
            for (int i = 0; i < 2; i++) { game.WonPoint("Mouna"); }
            for (int i = 0; i < 3; i++) { game.WonPoint("Mohamed"); }
            Assert.Equal("Thirty-Forty", game.GetScore());

          

        }
    }
}

