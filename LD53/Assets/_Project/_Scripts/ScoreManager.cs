using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score;
    
    public static ScoreManager singleton;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreboard;

    public UnityEvent<Transform> OnScore;

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
        
    }

    public void AddScore(Transform targetThatScored)
    {
        _score++;
        _scoreboard.text = _score.ToString();
        OnScore?.Invoke(targetThatScored);
    }
}
