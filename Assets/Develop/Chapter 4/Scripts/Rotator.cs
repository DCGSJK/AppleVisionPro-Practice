using UnityEngine;

namespace Develop.Chapter_4.Scripts
{
    // Rotator 클래스는 게임 오브젝트를 회전시키는 기능을 제공합니다.
    public class Rotator : MonoBehaviour
    {
        // 월드 공간에서 회전할지 여부를 결정하는 변수
        [SerializeField] private bool useWorldSpace = true;
        // 회전 속도를 나타내는 벡터
        [SerializeField] private Vector3 rotationVelocity = new Vector3(30f, 45f, 60f);
        // 최대 회전 시간을 설정하는 변수, 음수인 경우 무한 회전
        [SerializeField] private float maxRotationTime = -1.0f;

        // 회전 시간을 추적하는 타이머
        private float _rotatorTimer;

        // 스크립트가 처음 로드될 때 호출되는 메서드
        private void Awake()
        {
            // 타이머를 최대 회전 시간으로 초기화합니다.
            _rotatorTimer = maxRotationTime;
        }

        // 매 프레임마다 호출되는 메서드
        private void Update()
        {
            // 최대 회전 시간이 음수인 경우 무한 회전
            if (maxRotationTime < 0)
            {
                // 지정된 속도로 게임 오브젝트를 회전시킵니다.
                transform.Rotate(rotationVelocity * Time.deltaTime, useWorldSpace ? Space.World : Space.Self);
            }
            else
            {
                // 최대 회전 시간 내에서 회전
                if (_rotatorTimer <= maxRotationTime)
                {
                    // 지정된 속도로 게임 오브젝트를 회전시킵니다.
                    transform.Rotate(rotationVelocity * Time.deltaTime, useWorldSpace ? Space.World : Space.Self);
                    // 타이머를 증가시킵니다.
                    _rotatorTimer += Time.deltaTime;
                }
            }
        }

        // 회전을 활성화하는 메서드
        public void Activate()
        {
            // 타이머를 0으로 초기화하여 회전을 시작합니다.
            _rotatorTimer = 0;
        }
    }
}