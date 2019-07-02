using NUnit.Framework;
using smr.utils;

namespace smr.Tests.utils {
	[TestFixture]
	public class ReflectionUtilsTests {
		[Test]
		public void IsDerivedFromTest() {
			Assert.False(ReflectionUtils.IsDerivedFrom<B>(null, typeof(B)));
			Assert.False(ReflectionUtils.IsDerivedFrom(new A(), typeof(B)));
			Assert.True(ReflectionUtils.IsDerivedFrom(new B(), typeof(B)));
			Assert.True(ReflectionUtils.IsDerivedFrom(new C(), typeof(B)));
		}

		[Test]
		public void HasFieldOrPropertyTest() {
			Assert.Catch(() => ReflectionUtils.HasFieldOrProperty<Foo>(null, "V1"));
			var elem = new Foo();
			Assert.False(ReflectionUtils.HasFieldOrProperty(elem, "Method"));
			Assert.True(ReflectionUtils.HasFieldOrProperty(elem, "Field"));
			Assert.True(ReflectionUtils.HasFieldOrProperty(elem, "Prop"));
		}
		
		[Test]
		public void GetFieldOrPropertyTest() {
			Assert.Catch(() => ReflectionUtils.GetFieldOrPropertyValue<Foo>(null, "V1"));
			var elem = new Foo {Field = 1, Prop = 2};
			Assert.Catch(() => ReflectionUtils.GetFieldOrPropertyValue(elem, "Method"));
			Assert.AreEqual(ReflectionUtils.GetFieldOrPropertyValue(elem, "Field"), 1);
			Assert.AreEqual(ReflectionUtils.GetFieldOrPropertyValue(elem, "Prop"), 2);
		}
		
		[Test]
		public void SetFieldOrPropertyTest() {
			Assert.Catch(() => ReflectionUtils.SetFieldOrProperty<Foo>(null, "V1", 1));
			var elem = new Foo();
			Assert.Catch(() => ReflectionUtils.SetFieldOrProperty(elem, "Method", 1));
			Assert.Catch(() => ReflectionUtils.SetFieldOrProperty(elem, "Field", "not integer"));
			ReflectionUtils.SetFieldOrProperty(elem, "Field", 1);
			Assert.AreEqual(elem.Field, 1);
			ReflectionUtils.SetFieldOrProperty(elem, "Prop", 2);
			Assert.AreEqual(elem.Prop, 2);
		}

		private class Foo {
			public int Field;
			public int Prop { get; set; }

			public void Method() {
			}

			public Foo() {
				Method();
			}
		}

		class A {}
		class B : A {}
		class C : B { }
	}
}