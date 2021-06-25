using UnityEngine;

namespace Code.Spawner
{
    public class Randomizer
    {
        /// <summary>
        /// Devuelve un nuevo vector3 poco contronlado desde un punto especificado
        /// </summary>
        /// <param name="origin">posicion especifica</param>
        /// <param name="min">valor en X y Z</param>
        /// <param name="max">valor en X, Y(positivo) y Z</param>
        /// <param name="valueY">Requiere un valor negativo en Y</param>
        /// <returns>UnityEngine.Vector3</returns>
        public Vector3 RandomVector(Vector3 origin, float min, float max, float valueY = 0)
        {
            var randomX = origin.x + Random.Range(min, max);
            var randomY = origin.y + Random.Range(valueY, max);
            var randomZ = origin.z + Random.Range(min, max);
            return new Vector3(randomX, randomY, randomZ);
        }
        /// <summary>
        /// Devuelve un vector3 aleatorio ligeramente mas controlado
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="X">valor en X</param>
        /// <param name="neY">valor en Y negativo</param>
        /// <param name="poY">valor en Y positivo</param>
        /// <param name="Z">Valor en Z</param>
        /// <returns>UnityEngine.Vector3</returns>
        public Vector3 RandomVector(Vector3 origin, float X, float neY, float poY, float Z)
        {
            var randomX = origin.x + Random.Range(-X, X);
            var randomY = origin.y + Random.Range(neY, poY);
            var randomZ = origin.z + Random.Range(-Z, Z);
            return new Vector3(randomX, randomY, randomZ);
        }

        /// <summary>
        /// Devuelve un valor super controlado mas controlado en todos los ejes
        /// </summary>
        /// <param name="origin">Posicion espesifica</param>
        /// <param name="minX">minimo en X</param>
        /// <param name="maxX">maximo en X</param>
        /// <param name="minY">minimo en Y</param>
        /// <param name="maxY">maximo en Y</param>
        /// <param name="minZ">minimo en Z</param>
        /// <param name="maxZ">maximo en Z</param>
        /// <returns></returns>
        public Vector3 RandomVector(Vector3 origin, float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
        {
            var randomX = origin.x + Random.Range(minX, maxX);
            var randomY = origin.y + Random.Range(minY, maxY);
            var randomZ = origin.z + Random.Range(minZ, maxZ);
            return new Vector3(randomX, randomY, randomZ);
        }
        /// <summary>
        /// crea un pinto aleatorio poco controlador a partir de un origen
        /// </summary>
        /// <param name="origin">centro de la aleatoriedad</param>
        /// <param name="min">valor minimo aleatorio</param>
        /// <param name="max">valor maximo aleatorio</param>
        /// <returns></returns>
        public Vector2 RandomVector2(Vector3 origin, float min, float max)
        {
            var randomX = origin.x + Random.Range(min, max);
            var randomY = origin.y + Random.Range(min, max);
            return new Vector2(randomX, randomY);
        }

        /// <summary>
        /// Devuelve un valor aletario de de 0 a el valor indicado. Es estrictamente int 
        /// </summary>
        /// <param name="max">Valor maximo</param>
        /// <param name="min">Valor minimo</param>
        /// <returns>System.Int32</returns>
        public int IntRandom(int max, int min = 0)
        {
            var random = Random.Range(min, max);
            return random;
        }
        /// <summary>
        /// Devuelve un valor aletario de de 0 a el valor indicado. Es estrictamente float
        /// </summary>
        /// <param name="max">maximo valor</param>
        /// <param name="min">Valor minimo</param>
        /// <returns>System.Int32</returns>
        public float FloatRandom(float max, float min = 0)
        {
            var random = Random.Range(min, max);
            return random;
        }
    }
}