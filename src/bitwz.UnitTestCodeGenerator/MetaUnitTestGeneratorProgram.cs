using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using bitwz.CodeGenerator.Bitwise;
using bitwz.CodeGenerator.UnitTest;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator
{
    /// <summary>
    ///     Meta program I use to generate unit tests code for <see cref="BitwzMath" /> class (supports MSUnit, NUnit and
    ///     XUnit frameworks).
    /// </summary>
    internal static class MetaUnitTestGeneratorProgram
    {
        // I know.. This design sucks (and is very limited), but it is what I have come up with first.
        // I'll probably improve this a lot, later. This is not finished, it works though. CodeDOM/Roslyn anyone?
        private static readonly int[] Int32Numbers;

        static MetaUnitTestGeneratorProgram()
        {
            Int32Numbers = new[]
                           {
                               -2147483648, -1024741873, -32768, -4096, -255, -127, -92, -1, 0, 1, 92, 127, 255, 4096, 32767, 1073741823, 2147483647
                           };
        }

        [STAThread, UsedImplicitly]
        public static int Main()
        {
            StringBuilder b = new StringBuilder();

            foreach (UnitTestEngine engine in Utility.GetUnitTestEngines()) // Unit Test Engines
            {
                foreach (BitwiseExpression expression in Utility.GetBitwiseExpressions()) // Bitwise Expressions
                {
                    string bitwzName = expression.Kind.GetBitwzName();

                    foreach (int l in Int32Numbers)
                    {
                        expression.LeftOperand = l;
                        if (expression.IsUnary)
                        {
                            //b.AppendLine($"//{engine.Equal(expression.ToString(), expression.Compute<int>().ToString())}");
                            b.AppendLine(engine.Equal(bitwzName + "(" + expression.LeftOperand.Int32 + ")", expression.Compute<int>().ToString()));
                            continue;
                        }

                        foreach (int r in Int32Numbers)
                        {
                            expression.RightOperand = r;
                            //b.AppendLine($"//{engine.Equal(expression.ToString(), expression.Compute<int>().ToString())}");
                            Debug.Assert(expression.RightOperand != null, "expression.RightOperand != null");
                            b.AppendLine(engine.Equal(bitwzName + "(" + expression.LeftOperand.Int32 + ", " + expression.RightOperand.Int32 + ")", expression.Compute<int>().ToString()));
                        }
                    }

                    File.WriteAllText(engine.Type.GetFileNamePrefix(bitwzName.Substring(bitwzName.LastIndexOf('.') + 1)), b.ToString());
                    b.Clear();
                }
            }

            //Console.Read();
            return 0;
        }
    }
}