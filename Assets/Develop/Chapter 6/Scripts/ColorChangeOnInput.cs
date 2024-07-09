using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.PolySpatial.InputDevices;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using UnityEngine.InputSystem.LowLevel;

public class ColorChangeOnInput : MonoBehaviour
{
    void OnEnable()
    {
        EnhancedTouchSupport.Enable();   
    }
    void Update()
    {
        if (Touch.activeTouches.Count > 0) // 활성화된 터치가 있는지 확인
        {
            foreach (var touch in Touch.activeTouches)
            {
                Debug.Log($"Touch detected: {touch.phase} at position {touch.screenPosition}");
                if (touch.phase == TouchPhase.Began) // 터치가 되었는지 확인 
                {
                    SpatialPointerState touchData = EnhancedSpatialPointerSupport.GetPointerState(touch);// 터치 공간 포인터 상태 가져옴 
                    if (touchData.targetObject != null && touchData.Kind != SpatialPointerKind.Touch)
                    {
                        Debug.Log($"Hit object");
                        ChangeObjectColor(touchData.targetObject); // 터치가 된 객체 색상 변경 
                        break;
                    }
                }
            }
        }
    }

    void ChangeObjectColor(GameObject obj) // 객체 색상 변경 메서드 
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        if (objRenderer != null) // null이 아닌 경우 색상 변경 
        {
            objRenderer.material.color = new Color(Random.value, Random.value, Random.value); // 객체 색상 무작위 변경 
        }
    }
}
