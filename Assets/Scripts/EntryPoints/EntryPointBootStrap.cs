using System.Threading;
using TowerOfDeath.DI;
using TowerOfDeath.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerOfDeath.EntryPoints
{
    public class EntryPointBootStrap : MonoBehaviour
    {
        private DIContainer _rootContainer;
        
        private void Start()
        {
            //TODO: Init Loading Screen
            Thread.Sleep(2000);

            Initialization();
        }

        private void Initialization()
        {

            _rootContainer = new DIContainer();
            _rootContainer.RegisterSingleton(factory => new SceneService());
            
            var sceneService = _rootContainer.Resolve<SceneService>();
            sceneService.SceneLoaded += OnSceneLoaded;

            sceneService.LoadMainMenu();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            var sceneName = scene.name;
            
            if (sceneName.Equals(SceneService.MAIN_MENU_SCENE))
                LoadMainMenu();

            if (sceneName.Equals(SceneService.GAMEPLAY_SCENE))
                LoadGamePlay();
        }

        private void LoadMainMenu()
        {
            var entryPointMainMenu = GetEntryPoint<EntryPointMainMenu>();
            
            var mainMenuContainer = new DIContainer(_rootContainer);

            entryPointMainMenu.Initialization(mainMenuContainer);
        }

        private void LoadGamePlay()
        {
            var entryPointGamePlay = GetEntryPoint<EntryPointGamePlay>();

            var gamePlayContainer = new DIContainer(_rootContainer);

            entryPointGamePlay.Initialization(gamePlayContainer);
        }

        private IEntryPoint GetEntryPoint<T>() where T : Object, IEntryPoint
        {
            return Object.FindObjectOfType<T>();
        }
    }

}