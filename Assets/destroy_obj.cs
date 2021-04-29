using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_obj : MonoBehaviour
{
    public float destroy_Time;
    private void Awake()
    {
        Destroy(gameObject, destroy_Time);
    }

}
