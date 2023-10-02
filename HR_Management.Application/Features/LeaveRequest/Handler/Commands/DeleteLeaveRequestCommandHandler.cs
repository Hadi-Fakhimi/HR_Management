using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Commands
{
    public class DeleteLeaveRequestCommandHandler:IRequestHandler<DeleteLeaveRequestCommand,Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);
            }
            await _leaveRequestRepository.Delete(leaveRequest);
            return Unit.Value;
        }
    }
}
