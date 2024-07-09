using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.VisionOS;
using UnityEngine.XR.VisionOS.InputDevices;

namespace Develop.Chapter_4.Scripts
{
    // SpatialHandleInteractionHandler 클래스는 사용자의 손 위치와 회전을 기반으로 공간 상호작용을 처리합니다.
    public class SpatialHandleInteractionHandler : MonoBehaviour
    {
        // 사용자 손 오브젝트
        [SerializeField] private GameObject hand;
        // 공간 포인터 프리팹
        [SerializeField] private GameObject spatialPointerPrefab;
        // 공간 포인터의 최대 거리
        [SerializeField] private float spatialPointerDistance = 1000f;
        // 상호작용에 사용될 레이어 마스크
        [SerializeField] private LayerMask layersUsedForInteractions;

        // 손 위치 입력 액션
        [SerializeField] private InputActionProperty handPositionProperty;
        // 손 회전 입력 액션
        [SerializeField] private InputActionProperty handRotationProperty;
        // 공간 포인터 입력 액션
        [SerializeField] private InputActionProperty spatialPointerProperty;

        // 공간 포인터 오브젝트
        private GameObject _spatialPointer;
        // 공간 포인터의 라인 렌더러
        private LineRenderer _spatialPointerLine;
        // 선택된 오브젝트의 트랜스폼
        private Transform _selectedObject;

        // 스크립트가 처음 로드될 때 호출되는 메서드
        private void Awake()
        {
            // 공간 포인터 프리팹이 설정된 경우 인스턴스화하고 비활성화합니다.
            if (spatialPointerPrefab != null)
            {
                _spatialPointer = Instantiate(spatialPointerPrefab, transform);
                _spatialPointer.SetActive(false);
                var pointerLine = _spatialPointer.transform.GetChild(0);
                _spatialPointerLine = pointerLine.GetComponent<LineRenderer>();
            }
        }

        // 매 프레임마다 호출되는 메서드
        private void Update()
        {
            // 손 위치와 회전을 읽어와서 손 오브젝트에 적용합니다.
            var handPosition = handPositionProperty.action.ReadValue<Vector3>();
            var handRotation = handRotationProperty.action.ReadValue<Quaternion>();
        
            hand.transform.SetLocalPositionAndRotation(handPosition, handRotation);

            // 공간 포인터 상태를 읽어와서 포인터를 업데이트합니다.
            var pointerState = spatialPointerProperty.action.ReadValue<VisionOSSpatialPointerState>();
        
            UpdatePointer(pointerState, _spatialPointer);
        }

        // 공간 포인터를 업데이트하는 메서드
        // ReSharper disable Unity.PerformanceAnalysis
        private void UpdatePointer(VisionOSSpatialPointerState pointerState, GameObject pointer)
        {
            // 포인터가 활성 상태인지 여부를 결정합니다.
            var isPointerActive = pointerState.phase == VisionOSSpatialPointerPhase.Began ||
                                  pointerState.phase == VisionOSSpatialPointerPhase.Moved;

            // 포인터 디바이스의 위치와 회전을 가져옵니다.
            var pointerDevicePosition = transform.InverseTransformPoint(pointerState.inputDevicePosition);
            var pointerDeviceRotation = pointerState.inputDeviceRotation;
        
            // 포인터가 추적 상태인지 여부에 따라 활성화 또는 비활성화합니다.
            pointer.gameObject.SetActive(pointerState.isTracked);
            pointer.transform.SetLocalPositionAndRotation(pointerDevicePosition, pointerDeviceRotation);

            if (isPointerActive)
            {
                // 포인터 라인을 활성화하고 시작 위치와 방향을 설정합니다.
                _spatialPointerLine.enabled = true;
                _spatialPointerLine.SetPosition(1, new Vector3(0, 0, spatialPointerDistance));
                _spatialPointerLine.transform.rotation = pointerState.startRayRotation;

                // 레이캐스트를 사용하여 충돌한 오브젝트를 찾습니다.
                if (Physics.Raycast(pointerState.startRayOrigin, pointerState.startRayDirection, out RaycastHit hit,
                        Mathf.Infinity, layersUsedForInteractions))
                {
                    _selectedObject = hit.transform;
                    // 선택된 오브젝트에 Rotator 컴포넌트가 있는 경우 활성화합니다.
                    _selectedObject.GetComponent<Rotator>().Activate();
                    // 충돌한 오브젝트의 이름을 로그로 출력합니다.
                    Logger.instance.LogInfo($"(Pointer_{spatialPointerProperty.action.name}) ray collided with ({_selectedObject.name})");
                }
            }
            else
            {
                // 포인터 라인을 비활성화합니다.
                _spatialPointerLine.enabled = false;
            }
        }
    }
}
