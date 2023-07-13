using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointManager : MonoBehaviour
{
    
    void Start()
    {
        EventManager.EndPointPosition(transform.position);
    }

}
