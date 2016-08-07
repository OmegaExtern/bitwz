namespace bitwz
{
    public static partial class BitwzMath
    {
        /// <summary>
        ///     Performs a bitwise <c>Or</c> operation on two <see cref="int"/> values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise <c>Or</c> operation.</returns>
        /// <remarks>The bitwise <c>Or</c> operation sets a result bit only if either or both of the corresponding bits in <paramref name="left"/> and <paramref name="right"/> are set, as shown in the following table: <see cref="Properties.Resources.BitwiseOr"/>.</remarks>
        public static int bOr(int left, int right)
        {
            uint result = default(uint);
            for (byte i = 0; i < sizeof(int) * BITS; ++i)
            {
                if ((mod((long)floor((double)left / Pow2[i]), 2L) == 1L) || (mod((long)floor((double)right / Pow2[i]), 2L) == 1L))
                {
                    result += Pow2[i];
                }
            }

            return (int)result;
        }
    }
}