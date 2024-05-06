using Domain.Models;

namespace Application.Repositories
{
    public interface IJobDetailRepository
    {
        Task AddNewAsync(JobDetails jobDetails);
        Task UpdateAsync(JobDetails jobDetails);
        Task DeleteAsync(JobDetails jobDetails);
        Task<JobDetails> GetByIdAsync(int id);
        Task<List<JobDetails>> GetAllAsync();
        Task PermanentDeleteAsync(JobDetails jobDetails);
    }
}
