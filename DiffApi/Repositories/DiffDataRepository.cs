using System;
using DiffApi.Entities;
using DiffApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiffApi.Repositories
{
    public class DiffDataRepository : IDiffDataRepository
    {
        private readonly AppDbContext dbContext;

        public DiffDataRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DiffData> Save(DiffData entity)
        {
            if (!this.dbContext.DiffData.Any(e => e.Id == entity.Id))
            {
                this.dbContext.DiffData.Add(entity);
            }
            else
            {
                this.dbContext.DiffData.Update(entity);
            }

            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<DiffData?> Get(int id)
        {
            return await this.dbContext.DiffData.FindAsync(id);
        }
    }
}