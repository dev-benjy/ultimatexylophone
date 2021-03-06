using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AndroidAudioBypass;
using MoreMountains.NiceVibrations;
using TMPro;

public class M_Manager : MonoBehaviour
{
    public bool PentatonicMode = false;
    public bool SharpMode = false;
    public bool[] tempRegLog = new bool[32]; 
    public enum LocalizedVibrationType { Heavy, Light, Off };
    LocalizedVibrationType SetLocalVibrationType;
    public static M_Manager manager;
    public GameObject[] All_keys;
    public RectTransform[] All_keys_location;
    public RectTransform[] Change_Keyloc;
    public Animator[] ani;
    public SpriteRenderer[] Sprit;
    public note_labeller[] note;
    public bool[] key_played;
    public bool[] sound_ok;
    public AudioClip[] clips;
    BypassAudioSource audio_source;
  
    Camera camera;
    bool audio_available;
    public Touch touch;
    public Touch rest;
    bool switchtouch;
    int touchcount;

    public bool Mute = false;
    public GameObject sharpsUI;
    public Record record;
    [HideInInspector]
    public int natural_keys;
    

    void Awake()
    {
        for (int i = 0; i < All_keys.Length; i++)
        {
            ani[i] = All_keys[i].GetComponentInChildren<Animator>();
            Sprit[i] = All_keys[i].GetComponentInChildren<SpriteRenderer>();
            sound_ok[i] = true;
            key_played[i] = false;
        }

        if (key_played.Length != All_keys.Length)
        {
            Debug.LogError("number of keys are mismatched!");
        }
        natural_keys = 19;
        Assign(0);
        audio_source = GetComponent<BypassAudioSource>();
        camera = Camera.main;
        for (int i = 0; i < natural_keys; i++)
        {
            note[i] = All_keys[i].GetComponentInChildren<note_labeller>();
        }
        if(PlayerPrefs.HasKey("pentatonic"))
        {
            if(PlayerPrefs.GetInt("pentatonic") == 0)
            {
                Pentatonic_Mode(true);
            }
            else if (PlayerPrefs.GetInt("pentatonic") == 1)
            {
                Pentatonic_Mode(false);
            }
        }
    }
    public void Assign(int mode)
    {
        if(mode == 0)// all natural keys
        {
            for (int i = 0; i < 19; i++)
            {
                All_keys_location[i] = All_keys[i].GetComponent<RectTransform>();
            }
        }
        else if(mode == 1)// all sharps
        {
            for (int i = 19; i < 32; i++)
            {
                All_keys_location[i] = All_keys[i].GetComponent<RectTransform>();
            }
        }
        else if(mode == 2)// all pentatonic
        {
            All_keys_location[0] = All_keys[0].GetComponent<RectTransform>();
            All_keys_location[3] = All_keys[3].GetComponent<RectTransform>();
            All_keys_location[7] = All_keys[7].GetComponent<RectTransform>();
            All_keys_location[10] = All_keys[10].GetComponent<RectTransform>();
            All_keys_location[14] = All_keys[14].GetComponent<RectTransform>();
            All_keys_location[17] = All_keys[17].GetComponent<RectTransform>();
        }
      
    }
    
