namespace bitwz
{
    public static partial class BitwzMath
    {
        /// <summary>
        ///     Returns the bitwise one's complement of a <see cref="int"/> value.
        /// </summary>
        /// <param name="value">An integer value.</param>
        /// <returns>The result of the bitwise one's complement of <paramref name="value"/>.</returns>
        /// <remarks>The bitwise one's complement operator reverses each bit in a numeric value. That is, bits in <paramref name="value"/> that are 0 are set to 1 in the result, and bits that are 1 are set to 0 in the result. The following table illustrates the bitwise one's complement operation: <see cref="Properties.Resources.BitwiseNot"/>.</remarks>
        public static int bNot(int value) => (int)tobit(MODM - mod(value, MOD));
    }
}