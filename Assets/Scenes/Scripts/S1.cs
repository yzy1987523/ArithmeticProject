using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1
{
    public string ReverseLeftWords(string s, int n)
    {    
        return s.Substring(n) + s.Substring(0, n);
    }

}
public class S2
{

public class ListNode
 {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

    public ListNode GetKthFromEnd(ListNode head, int k)
    {
        if (head == null) return null;
        List<ListNode> listNodes=new List<ListNode>();
        ListNode temp = head;
        while (temp!= null)
        {
            listNodes.Add(temp);
            temp = temp.next;
        }
        var _index= listNodes.Count-k;
        if (_index < 0)
        {
            return null;
        }
        return listNodes[_index];
    }

}