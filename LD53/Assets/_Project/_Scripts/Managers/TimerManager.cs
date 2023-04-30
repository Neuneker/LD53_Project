using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{

    [SerializeField] private float _timer;
    [SerializeField] private TMPro.TextMeshProUGUI _timerText;
    [SerializeField] private GameSceneManager _gameSceneManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        _timerText.text = ((int)_timer).ToString();
        if (_timer < 0) _gameSceneManager.ResetLevel();
    }

    public void IncreaseTimer()
    {
        _timer += 2;
    }
}
