using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace TowerOfDeath
{
    public class DungeounController : BaseController<IDungeounView, IDungeounModel>, IDungeounController
    {
        protected override void Bind()
        {
            
        }

        protected override void UnBind()
        {
            
        }

        private void Start()
        {
            Invoke(nameof(Spawn), 2f);
        }

        private void Spawn()
        {           
            model.SpawnGoldRoom();
            model.SpawnBossRoom();
        }
    }
}