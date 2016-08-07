using System;
using System.ComponentModel;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator.Bitwise
{
    internal static class BitwiseExtensions
    {
        [NotNull]
        internal static string GetBitwiseToken(this ExpressionKind expressionKind)
        {
            if (!expressionKind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(expressionKind), (int)expressionKind, typeof(ExpressionKind));
            }

            switch (expressionKind)
            {
                case ExpressionKind.BitwiseAnd:
                    return "&";
                case ExpressionKind.BitwiseLeftShift:
                    return "<<";
                case ExpressionKind.BitwiseNot:
                    return "~";
                case ExpressionKind.BitwiseOr:
                    return "|";
                case ExpressionKind.BitwiseRightShift:
                    return ">>";
                case ExpressionKind.BitwiseXor:
                    return "^";
                default:
                    throw new ArgumentOutOfRangeException(nameof(expressionKind), expressionKind, null);
            }
        }

        [NotNull]
        internal static string GetBitwzName(this ExpressionKind expressionKind)
        {
            if (!expressionKind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(expressionKind), (int)expressionKind, typeof(ExpressionKind));
            }

            switch (expressionKind)
            {
                case ExpressionKind.BitwiseAnd:
                    return typeof(BitwzMath).FullName + "." + nameof(BitwzMath.bAnd);
                case ExpressionKind.BitwiseLeftShift:
                    return typeof(BitwzMath).FullName + "." + nameof(BitwzMath.bShl);
                case ExpressionKind.BitwiseNot:
                    return typeof(BitwzMath).FullName + "." + nameof(BitwzMath.bNot);
                case ExpressionKind.BitwiseOr:
                    return typeof(BitwzMath).FullName + "." + nameof(BitwzMath.bOr);
                case ExpressionKind.BitwiseRightShift:
                    return typeof(BitwzMath).FullName + "." + nameof(BitwzMath.bShr);
                case ExpressionKind.BitwiseXor:
                    return typeof(BitwzMath).FullName + "." + nameof(BitwzMath.bXor);
                default:
                    throw new ArgumentOutOfRangeException(nameof(expressionKind), expressionKind, null);
            }
        }

        internal static bool HasEqualPrecedenceAs(this ExpressionKind expressionKind, ExpressionKind otherExpressionKind)
        {
            if (!expressionKind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(expressionKind), (int)expressionKind, typeof(ExpressionKind));
            }
            if (!otherExpressionKind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(otherExpressionKind), (int)otherExpressionKind, typeof(ExpressionKind));
            }

            return Math.Abs((int)expressionKind - (int)otherExpressionKind) < 5000;
        }

        internal static bool HasHigherPrecedenceThan(this ExpressionKind expressionKind, ExpressionKind otherExpressionKind)
        {
            if (!expressionKind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(expressionKind), (int)expressionKind, typeof(ExpressionKind));
            }
            if (!otherExpressionKind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(otherExpressionKind), (int)otherExpressionKind, typeof(ExpressionKind));
            }

            return (Math.Abs((int)expressionKind - (int)otherExpressionKind) >= 5000) && ((int)expressionKind > (int)otherExpressionKind);
        }

        internal static bool HasLowerPrecedenceThan(this ExpressionKind expressionKind, ExpressionKind otherExpressionKind)
        {
            if (!expressionKind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(expressionKind), (int)expressionKind, typeof(ExpressionKind));
            }
            if (!otherExpressionKind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(otherExpressionKind), (int)otherExpressionKind, typeof(ExpressionKind));
            }

            return (Math.Abs((int)expressionKind - (int)otherExpressionKind) >= 5000) && ((int)expressionKind < (int)otherExpressionKind);
        }

        internal static bool IsBitwise(this ExpressionKind expressionKind)
        {
            if (!Enum.IsDefined(typeof(ExpressionKind), expressionKind))
            {
                throw new InvalidEnumArgumentException(nameof(expressionKind), (int)expressionKind, typeof(ExpressionKind));
            }

            return ((int)expressionKind > (int)ExpressionKind.ReservedBitwiseBegin) && ((int)expressionKind < (int)ExpressionKind.ReservedBitwiseEnd);
        }

        internal static bool IsUnary(this ExpressionKind expressionKind)
        {
            if (!expressionKind.IsBitwise())
            {
                throw new InvalidEnumArgumentException(nameof(expressionKind), (int)expressionKind, typeof(ExpressionKind));
            }

            return expressionKind == ExpressionKind.BitwiseNot;
        }
    }
}