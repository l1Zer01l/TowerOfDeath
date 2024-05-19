using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace TowerOfDeath.Services
{
    public class SceneService
    {
        public event UnityAction<Scene, LoadSceneMode> SceneLoaded;

        public const string MAIN_MENU_SCENE = "MAIN_MENU_SCENE";
        public const string BOOTSTRAP_SCENE = "BOOTSTRAP_SCENE";
        public const string GAMEPLAY_SCENE = "GAMEPLAY_SCENE";

        public SceneService()
        {
            SceneManager.sceneLoaded += SceneLoaded;
        }
        
        public string GetActiveScene()
        {
            return SceneManager.GetActiveScene().name;
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(MAIN_MENU_SCENE);
        }

        public void LoadGamePlay()
        {
            SceneManager.LoadScene(GAMEPLAY_SCENE);
        }
    }
}
