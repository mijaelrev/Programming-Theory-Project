using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

namespace Code.ElementsManager
{
    public class LavaBlock : Block
    {
        private CancellationTokenSource _cancelToken = new CancellationTokenSource();
        [SerializeField] private float _timeKill = 1f;
        [SerializeField] private float _currentTime;
        private void OnCollisionEnter(Collision collision)
        {
            CollisionAction(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            _cancelToken?.Cancel();
            //Task.Run(() => CollisionAction(collision), _cancelToken.Token);
            //Task.FromCanceled(_cancelToken);
        }
        protected override void TriggerAction(Collider other)
        {

        }
        internal async override void CollisionAction(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            Debug.Log("Inicio de la asincronia");
            await Task.Delay(System.TimeSpan.FromSeconds(_timeKill));
            Debug.Log("Tiempo de espera terminado");
            if (_cancelToken.IsCancellationRequested) return;
            PlayerKill();
            Debug.Log("Asincronia ejecutada");
        }

        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);

        internal override void Release() => Debug.Log("Lava Reciclado");

    }
}