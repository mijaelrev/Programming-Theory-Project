using UnityEngine;
namespace Code
{
    public class SingletonClass: MonoBehaviour
    {
        public static SingletonClass Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if(Instance != this) Destroy(gameObject);
            
        }

    }

}