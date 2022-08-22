using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Snippets
{

	public interface IA<T, U> { void Run(T p1, U p2); }

	public class A : IA<string, string> { void IA<string, string>.Run(string p1, string p2) { Console.WriteLine("from AAAAAAAAAAAAAA"); } }



	internal class ExplicitInterfaceCall
	{

		public static void Run()
		{
			var typeA = typeof(A);
			var inst = Activator.CreateInstance(typeA);

			var executeMethodInfo = typeA.GetMethod("Run", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod);
			Console.WriteLine("->" + executeMethodInfo);


			var handlerInterface = typeA.GetInterfaces().FirstOrDefault(i => i.GetGenericTypeDefinition() == typeof(IA<,>));
			Console.WriteLine("->" + handlerInterface);

			var responseTask = handlerInterface.InvokeMember("Run",
							BindingFlags.InvokeMethod,
							null,
							inst,
							new object[] { "s", "s" });

			Console.WriteLine("->" + executeMethodInfo);
		}
	}
}
