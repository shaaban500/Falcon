using Falcon.Models;

namespace Falcon.Services
{
    public interface ICodeforcesContests
    {
        Task<Contest?> GetUpComing();
    }
}
