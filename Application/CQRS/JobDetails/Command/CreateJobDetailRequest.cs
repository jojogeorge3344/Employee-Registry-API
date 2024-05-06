using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.CQRS.JobDetails.Command
{
    public class CreateJobDetailRequest : IRequest<bool>
    {
        public Domain.Models.JobDetails jobDetails { get; set; }
        public CreateJobDetailRequest(Domain.Models.JobDetails jobDetails)
        {
            this.jobDetails = jobDetails;
        }
    }
    public class CreateJobDetailRequestHandler : IRequestHandler<CreateJobDetailRequest, bool> 
    {
        private readonly IJobDetailRepository jobDetailRepository;
        private readonly IMapper mapper;

        public CreateJobDetailRequestHandler(IJobDetailRepository jobDetailRepository, IMapper mapper)
        {
            this.jobDetailRepository = jobDetailRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateJobDetailRequest request, CancellationToken cancellationToken)
        {
            Domain.Models.JobDetails job = mapper.Map<Domain.Models.JobDetails>(request.jobDetails);
            await jobDetailRepository.AddNewAsync(job);

            return true;
        }
    }
}
