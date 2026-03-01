namespace Spedia.DataBaseModels
{
    public class LevelTB
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; } = string.Empty;
        //HashSet افضل من List
        //افضل في السرعه و عدم التكرار
        public ICollection<StudentTB> studentTBs { get; set; } = new HashSet<StudentTB>();

    }
}
