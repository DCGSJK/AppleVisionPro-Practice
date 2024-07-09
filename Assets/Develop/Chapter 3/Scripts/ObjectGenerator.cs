using UnityEngine;

namespace Develop.Chapter_3.Scripts
{
    public class ObjectGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] objectPrefabs;

        public void GenerateObject()
        {
            var random = Random.Range(0, objectPrefabs.Length);
            Instantiate(objectPrefabs[random], this.transform);
        }
    }
}
