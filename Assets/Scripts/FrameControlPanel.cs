using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UniformAcceleration
{
    public class FrameControlPanel : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private Text deltaTimeText;
        [SerializeField]
        private Button startButton;
        [SerializeField]
        private Button resetButton;

        private IEnumerator timer;
        private UnityEvent OnFrameEvent = new UnityEvent();
        private UnityEvent OnStartButton = new UnityEvent();
        private UnityEvent OnResetButton = new UnityEvent();

        private float lasttime;

        void Start()
        {
            lasttime = Time.time;
            StartTimer(slider.value);
            slider.onValueChanged.AddListener(var => 
            {
                deltaTimeText.text = GetDeltaTimeTextFormat(var);
                StartTimer(var);
            });
            startButton.onClick.AddListener(() => OnStartButton.Invoke());
            resetButton.onClick.AddListener(() =>
            {
                ClearFrameEvent();
                OnResetButton.Invoke();
            });
        }

        void StartTimer(float seconds)
        {
            if (timer != null) StopCoroutine(timer);
            timer = CountTime(seconds);
            StartCoroutine(timer);
        }

        IEnumerator CountTime(float seconds)
        {
            while (true)
            {
                OnFrameEvent.Invoke();
                var now = Time.time;
                Debug.Log("WaitTime :" + (now - lasttime));
                lasttime = now;
                yield return new WaitForSeconds(seconds);
            }
        }

        public void SetFrameEvent(UnityAction action)
        {
            OnFrameEvent.AddListener(action);
        }

        public void RemoveFrameEvent(UnityAction action)
        {
            OnFrameEvent.RemoveListener(action);
        }

        public void ClearFrameEvent()
        {
            OnFrameEvent.RemoveAllListeners();
        }

        public void SetStartEvent(UnityAction action)
        {
            OnStartButton.AddListener(action);
        }

        public void SetResetEvent(UnityAction action)
        {
            OnResetButton.AddListener(action);
        }

        private string GetDeltaTimeTextFormat(float seconds)
        {
            return $"delta Time : {seconds:0.00} [s]";
        }

    }
}