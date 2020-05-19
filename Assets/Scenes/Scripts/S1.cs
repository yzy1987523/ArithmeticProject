using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1 : MonoBehaviour
{
    public string ReverseLeftWords(string s, int n)
    {    
        return s.Substring(n) + s.Substring(0, n);
    }

}
