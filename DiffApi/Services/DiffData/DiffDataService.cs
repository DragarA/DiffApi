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

        /// <summary>
        /// Saves the request data into the database under the correct identifier. If the identifier exists, the records gets updated.
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="side">Type of data value</param>
        /// <param name="value">Data value in base64 encoded string</param>
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

        /// <summary>
        /// Retrieves the entity from the database by the identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DiffData entity</returns>
        public async Task<DiffData?> GetById(int id)
        {
            return await this.diffDataRepository.Get(id);
        }
    }
}