    private void Update()
    {
        
        touchcount = Input.touchCount;
       
        if(!Mute)
        {
            for (int i = 0; i < touchcount; i++)
            {

                touch = Input.GetTouch(i);

                ChkRec(0);
               
                ChkRec(1);
                ChkRec(2);
                ChkRec(3);
                ChkRec(4);
                ChkRec(5);
                ChkRec(6);
                ChkRec(7);
                ChkRec(8);
                ChkRec(9);
                ChkRec(10);
                ChkRec(11);
                ChkRec(12);
                ChkRec(13);
                ChkRec(14);
                ChkRec(15);
                ChkRec(16);
                ChkRec(17);
                ChkRec(18);
                ChkRec(19);
                ChkRec(20);
                ChkRec(21);
                ChkRec(22);
                ChkRec(23);
                ChkRec(24);
                ChkRec(25);
                ChkRec(26);
                ChkRec(27);
                ChkRec(28);
                ChkRec(29);
                ChkRec(30);
                ChkRec(31);
               // audio_source.tt.text = "";

                if (touch.phase == TouchPhase.Began)
                {
                    //record.KeyDataReceiver()();
                 
                    Keys();                 
                    audio_available = true;
                }
               
            }
           
            if (touch.phase == TouchPhase.Ended)
            {
                for (int b = 0; b < key_played.Length; b++)
                {
                    ani[b].SetBool("isplayed", false);
                }
            }


        }
        else { return;}
    }
    public void ChkRec(int n)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(All_keys_location[n], touch.position, camera))
        {
            key_played[n] = true;
        }
        else { key_played[n] = false; }
    }

    private void LateUpdate()
    {
        if (touch.phase == TouchPhase.Moved)
        {
            if (audio_available)
            {
                Prevent_Repeat_On_Began();

                audio_available = false;
            }
            Keys_Move();
        }

    }
   
   // public double recMark;
    public void Keys()
    {
    
        if (key_played[0])
        {
            audio_source.Play(0); //tempRegLog[0] = true;
             HapticCall();
            ani[0].SetBool("isplayed", key_played[0]);
        }
        if (key_played[1])
        {
            audio_source.Play(1); //tempRegLog[1] = true;
            HapticCall();
            ani[1].SetBool("isplayed", key_played[1]);
        }
        if (key_played[2])
        {
            audio_source.Play(2); //tempRegLog[2] = true;
            HapticCall();
            ani[2].SetBool("isplayed", key_played[2]);
        }
        if (key_played[3])
        {
            audio_source.Play(3); //tempRegLog[3] = true;
            HapticCall();
            ani[3].SetBool("isplayed", key_played[3]);
        }
        if (key_played[4])
        {
            audio_source.Play(4); //tempRegLog[4] = true;
            HapticCall();
            ani[4].SetBool("isplayed", key_played[4]);
        }
        if (key_played[5])
        {
            audio_source.Play(5); //tempRegLog[5] = true;
            HapticCall();
            ani[5].SetBool("isplayed", key_played[5]);
        }
        if (key_played[6])
        {
            audio_source.Play(6);  //tempRegLog[6] = true;
            HapticCall();
            ani[6].SetBool("isplayed", key_played[6]);
        }
        if (key_played[7])
        {
            audio_source.Play(7);  //tempRegLog[7] = true;
            HapticCall();
            ani[7].SetBool("isplayed", key_played[7]);
        }
        if (key_played[8])
        {
            audio_source.Play(8); //tempRegLog[8] = true;
            HapticCall();
            ani[8].SetBool("isplayed", key_played[8]);
        }
        if (key_played[9])
        {
            audio_source.Play(9);  //tempRegLog[9] = true;
            HapticCall();
            ani[9].SetBool("isplayed", key_played[9]);
        }
        if (key_played[10])
        {
            audio_source.Play(10);  //tempRegLog[10] = true;
            HapticCall();
            ani[10].SetBool("isplayed", key_played[10]);
        }
        if (key_played[11])
        {
            audio_source.Play(11);  //tempRegLog[11] = true;
            HapticCall();
            ani[11].SetBool("isplayed", key_played[11]);
        }
        if (key_played[12])
        {
            audio_source.Play(12);  //tempRegLog[12] = true;
            HapticCall();
            ani[12].SetBool("isplayed", key_played[12]);
        }
        if (key_played[13])
        {
            audio_source.Play(13);  //tempRegLog[13] = true;
            HapticCall();
            ani[13].SetBool("isplayed", key_played[13]);
        }
        if (key_played[14])
        {
            audio_source.Play(14);  //tempRegLog[14] = true;
            HapticCall();
            ani[14].SetBool("isplayed", key_played[14]);
        }
        if (key_played[15])
        {
            audio_source.Play(15);  //tempRegLog[15] = true;
            HapticCall();
            ani[15].SetBool("isplayed", key_played[15]);
        }
        if (key_played[16])
        {
            audio_source.Play(16);  //tempRegLog[16] = true;
            HapticCall();
            ani[16].SetBool("isplayed", key_played[16]);
        }
        if (key_played[17])
        {
            audio_source.Play(17);  //tempRegLog[17] = true;
            HapticCall();
            ani[17].SetBool("isplayed", key_played[17]);
        }
        if (key_played[18])
        {
            audio_source.Play(18);  //tempRegLog[18] = true;
            HapticCall();
            ani[18].SetBool("isplayed", key_played[18]);
        }
        if (key_played[19])
        {
            audio_source.Play(19);  //tempRegLog[19] = true;
            HapticCall();
            ani[19].SetBool("isplayed", key_played[19]);
        }
        if (key_played[20])
        {
            audio_source.Play(20);  //tempRegLog[20] = true;
            HapticCall();
            ani[20].SetBool("isplayed", key_played[20]);
        }
        if (key_played[21])
        {
            audio_source.Play(21);  //tempRegLog[21] = true;
            HapticCall();
            ani[21].SetBool("isplayed", key_played[21]);
        }
        if (key_played[22])
        {
            audio_source.Play(22);  //tempRegLog[22] = true;
            HapticCall();
            ani[22].SetBool("isplayed", key_played[22]);
        }
        if (key_played[23])
        {
            audio_source.Play(23);  //tempRegLog[23] = true;
            HapticCall();
            ani[23].SetBool("isplayed", key_played[23]);
        }
        if (key_played[24])
        {
            audio_source.Play(24);  //tempRegLog[24] = true;
            HapticCall();
            ani[24].SetBool("isplayed", key_played[24]);
        }
        if (key_played[25])
        {
            audio_source.Play(25);  //tempRegLog[25] = true;
            HapticCall();
            ani[25].SetBool("isplayed", key_played[25]);
        }
        if (key_played[26])
        {
            audio_source.Play(26);  //tempRegLog[26] = true;
            HapticCall();
            ani[26].SetBool("isplayed", key_played[26]);
        }
        if (key_played[27])
        {
            audio_source.Play(27);  //tempRegLog[27] = true;
            HapticCall();
            ani[27].SetBool("isplayed", key_played[27]);
        }
        if (key_played[28])
        {
            audio_source.Play(28);  //tempRegLog[28] = true;
            HapticCall();
            ani[28].SetBool("isplayed", key_played[28]);
        }
        if (key_played[29])
        {
            audio_source.Play(29);  //tempRegLog[29] = true;
            HapticCall();
            ani[29].SetBool("isplayed", key_played[29]);
        }
        if (key_played[30])
        {
            audio_source.Play(30);  //tempRegLog[30] = true;
            HapticCall();
            ani[30].SetBool("isplayed", key_played[30]);
        }
        if (key_played[31])
        {
            audio_source.Play(31);  //tempRegLog[31] = true;
            HapticCall();
            ani[31].SetBool("isplayed", key_played[31]);
        }

        if(record.Recording)
        {
            record.KeyDataReceiver();
        }
    }  
    void Keys_Move()
    {
        
        if (key_played[0] && sound_ok[0])
        {
            audio_source.Play(0);
            record.KeyDataReceiver(); //tempRegLog[0] = true; 
            Reset_Sound_Ok();
            HapticCall();
            ani[0].SetBool("isplayed", true);
            sound_ok[0] = false;

        }
        if (key_played[1] && sound_ok[1])
        {
            audio_source.Play(1);
            record.KeyDataReceiver(); //tempRegLog[1] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[1].SetBool("isplayed", true);
            sound_ok[1] = false;
        }
        if (key_played[2] && sound_ok[2])
        {
            audio_source.Play(2);
            record.KeyDataReceiver(); //tempRegLog[2] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[2].SetBool("isplayed", true);
            sound_ok[2] = false;
        }
        if (key_played[3] && sound_ok[3])
        {
            audio_source.Play(3);
            record.KeyDataReceiver(); //tempRegLog[3] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[3].SetBool("isplayed", true);
            sound_ok[3] = false;
        }
        if (key_played[4] && sound_ok[4])
        {
            audio_source.Play(4);
            record.KeyDataReceiver(); //tempRegLog[4] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[4].SetBool("isplayed", true);
            sound_ok[4] = false;
        }
        if (key_played[5] && sound_ok[5])
        {
            audio_source.Play(5);
            record.KeyDataReceiver(); //tempRegLog[5] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[5].SetBool("isplayed", true);
            sound_ok[5] = false;
        }
        if (key_played[6] && sound_ok[6])
        {
            audio_source.Play(6);
            record.KeyDataReceiver(); //tempRegLog[6] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[6].SetBool("isplayed", true);
            sound_ok[6] = false;
        }
        if (key_played[7] && sound_ok[7])
        {
            audio_source.Play(7);
            record.KeyDataReceiver(); //tempRegLog[7] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[7].SetBool("isplayed", true);
            sound_ok[7] = false;
        }
        if (key_played[8] && sound_ok[8])
        {
            audio_source.Play(8);
            record.KeyDataReceiver(); //tempRegLog[8] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[8].SetBool("isplayed", true);
            sound_ok[8] = false;

        }
        if (key_played[9] && sound_ok[9])
        {
            audio_source.Play(9);
            record.KeyDataReceiver(); //tempRegLog[9] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[9].SetBool("isplayed", true);
            sound_ok[9] = false;
        }
        if (key_played[10] && sound_ok[10])
        {
            audio_source.Play(10);
            record.KeyDataReceiver(); //tempRegLog[10] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[10].SetBool("isplayed", true);
            sound_ok[10] = false;
        }
        if (key_played[11] && sound_ok[11])
        {
            audio_source.Play(11);
            record.KeyDataReceiver(); //tempRegLog[11] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[11].SetBool("isplayed", true);
            sound_ok[11] = false;
        }
        if (key_played[12] && sound_ok[12])
        {
            audio_source.Play(12);
            record.KeyDataReceiver(); //tempRegLog[12] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[12].SetBool("isplayed", true);
            sound_ok[12] = false;
        }
        if (key_played[13] && sound_ok[13])
        {
            audio_source.Play(13);
            record.KeyDataReceiver(); //tempRegLog[13] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[13].SetBool("isplayed", true);
            sound_ok[13] = false;
        }
        if (key_played[14] && sound_ok[14])
        {
            audio_source.Play(14);
            record.KeyDataReceiver(); //tempRegLog[14] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[14].SetBool("isplayed", true);
            sound_ok[14] = false;
        }
        if (key_played[15] && sound_ok[15])
        {
            audio_source.Play(15);
            record.KeyDataReceiver(); //tempRegLog[15] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[15].SetBool("isplayed", true);
            sound_ok[15] = false;
        }
        if (key_played[16] && sound_ok[16])
        {
            audio_source.Play(16);
            record.KeyDataReceiver(); //tempRegLog[16] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[16].SetBool("isplayed", true);
            sound_ok[16] = false;
        }
        if (key_played[17] && sound_ok[17])
        {
            audio_source.Play(17);
            record.KeyDataReceiver(); //tempRegLog[17] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[17].SetBool("isplayed", true);
            sound_ok[17] = false;
        }
        if (key_played[18] && sound_ok[18])
        {
            audio_source.Play(18);
            record.KeyDataReceiver(); //tempRegLog[18] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[18].SetBool("isplayed", true);
            sound_ok[18] = false;
        }
        if (key_played[19] && sound_ok[19])
        {
            audio_source.Play(19);
            record.KeyDataReceiver(); //tempRegLog[19] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[19].SetBool("isplayed", true);
            sound_ok[19] = false;
        }
        if (key_played[20] && sound_ok[20])
        {
            audio_source.Play(20);
            record.KeyDataReceiver(); //tempRegLog[20] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[20].SetBool("isplayed", true);
            sound_ok[20] = false;
        }
        if (key_played[21] && sound_ok[21])
        {
            audio_source.Play(21);
            record.KeyDataReceiver(); //tempRegLog[21] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[21].SetBool("isplayed", true);
            sound_ok[21] = false;
        }
        if (key_played[22] && sound_ok[22])
        {
            audio_source.Play(22);
            record.KeyDataReceiver(); //tempRegLog[22] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[22].SetBool("isplayed", true);
            sound_ok[22] = false;
        }
        if (key_played[23] && sound_ok[23])
        {
            audio_source.Play(23);
            record.KeyDataReceiver(); //tempRegLog[23] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[23].SetBool("isplayed", true);
            sound_ok[23] = false;
        }
        if (key_played[24] && sound_ok[24])
        {
            audio_source.Play(24);
            record.KeyDataReceiver(); //tempRegLog[24] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[24].SetBool("isplayed", true);
            sound_ok[24] = false;
        }
        if (key_played[25] && sound_ok[25])
        {
            audio_source.Play(25);
            record.KeyDataReceiver(); //tempRegLog[25] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[25].SetBool("isplayed", true);
            sound_ok[25] = false;
        }
        if (key_played[26] && sound_ok[26])
        {
            audio_source.Play(26);
            record.KeyDataReceiver(); //tempRegLog[26] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[26].SetBool("isplayed", true);
            sound_ok[26] = false;
        }
        if (key_played[27] && sound_ok[27])
        {
            audio_source.Play(27);
            record.KeyDataReceiver(); //tempRegLog[27] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[27].SetBool("isplayed", true);
            sound_ok[27] = false;
        }
        if (key_played[28] && sound_ok[28])
        {
            audio_source.Play(28);
            record.KeyDataReceiver(); //tempRegLog[28] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[28].SetBool("isplayed", true);
            sound_ok[28] = false;
        }
        if (key_played[29] && sound_ok[29])
        {
            audio_source.Play(29);
            record.KeyDataReceiver(); //tempRegLog[29] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[29].SetBool("isplayed", true);
            sound_ok[29] = false;
        }
        if (key_played[30] && sound_ok[30])
        {
            audio_source.Play(30);
            record.KeyDataReceiver(); //tempRegLog[30] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[30].SetBool("isplayed", true);
            sound_ok[30] = false;
        }
        if (key_played[31] && sound_ok[31])
        {
            audio_source.Play(31);
            record.KeyDataReceiver(); //tempRegLog[31] = true;
            Reset_Sound_Ok();
            HapticCall();
            ani[31].SetBool("isplayed", true);
            sound_ok[31] = false;
        }
        ////tempRegLog = //tempRegLog;
    }
    void Reset_Sound_Ok()
    {
        
        if (!key_played[0])
        {
            sound_ok[0] = true;
        }
        if (!key_played[1])
        {
            sound_ok[1] = true;
        }
        if (!key_played[2] )
        {
            sound_ok[2] = true;
        }
        if (!key_played[3]  )
        {
            sound_ok[3] = true;
        }
        if (!key_played[4]  )
        {
            sound_ok[4] = true;
        }
        if (!key_played[5]  )
        {
            sound_ok[5] = true;
        }
        if (!key_played[6]  )
        {
            sound_ok[6] = true;
        }
        if (!key_played[7]  )
        {
            sound_ok[7] = true;
        }
        if (!key_played[8]  )
        {
            sound_ok[8] = true;
        }
        if (!key_played[9]  )
        {
            sound_ok[9] = true;
        }
        if (!key_played[9]  )
        {
            sound_ok[9] = true;
        }
        if (!key_played[10]  )
        {
            sound_ok[10] = true;
        }
        if (!key_played[11]  )
        {
            sound_ok[11] = true;
        }
        if (!key_played[12]  )
        {
            sound_ok[12] = true;
        }
        if (!key_played[13]  )
        {
            sound_ok[13] = true;
        }
        if (!key_played[14])
        {
            sound_ok[14] = true;
        }
        if (!key_played[15])
        {
            sound_ok[15] = true;
        }
        if (!key_played[16])
        {
            sound_ok[16] = true;
        }
        if (!key_played[17])
        {
            sound_ok[17] = true;
        }
        if (!key_played[18])
        {
            sound_ok[18] = true;
        }
        if (!key_played[19])
        {
            sound_ok[19] = true;
        }
        if (!key_played[20])
        {
            sound_ok[20] = true;
        }
        if (!key_played[21])
        {
            sound_ok[21] = true;
        }
        if (!key_played[22])
        {
            sound_ok[22] = true;
        }
        if (!key_played[23])
        {
            sound_ok[23] = true;
        }
        if (!key_played[24])
        {
            sound_ok[24] = true;
        }
        if (!key_played[25])
        {
            sound_ok[25] = true;
        }
        if (!key_played[26])
        {
            sound_ok[26] = true;
        }
        if (!key_played[27])
        {
            sound_ok[27] = true;
        }
        if (!key_played[28])
        {
            sound_ok[28] = true;
        }
        if (!key_played[29])
        {
            sound_ok[29] = true;
        }
        if (!key_played[30])
        {
            sound_ok[30] = true;
        }
        if (!key_played[31])
        {
            sound_ok[31] = true;
        }
        for (int b = 0; b < key_played.Length; b++)
        {
            ani[b].SetBool("isplayed", false);
        }
    }
    void Prevent_Repeat_On_Began()
    {
        if (key_played[0])
        {
            sound_ok[0] = false;
        }

        if (key_played[1])
        {
            sound_ok[1] = false;
        }

        if (key_played[2])
        {
            sound_ok[2] = false;
        }

        if (key_played[3])
        {
            sound_ok[3] = false;
        }

        if (key_played[4])
        {
            sound_ok[4] = false;
        }

        if (key_played[5])
        {
            sound_ok[5] = false;
        }

        if (key_played[6])
        {
            sound_ok[6] = false;
        }

        if (key_played[7])
        {
            sound_ok[7] = false;
        }

        if (key_played[8])
        {
            sound_ok[8] = false;
        }

        if (key_played[9])
        {
            sound_ok[9] = false;
        }

        if (key_played[10])
        {
            sound_ok[10] = false;
        }

        if (key_played[11])
        {
            sound_ok[11] = false;
        }

        if (key_played[12])
        {
            sound_ok[12] = false;
            //Keys_Move();
        }

        if (key_played[13])
        {
            sound_ok[13] = false;
           // Keys_Move();
        }
        if (key_played[14])
        {
            sound_ok[14] = false;
            // Keys_Move();
        }
        if (key_played[15])
        {
            sound_ok[15] = false;
            // Keys_Move();
        }
        if (key_played[16])
        {
            sound_ok[16] = false;
            // Keys_Move();
        }
        if (key_played[17])
        {
            sound_ok[17] = false;
            // Keys_Move();
        }
        if (key_played[18])
        {
            sound_ok[18] = false;
            // Keys_Move();
        }
        if (key_played[19])
        {
            sound_ok[19] = false;
            // Keys_Move();
        }
        if (key_played[20])
        {
            sound_ok[20] = false;
            // Keys_Move();
        }
        if (key_played[21])
        {
            sound_ok[21] = false;
            // Keys_Move();
        }
        if (key_played[22])
        {
            sound_ok[22] = false;
            // Keys_Move();
        }
        if (key_played[23])
        {
            sound_ok[23] = false;
            // Keys_Move();
        }
        if (key_played[24])
        {
            sound_ok[24] = false;
            // Keys_Move();
        }
        if (key_played[25])
        {
            sound_ok[25] = false;
            // Keys_Move();
        }
        if (key_played[26])
        {
            sound_ok[26] = false;
            // Keys_Move();
        }
        if (key_played[27])
        {
            sound_ok[27] = false;
            // Keys_Move();
        }
        if (key_played[28])
        {
            sound_ok[28] = false;
            // Keys_Move();
        }
        if (key_played[29])
        {
            sound_ok[29] = false;
            // Keys_Move();
        }
        if (key_played[30])
        {
            sound_ok[30] = false;
            // Keys_Move();
        }
        if (key_played[31])
        {
            sound_ok[31] = false;
            // Keys_Move();
        }
        ////tempRegLog = //tempRegLog;
    }
    public void PointerDownChangeRect(bool active)
    {
        if (active && SharpMode)
        {

            All_keys_location[10] = Change_Keyloc[1];
            All_keys_location[11] = Change_Keyloc[2];
            All_keys_location[12] = Change_Keyloc[3];
            All_keys_location[13] = Change_Keyloc[4];
            All_keys_location[14] = Change_Keyloc[5];
            All_keys_location[15] = Change_Keyloc[6];


        }
        else if(!active)
        {                    
            All_keys_location[11] = All_keys[11].GetComponent<RectTransform>();
            All_keys_location[12] = All_keys[12].GetComponent<RectTransform>();
            All_keys_location[13] = All_keys[13].GetComponent<RectTransform>();
            All_keys_location[14] = All_keys[14].GetComponent<RectTransform>();
            All_keys_location[15] = All_keys[15].GetComponent<RectTransform>();
            All_keys_location[16] = All_keys[16].GetComponent<RectTransform>();
        }
        Debug.Log(active + "RECT IS CHANGED");
    }
    public void WebViewRectChange(bool active)
    {
        if(active)
        {
            All_keys_location[4] = Change_Keyloc[0];
        }
        else if(!active)
        {
            All_keys_location[4] = All_keys[4].GetComponent<RectTransform>();
        }
    }
    public void MuteBox(bool yes)
    {
        Mute = yes;
    }
    public void Pentatonic_Mode(bool mode)
    {
        Sprit[0].enabled = mode;
        Sprit[3].enabled = mode;
        Sprit[7].enabled = mode;
        Sprit[10].enabled = mode;
        Sprit[14].enabled = mode;
        Sprit[17].enabled = mode;
        note[0].gameObject.SetActive(mode);
        note[3].gameObject.SetActive(mode);
        note[7].gameObject.SetActive(mode);
        note[10].gameObject.SetActive(mode);
        note[14].gameObject.SetActive(mode);
        note[17].gameObject.SetActive(mode);
        if (mode)
        {
            PentatonicMode = false;
            Assign(2);
            PlayerPrefs.SetInt("pentatonic", 0);
        }
        else if(!mode)
        {
            All_keys_location[0] = null;
            All_keys_location[3] = null;
            All_keys_location[7] = null;
            All_keys_location[10] = null;
            All_keys_location[14] = null;
            All_keys_location[17] = null;
            PentatonicMode = true;
            PlayerPrefs.SetInt("pentatonic", 1);
        }
    }
    public void Sharp_Unsharp(bool mode)
    {
        for (int i = 19; i < 32; i++)
        {
            Sprit[i].enabled = mode;
        }
        sharpsUI.SetActive(mode);
        if(mode)
        {
            SharpMode = true;
            Assign(1);
        }
        else if(!mode)
        {
            SharpMode = false;
            for (int i = 19; i < 32; i++)
            {
                All_keys_location[i] = null;
            }
        }
    }

    void Vib(LocalizedVibrationType type)
    {
        if(type == LocalizedVibrationType.Heavy)
        {
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
        }
        else if(type == LocalizedVibrationType.Light)
        {
            MMVibrationManager.Haptic(HapticTypes.Selection);
        }
        else if(type == LocalizedVibrationType.Off)
        {
            MMVibrationManager.Haptic(HapticTypes.None);
        }
        else { return; }
    }
    void  HapticCall()
    {
        Vib(SetLocalVibrationType);
    }
    public void ChangeVibrationType(LocalizedVibrationType type)
    {
        SetLocalVibrationType = type;
    }
   
}

