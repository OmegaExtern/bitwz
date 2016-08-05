using System;
using System.Runtime.CompilerServices;

namespace bitwz
{
    /// <summary>
    ///     Bitwise (math) library. Home-made (from scratch) implementation of bitwise operations: <c>And</c>, <c>Not</c>,
    ///     <c>Or</c>, <c>XOr</c>, <c>left-shift</c> and <c>right-shift</c>.
    ///     <para />
    ///     Its source code is intended for educational purposes only. It only supports <see cref="int" /> type (might
    ///     add support for other integral types in future).
    /// </summary>
    public static partial class BitwzMath
    {
        /// <summary>
        ///     Number of bits in a byte.
        /// </summary>
        private const byte BITS = 8;
        private const long MOD = 4294967296L, MODM = 4294967295L;
        /// <summary>
        ///     Pre-compiled "Pow(2, n)" array where n is in range from 0 to 31.
        ///     <para />
        ///     Usage: Pow2[n].
        /// </summary>
        private static readonly uint[] Pow2;

        /// <summary>
        ///     Static constructor is used to initialize static data members of <see cref="BitwzMath" /> class.
        /// </summary>
        static BitwzMath()
        {
            Pow2 = new[]
                   {
                       1U, 2U, 4U, 8U, 16U, 32U, 64U, 128U, 256U, 512U, 1024U, 2048U, 4096U, 8192U, 16384U, 32768U, 65536U, 131072U, 262144U, 524288U, 1048576U, 2097152U, 4194304U, 8388608U, 16777216U, 33554432U, 67108864U, 134217728U, 268435456U, 536870912U, 1073741824U, 2147483648U
                   };
        }

        /// <summary>
        ///     Returns the largest integer less than or equal to the specified double-precision floating-point number.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///     The largest integer less than or equal to d. If d is equal to <see cref="double.NaN" />,
        ///     <see cref="double.NegativeInfinity" />, or <see cref="double.PositiveInfinity" />, that value is returned.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double floor(double d) => Math.Floor(d);

        //public static double floor(double d)
        //{
        //    if (double.IsNaN(d) || double.IsNegativeInfinity(d) || double.IsPositiveInfinity(d))
        //    {
        //        return d;
        //    }
        //    double l = (long)d;
        //    return l > d ? l - 1 : l;
        //}

        // pow is not needed any more as it uses pre-compiled array (Pow2).
        //private static int pow(int value, int y)
        //{
        //    int result = value;
        //    for (int i = y; i > 1; --i)
        //    {
        //        result *= value;
        //    }
        //    return result;
        //}

        /// <summary>
        ///     Normalizes a number to the numeric range of bit operations.
        /// </summary>
        /// <param name="value">A number to be normalized.</param>
        /// <returns>A value that has been normalized to the numeric range of bit operations.</returns>
        private static long tobit(long value)
        {
            value = mod(value, MOD);
            if (value < 0x80000000L)
            {
                return value;
            }

            return value - MOD;
        }

        /// <summary>
        ///     Computes the remainder after dividing its first operand by its second.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <param name="divisor">Divisor value.</param>
        /// <returns>Returns the real remainder after division (modulo operation)</returns>
        private static int mod(int dividend, int divisor) => dividend - divisor * (int)floor((double)dividend / divisor);

        /// <summary>
        ///     Computes the remainder after dividing its first operand by its second.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <param name="divisor">Divisor value.</param>
        /// <returns>Returns the real remainder after division (modulo operation)</returns>
        private static long mod(long dividend, long divisor) => dividend - divisor * (long)floor((double)dividend / divisor);

        /// <summary>
        ///     Computes the remainder after dividing its first operand by its second.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <param name="divisor">Divisor value.</param>
        /// <returns>Returns the remainder after division (modulo operation)</returns>
        private static double mod(double dividend, double divisor) => dividend - divisor * floor(dividend / divisor);
    }
}