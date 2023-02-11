using System.Text;

namespace CSharpToTSConverter
{
    public static class Converter
    {
        static readonly string[] _numberTypes = { "int", "double", "decimal" };

        public static string ReadClass(string path, string name)
        {
            var lines = File.ReadAllLines(path).ToList();

            var start = lines.FindIndex(x => x.Contains("class")) + 2;
            name = string.IsNullOrEmpty(name) ? lines[start - 2].Trim().Split(' ')[2] : name;
            var end = lines.FindLastIndex(x => x.Contains('}')) - 1;

            var classLines = lines.GetRange(start, end - start);

            var fields = classLines.Select(line =>
            {
                line = line.Trim();
                var words = line.Split(' ');
                var name = char.ToLower(words[2][0]) + words[2][1..];
                var type = char.ToLower(words[1][0]) + words[1][1..].Replace("?", "");

                type = CheckType(type);

                return new Field(name, type, line.Contains('?'));
            });

            var builder = new StringBuilder();
            builder.AppendLine("export default interface " + name + " {");
            foreach (var field in fields)
            {
                builder.AppendLine($"\t{field.ToTs()}");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }

        private static string CheckType(string type)
        {
            if (_numberTypes.Contains(type))
            {
                return "number";
            }

            if (type.Contains("Enumerable"))
            {
                var start = type.IndexOf('<') + 1;
                var end = type.LastIndexOf('>');

                var innerType = type[start..end];

                innerType = CheckType(innerType);

                return innerType + "[]";
            }

            return type;
        }
    }
}
