using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTesting_Structures_Patterns.Structures.Greedy
{
    /// <summary>
    /// Compresses data to reduce its size without losing any of the details
    /// </summary>
    public class Huffman
    {
        HNode root;

        public Dictionary<char, string> codesDictionary;
        internal class HNode
        {
            internal int item;
            internal char ch;
            internal HNode left;
            internal HNode right;

            internal HNode()
            {

            }

            internal HNode(char data, int amount)
            {
                this.item = amount;
                this.ch = data;
                left = right = null;
            }

        }

        public string GetMsgEncoded(string value)
        {
            var sb = new StringBuilder();
            if (!codesDictionary.Any())
            {
                GetTableCodes(value);
            }
            else
            {
                foreach (var item in value)
                {
                    sb.Append(codesDictionary.Where(x => x.Key == item).Select(x => x.Value).FirstOrDefault());
                }
            }
            return sb.ToString();
        }

        public Huffman()
        {
            codesDictionary = new Dictionary<char, string>();
        }

        private Dictionary<char, int> GetCharsAndCount(string data)
        {
            var dict = new Dictionary<char, int>();
            var temp = data.GroupBy(x => x).Select(x => new { ch = x.Key, ct = x.Count() });

            foreach (var item in temp)
            {
                dict.Add(item.ch, item.ct);
            }

            return dict;
        }

        public void GetTableCodes(string value)
        {
            GetH(value);
            GetTable(this.root, "");
        }
        private void GetTable(HNode root, string s)
        {
            if (root.left == null && root.right == null && Char.IsLetter(root.ch))
            {
                codesDictionary.Add(root.ch, s);
                return;
            }

            GetTable(root.left, s + "0");
            GetTable(root.right, s + "1");
        }

        private void GetH(string value)
        {
            var dict = GetCharsAndCount(value);
            var queue = new Queue<HNode>();

            foreach (var item in dict)
            {
                HNode hn = new HNode(item.Key, item.Value);
                queue.Enqueue(hn);
            }

            root = null;

            while (queue.Count() > 1)
            {
                var x = queue.Dequeue();

                var y = queue.Dequeue();

                HNode node = new HNode();

                node.item = x.item + y.item;
                node.ch = '-';
                node.left = x;
                node.right = y;
                root = node;

                queue.Enqueue(node);
            }

        }
    }

}
