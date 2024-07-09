using UnityEngine;
using UnityEngine.InputSystem;

namespace Develop.Chapter_3.Scripts
{
    // InputHandler 클래스는 터치 입력을 처리하고, 입력에 따라 커서와 로그를 업데이트합니다.
    public class InputHandler : MonoBehaviour
    {
        // 커서 프리팹
        [SerializeField]
        private GameObject cursorPrefab;
        // 로그 출력 클래스
        [SerializeField]
        private Log log;

        // 커서 사용 여부
        private bool _useCursor;
        // 커서 게임 오브젝트
        private GameObject _cursor;
        // VisionOS 입력 시스템
        private VisionOSInputs _visionOSInputs;
        // 메인 카메라
        private Camera _mainCamera;

        // 스크립트가 처음 로드될 때 호출되는 메서드
        private void Awake()
        {
            // VisionOS 입력 시스템 초기화 및 활성화
            _visionOSInputs = new VisionOSInputs();
            _visionOSInputs.Enable();

            // 터치 탭과 터치 위치 변경 이벤트 핸들러 등록
            _visionOSInputs.WindowedApp.TouchTap.performed += OnTouchTap;
            _visionOSInputs.WindowedApp.TouchPosition.performed += OnTouchPositionChanged;

            // 메인 카메라 참조 저장
            _mainCamera = Camera.main;

            // 커서 프리팹이 설정된 경우 인스턴스화하고 비활성화합니다.
            if (cursorPrefab != null)
            {
                _useCursor = true;
                _cursor = Instantiate(cursorPrefab);
                _cursor.SetActive(false);
            }
        }

        // 터치 탭 이벤트가 발생했을 때 호출되는 메서드
        private void OnTouchTap(InputAction.CallbackContext context) 
        {
            // 로그에 터치 탭 실행 메시지를 출력합니다.
            log.PrintLine("Touch tap was executed", "red");
        }

        // 터치 위치 변경 이벤트가 발생했을 때 호출되는 메서드
        private void OnTouchPositionChanged(InputAction.CallbackContext context)
        {
            // 터치 위치를 읽어옵니다.
            Vector2 touchPosition = context.ReadValue<Vector2>();

            // 로그에 터치 위치 변경 메시지를 출력합니다.
            log.PrintLine($"Touch position changed: {touchPosition}", "black");

            // 커서를 사용하는 경우, 커서를 활성화하고 위치를 업데이트합니다.
            if (_useCursor)
            {
                _cursor.SetActive(true);
                _cursor.transform.position = _mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, -_mainCamera.transform.position.z));
            }
        }

        // 스크립트가 파괴될 때 호출되는 메서드
        private void OnDestroy()
        {
            // 터치 이벤트 핸들러 등록 해제
            _visionOSInputs.WindowedApp.TouchTap.performed -= OnTouchTap;
            _visionOSInputs.WindowedApp.TouchPosition.performed -= OnTouchPositionChanged;
        }
    }
}
