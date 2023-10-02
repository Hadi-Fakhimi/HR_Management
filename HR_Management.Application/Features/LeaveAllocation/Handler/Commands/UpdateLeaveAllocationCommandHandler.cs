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
    public class UpdateLeaveAllocationCommandHandler:IRequestHandler<UpdateLeaveAllocationCommand,Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (validatorResult.IsValid == false)
            {
                throw new ValidationException(validatorResult);
            }

            var leaveRequest = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
            _mapper.Map(request.LeaveAllocationDto, leaveRequest);
            await _leaveAllocationRepository.Update(leaveRequest);
            return Unit.Value;
        }
    }
}
