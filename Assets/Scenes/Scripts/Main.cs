using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private S1 s1=new S1();

    void Start()
    {        
        Debug.Log(s1.ReverseLeftWords("asdasdaefse", 2));
    }

   
}
