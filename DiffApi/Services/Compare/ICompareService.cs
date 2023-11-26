using System;
using DiffApi.Utils;
using DiffApi.Entities;
using DiffApi.Models;

namespace DiffApi.Services
{
    public interface ICompareService
    {
        public DiffResponseModel Compare(DiffData diffData);

    }
}