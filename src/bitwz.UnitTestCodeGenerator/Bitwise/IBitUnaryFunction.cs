namespace bitwz.CodeGenerator.Bitwise
{
    internal interface IBitUnaryFunction
    {
        sbyte Compute(sbyte value);

        byte Compute(byte value);

        char Compute(char value);

        short Compute(short value);

        ushort Compute(ushort value);

        int Compute(int value);

        uint Compute(uint value);

        long Compute(long value);

        ulong Compute(ulong value);
    }
}