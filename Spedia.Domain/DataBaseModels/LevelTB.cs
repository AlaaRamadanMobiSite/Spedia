namespace Spedia.DataBaseModels
{
    public class LevelTB
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; } = string.Empty;
        public ICollection<StudentTB> studentTBs { get; set; } = new HashSet<StudentTB>();

    }
}
