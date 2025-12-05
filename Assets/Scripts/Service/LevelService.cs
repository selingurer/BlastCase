using System.Linq;
using ScriptableObject;
using VContainer;

namespace Service
{
    public interface ILevelService
    {
        public LevelConfig CurrentLevel();
        public void NextLevel();
    }

    public class LevelService : ILevelService
    {
        private UserService userService;
        private LevelDatabase levelDatabase;
        private int currentLevel;

        [Inject]
        public LevelService(LevelDatabase levelDatabase, UserService userService)
        {
            this.levelDatabase = levelDatabase;
            this.userService = userService;
            currentLevel = userService.GetUserLevel();
        }

        public LevelConfig CurrentLevel()
        {
            return levelDatabase.Levels
                .FirstOrDefault(x => x.LevelID == currentLevel);
        }

        public void NextLevel()
        {
            currentLevel ++;
            userService.SetUserLevel(currentLevel);
        }
    }
}