using System.Collections.Generic;
using NUnit.Framework;
using smr.utils;

namespace smr.Tests.utils {
	[TestFixture]
	public class ListUtilsTests {
		[Test]
		public void ShiftTest() {
			Assert.Catch(() => ListUtils.Shift<List<int>>(null));
			Assert.Catch(() => ListUtils.Shift(new List<int>()));
			Assert.AreEqual(1, ListUtils.Shift(new List<int> {1, 2, 3}));
		}

		[Test]
		public void PopTest() {
			Assert.Catch(() => ListUtils.Pop<List<int>>(null));
			Assert.Catch(() => ListUtils.Pop(new List<int>()));
			Assert.AreEqual(3, ListUtils.Pop(new List<int> {1, 2, 3}));
		}

		[Test]
		public void SpliceTest() {
			var list = new List<int> { 1, 2, 3, 4, 5 };

			Assert.Catch(() => ListUtils.Splice<List<int>>(null, 0, 1));
			Assert.Catch(() => ListUtils.Splice(list, -1, 1));
			Assert.Catch(() => ListUtils.Splice(list, 0, -1));
			Assert.Catch(() => ListUtils.Splice(list, 0, list.Count + 1));
			Assert.Catch(() => ListUtils.Splice(list, list.Count, 1));

			var spliced = ListUtils.Splice(list, 3, 0);
			Assert.AreEqual(spliced, new List<int>());
			Assert.AreEqual(list, new List<int>{ 1, 2, 3, 4, 5 });
			
			spliced = ListUtils.Splice(list, 1, 2);
			Assert.AreEqual(spliced, new List<int>{ 2, 3 });
			Assert.AreEqual(list, new List<int>{ 1, 4, 5 });
			
			spliced = ListUtils.Splice(list, 2, 1);
			Assert.AreEqual(spliced, new List<int>{ 5 });
			Assert.AreEqual(list, new List<int>{ 1, 4 });
			
			spliced = ListUtils.Splice(list, 0, 2);
			Assert.AreEqual(spliced, new List<int>{ 1, 4 });
			Assert.AreEqual(list, new List<int>());
		}
	}
}