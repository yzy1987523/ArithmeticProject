
using System;
using System.Collections.Generic;
using System.Numerics;

public class S11
{ 
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {   
        var _p1 = l1;//栈首
        var _p2 = l2;//栈首
        List<ListNode> newList = new List<ListNode>();
        while (_p1 != null || _p2 != null)
        {
            if (_p1 != null && _p2 != null)
            {
                if (_p1.val > _p2.val)
                {
                    newList.Add(_p2);
                    _p2 = _p2.next;
                }
                else
                {
                    newList.Add(_p1);
                    _p1 = _p1.next;
                }
            }
            else
            {
                if (_p1 != null)
                {
                    newList.Add(_p1);
                    _p1 = _p1.next;
                }
                else
                {
                    newList.Add(_p2);
                    _p2 = _p2.next;
                }
            }
        }
        
        return TransToListNode(newList);
    }
    ListNode TransToListNode(List<ListNode> lists)
    {
        ListNode listNode = null;
        for (int i = lists.Count - 1; i >= 0; i--)
        {
            ListNode node = new ListNode(lists[i].val)
            {
                next = listNode
            };
            listNode = node;
        }         
        return listNode;
    }
    public int HammingWeight(uint n)
    {
        var _step = 0;
        var _count = 0;
        while (_step < 32)
        {
            if ((n & 1) == 1)
            {
                _count++;
            }
            n=n>>1;
            _step++;
        }
        return _count;
    }
    public int KthLargest(TreeNode root, int k)
    {
        List<int> heap = new List<int>();
        dfs(heap, root);
        heap.Sort();

        return heap[heap.Count-k];
    }
    void dfs(List<int> heap, TreeNode node)
    {
        if (node == null) return;
        heap.Add(node.val);           
        dfs(heap, node.left);
        dfs(heap, node.right);
    }

}
public class S12
{
    public class KV
    {
        public int key;
        public int value;
        public KV(int _key, int _value)
        {
            key = _key;
            value = _value;
        }
    }
    public class LRUCache
    {
        List<KV> objs ;
        int length;
        public LRUCache(int capacity)
        {
            length = capacity;
            objs = new List<KV>();
        }

        public int Get(int key)
        {
            if (Exists(key))
            {                
                return PickKey(key).value;
            }
            else
            {
                return -1;
            }
           
        }

        public void Put(int key, int value)
        {
            if (Exists(key))
            {
                var _kv = objs.Find(x => x.key == key);
                objs.Remove(_kv);
                _kv.value = value;
                objs.Add(_kv);
            }
            else
            {
                if(objs.Count>= length)
                {
                    var _kv = objs[0];
                    objs.Remove(_kv);                   
                }                
                objs.Add(new KV(key, value));
               
            }
        }
        bool Exists(int key)
        {
            return objs.Exists(x => x.key == key);
        }
        KV PickKey(int key)
        {
            var _kv = objs.Find(x => x.key == key);
            objs.Remove(_kv);
            objs.Add(_kv);
            return _kv;
        }
    }

}