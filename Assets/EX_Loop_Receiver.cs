using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_Loop_Receiver : MonoBehaviour
{
    public Record record;
    public Record.Each[] Stamp = new Record.Each[1000];
    public double[] time = new double[1000];
    public double[] damp = new double[500];
    int dstart;
    public int iterator;
    int reset;
    public double NewLoopTime;
    public bool cancel = false;
    public bool MarkerPlaced = false;
    public double MarkerTrack;
    AudioSource audi;
    Rec_SoundDataReceiver recce;
    private void Start()
    {
        iterator = 0;
        reset = iterator;
        audi = gameObject.GetComponent<AudioSource>();
        recce = gameObject.GetComponent<Rec_SoundDataReceiver>();
    }
    bool[] PlayArray; //temp array used to keep playy notes at a particular instance
    public void ResetLoop()
    {
        iterator = reset;
        Playloop();
    }
    public void Playloop()
    {
        if (cancel)
        {
            iterator = 0;
            return;
        }
        PlayArray = Stamp[iterator].note;
        Invoke("ReadNote", (float)time[iterator]);
    }
    void ReadNote()
    {
        if (PlayArray[0])
        {
            SoundDataSend(0);
        }
        if (PlayArray[1])
        {
            SoundDataSend(1);
        }
        if (PlayArray[2])
        {
            SoundDataSend(2);
        }
        if (PlayArray[3])
        {
            SoundDataSend(3);
        }
        if (PlayArray[4])
        {
            SoundDataSend(4);
        }
        if (PlayArray[5])
        {
            SoundDataSend(5);
        }
        if (PlayArray[6])
        {
            SoundDataSend(6);
        }
        if (PlayArray[7])
        {
            SoundDataSend(7);
        }
        if (PlayArray[8])
        {
            SoundDataSend(8);
        }
        if (PlayArray[9])
        {
            SoundDataSend(9);
        }
        if (PlayArray[10])
        {
            SoundDataSend(10);
        }
        if (PlayArray[11])
        {
            SoundDataSend(11);
        }
        if (PlayArray[12])
        {
            SoundDataSend(12);
        }
        if (PlayArray[13])
        {
            SoundDataSend(13);
        }
        if (PlayArray[14])
        {
            SoundDataSend(14);
        }
        if (PlayArray[15])
        {
            SoundDataSend(15);
        }
        if (PlayArray[16])
        {
            SoundDataSend(16);
        }
        if (PlayArray[17])
        {
            SoundDataSend(17);
        }
        if (PlayArray[18])
        {
            SoundDataSend(18);
        }
        if (PlayArray[19])
        {
            SoundDataSend(19);
        }
        if (PlayArray[20])
        {
            SoundDataSend(20);
        }
        if (PlayArray[21])
        {
            SoundDataSend(21);
        }
        if (PlayArray[22])
        {
            SoundDataSend(22);
        }
        if (PlayArray[23])
        {
            SoundDataSend(23);
        }
        if (PlayArray[24])
        {
            SoundDataSend(24);
        }
        if (PlayArray[25])
        {
            SoundDataSend(25);
        }
        if (PlayArray[26])
        {
            SoundDataSend(26);
        }
        if (PlayArray[27])
        {
            SoundDataSend(27);
        }
        if (PlayArray[28])
        {
            SoundDataSend(28);
        }
        if (PlayArray[29])
        {
            SoundDataSend(29);
        }
        if (PlayArray[30])
        {
            SoundDataSend(30);
        }
        if (PlayArray[31])
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
