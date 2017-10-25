using System.Collections;
using System.Collections.Generic;

namespace Common
{
	public sealed class Option<T> : IEnumerable<T>
	{
		private Option()
		{
		}

		public Option(T target)
		{
			Target = target;
		}

		public static Option<T> Empty() => new Option<T>();

		private T Target { get; set; }

		public IEnumerator<T> GetEnumerator()
		{
			if (Target != null)
				yield return Target;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public static class OptionExtensions
	{
		public static Option<T> AsOption<T>(this object value) => new Option<T>((T) value);
	}
}
