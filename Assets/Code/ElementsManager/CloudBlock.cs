using UnityEngine;
using System.Threading.Tasks;

namespace Code.ElementsManager
{
    public class CloudBlock : Block
    {

        private void OnCollisionEnter(Collision collision) => CollisionAction(collision);
        protected override void TriggerAction(Collider other) { }

        internal override void CollisionAction(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            CloudDisolve();
        }
        private async void CloudDisolve()
        {
            await Task.Delay(System.TimeSpan.FromSeconds(_touchTimeRecycle));
            Recycle();
        }

        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);
        internal override void Release() => Debug.Log("CloudBlock Recycle");
    }
}