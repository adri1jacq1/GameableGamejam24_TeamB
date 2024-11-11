using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSingleton : MonoBehaviour
{
    public static AudioManagerSingleton Instance { get; private set; }
    public AudioSource audioSourceEat, audioSourceshoot; 
    // Start is called before the first frame update
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEatingSound()
    {
        audioSourceEat.Play();
    }
    public void PlayShootSound()
    {
        audioSourceshoot.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
