using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using AndroidAudioBypass;

public class Rec_SoundDataReceiver : MonoBehaviour
{
    public BypassAudioSource native_source;
    AudioSource source;
    public Record record;
    bool Dampen;
    float step_dampfade = 0.30f;
    float threshold;
    float AttackThreshold;
    public AudioClip[] PlayArray = new AudioClip[32];
    public float LoopPitch;
    public int LoopInst;
    int instrument_select;

    private void Start()
    {
      
        var config = AudioSettings.GetConfiguration();
        config.dspBufferSize = 4096;
        
        source = gameObject.GetComponent<AudioSource>();
    }
    public void InstSelect(int n)
    {
        if(n == 0)
        {
            PlayArray = record.Marimba_Array;
        }
        else if(n == 1)
        {
            PlayArray = record.Vibro_Array;
        }
        else if(n == 2)
        {
            PlayArray = record.Xylo_Array;
        }
        LoopInst = n;
    }
    public void Set_PitchOctave(float rate)
    {
        source.pitch = rate;
        LoopPitch = rate;
    }
    public void Play(int clip)
    {
        source.PlayOneShot(PlayArray[clip]);
        // source.clip = Marimba_Array[clip];
        //native_source.Play(clip);
        // source.PlayScheduled(AudioSettings.dspTime);

    }
    IEnumerator DampNote()
    {
        //
        yield return null;
    }
    public void LoopDamper(bool d)
    {
        if(d)
        {

            Dampen = true;
        }
        else if(!d)
        {
            Dampen = false;

        }
    }

}
