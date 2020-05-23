using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private S9 s=new S9();

    [ContextMenu("test")]
    void test()
    {        
        Debug.Log(s.MinWindow("a", "a"));
    }

   
}
