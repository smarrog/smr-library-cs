using System;
using System.Collections.Generic;
using System.Linq;

namespace smr.utils {
	public static class ListUtils {
		public static T Shift<T>(List<T> list) {
			if (list == null) {
				throw new Exception("List is null");
			}
			if (list.Count == 0) {
				throw new Exception("Try to shift from empty list");
			}
			var first = list.First();
			list.RemoveAt(0);
			return first;
		}
		
		
		public static T Pop<T>(List<T> list) {
			if (list == null) {
				throw new Exception("List is null");
			}
			if (list.Count == 0) {
				throw new Exception("Try to pop from empty list");
			}
			var last = list.Last();
			list.RemoveAt(list.Count - 1);
			return last;
		}

		public static List<T> Splice<T>(List<T> list, int index, int count) {
			if (list == null) {
				throw new Exception("List is null");
			}
			var result = list.GetRange(index, count);
			list.RemoveRange(index, count);
			return result;
		}
	}
}