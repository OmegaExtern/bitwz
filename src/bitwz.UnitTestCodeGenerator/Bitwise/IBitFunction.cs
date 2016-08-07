namespace bitwz.CodeGenerator.Bitwise
{
    internal interface IBitFunction
    {
        sbyte Compute(sbyte leftValue, sbyte rightValue);

        byte Compute(byte leftValue, byte rightValue);

        char Compute(char leftValue, char rightValue);

        short Compute(short leftValue, short rightValue);

        ushort Compute(ushort leftValue, ushort rightValue);

        int Compute(int leftValue, int rightValue);

        uint Compute(uint leftValue, uint rightValue);

        long Compute(long leftValue, long rightValue);

        ulong Compute(ulong leftValue, ulong rightValue);
    }
}