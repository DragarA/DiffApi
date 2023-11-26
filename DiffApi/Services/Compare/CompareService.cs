using System;
using DiffApi.Entities;
using DiffApi.Models;
using DiffApi.Utils;

namespace DiffApi.Services
{
    public class CompareService : ICompareService
    {
        /// <summary>
        /// Executes the comparison of the base64 decoded strings
        /// </summary>
        /// <param name="diffData">Db entity containing the identifier and 2 data values</param>
        /// <returns>Comparison result alongside with comparison details</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public DiffResponseModel Compare(DiffData diffData)
        {
            if (diffData == null || !diffData.IsValid())
            {
                throw new InvalidOperationException();
            }

            var leftBytes = Convert.FromBase64String(diffData.LeftValue);
            var rightBytes = Convert.FromBase64String(diffData.RightValue);

            var response = new DiffResponseModel();

            if (leftBytes.Length != rightBytes.Length)
            {
                response.DiffResultType = "SizeDoNotMatch";
                return response;
            }

            List<DiffDetailModel> diffs = new List<DiffDetailModel>();


            for (int i = 0; i < leftBytes.Length; i++)
            {
                if (leftBytes[i] != rightBytes[i])
                {
                    int j = i;
                    while (i < leftBytes.Length && leftBytes[i] != rightBytes[i])
                    {
                        i++;
                    }

                    int diffLength = i - j;
                    diffs.Add(new DiffDetailModel { Offset = j, Length = diffLength });
                }
            }

            if(diffs.Count > 0)
            {
                response.Diffs = diffs;
                response.DiffResultType = "ContentDoNotMatch";
            }
            else
            {
                response.DiffResultType = "Equals";
            }

            return response;
        }
    }
}