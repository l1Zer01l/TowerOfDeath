using UnityEngine;

namespace TowerOfDeath.Services
{
    public static class ExtentionService
    {
        public static TControlller SetupController<TControlller, TView>(TView view) where TControlller : MonoBehaviour, IController
                                                                                    where TView : MonoBehaviour, IView
        {
            var controller = view.GetComponent<TControlller>();
            if (controller is not null)
            {
                Object.Destroy(controller);
            }
            return view.gameObject.AddComponent<TControlller>();
        }
    }
}