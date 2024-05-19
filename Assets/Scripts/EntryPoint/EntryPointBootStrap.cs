using TowerOfDeath.DI;
using TowerOfDeath.Service;
using UnityEngine;

public class EntryPointBootStrap : MonoBehaviour
{
    private DIContainer _rootContainer;
    private void Start()
    {
        //TODO: Init Loading Screen       
        Initialization();
    }

    private void Initialization()
    {
        _rootContainer = new DIContainer();
        _rootContainer.RegisterSingleton(factory => new SceneService());

        //TODO: Load EntryPoint MainMenu or GamePlay EntryPoint

        //var sceneService = _rootContainer.Resolve<SceneService>();
        //sceneService.LoadMainMenu();
    }

}

