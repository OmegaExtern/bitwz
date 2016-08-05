using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator
{
    internal static class TypeExtensions
    {
        [NotNull]
        internal static IEnumerable<T> GetEnumValues<T>([NotNull] this Type enumType) where T : struct, IComparable, IConvertible, IFormattable
        {
            if (enumType == null)
            {
                throw new ArgumentNullException(nameof(enumType));
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type provided must be an " + typeof(Enum).Name + ".", nameof(enumType));
            }
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type provided must be an " + typeof(Enum).Name + ".", nameof(T));
            }

            return (T[])Enum.GetValues(enumType);
        }

        internal static bool IsIntegral(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Char:
                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }
    }
}