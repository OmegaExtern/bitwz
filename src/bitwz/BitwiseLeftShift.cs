namespace bitwz
{
    public static partial class BitwzMath
    {
        /// <summary>
        ///     Shifts a <see cref="int"/> <paramref name="value"/> a specified number of bits to the left.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift <paramref name="value"/> to the left.</param>
        /// <returns>A value that has been shifted to the left by the specified number of bits.</returns>
        public static int bShl(int value, int shift)
        {
            if (shift < 0)
            {
                return bShr(value, -shift);
            }

            return value * (int)mod(Pow2[shift], MOD);
        }
    }
}