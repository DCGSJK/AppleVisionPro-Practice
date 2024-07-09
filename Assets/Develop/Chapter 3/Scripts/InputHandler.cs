using UnityEngine;
using UnityEngine.InputSystem;

namespace Develop.Chapter_3.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject cursorPrefab;
        [SerializeField]
        private Log log;

        private bool _useCursor;
        private GameObject _cursor;
        private VisionOSInputs _visionOSInputs;
        private Camera _mainCamera;

        private void Awake()
        {
            _visionOSInputs = new VisionOSInputs();
            _visionOSInputs.Enable();
            _visionOSInputs.WindowedApp.TouchTap.performed += OnTouchTap;
            _visionOSInputs.WindowedApp.TouchPosition.performed += OnTouchPositionChanged;
            _mainCamera = Camera.main;

            if (cursorPrefab != null)
            {
                _useCursor = true;
                _cursor = Instantiate(cursorPrefab);
                _cursor.SetActive(false);
            }
        }

        private void OnTouchTap(InputAction.CallbackContext context) => log.PrintLine($"Touch tap was executed", "red");

        private void OnTouchPositionChanged(InputAction.CallbackContext context)
        {
            Vector2 touchPosition = context.ReadValue<Vector2>();
            log.PrintLine($"Touch position changed: {touchPosition}", "black");
            if (_useCursor)
            {
                _cursor.SetActive(true);
                _cursor.transform.position = _mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, -_mainCamera.transform.position.z));
            }
        }

        private void OnDestroy()
        {
            _visionOSInputs.WindowedApp.TouchTap.performed -= OnTouchTap;
            _visionOSInputs.WindowedApp.TouchPosition.performed -= OnTouchPositionChanged;
        }
    }
}
