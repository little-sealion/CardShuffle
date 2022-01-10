using System;
namespace CardShuffle
{
	public static class Extensions
	{
		//You can see the addition of the this modifier on the first argument to the method. That means you call the method
        //as though it were a member method of the type of the first argument.
		public static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first,IEnumerable<T> second)
        {
			var firstIter = first.GetEnumerator();
			var secondIter = second.GetEnumerator();
			while(firstIter.MoveNext() && secondIter.MoveNext())
            {
				yield return firstIter.Current;
				yield return secondIter.Current;
			}
        }

		public static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
			var firstIter = first.GetEnumerator();
			var secondIter = second.GetEnumerator();
			while(firstIter.MoveNext() && secondIter.MoveNext())
            {
				if (!firstIter.Current.Equals( secondIter.Current)) return false;
            }
			return true;
        }

		public static IEnumerable<T> LogQuery<T>(this IEnumerable<T> sequence, string tag)
        {
			// File.AppendText creates a new file if the file doesn't exist.
			using (var writer = File.AppendText("debug.log"))
			{
				writer.WriteLine($"executing query {tag}");
			}
			return sequence;
		}

	}
}

