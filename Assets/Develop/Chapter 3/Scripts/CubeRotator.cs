using UnityEngine;

namespace Develop.Chapter_3.Scripts
{
    public class CubeRotator : MonoBehaviour
    {
        private void Update()
        {
            transform.eulerAngles += Vector3.down;
        }
    }
}
