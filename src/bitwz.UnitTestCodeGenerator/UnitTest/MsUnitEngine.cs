using JetBrains.Annotations;

namespace bitwz.CodeGenerator.UnitTest
{
    [UnitTestEngine(EngineType.MsUnitEngine), UsedImplicitly]
    internal sealed class MsUnitEngine : UnitTestEngine
    {
        public override string Equal(string expected, string actual) => "Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(" + expected + ", " + actual + ");";

        public override EngineType Type => EngineType.MsUnitEngine;
    }
}