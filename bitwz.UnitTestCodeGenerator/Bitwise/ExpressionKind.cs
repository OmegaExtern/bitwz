namespace bitwz.CodeGenerator.Bitwise
{
    internal enum ExpressionKind
    {
        /// <summary>
        ///     Invalid/Unknown/Other.
        /// </summary>
        None,
        // NOTE: Value is set to "precedence number". In that order of precedence from lowest to highest:
        ReservedBitwiseBegin,
        /// <summary>
        ///     Bitwise OR.
        /// </summary>
        BitwiseOr = 10000,
        /// <summary>
        ///     Bitwise eXclusive OR.
        /// </summary>
        BitwiseXor = 20000,
        /// <summary>
        ///     Bitwise AND.
        /// </summary>
        BitwiseAnd = 30000,
        /// <summary>
        ///     Bitwise Left-Shift.
        /// </summary>
        BitwiseLeftShift = 40000,
        /// <summary>
        ///     Bitwise Right-Shift.
        /// </summary>
        BitwiseRightShift,
        /// <summary>
        ///     Bitwise NOT.
        /// </summary>
        BitwiseNot = 50000,
        ReservedBitwiseEnd
    }
}