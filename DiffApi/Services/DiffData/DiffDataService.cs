using System;
using DiffApi.Entities;
using DiffApi.Repositories;
using DiffApi.Utils;

namespace DiffApi.Services
{
    public class DiffDataService: IDiffDataService
    {
        private readonly IDiffDataRepository diffDataRepository;

        public DiffDataService(IDiffDataRepository diffDataRepository)
        {
            this.diffDataRepository = diffDataRepository;
        }

        public async Task CreateOrUpdate(int id, DiffSideEnum side, string value)
        {
            var entity = await this.GetById(id);

            if(entity != null)
            {
                entity.SetValueBySide(side, value);
            }
            else
            {
                entity = new DiffData(id, side, value);
            }

            await this.diffDataRepository.Save(entity);
        }

        public async Task<DiffData?> GetById(int id)
        {
            return await this.diffDataRepository.Get(id);
        }
    }
}