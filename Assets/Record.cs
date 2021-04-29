using System;
using System.Collections;
using UnityEngine;
using Unity.Collections;
using System.Diagnostics;
using AndroidAudioBypass;

public class Record : MonoBehaviour
{
    [Serializable]
    public class Each
    {
        public bool[] note = new bool[32];
    }
    public Stopwatch sw = new Stopwatch();
    public int iterator;
    //public bool[] Man.key_played = new bool[32];
    public Each[] each = new Each[1000];
    public double[] DeltaTime = new double[1000];
    public double SlaveLoopDelta = 0;
    public double RecordEndtime;
    public EX_Loop_Receiver ex_Loop;
    public PrimaryLoop_Receiver PrimeLoop;
    public Rec_SoundDataReceiver PrimeSoundReceiver;
    public Rec_SoundDataReceiver EX_LoopAudioReceiver;
    public Loop_Receiver[] _Loop = new Loop_Receiver[10] ;
    public Rec_SoundDataReceiver[] _SoundDataReceiver = new Rec_SoundDataReceiver[10];
    public M_Manager Man;
    public BypassAudioSource sourceAudio;
    public bool Recording = false;
    public int CurrentLoop = 0;
    bool SaveInProgress;
    public AudioClip[] Marimba_Array;
    public AudioClip[] Xylo_Array;
    public AudioClip[] Vibro_Array;
    public double RecMark;
    public double test1;
    public double test2;
    public double test;
    bool primaryplay = false;
    void Start()
    {
        Physics2D.autoSimulation = false;
       // Man = gameObject.GetComponentInParent<M_Manager>();
       // sourceAudio = gameObject.GetComponentInParent<BypassAudioSource>();
        sw.Start();
    }

    public void KeyDataReceiver()
    {
        RecMark = sw.ElapsedMilliseconds;
       // RecNote();
        if (!primaryplay)
        {
            PrimeLoop.RecNote();
            UnityEngine.Debug.Log("g");
        }
        else
        {
            
            _Loop[CurrentLoop].RecNote();
        }
       // test = test2 - test1;
    }
    public bool keyCorrectOff = false;

    /* public void LoopTransfer()
     {


     }*/
    /// <summary>
    /// meant to use only as a debug tool to correct weird loop sync glitch... worst case scenario should be releasable with it in use.
    /// </summary>
    /* public void KeySyncCorrector()
     {         
         iterator++;
     }*/
    /// <summary>
    /// Function records main Array
    /// </summary>
    private void RecNote()
    {
        //await Man.Keys();
        DeltaTime[iterator] = RecMark;
        Each tempEach = new Each();
        if (Man.key_played[0])
        {
            tempEach.note[0] = true;
            //Man.key_played[0] = false;

        }
        if (Man.key_played[1])
        {
            tempEach.note[1] = true;
          //  Man.key_played[1] = false;
        }
        if (Man.key_played[2])
        {
            tempEach.note[2] = true;
          //  Man.key_played[2] = false;
        }
        if (Man.key_played[3])
        {
            tempEach.note[3] = true;
            //Man.key_played[3] = false;
        }
        if (Man.key_played[4])
        {
            tempEach.note[4] = true;
           // Man.key_played[4] = false;

        }
        if (Man.key_played[5])
        {
            tempEach.note[5] = true;
           // Man.key_played[5] = false;
        }
        if (Man.key_played[6])
        {
            tempEach.note[6] = true;
           // Man.key_played[6] = false;
        }
        if (Man.key_played[7])
        {
            tempEach.note[7] = true;
           // Man.key_played[7] = false;
        }
        if (Man.key_played[8])
        {
            tempEach.note[8] = true;
           // Man.key_played[8] = false;
        }
        if (Man.key_played[9])
        {
            tempEach.note[9] = true;
            //Man.key_played[9] = false;
        }
        if (Man.key_played[10])
        {
            tempEach.note[10] = true;
           // Man.key_played[10] = false;
        }
        if (Man.key_played[11])
        {
            tempEach.note[11] = true;
            //Man.key_played[11] = false;
        }
        if (Man.key_played[12])
        {
            tempEach.note[12] = true;
           // Man.key_played[12] = false;
        }
        if (Man.key_played[13])
        {
            tempEach.note[13] = true;
            //Man.key_played[13] = false;
        }
        if (Man.key_played[14])
        {
            tempEach.note[14] = true;
           // Man.key_played[14] = false;
        }
        if (Man.key_played[15])
        {
            tempEach.note[15] = true;
           // Man.key_played[15] = false;
        }
        if (Man.key_played[16])
        {
            tempEach.note[16] = true;
           // Man.key_played[16] = false;
        }
        if (Man.key_played[17])
        {
            tempEach.note[17] = true;
           // Man.key_played[17] = false;
        }
        if (Man.key_played[18])
        {
            tempEach.note[18] = true;
            //Man.key_played[18] = false;
        }
        if (Man.key_played[19])
        {
            tempEach.note[19] = true;
           // Man.key_played[19] = false;
        }
        if (Man.key_played[20])
        {
            tempEach.note[20] = true;
           // Man.key_played[20] = false;
        }
        if (Man.key_played[21])
        {
            tempEach.note[21] = true;
           // Man.key_played[21] = false;
        }
        if (Man.key_played[22])
        {
            tempEach.note[22] = true;
            //Man.key_played[22] = false;
        }
        if (Man.key_played[23])
        {
            tempEach.note[23] = true;
            //Man.key_played[23] = false;
        }
        if (Man.key_played[24])
        {
            tempEach.note[24] = true;
            //Man.key_played[24] = false;
        }
        if (Man.key_played[25])
        {
            tempEach.note[25] = true;
            //Man.key_played[25] = false;
        }
        if (Man.key_played[26])
        {
            tempEach.note[26] = true;
           // Man.key_played[26] = false;
        }
        if (Man.key_played[27])
        {
            tempEach.note[27] = true;
           // Man.key_played[27] = false;
        }
        if (Man.key_played[28])
        {
            tempEach.note[28] = true;
           // Man.key_played[28] = false;
        }
        if (Man.key_played[29])
        {
            tempEach.note[29] = true;
            //Man.key_played[29] = false;
        }
        if (Man.key_played[30])
        {
            tempEach.note[30] = true;
           // Man.key_played[30] = false;
        }
        if (Man.key_played[31])
        {
            tempEach.note[31] = true;
           // Man.key_played[31] = false;
        }
        each[iterator] = tempEach;
        iterator++;
        UnityEngine.Debug.Log("testframe2 is " + Time.frameCount + "and time is" + Time.time);
    }


