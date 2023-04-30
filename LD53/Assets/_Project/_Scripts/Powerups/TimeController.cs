using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _timeDilation;
    [SerializeField] private float _timeDialationInSeconds;

    private Coroutine runningCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = _timeDilation;
        foreach(AudioSource audioSource in GameObject.FindObjectsByType<AudioSource>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            audioSource.pitch = Time.timeScale;
        }
        runningCoroutine = StartCoroutine(TimeDilationCoroutine());
    }

    // Update is called once per frame
    IEnumerator TimeDilationCoroutine()
    {
        yield return new WaitForSeconds(_timeDialationInSeconds);
        Time.timeScale = 1;
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
