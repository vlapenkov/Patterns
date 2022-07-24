using Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Builder
{
    public class CodeBuilder
    {

        private Dictionary<string, string> Values = new Dictionary<string, string>();

        private string ClassName;

        public CodeBuilder(string className)
        {
            ClassName = className;

        }
        public CodeBuilder AddField(string name, string value)
        {
            Values[name] = value;
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {ClassName}");
            sb.AppendLine("{");
            foreach (var item in Values)
                sb.AppendLine($" public {item.Value} {item.Key};");
            sb.AppendLine("}");
            return sb.ToString();

        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();

            var codeBuilder = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");



            Console.WriteLine(codeBuilder);

            Console.ReadKey();
        }
    }
}
