using System;
using System.Collections;
using UnityEngine;

public class Loop_Receiver : MonoBehaviour
{
    M_Manager Man;
    Record record;
    public Record.Each[] Stamp = new Record.Each[1000];
    public double[] time = new double[1000];
    public int iterator;
    int reset;
    public bool cancel = false;
    public bool MarkerPlaced = false;
    public double MarkerTrack;
    AudioSource audi;   
    Rec_SoundDataReceiver recce;

    private void Start()
    {
        Man = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<M_Manager>();
        record = GameObject.FindGameObjectWithTag("Record").GetComponent<Record>();
        iterator = 0;
        reset = iterator;
        audi = gameObject.GetComponent<AudioSource>();
        recce = gameObject.GetComponent<Rec_SoundDataReceiver>();
    }

    public void RecNote()
    {
        time[iterator] = record.RecMark;
        //record.keyCorrectOff = true;
        Record.Each each = new Record.Each();
        if (Man.key_played[0])
        {
            each.note[0] = true;
            //Man.key_played[0] = false;

        }
        if (Man.key_played[1])
        {
            each.note[1] = true;
            //Man.key_played[1] = false;
        }
        if (Man.key_played[2])
        {
            each.note[2] = true;
           // Man.key_played[2] = false;
        }
        if (Man.key_played[3])
        {
            each.note[3] = true;
           // Man.key_played[3] = false;
        }
        if (Man.key_played[4])
        {
            each.note[4] = true;
           // Man.key_played[4] = false;

        }
        if (Man.key_played[5])
        {
            each.note[5] = true;
           // Man.key_played[5] = false;
        }
        if (Man.key_played[6])
        {
            each.note[6] = true;
          //  Man.key_played[6] = false;
        }
        if (Man.key_played[7])
        {
            each.note[7] = true;
            //Man.key_played[7] = false;
        }
        if (Man.key_played[8])
        {
            each.note[8] = true;
          //  Man.key_played[8] = false;
        }
        if (Man.key_played[9])
        {
            each.note[9] = true;
            //Man.key_played[9] = false;
        }
        if (Man.key_played[10])
        {
            each.note[10] = true;
           // Man.key_played[10] = false;
        }
        if (Man.key_played[11])
        {
            each.note[11] = true;
            //Man.key_played[11] = false;
        }
        if (Man.key_played[12])
        {
            each.note[12] = true;
           // Man.key_played[12] = false;
        }
        if (Man.key_played[13])
        {
            each.note[13] = true;
           // Man.key_played[13] = false;
        }
        if (Man.key_played[14])
        {
            each.note[14] = true;
           // Man.key_played[14] = false;
        }
        if (Man.key_played[15])
        {
            each.note[15] = true;
           // Man.key_played[15] = false;
        }
        if (Man.key_played[16])
        {
            each.note[16] = true;
           // Man.key_played[16] = false;
        }
        if (Man.key_played[17])
        {
            each.note[17] = true;
           // Man.key_played[17] = false;
        }
        if (Man.key_played[18])
        {
            each.note[18] = true;
           // Man.key_played[18] = false;
        }
        if (Man.key_played[19])
        {
            each.note[19] = true;
           // Man.key_played[19] = false;
        }
        if (Man.key_played[20])
        {
            each.note[20] = true;
           // Man.key_played[20] = false;
        }
        if (Man.key_played[21])
        {
            each.note[21] = true;
          //  Man.key_played[21] = false;
        }
        if (Man.key_played[22])
        {
            each.note[22] = true;
            //Man.key_played[22] = false;
        }
        if (Man.key_played[23])
        {
            each.note[23] = true;
           // Man.key_played[23] = false;
        }
        if (Man.key_played[24])
        {
            each.note[24] = true;
           // Man.key_played[24] = false;
        }
        if (Man.key_played[25])
        {
            each.note[25] = true;
            //Man.key_played[25] = false;
        }
        if (Man.key_played[26])
        {
            each.note[26] = true;
           // Man.key_played[26] = false;
        }
        if (Man.key_played[27])
        {
            each.note[27] = true;
           // Man.key_played[27] = false;
        }
        if (Man.key_played[28])
        {
            each.note[28] = true;
            //Man.key_played[28] = false;
        }
        if (Man.key_played[29])
        {
            each.note[29] = true;
            //Man.key_played[29] = false;
        }
        if (Man.key_played[30])
        {
            each.note[30] = true;
           // Man.key_played[30] = false;
        }
        if (Man.key_played[31])
        {
            each.note[31] = true;
            //Man.key_played[31] = false;
        }
        Stamp[iterator] = each;
      //  double tef = record.sw.ElapsedMilliseconds;
        iterator++;
       // record.test2 = tef;
       // record.test = record.test2 - record.test1;
        //calculates elapsed test time data consisting of possible lag in the the script.
    }

