using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//人物的interpolate（在unity）可消除人物移动时的抖抖性，be more stable
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] AudioClip crashSFX;
    bool occurOneSound = true;

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Gound") 
        {
            FindObjectOfType<PlayerController>().DisableControls();
            Invoke("ReloadScence",loadDelay);
            CrashEffect.Play();
            //sound
            if (occurOneSound)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                occurOneSound = false;
            }
        }
    }

    void ReloadScence()
    {
        SceneManager.LoadScene(0);
    }
}
