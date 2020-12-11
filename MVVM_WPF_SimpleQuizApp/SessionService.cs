using System;

namespace MVVM_WPF_SimpleQuizApp
{
    public interface ISessionService
    {
        public void SetDifficulty(int difficulty);
        public int GetDifficulty();

        public void SetUsername(string username);
        public string GetUsername();

        public void SetScore(int score);
        public int GetScore();
    }

    public class SessionService : ISessionService
    {
        private string Username = String.Empty;
        private int SelectedDifficulty = 0;
        private int Score = 0;

        public void SetDifficulty(int difficulty)
        {
            if (SelectedDifficulty == 0)
                SelectedDifficulty = difficulty;
        }

        public int GetDifficulty()
        {
            return SelectedDifficulty;
        }

        public void SetUsername(string username)
        {
            if (Username == String.Empty)
                Username = username;
        }

        public string GetUsername()
        {
            return Username;
        }

        public void SetScore(int score)
        {
            Score = score;
        }

        public int GetScore()
        {
            return Score;
        }
    }
}