    public void SaveLoop()
    {
        Array.Resize(ref Stamp, iterator);
        Array.Resize(ref time, iterator + 1);
        time[iterator] = (record.RecordEndtime - time[iterator - 1]) * 0.001f;
        for (int i = (iterator - 1); i > 0; i--)
        {
            time[i] = (time[i] - time[i - 1]) * 0.001f;
        }
        time[0] = (time[0] - record.SlaveLoopDelta) * 0.001f;

        iterator = 0;
        record.SYNCSTART("slavesync");
    }
    bool[] PlayArray; //temp array used to keep playy notes at a particular instance
    public void ResetLoop()
    {
        
    }
    public void Playloop()
    {
        if(cancel)
        {
            iterator = 0;
            return;
        }
        PlayArray = Stamp[iterator].note;
        Invoke("ReadNote", (float)time[iterator]);      
    }
    void ReadNote()
    {  
        if ( PlayArray[0])
        {
            SoundDataSend(0);           
        }
        if ( PlayArray[1])
        {
            SoundDataSend(1);
        }
        if ( PlayArray[2])
        {
            SoundDataSend(2);
        }
        if ( PlayArray[3])
        {
            SoundDataSend(3);
        }
        if ( PlayArray[4])
        {
            SoundDataSend(4);
        }
        if ( PlayArray[5])
        {
            SoundDataSend(5);
        }
        if ( PlayArray[6])
        {
            SoundDataSend(6);
        }
        if ( PlayArray[7])
        {
            SoundDataSend(7);
        }
        if ( PlayArray[8])
        {
            SoundDataSend(8);
        }
        if ( PlayArray[9])
        {
            SoundDataSend(9);
        }
        if ( PlayArray[10])
        {
            SoundDataSend(10);
        }
        if ( PlayArray[11])
        {
            SoundDataSend(11);
        }
        if ( PlayArray[12])
        {
            SoundDataSend(12);
        }
        if ( PlayArray[13])
        {
            SoundDataSend(13);
        }
        if ( PlayArray[14])
        {
            SoundDataSend(14);
        }
        if ( PlayArray[15])
        {
            SoundDataSend(15);
        }
        if ( PlayArray[16])
        {
            SoundDataSend(16);
        }
        if ( PlayArray[17])
        {
            SoundDataSend(17);
        }
        if ( PlayArray[18])
        {
            SoundDataSend(18);
        }
        if ( PlayArray[19])
        {
            SoundDataSend(19);
        }
        if ( PlayArray[20])
        {
            SoundDataSend(20);
        }
        if ( PlayArray[21])
        {
            SoundDataSend(21);
        }
        if ( PlayArray[22])
        {
            SoundDataSend(22);
        }
        if ( PlayArray[23])
        {
            SoundDataSend(23);
        }
        if ( PlayArray[24])
        {
            SoundDataSend(24);
        }
        if ( PlayArray[25])
        {
            SoundDataSend(25);
        }
        if ( PlayArray[26])
        {
            SoundDataSend(26);
        }
        if ( PlayArray[27])
        {
            SoundDataSend(27);
        }
        if ( PlayArray[28])
        {
            SoundDataSend(28);
        }
        if ( PlayArray[29])
        {
            SoundDataSend(29);
        }
        if ( PlayArray[30])
        {
            SoundDataSend(30);
        }
        if ( PlayArray[31])
        {
            SoundDataSend(31);
        }
        iterator++;
        if (iterator == Stamp.Length)
        {
            Invoke("Playloop", (float)time[iterator]);
            iterator = reset;
            return;
        }
        Playloop();
    }
    public void SoundDataSend(int note)
    {
        recce.Play(note);
    }




}


