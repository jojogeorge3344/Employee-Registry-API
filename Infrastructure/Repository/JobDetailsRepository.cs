using Application.Repositories;
using Domain.Models;
using Infrastructure.Cotexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class JobDetailsRepository : IJobDetailRepository
    {
        private readonly ApplicationDbContext dbConnection;

        public JobDetailsRepository(ApplicationDbContext dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task AddNewAsync(JobDetails jobDetails)
        {
            await dbConnection.AddAsync(jobDetails);
            await dbConnection.SaveChangesAsync();
        }

        public Task DeleteAsync(JobDetails jobDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobDetails>> GetAllAsync()
        {
            return await dbConnection.JobDetails.ToListAsync();
        }

        public async Task<JobDetails> GetByIdAsync(int id)
        {
            return await dbConnection.JobDetails
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task PermanentDeleteAsync(JobDetails jobDetails)
        {
            dbConnection.JobDetails.Remove(jobDetails);
            await dbConnection.SaveChangesAsync();
        }

        public async Task UpdateAsync(JobDetails jobDetails)
        {
            dbConnection.JobDetails.Update(jobDetails);
            await dbConnection.SaveChangesAsync();
        }
    }
}
