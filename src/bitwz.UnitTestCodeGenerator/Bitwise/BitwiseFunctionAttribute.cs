using System;
using System.ComponentModel;

namespace bitwz.CodeGenerator.Bitwise
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class BitwiseFunctionAttribute : Attribute
    {
        internal BitwiseFunctionAttribute(ExpressionKind kind)
        {
            if (!kind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(kind), (int)kind, typeof(ExpressionKind));
            }

            Kind = kind;
            IsUnary = kind.IsUnary();
            Operator = kind.GetBitwiseToken();
        }

        public ExpressionKind Kind
        {
            get;
        }

        public bool IsUnary
        {
            get;
        }

        public string Operator
        {
            get;
        }
    }
}