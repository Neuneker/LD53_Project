using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{

    [SerializeField] private float _timer;
    [SerializeField] private TMPro.TextMeshProUGUI _timerText;
    [SerializeField] private GameSceneManager _gameSceneManager;

    public UnityEvent OnGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ScoreManager.singleton.started) return;
        _timer -= Time.deltaTime;
        _timerText.text = ((int)_timer).ToString();
        if (_timer < 0)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            OnGameOver?.Invoke();
        }
    }

    public void IncreaseTimer()
    {
        _timer += 2;
    }
}
