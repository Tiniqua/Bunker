using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{
    public GameObject bossHealthUI;
    public bool PlayBM = false;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Debug.Log("entered");
            bossHealthUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            audioData = GetComponent<AudioSource>();
            audioData.Pause();
            Debug.Log("exit");
        }
        
    }
}
