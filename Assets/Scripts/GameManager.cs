using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float resetDistanceY;


    // Start is called before the first frame update
    void Start()
    {
        Road.manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
