using JetBrains.Annotations;

namespace bitwz.CodeGenerator.UnitTest
{
    [UnitTestEngine(EngineType.NUnitEngine), UsedImplicitly]
    internal sealed class NUnitEngine : UnitTestEngine
    {
        public override string Equal(string expected, string actual) => "NUnit.Framework.Assert.That(" + actual + ", Is.EqualTo(" + expected + "));";

        public override EngineType Type => EngineType.NUnitEngine;
    }
}