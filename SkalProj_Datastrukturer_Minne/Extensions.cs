using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public static class Extensions
    {



        //Statisk metod 
        //this är det vi skickar in
        //T1, T2 generiska typer
        //T2 : T1 så vi kan skicka in ett Dog i en Animal lista T2 är en T1 
        public static void AddColl<T1, T2>(this IEnumerable<T1> collection, T2 value) where T2 : T1
        {
            var typeOfCollection = collection.GetType().Name;
            var v = typeOfCollection.Substring(0, typeOfCollection.Length - 2);

            switch (v)
            {
                case "Queue":
                    var q = collection as Queue<T1>;
                    q.Enqueue(value);
                    break;
                case "List":
                    var l = collection as List<T1>;
                    l.Add(value);
                    break;
                case "Stack":
                    break;
                default:
                    break;
            }
        }

        public static void RemoveColl<T1, T2>(this IEnumerable<T1> collection, T2 value) where T2 : T1{
            var typeOfCollection = collection.GetType().Name;
            var v = typeOfCollection.Substring(0, typeOfCollection.Length - 2);

            switch (v)
            {
                case "Queue":
                    var q = collection as Queue<T1>;
                    q.Dequeue();
                    break;
                case "List":
                    var l = collection as List<T1>;
                    l.Remove(value);
                    break;
                case "Stack":
                    var s = collection as Stack<T1>;
                    s.Pop();
                    break;
                default:
                    break;
            }

        }
    }




    }
}
}
