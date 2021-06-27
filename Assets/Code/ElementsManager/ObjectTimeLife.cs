using UnityEngine;
namespace Code.ElementsManager
{
    public class ObjectTimeLife : MonoBehaviour
    {
        [SerializeField] private int _timeLife = 3;
        private void Start() => Destroy(gameObject, _timeLife);
    }
}