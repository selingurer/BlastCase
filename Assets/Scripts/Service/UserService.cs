namespace Service
{
    public class UserService
    {
        private int levelID = 1;

        public int GetUserLevel()
        {
            return levelID;
        }

        public void SetUserLevel(int level)
        {
            levelID = level;
        }
    }
}