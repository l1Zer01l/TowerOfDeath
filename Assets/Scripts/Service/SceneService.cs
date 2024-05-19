using UnityEngine.SceneManagement;

namespace TowerOfDeath.Service
{

    public class SceneService
    {
        public const string MAIN_MENU_SCENE = "MAIN_MENU_SCENE";
        public const string BOOTSTRAP_SCENE = "BOOTSTRAP_SCENE";


        public string GetActiveScene()
        {
            return SceneManager.GetActiveScene().name;
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(MAIN_MENU_SCENE);
        }
    }
}
