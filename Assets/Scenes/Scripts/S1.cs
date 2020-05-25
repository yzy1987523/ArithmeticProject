using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}
public class S1
{
    public string ReverseLeftWords(string s, int n)
    {
        return s.Substring(n) + s.Substring(0, n);
    }

}
public class S2
{

   

    public ListNode GetKthFromEnd(ListNode head, int k)
    {
        if (head == null) return null;
        List<ListNode> listNodes = new List<ListNode>();
        ListNode temp = head;
        while (temp != null)
        {
            listNodes.Add(temp);
            temp = temp.next;
        }
        var _index = listNodes.Count - k;
        if (_index < 0)
        {
            return null;
        }
        return listNodes[_index];
    }

}
public class S3
{
    public int[] PrintNumbers(int n)
    {
        var _num = 1;
        while (n > 0)
        {
            _num *= 10;
            n--;
        }
        var _array = new int[_num - 1];
        for (var i = 0; i < _num - 1; i++)
        {
            _array[i] = i + 1;
        }
        return _array;
    }

}
public class S4
{
   
    public TreeNode MirrorTree(TreeNode root)
    {
        if (root == null) return null;
        var _right = MirrorTree(root.right);
        root.right = MirrorTree(root.left);
        root.left = _right;
        return root;
    }
}
public class S5
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        var _left = MaxDepth(root.left) + 1;
        var _right = MaxDepth(root.right) + 1;
        return Math.Max(_left, _right);
    }
}
public class S6
{
    public string ReplaceSpace(string s)
    {
        StringBuilder stringBuilder = new StringBuilder(s);
        var _temp = 0;
        while (_temp < stringBuilder.Length)
        {
            if (stringBuilder[_temp] == ' ')
            {
                stringBuilder[_temp] = '%';
                stringBuilder.Insert(_temp + 1, "20");
                _temp += 2;
            }
            _temp++;
        }
        return stringBuilder.ToString();
    }
}
public class S7
{
    
    public int[] ReversePrint(ListNode head)
    {
        if (head == null) return new int[] { };
        var list = new List<int>();
        GetNextNode(head, list);
        return list.ToArray();
    }
    void GetNextNode(ListNode node, List<int> list)
    {
        if (node.next == null)
        {
            list.Add(node.val);
        }
        else
        {

            GetNextNode(node.next, list);
            list.Add(node.val);
        }
    }
}
public class S8
{
  
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null) return head;
        var _head = head;
        var _point = head.next;
        while (_point != null)
        {
            var _temp = _point.next;
            _head.next = _temp;
            _point.next = head;
            head = _point;
            _point = _temp;
        }
        return head;
    }

}
public class S9
{
    //早先思路：先考虑从左到右
    //找到t中第一个相同的字符
    //然后将字符存入_matchList及state
    //然后往下找，当出现相同的时候存入state，再看_matchList中有没有,没有就加入，有就看是否==s[_maxLeft]，否就跳过，是就找到最左侧不为空的state，并将_maxLeft=index
    //然后用类似的方式考虑从右到左
    //最后看_matchList的长度是否与t一致
    //一样就提取s中_maxLeft到_maxRight的字符串      
    //BUG：忘记处理从右往左时，最右侧与最左侧相同的情况
    //于是换思路：看题解
    //看了滑动窗口的原理
    Dictionary<char, int> sDic = new Dictionary<char, int>();
    Dictionary<char, int> tDic = new Dictionary<char, int>();
    public string MinWindow(string s, string t)
    {
        sDic.Clear();
        tDic.Clear();
        //考虑t中有相同字符的情况，所以需要统计t中每个字符的出现次数
        for (var i = 0; i < t.Length; i++)
        {
            AddItem(tDic, t[i]);
        }

        var left = 0;
        var right = 0;
        int areaL = 0;
        int ansL = s.Length + 1;
        while (right < s.Length)
        {
            if (right < s.Length && tDic.ContainsKey(s[right]))
            {
                AddItem(sDic, s[right]);
            }
            while (CheckDic() && left <= right)
            {
                if (ansL > right - left + 1)
                {
                    ansL = right - left + 1;
                    areaL = left;
                }
                RemoveItem(sDic, s[left]);
                left++;
            }
            right++;
        }
        if (ansL > s.Length) return "";
        return s.Substring(areaL, ansL);
    }
    void AddItem(Dictionary<char, int> dic, char key)
    {
        if (dic.ContainsKey(key))
        {
            dic[key]++;
        }
        else
        {
            dic.Add(key, 1);
        }
    }
    void RemoveItem(Dictionary<char, int> dic, char key)
    {
        if (dic.ContainsKey(key))
        {
            dic[key]--;
        }
    }
    bool CheckDic()
    {
        foreach (var i in tDic)
        {
            if (sDic.ContainsKey(i.Key))
            {
                if (sDic[i.Key] < tDic[i.Key])
                {
                    return false;
                }
            }
            else
            {

                return false;
            }
        }
        return true;
    }

}

public class S10
{
    //用找最小K数的方法找中位数
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var n = nums1.Length + nums2.Length;
        if ((n & 1) == 0)
        {
            return (FindKthElm(nums1, nums2, n >> 1) + FindKthElm(nums1, nums2, (n >> 1) + 1)) / 2.0;//返回值是double类型
        }
        return FindKthElm(nums1, nums2, (n >> 1) + 1);
    }
    //找第K个元素
    int FindKthElm(int[] nums1, int[] nums2, int k)
    {
        if (!(1 <= k && k <= nums1.Length + nums2.Length)) return 0;
        int left = Math.Max(0, k - nums2.Length);
        int right = Math.Min(k, nums1.Length);
        while (left < right)
        {
            int m = left + (right - left) / 2;
            if (nums2[k - m - 1] > nums1[m]) left = m + 1;
            else right = m;
        }//循环结束时的位置le即为所求位置，第k小即为max(nums1[le-1]),nums2[k-le-1])，但是由于le可以为0、k,所以
        //le-1或者k-le-1可能不存在所以下面单独判断下
        int nums1LeftMax = left == 0 ? int.MinValue : nums1[left - 1];
        int nums2LeftMax = left == k ? int.MinValue : nums2[k - left - 1];
        return Math.Max(nums1LeftMax, nums2LeftMax);
    }
}