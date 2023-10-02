using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services
{
    public class LeaveTypeService:BaseHttpService,ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public LeaveTypeService(IMapper mapper,IClient httpClient, ILocalStorageService localStorageService)
            :base(httpClient, localStorageService)
        {
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public async Task<List<LeaveTypeVm>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVm>>(leaveTypes);
        }

        public async Task<LeaveTypeVm> GetLeaveTypeDetails(int id)
        {
            var leaveType = await _client.LeaveTypesGETAsync(id);
            return  _mapper.Map<LeaveTypeVm>(leaveType);
        }


        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVm leaveType)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDto createLeaveTypeDto =
                    _mapper.Map<CreateLeaveTypeDto>(leaveType);

                //ToDo Auth

                var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveTypeDto);

                if (apiResponse.Success)
                {
                    response.Date = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var err in apiResponse.Errors)
                    {
                        response.ValidationError += err + Environment.NewLine;
                    }
                }

                return response;
            }
            catch (ApiException e)
            {
                return ConvertApiExceptions<int>(e);
            }
            
        }

        public async Task<Response<int>> UpdateLeaveType(int id,LeaveTypeVm leaveType)
        {
            try
            {
                LeaveTypeDto leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
                await _client.LeaveTypesPUTAsync(id, leaveTypeDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException e)
            {
                return ConvertApiExceptions<int>(e);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<int>() { Success = true };

            }
            catch (ApiException e)
            {
                return ConvertApiExceptions<int>(e);
            }
        }
    }
}
