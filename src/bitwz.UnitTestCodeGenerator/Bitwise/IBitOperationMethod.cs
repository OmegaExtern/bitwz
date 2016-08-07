using System.Reflection;

namespace bitwz.CodeGenerator.Bitwise
{
    internal interface IBitOperationMethod
    {
        MethodInfo Get_SByte();

        MethodInfo Get_Byte();

        MethodInfo Get_Char();

        MethodInfo Get_Int16();

        MethodInfo Get_UInt16();

        MethodInfo Get_Int32();

        MethodInfo Get_UInt32();

        MethodInfo Get_Int64();

        MethodInfo Get_UInt64();
    }
}