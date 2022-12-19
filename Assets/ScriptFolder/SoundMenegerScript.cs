using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenegerScript : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.volume = 0.0005f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
