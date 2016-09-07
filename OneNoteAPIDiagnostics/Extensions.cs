using System;
using System.Collections.Generic;
namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	public static class Extensions
	{
		public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
		{
			foreach (T item in collection)
				action(item);
		}
	}
}
