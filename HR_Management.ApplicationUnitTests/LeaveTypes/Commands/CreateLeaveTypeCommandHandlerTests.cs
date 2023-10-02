using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Profiles;
using HR_Management.ApplicationUnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR_Management.ApplicationUnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;
        CreateLeaveTypeDto _leaveTypeDto;
        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepository = MockLeaveRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(m =>
                m.AddProfile<MappingProfile>());

            _mapper = mapperConfig.CreateMapper();

            _leaveTypeDto = new CreateLeaveTypeDto()
            {
                DefaultDay = 15,
                Name = "testDto"
            };
        }

        [Fact]
        public async Task CreateLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepository.Object,_mapper);
            var result = await handler.Handle(
                new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto}, CancellationToken.None);
            result.ShouldBeOfType<int>();

            var leaveType = await _mockRepository.Object.GetAll();

            leaveType.Count.ShouldBe(3);
        }
    }
}
