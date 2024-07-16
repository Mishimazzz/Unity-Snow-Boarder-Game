using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player") 
        {
            finishEffect.Play();//play 粒子模型
            //sound
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScence",loadDelay); // delay the time of you back the start point once you reach the endline/crush your head
        }
        
    }

    void ReloadScence()
    {
        SceneManager.LoadScene(0);//go back to the start point, since our scene of finshLine is index 0
                                                            //(check on setting->builiding setting, add ot delete the scene to manage)
    }
}
