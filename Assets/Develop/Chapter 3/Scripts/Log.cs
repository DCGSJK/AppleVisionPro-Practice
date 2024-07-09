using System;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Develop.Chapter_3.Scripts
{
    // Log 클래스는 텍스트 로그를 출력하고 관리하는 기능을 제공합니다.
    public class Log : MonoBehaviour
    {
        // 로그를 출력할 TMP_Text 컴포넌트
        private TMP_Text _log;
        // 최대 출력 라인 수
        [SerializeField]
        private int maxLine = 15;

        // 스크립트가 처음 로드될 때 호출되는 메서드
        private void Awake()
        {
            // TMP_Text 컴포넌트를 가져옵니다.
            _log = GetComponent<TMP_Text>();
        }

        // 스크립트가 시작될 때 호출되는 메서드
        private void Start()
        {
            // 로그 텍스트를 초기화합니다.
            _log.text = string.Empty;
        }

        // 로그 메시지를 출력하는 메서드
        public void PrintLine(string msg, string color)
        {
            // 로그의 라인 수가 최대 라인 수를 초과하면 로그를 초기화합니다.
            if (_log.text.Split('\n').Count() > maxLine)
            {
                _log.text = string.Empty;
            }

            // 로그에 새로운 메시지를 추가합니다.
            _log.text += "<color=" + color + $">{DateTime.Now:HH:MM:ss.FFF} {msg}</color>\n";
        }
    }
}