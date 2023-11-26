using System;
using DiffApi.Entities;
using DiffApi.Utils;

namespace DiffApi.Services
{
    public interface IDiffDataService
    {
        Task<DiffData?> GetById(int id);
        Task CreateOrUpdate(int id, DiffSideEnum side, string value);
    }
}