    /// <summary>
    /// Begins the Key Storage cycle at RecNote() ------------------------------- (1)
    /// </summary>
    /// 
    public float SafetyStopRecord_time = 500f;
    public void StartRecord()
    {

        if (Recording || SaveInProgress)
        {
            UnityEngine.Debug.LogError("A Recording or Saving is already in progress.");
            //place error msg here
            return;
        }
      /*  for (int i = 0; i < Man.key_played.Length; i++)
        {
            Man.key_played[i] = false;
        }*/
        
        SlaveLoopDelta = PrimeLoop.NewLoopTime;
        iterator = 0;
        Invoke("SafetyStop",SafetyStopRecord_time);
        Recording = true;
        if (primaryplay)
        {

        }
    }

    /// <summary>
    /// Stops Sending Key Notes to the Record Array ----------------------------- (2)
    /// </summary>
    public void StopRecord()
    {
        RecordEndtime = sw.ElapsedMilliseconds;
        if(primaryplay)
        {
           // RecordEndtime = RecordEndtime ;
        }
       // sw.Stop();
        //sw.Reset();
        UnityEngine.Debug.Log("stop called save loop in progress");
        Recording = false;
       
        SaveLoop();
    }
    public void autoStop()
    {
        StopRecord();
    }
   
    /// <summary>
    ///Initialize save in StoreLoop() and sends to play on yielding return value ------------------- (3)
    /// </summary>
    public void SaveLoop()
    {
        //load timer on
        SaveInProgress = true;
       // _Loop[CurrentLoop].SaveLoop();
        //StoreLoop(CurrentLoop);
        // SYNCSTART("slavesync");

        if (CurrentLoop == 0 && !primaryplay )
        {
            //PrimaryLoopSaver();
            //PrimeLoop.StartLoop();
            PrimeLoop.SaveLoop();
            primaryplay = true;
        }
        else
        {
            _Loop[CurrentLoop].SaveLoop();
            //StoreLoop(CurrentLoop);
           // SYNCSTART("slavesync");
            
            CurrentLoop++;
        }
        SaveInProgress = false;      
        //load timer off
    }

    public void SYNCSTART(string type)
    {
        if(type == "primary")
        {
            //PrimeLoop.cancel = true;
            PrimeLoop.StartLoop();
        }
        else if(type == "slavesync")
        {
            PrimeLoop.cancel = true;           
            for (int i = 0; i <= CurrentLoop ; i++)
            {
                _Loop[i].Playloop();
            }
            //PrimeLoop.StartLoop();
        }       
    }



