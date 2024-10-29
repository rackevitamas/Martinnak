﻿using Kreata.Backend.Datas.Entities;

namespace Kreata.Backend.Repos
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetAll();
        Task<Student?> GetBy(Guid id);
        Task<bool> Update(Student existingStudent);
    }
}
