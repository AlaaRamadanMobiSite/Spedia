namespace Spedia.DataBaseModels
{
    public class StudentTB
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set;} = string.Empty;
        public string StudentPass { get; set; } = string.Empty;
        public int LevelId { get; set; }
        public string StudentImage { get; set; } = string.Empty;
        public LevelTB Level { get; set; } = default!;

    }
}
