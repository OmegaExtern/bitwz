namespace bitwz
{
    public static partial class BitwzMath
    {
        /// <summary>
        ///     Performs a bitwise exclusive Or (<c>XOr</c>) operation on two <see cref="int"/> values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise exclusive Or (<c>XOr</c>) operation.</returns>
        /// <remarks>The result of a bitwise exclusive Or (<c>XOr</c>) operation is <c>true</c> if the values of the two bits are different; otherwise, it is <c>false</c>. The following table illustrates the exclusive Or operation: <see cref="Properties.Resources.BitwiseXOr"/>.</remarks>
        public static int bXor(int left, int right)
        {
            uint result = default(uint);
            for (byte i = 0; i < sizeof(int) * BITS; ++i)
            {
                if (mod(left, 2) == 0)
                {
                    if (mod(right, 2) == 1)
                    {
                        right -= 1;
                        result += Pow2[i];
                    }
                }
                else
                {
                    left -= 1;
                    if (mod(right, 2) == 0)
                    {
                        result += Pow2[i];
                    }
                    else
                    {
                        right -= 1;
                    }
                }
                right /= 2;
                left /= 2;
            }

            return (int)result;
        }
    }
}