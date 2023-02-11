namespace CSharpToTSConverter
{
    public class Field
    {
        public string Name { get; }
        public string Type { get; }
        public bool Nullable { get; }
        public Field(string name, string type, bool nullable) 
        {
            Name = name;
            Type = type;
            Nullable = nullable;
        }

        public string ToTs() => $"{Name}{(Nullable ? '?' : "")}: {Type}";
    }
}
