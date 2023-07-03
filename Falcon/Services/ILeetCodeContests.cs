using Falcon.Models;

namespace Falcon.Services
{
    public interface ILeetCodeContests
    {
        Task<Contest?> GetUpComing();
    }
}
