using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.PolySpatial.InputDevices;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using UnityEngine.InputSystem.LowLevel;

public class MoveObjectOnInput : MonoBehaviour
{
    private GameObject selectedObject; // 객체 저장 변수 
    private Vector3 lastPosition; // 터치 위치 저장 변수 

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            foreach (var touch in Touch.activeTouches)
            {
                SpatialPointerState touchData = EnhancedSpatialPointerSupport.GetPointerState(touch);

                if (touchData.targetObject != null && touchData.Kind != SpatialPointerKind.Touch)
                {
                    if (touch.phase == TouchPhase.Began) // 터치 시작 터치가 움직이면 초기 위치를 기록
                    {
                        selectedObject = touchData.targetObject;
                        lastPosition = touchData.interactionPosition;
                    }
                    else if (touch.phase == TouchPhase.Moved && selectedObject != null)
                    {
                        // 터치 이동 거리를 계산하여 객체 이동 
                        Vector3 deltaPosition = touchData.interactionPosition - lastPosition;
                        selectedObject.transform.position += deltaPosition;
                        // 마지막 위치 업데이트 
                        lastPosition = touchData.interactionPosition;
                    }
                }
            }
        }

        if (Touch.activeTouches.Count == 0) // 선택한 개체 재설정 
        {
            selectedObject = null;
        }
    }
}
