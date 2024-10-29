using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class StudentRepo : IStudentRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public StudentRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student?> GetBy(Guid id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Student>> GetAll()
        {
            int count = _dbContext.Students.Count();
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<bool> Update(Student student)
        {
            _dbContext.Students.Update(student);
            var changes = await _dbContext.SaveChangesAsync();
            return changes > 0;
        }
    }
}
