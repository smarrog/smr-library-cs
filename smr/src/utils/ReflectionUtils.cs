using System;

namespace smr.utils {
	public class ReflectionUtils {
		public static bool IsDerivedFrom<T>(T elem, Type t) {
			return elem != null && t.IsInstanceOfType(elem);
		}
		
		public static bool HasFieldOrProperty<T>(T elem, string key) {
			return elem.GetType().GetField(key) != null || elem.GetType().GetProperty(key) != null;
		}

		public static object GetFieldOrPropertyValue<T>(T elem, string key) {
			var fieldInfo = elem.GetType().GetField(key);
			if (fieldInfo != null) {
				return fieldInfo.GetValue(elem);
			}
			var propertyInfo = elem.GetType().GetProperty(key);
			if (propertyInfo != null) {
				return propertyInfo.GetValue(elem);
			}
			throw new Exception("No field or property: " + key);
		}

		public static void SetFieldOrProperty<T>(T elem, string key, object value) {
			var fieldInfo = elem.GetType().GetField(key);
			if (fieldInfo != null) {
				fieldInfo.SetValue(elem, value);
				return;
			}
			var propertyInfo = elem.GetType().GetProperty(key);
			if (propertyInfo != null) {
				propertyInfo.SetValue(elem, value);
				return;
			}
			throw new Exception("No field or property: " + key);
		}
	}
}