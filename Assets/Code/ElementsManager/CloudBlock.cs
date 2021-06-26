using UnityEngine;
using System.Threading.Tasks;

namespace Code.ElementsManager
{
    public class CloudBlock : Block
    {

        protected override void TriggerAction(Collider other) => Debug.Log("No Implementedo");
        private void OnCollisionEnter(Collision collision) => CollisionAction(collision);
        internal async override void CollisionAction(Collision collision) 
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            await Task.Delay(System.TimeSpan.FromSeconds(_touchTimeRecycle));
            Recycle();
        }
        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);
        internal override void Release() => Debug.Log("Recycled CloudBlock");
    }
}