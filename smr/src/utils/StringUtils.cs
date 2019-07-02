using System;
using System.Globalization;
using System.Linq;

namespace smr.utils {
	public class StringUtils {
		public static bool StartsWith(string s, string prefix) {
			return !string.IsNullOrEmpty(s) && s.IndexOf(prefix, StringComparison.Ordinal) == 0;
		}

		public static string CapitalizeFirstLetter(string s) {
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
		}

		public static string Unquote(string s, bool recursive = false) {
			if (!string.IsNullOrEmpty(s) && s.First() == '"' && s.Last() == '"') {
				s = s.Substring(1, s.Length - 2);
				return recursive ? Unquote(s) : s;
			}
			return s;
		}

		public static string Quote(string s) {
			if (!string.IsNullOrEmpty(s) && (s.First() != '"' || s.Last() != '"')) {
				return '"' + s + '"';
			}
			return s;
		}
	}
}