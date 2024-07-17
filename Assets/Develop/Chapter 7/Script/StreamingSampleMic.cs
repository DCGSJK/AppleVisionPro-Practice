using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Whisper.Utils;

namespace Whisper.Samples
{
    // 이 클래스는 Whisper API를 사용하여 마이크 입력을 실시간으로 스트리밍하고 텍스트로 변환합니다.
    public class StreamingSampleMic : MonoBehaviour
    {
        [Header("Whisper Setup")]
        [SerializeField] private WhisperManager whisper; // WhisperManager 인스턴스
        [SerializeField] private MicrophoneRecord microphoneRecord; // 마이크 입력을 기록하는 MicrophoneRecord 인스턴스

        [Header("UI")]
        [SerializeField] private Button button; // 녹음 시작/중지 버튼
        [SerializeField] private TextMeshProUGUI buttonText; // 버튼 텍스트
        [SerializeField] private TextMeshProUGUI text; // 변환된 텍스트를 표시할 UI 요소
        [SerializeField] private WhisperStream _stream; // WhisperStream 인스턴스

        // Start 메서드는 게임 오브젝트가 활성화될 때 호출됩니다.
        private async void Start()
        {
            // Whisper 스트림을 생성하고 초기화합니다.
            _stream = await whisper.CreateStream(microphoneRecord);
            // 스트림 결과가 업데이트될 때 호출되는 이벤트 핸들러를 추가합니다.
            _stream.OnResultUpdated += OnResult;
            // 녹음이 중지될 때 호출되는 이벤트 핸들러를 추가합니다.
            microphoneRecord.OnRecordStop += OnRecordStop;
            // 버튼 클릭 리스너를 추가합니다.
            button.onClick.AddListener(OnButtonPressed);
        }

        // 버튼이 클릭될 때 호출되는 메서드입니다.
        private void OnButtonPressed()
        {
            if (!microphoneRecord.IsRecording)
            {
                // 녹음이 시작되지 않은 경우 스트림을 시작하고 녹음을 시작합니다.
                _stream.StartStream();
                microphoneRecord.StartRecord();
            }
            else
            {
                // 녹음이 이미 진행 중인 경우 녹음을 중지합니다.
                microphoneRecord.StopRecord();
            }

            // 버튼 텍스트를 업데이트합니다.
            buttonText.text = microphoneRecord.IsRecording ? "Stop" : "Start";
        }

        // 녹음이 중지될 때 호출되는 메서드입니다.
        private void OnRecordStop(AudioChunk recordedAudio) => buttonText.text = "Start";

        // 스트림 결과가 업데이트될 때 호출되는 메서드입니다.
        private void OnResult(string result) => text.text = result;
    }
}
