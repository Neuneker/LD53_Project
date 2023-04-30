using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _timeDilationScale;
    [SerializeField] private float _timeDialationDuration;
    [SerializeField] private float _timeToSlowDown;
    [SerializeField] private float _timeToSpeedUp;

    private Coroutine runningCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        runningCoroutine = StartCoroutine(TimeDilationCoroutine());
    }

    // Update is called once per frame
    IEnumerator TimeDilationCoroutine()
    {
        float deltaTime = 0;
        while (_timeDilationScale != Time.timeScale)
        {
            deltaTime += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(1, _timeDilationScale, deltaTime / _timeToSlowDown);
            SetAudioPitches();
            yield return null;
        }

        yield return new WaitForSeconds(_timeDialationDuration - _timeToSlowDown);

        deltaTime = 0;
        while (1 != Time.timeScale)
        {
            deltaTime += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(_timeDilationScale, 1, deltaTime / _timeToSpeedUp);
            SetAudioPitches();
            yield return null;
        }        
    }
    private void Update()
    {
        Debug.Log(Time.timeScale);
    }
    private void SetAudioPitches()
    {
        foreach (AudioSource audioSource in GameObject.FindObjectsByType<AudioSource>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            audioSource.pitch = Time.timeScale;
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
        foreach (AudioSource audioSource in GameObject.FindObjectsByType<AudioSource>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            audioSource.pitch = Time.timeScale;
        }
        StopAllCoroutines();
    }
}
