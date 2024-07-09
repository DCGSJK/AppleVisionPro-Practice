using UnityEngine;

namespace Develop.Chapter_3.Scripts
{
    // ObjectGenerator 클래스는 지정된 프리팹 배열에서 무작위로 오브젝트를 생성하는 기능을 제공합니다.
    public class ObjectGenerator : MonoBehaviour
    {
        // 생성할 오브젝트 프리팹 배열
        [SerializeField]
        private GameObject[] objectPrefabs;

        // 오브젝트를 무작위로 생성하는 메서드
        public void GenerateObject()
        {
            // 프리팹 배열에서 무작위 인덱스를 선택합니다.
            var random = Random.Range(0, objectPrefabs.Length);
            // 선택된 프리팹을 현재 게임 오브젝트의 위치에 생성합니다.
            Instantiate(objectPrefabs[random], this.transform);
        }
    }
}