namespace Game_GuessTheNumber.Models
{
    public class GameRule
    {
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
        public int MaxAttemptCount { get; set; }
        public int TheNumber { get; set; }
    }
}
