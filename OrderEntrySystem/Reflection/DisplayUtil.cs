using OrderEntryEngine;
using OrderEntrySystem;
using System.Reflection;

namespace OrderEntrySystem
{
    public static class DisplayUtil
    {
        public static string GetControlDescription(MemberInfo memberInfo)
        {
            string result = ReflectionUtil.GetAttributePropertyValueAsString(memberInfo, typeof(EntityControlAttribute), "Description");

            if (result == null || result == string.Empty)
            {
                result = memberInfo.Name.ToString();
            }

            return result;
        }

        public static int GetControlSequence(MemberInfo memberInfo)
        {
            int result = (int)ReflectionUtil.GetAttributePropertyValue(memberInfo, typeof(EntityControlAttribute), "Sequence");



            return result;
        }



        public static string GetColumnDescription(MemberInfo memberInfo)
        {
            string result = ReflectionUtil.GetAttributePropertyValueAsString(memberInfo, typeof(EntityColumnAttribute), "Description");

            if (result == null || result == string.Empty)
            {
                result = memberInfo.Name.ToString();
            }

            return result;
        }

        public static int GetColumnSequence(MemberInfo memberInfo)
        {
            int result = (int)ReflectionUtil.GetAttributePropertyValue(memberInfo, typeof(EntityColumnAttribute), "Sequence");



            return result;
        }

        public static int GetColumnWidth(MemberInfo memberInfo)
        {
            int result = (int)ReflectionUtil.GetAttributePropertyValue(memberInfo, typeof(EntityColumnAttribute), "Width");


            return result;
        }

        







        public static ControlType GetControlType(PropertyInfo propertyInfo)
        {
            object result = ReflectionUtil.GetAttributePropertyValue(propertyInfo, typeof(EntityControlAttribute), "ControlType");

            if (result == null)
            {
                result = ControlType.None;
            }

            return (ControlType)result;
        }

        public static string GetFieldDescription(MemberInfo memberInfo)
        {
            string result = ReflectionUtil.GetAttributePropertyValueAsString(memberInfo, typeof(EntityDescriptionAttribute), "Description");

            if (result == null || result == string.Empty)
            {
                result = memberInfo.Name.ToString();
            }

            return result;
        }

        public static bool HasColumn(MemberInfo memberInfo)
        {
            return ReflectionUtil.HasAttribute(memberInfo, typeof(EntityColumnAttribute));
        }

        public static bool HasControl(MemberInfo memberInfo)
        {
            return ReflectionUtil.HasAttribute(memberInfo, typeof(EntityControlAttribute));
        }
    }
}
