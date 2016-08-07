using JetBrains.Annotations;

namespace bitwz.CodeGenerator.UnitTest
{
    [UnitTestEngine(EngineType.XUnitEngine), UsedImplicitly]
    internal sealed class XUnitEngine : UnitTestEngine
    {
        public override string Equal(string expected, string actual) => "Xunit.Assert.Equal(" + expected + ", " + actual + ");";

        public override EngineType Type => EngineType.XUnitEngine;
    }
}