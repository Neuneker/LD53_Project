using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperManager : MonoBehaviour
{
    private bool hasBeenScored;
    private float stoppedMovingTime;

    public AudioClip throwClip;
    public AudioClip collisionClip;
    public AudioSource audioSource;

    public float velocityForMaxVolume;
    public float throwPower;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = throwPower;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            stoppedMovingTime += Time.deltaTime;
            if (stoppedMovingTime > 1) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        //if (hasBeenScored) return;
        //hasBeenScored = true;
        Destroy(other.gameObject);
        ScoreManager.singleton.AddScore(other.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float volume = Mathf.Clamp01(GetComponent<Rigidbody>().velocity.magnitude / velocityForMaxVolume);
        audioSource.clip = collisionClip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
