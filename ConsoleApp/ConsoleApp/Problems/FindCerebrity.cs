using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal static  class FindCerebrity
    {

		private class Person
        {
			public int Id { get; set; }

			public List<Person> Friends = new List<Person> { };

            public Person(int id)
            {
                Id = id;
            }

            public bool IsFriend (Person p)
            {
				return Friends.Contains (p);
            }

            public override string ToString()
            {
                return Id.ToString();
            }
        }

		public static void Run()
		{
			Person maks = new Person(1); 
			Person mark = new Person(2) { Friends = new List<Person> { maks } };
			Person ivan = new Person(3) { Friends = new List<Person> { maks, mark } };
			Person petr = new Person(4) { Friends = new List<Person> { maks } };
			
			Person igor = new Person(5) { Friends = new List<Person> { maks, petr, ivan } };

			//maks.Friends.Add(petr);

			var list = new List<Person> { mark, ivan, petr, maks, igor };

			Person celebrity = list[0];

			int comparePerson1 = 0;
			int comparePerson2 = list.Count-1;

			
			while(comparePerson1 < comparePerson2)
            {
				Console.WriteLine($"p1={list[comparePerson1]}; p2={list[comparePerson2]}");


				Person localCelebrity = null;
				if (list[comparePerson1].IsFriend(list[comparePerson2]))
				{
					celebrity = list[comparePerson2];
					comparePerson1++;
				}
				else
				{
					celebrity = list[comparePerson1];
					comparePerson2--;
				}


				Console.WriteLine($"		local={celebrity}");
			}

			for(int i =0; i< list.Count; i++)
            {
				if (list[i] == celebrity)
					continue;

                if (celebrity.IsFriend(list[i]))
                {
					celebrity = null;
					break;

				}
            }

			Console.WriteLine($"result={celebrity}");
		}
	}
}
