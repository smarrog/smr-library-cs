using NUnit.Framework;
using smr.utils;

namespace smr.Tests.utils {
	[TestFixture]
	public class StringUtilsTests {
		[Test]
		public void StartsWithTest() {
			Assert.False(StringUtils.StartsWith(null, "foo"));
			Assert.False(StringUtils.StartsWith("", "foo"));
			Assert.False(StringUtils.StartsWith("f", "foo"));
			Assert.False(StringUtils.StartsWith("bar_foo", "foo"));
			
			Assert.True(StringUtils.StartsWith("foo", "foo"));
			Assert.True(StringUtils.StartsWith("foo_bar", "foo"));
		}

		[Test]
		public void CapitalizeFirstLetterTest() {
			Assert.Catch(() =>StringUtils.CapitalizeFirstLetter(null));
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter(""), "");
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter("a"), "A");
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter("A"), "A");
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter("1"), "1");
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter("1a"), "1A");
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter("foo"), "Foo");
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter("FOO"), "Foo");
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter("fOO"), "Foo");
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter("FOO"), "Foo");
			Assert.AreEqual(StringUtils.CapitalizeFirstLetter(" foo"), " Foo");
		}

		[Test]
		public void QuoteTest() {
			Assert.Null(StringUtils.Quote(null));
			Assert.AreEqual(StringUtils.Quote(""), "");
			Assert.AreEqual(StringUtils.Quote("foo"), "\"foo\"");
			Assert.AreEqual(StringUtils.Quote("\"foo"), "\"\"foo\"");
			Assert.AreEqual(StringUtils.Quote("foo\""), "\"foo\"\"");
			Assert.AreEqual(StringUtils.Quote("\"foo\""), "\"foo\"");
		}

		[Test]
		public void UnquoteTest() {
			Assert.Null(StringUtils.Unquote(null));
			Assert.AreEqual(StringUtils.Unquote(""), "");
			Assert.AreEqual(StringUtils.Unquote("\"foo\""), "foo");
			Assert.AreEqual(StringUtils.Unquote("\"\"foo\"\""), "\"foo\"");
			Assert.AreEqual(StringUtils.Unquote("\"\"foo\"\"", true), "foo");
			Assert.AreEqual(StringUtils.Unquote("\"foo"), "\"foo");
			Assert.AreEqual(StringUtils.Unquote("foo\""), "foo\"");
		}
	}
}