using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// what if you cloned another child in audio mixer - that way each child could get their own signal


public class recorder : MonoBehaviour
{

    private AudioSource audioSource;
    private bool hasPlayed = false;
    public bool isRecording = false;
    // Start is called before the first frame update
    void Start()
    {
      audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
      audioSource.loop = false;
      audioSource.clip = Microphone.Start(null, true, 10, 44100);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoSomething()
    {
      Debug.Log("well hello there");
    }

    public void Record()
    {
      Debug.Log("start record");
      audioSource.clip = Microphone.Start(null, false, 10, 44100);
      isRecording = true;
      Debug.Log("recording...");
    }

    public void Stop()
    {
      Debug.Log("stop record");
      Microphone.End(null);
      isRecording = false;
    }

    public void Play()
    {
      Debug.Log("has played " + hasPlayed);
      if (!hasPlayed){
        audioSource.Play();
        hasPlayed = true;
        Debug.Log("playing?");
      }
      else
      {
        hasPlayed = false;
      }
      Debug.Log("has played " + hasPlayed);

    }
}
