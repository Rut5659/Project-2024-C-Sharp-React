using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using OfficeOpenXml;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Services
{
    public class AssignmentService : IAssignmentService
    {
        //private readonly IAssignmentRepository repository;
        private readonly IAssignmentRepository repository;
        private readonly IMapper mapper;
        public AssignmentService(IAssignmentRepository repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }

        public async Task<AssignmentDto> AddItem(AssignmentDto item)
        {
            return mapper.Map<AssignmentDto>(await repository.AddItem(mapper.Map<Assignment>(item)));
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<AssignmentDto>> GetAll()
        {
            return mapper.Map<List<AssignmentDto>>(await repository.getAll());
        }

        public async Task<AssignmentDto> GetById(int id)
        {
            return mapper.Map<AssignmentDto>(await repository.get(id));
        }

        public void UpdateItem(AssignmentDto item, int id)
        {
            repository.UpdateItem(mapper.Map<Assignment>(item), id);
        }

        public async Task<List<AssignmentDto>> ProcessFileAsync(IFormFile file)
        {
            List<AssignmentDto> processedRecords = new List<AssignmentDto>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var stream = file.OpenReadStream())
            using (var package = new ExcelPackage(stream))
            {
                if (package.Workbook.Worksheets.Count == 0)
                {
                    throw new Exception("Excel file does not contain any worksheets.");
                }

                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) 
                {
                 
                    AssignmentDto record = new AssignmentDto
                    {
                        Title = worksheet.Cells[row, 1].Text,
                        Description = worksheet.Cells[row, 2].Text,
                        ProductionDate = DateTime.Parse(worksheet.Cells[row, 3].Text),
                        DueDate = DateTime.Parse(worksheet.Cells[row, 4].Text),
                        Language = worksheet.Cells[row, 5].Text,
                        ProjectId = int.Parse(worksheet.Cells[row, 6].Text),
                        Priority = (AssignmentDto.AssignmentPriority)int.Parse(worksheet.Cells[row, 7].Text),
                        Status = (AssignmentDto.AssignmentStatus)int.Parse(worksheet.Cells[row, 8].Text)
                    };

               
                    await repository.AddItem(mapper.Map<Assignment>(record));

                    processedRecords.Add(record);
                }
            }

            return processedRecords;
        }

        public async Task<List<AssignmentDto>> GetByStatus(Assignment.AssignmentStatus status)
        {
            return mapper.Map<List<AssignmentDto>>(await repository.GetByStatus(status));
        }
    }
    
}
