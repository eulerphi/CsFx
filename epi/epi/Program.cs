using epi.arrays;
using epi.common;
using epi.dynamicprogramming;
using epi.hashes;
using epi.lists;
using epi.queues;
using epi.stacks;
using epi.trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi {
    class Program {
        static void Main(string[] args) {
            //var fulltext = "My paramount object in this struggle is to save the Union and is not either to save or to destroy slavery If I could save the Union without freeing any slave I would do it and if I could save it by freeing all the slaves I would do it and if I could save it by freeing some and leaving others alone I would also do that";
            //var text = fulltext.Split(' ');
            ////var words = new HashSet<string> { "save", "slavery", "any", "Union" };
            //var words = new string[] { "Union", "save" };
            var text = new string[] { "a", "b", "a", "a", "c" };
            var words = new string[] { "b", "a", "c" };
            //var text = new string[] { "a", "a", "a", "a", "b", "a" };
            //var words = new string[] { "b", "a" };

            var result = GetShortestSequentialDigest.GetBook(text, words);
            var sub = text.Skip(result.Item1).Take(result.Item2 - result.Item1 + 1).ToList();
        }
    }
}
