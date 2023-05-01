using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score;
    
    public static ScoreManager singleton;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreboard;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreboardGameOver;

    public UnityEvent<Transform> OnScore;
    public UnityEvent OnStart;

    public bool started = false;
    public float timeSinceStart = 0;

    private void Awake()
    {
        singleton = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started) timeSinceStart += Time.deltaTime;
    }

    public void AddScore(Transform targetThatScored)
    {
        if (!started)
        {
            OnStart?.Invoke();
            started = true;
        }
        _score++;
        _scoreboard.text = _score.ToString();
        _scoreboardGameOver.text = _score.ToString();
        OnScore?.Invoke(targetThatScored);
    }
}
