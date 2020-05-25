using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private S9 s=new S9();

    [ContextMenu("test")]
    void test()
    {        
        //Debug.Log(12&1);
        //Debug.Log(13 & 1);
        List<KV> l = new List<KV>();
        //l.Add(0);
        //l.Add(1);
        Debug.Log(l.Find(x => x.key == 1));
    }
    public struct KV
    {
        public int key;
        public int value;
        public KV(int _key, int _value)
        {
            key = _key;
            value = _value;
        }
    }

}

