using System;
using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Models;
using System.Linq;
using HR_Management.Application.Responses;
using HR_Management.Domain;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Commands
{
    public class CreateLeaveRequestCommandHandler:IRequestHandler<CreateLeaveRequestCommand,BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validatorResult.IsValid == false)
            {
                // throw new ValidationException(validatorResult);

                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();

            }

            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;

            var email = new Email()
            {
                To = "mahdifakhimi98@gmail.com",
                subject = "Leave Request Submit",
                body = $"your leave request for {request.LeaveRequestDto.StartDate}" +
                       $" to {request.LeaveRequestDto.EndDate}" +
                       $"has been submit"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception e)
            {
              //log
            }

            return response;

        }
    }
}
