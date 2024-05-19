using TowerOfDeath.DI;
using UnityEngine;

public class EntryPointBootStrap : MonoBehaviour
{
    private DIContainer _rootContainer;
    private void Start()
    {
        _rootContainer = new DIContainer();
        Initialization();
    }

    private void Initialization()
    {

    }

}

