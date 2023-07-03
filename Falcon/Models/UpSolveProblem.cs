namespace Falcon.Models
{
    public class UpSolveProblem
    {
        public int Id { get; set; }
        public required string ProblemURL { get; set; }
        public bool IsSolved { get; set; } = false;
        public bool IsDelayed { get; set; } = false;
        public bool IsFavourite { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}
