using System;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator.Bitwise
{
    internal static class TypeExtensions
    {
        internal static bool IsBitwiseExpression([NotNull] this Type type)
        {
            if ((type == typeof(BitwiseAndExpression)) || (type == typeof(BitwiseLeftShiftExpression)) || (type == typeof(BitwiseNotExpression)) || (type == typeof(BitwiseOrExpression)) || (type == typeof(BitwiseRightShiftExpression)) || (type == typeof(BitwiseXorExpression)))
            {
                return true;
            }

            BitwiseFunctionAttribute bitwiseFunctionAttribute = (BitwiseFunctionAttribute)Attribute.GetCustomAttribute(type, typeof(BitwiseFunctionAttribute));
            if ((bitwiseFunctionAttribute == null) || !bitwiseFunctionAttribute.Kind.IsBitwise())
            {
                return false;
            }
            
            return type.IsSealed && (type.BaseType == typeof(BitwiseExpression)) && (typeof(IBitFunction).IsAssignableFrom(type) || typeof(IBitUnaryFunction).IsAssignableFrom(type));
        }
    }
}