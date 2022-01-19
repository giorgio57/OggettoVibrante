using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    public float sensitivity = 100; //Well, it's the sensitivity of the microphone, duh
    public float loudness = 0; //This is what you'll probably want to use as the actual input
    public float loudnessThreshold = 0.5f; //This one is optional, it makes it so that not every sound triggers your input and is easier to use than adjusting sensitivity
    public static MicrophoneInput microphoneInput;
    //private AudioSource audioSource;


    // Use this for initialization
    void Awake()
    {
        if (microphoneInput != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Object.DontDestroyOnLoad(gameObject);
            microphoneInput = this;
        }
    }

    void Start()
    {
        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 10, 44100); //Here we grab the default microphone of the system the game is played on
        GetComponent<AudioSource>().loop = true; // Set the AudioClip to loop
        GetComponent<AudioSource>().mute = true; // Mute the sound, we don't want the player to hear it
        while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the recording has started 
        GetComponent<AudioSource>().Play(); // Play the audio source!
    }

    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
        GetComponent<AudioSource>().mute = false;

    }   

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        GetComponent<AudioSource>().GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;

    }
}