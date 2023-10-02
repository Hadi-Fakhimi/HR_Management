using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Contracts.Persistence;

namespace HR_Management.Application.Features.LeaveAllocation.Handler.Commands
{
    public class DeleteLeaveAllocationCommandHandler:IRequestHandler<DeleteLeaveTypeCommand,Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);
            if (leaveAllocation == null)
            {
                throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);

            }
            await _leaveAllocationRepository.Delete(leaveAllocation);
            return Unit.Value;

        }
    }
}
