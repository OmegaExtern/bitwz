namespace bitwz
{
    public static partial class BitwzMath
    {
        /// <summary>
        ///     Shifts a <see cref="int"/> <paramref name="value"/> a specified number of bits to the right.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift <paramref name="value"/> to the right.</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits.</returns>
        public static int bShr(int value, int shift)
        {
            if (shift < 0)
            {
                return bShl(value, -shift);
            }

            return (int)floor(mod((double)value, MOD) / Pow2[shift]);
        }
    }
}