using JetBrains.Annotations;

namespace bitwz.CodeGenerator.UnitTest
{
    internal interface IUnitTestEngine
    {
        [NotNull]
        string Equal([NotNull] string expected, [NotNull] string actual);
    }
}