    int counter = 0;
    Each[] tempEach = new Each[1000];
    double[] TempDeltaTime = new double[1000];
    IEnumerator CreateComplexLoop()
    {     
        Array.Resize(ref tempEach, iterator);
        Array.Resize(ref TempDeltaTime, iterator + 1);
        for (int i = 0; i < iterator; i++)
        {
            for (int j = 0; j < Man.key_played.Length; j++)
            {
                tempEach[i].note[j] = each[i].note[j];
                each[i].note[j] = false;
            }
        }
       // TempDeltaTime[0] = (DeltaTime[0] - SlaveLoopDelta);
        for (int i = 0; i < iterator; i++)
        {
            TempDeltaTime[i] = (DeltaTime[i] - SlaveLoopDelta);
        }       
        TempDeltaTime[iterator] = (RecordEndtime - SlaveLoopDelta);
        //all Man.key_playedic before array is cleared below
        Array.Clear(DeltaTime, 0, DeltaTime.Length);
        Array.Resize(ref DeltaTime, 1000);
        iterator = 0;
        yield return null;
        _Loop[CurrentLoop].time[0] = P_CompareT[0];
    }
    int FindLoopBitePoint()
    {
        for(int i = 0; i < P_CompareT.Length; i++)
        {
            UnityEngine.Debug.Log("bitepoint not found");
            if(P_CompareT[i] >= DeltaTime[i])
            {
                return i;
            }
        }
        return 0;
    }
    void BuildLoop(int n)
    {
        //some check null stuff
        // sgart logic right here
        CheckNoteHeirarchy(n);

    }
    int cc  = 0;
    void CheckNoteHeirarchy(int i)
    {     
        
    }
    void ConcatenateNotes(Each a, Each b)
    {
        for(int i= 0; i < a.note.Length; i++)
        {
            if(a.note[i] || b.note[i])
            {
               // _Loop[CurrentLoop].Stamp[i] = true;
            }
        }
    }
    /// <summary>
    ///  Saves the record array in the corresponding CurrentLoop
    /// </summary>
    void StoreLoop(int cLoop)
    {
      

    }
    Each[] P_CompareN = new Each[1000];
    double[] P_CompareT = new double[1000];
    void PrimaryLoopSaver()
    {
        Array.Resize(ref PrimeLoop.Stamp, iterator + 1);
        Array.Resize(ref PrimeLoop.time, iterator + 1);
        Array.Resize(ref P_CompareN, iterator + 1);
        Array.Resize(ref P_CompareT, iterator + 1);
        for (int i = 0; i < iterator; i++)
        {
            for (int e = 0; e < Man.key_played.Length; e++)
            {
                P_CompareN[i].note[e] = PrimeLoop.Stamp[i].note[e] = each[i].note[e];
                each[i].note[e] = false;
            }
        }
        P_CompareT[iterator] =  PrimeLoop.time[iterator] = (RecordEndtime - DeltaTime[iterator - 1]) * 0.001f;

        for (int i = (iterator - 1); i > 0; i--)
        {
            P_CompareT[i] = PrimeLoop.time[i] = (DeltaTime[i] - DeltaTime[i - 1]) * 0.001f;
        }
        P_CompareT[0] = PrimeLoop.time[0] = 0;


        //all Man.key_playedic before array is cleared below
        Array.Clear(DeltaTime, 0, DeltaTime.Length);
        Array.Resize(ref DeltaTime, 1000);
        iterator = 0;
    }
    


    public void CancelLoopinRealtime()
    {
        Recording = false;
       // each = new Each[1000];
       // DeltaTime = new double[1000];
       // dstart = 0;
        iterator = 0;
    }

    public void Rec_PitchChanger(float m_rate)
    {
        EX_LoopAudioReceiver.Set_PitchOctave(m_rate);
        _SoundDataReceiver[0].Set_PitchOctave(m_rate);
    }
    public void Rec_InstChanger(int n)
    {
        //EX_LoopAudioReceiver.InstSelect(n);
        PrimeSoundReceiver.InstSelect(n);
        for(int i = 0; i < _SoundDataReceiver.Length; i++)
        {
            _SoundDataReceiver[i].InstSelect(n);
        }
        
    }
    public void TestButton()
    {
        Man.Keys();
      UnityEngine.Debug.Log("test called");
    }
    public void SafetyStop()
    {
        Recording = false;
        return;
    }
}
