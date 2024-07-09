using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Develop.Chapter_4.Scripts
{
    // Logger 클래스는 로그 메시지를 화면에 표시하기 위한 싱글톤 클래스입니다.
    public class Logger : MonoBehaviour
    {
        // 싱글톤 인스턴스를 저장하기 위한 정적 변수
        private static Logger _instance;

        // 싱글톤 인스턴스를 가져오기 위한 프로퍼티
        public static Logger instance
        {
            get
            {
                // 인스턴스가 null인 경우, 씬에서 Logger 오브젝트를 찾습니다.
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Logger>();

                    // Logger 오브젝트를 찾지 못한 경우, 새로 생성합니다.
                    if (_instance == null)
                    {
                        GameObject loggerObject = new GameObject("Logger");
                        _instance = loggerObject.AddComponent<Logger>();
                    }
                }

                return _instance;
            }
        }

        // 로그를 표시할 TextMeshProUGUI 컴포넌트
        [SerializeField] private TextMeshProUGUI debugAreaText;
        // 디버그 기능을 활성화할지 여부
        [SerializeField] private bool enableDebug;
        // 최대 표시할 로그 라인 수
        [SerializeField] private int maxLines = 15;

        // Logger 컨테이너의 Transform
        private Transform _loggerContainer;
        // 디버그 표시를 토글할 버튼
        private Button _toggleButton;
        // 디버그 표시의 가시성 여부
        private bool _isVisible = true;

        // 스크립트가 처음 로드될 때 호출되는 메서드
        private void Awake()
        {
            // 인스턴스가 null인 경우, 현재 인스턴스로 설정하고 파괴되지 않도록 합니다.
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                // 이미 인스턴스가 존재하는 경우, 새로운 오브젝트를 파괴합니다.
                Destroy(gameObject);
            }

            // debugAreaText가 설정되지 않은 경우, 컴포넌트를 가져옵니다.
            if (debugAreaText == null)
            {
                debugAreaText = GetComponent<TextMeshProUGUI>();
            }
            // 텍스트 초기화
            debugAreaText.text = string.Empty;
        }

        // 스크립트가 활성화될 때 호출되는 메서드
        private void OnEnable()
        {
            // 디버그 텍스트 컴포넌트와 스크립트 활성화 여부 설정
            debugAreaText.enabled = enableDebug;
            enabled = enableDebug;

            // 활성화된 경우, 활성화 로그를 추가합니다.
            if (enabled)
            {
                debugAreaText.text +=
                    $"<color=\"white\">{DateTime.Now.ToString("HH:mm:ss.fff")} {this.GetType().Name} enabled</color>\n";
            }
        }

        // 로그 텍스트를 지우는 메서드
        public void Clear() => debugAreaText.text = string.Empty;

        // 정보 로그를 추가하는 메서드
        public void LogInfo(string message)
        {
            ClearLines(); // 기존 라인을 지우는 메서드 호출
            debugAreaText.text +=
                $"<color=\"green\">{DateTime.Now:HH:mm:ss.fff} {message}</color>\n"; // 로그 메시지 추가
        }

        // 에러 로그를 추가하는 메서드
        public void LogError(string message)
        {
            ClearLines(); // 기존 라인을 지우는 메서드 호출
            debugAreaText.text +=
                $"<color=\"red\">{DateTime.Now:HH:mm:ss.fff} {message}</color>\n"; // 로그 메시지 추가
        }

        // 경고 로그를 추가하는 메서드
        public void LogWarning(string message)
        {
            ClearLines(); // 기존 라인을 지우는 메서드 호출
            debugAreaText.text +=
                $"<color=\"white\">{DateTime.Now:HH:mm:ss.fff} {message}</color>\n"; // 로그 메시지 추가
        }

        // 최대 라인을 초과한 경우 로그를 지우는 메서드
        private void ClearLines()
        {
            // 현재 텍스트의 라인 수가 maxLines를 초과한 경우, 텍스트를 초기화합니다.
            if (debugAreaText.text.Split('\n').Count() >= maxLines)
            {
                debugAreaText.text = string.Empty;
            }
        }
    }
}
