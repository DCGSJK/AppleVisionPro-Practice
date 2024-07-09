using UnityEngine;

namespace Develop.Chapter_3.Scripts
{
    // CubeRotator 클래스는 게임 오브젝트(주로 큐브)를 회전시키는 간단한 스크립트입니다.
    public class CubeRotator : MonoBehaviour
    {
        // 매 프레임마다 호출되는 메서드
        private void Update()
        {
            // 게임 오브젝트의 회전 각도(eulerAngles)에 Vector3.down을 더하여 매 프레임마다 아래쪽으로 회전시킵니다.
            transform.eulerAngles += Vector3.down;
        }
    }
}