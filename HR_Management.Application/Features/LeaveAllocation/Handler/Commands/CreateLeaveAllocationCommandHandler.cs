using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveAllocation.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocation.Handler.Commands
{
    public class CreateLeaveAllocationCommandHandler:IRequestHandler<CreateLeaveAllocationCommand,int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (validatorResult.IsValid == false)
            {
                throw new ValidationException(validatorResult);
            }
            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.LeaveAllocationDto);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
