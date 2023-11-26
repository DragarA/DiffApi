using System;
using DiffApi.Entities;
using DiffApi.Utils;

namespace DiffApi.Repositories
{
    public interface IDiffDataRepository
    {
        Task<DiffData> Save(DiffData entity);
        Task<DiffData?> Get(int id);
    }
}