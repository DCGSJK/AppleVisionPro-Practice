using System;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Develop.Chapter_3.Scripts
{
    public class Log : MonoBehaviour
    {
        private TMP_Text _log;
        [SerializeField]
        private int maxLine = 15;

        private void Awake()
        {
            _log = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _log.text = string.Empty;
        }

        public void PrintLine(string msg, string color)
        {
            if (_log.text.Split('\n').Count() > maxLine)
            {
                _log.text = string.Empty;
            }

            _log.text += "<color=" + color + $">{DateTime.Now:HH:MM:ss.FFF} {msg}</color>\n";
        }
    }
}
