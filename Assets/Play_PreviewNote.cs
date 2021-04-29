using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AndroidAudioBypass;

public class Play_PreviewNote : MonoBehaviour
{

    public BypassAudioSource audi;
    public void play_Note()
    {
        audi.Play(4);
      
        
    }

}
