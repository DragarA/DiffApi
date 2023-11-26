using System;
namespace DiffApi.Models
{
    public class DiffResponseModel
    {
        public string DiffResultType { get; set; }
        public List<DiffDetailModel>? Diffs { get; set; }
    }

    public class DiffDetailModel
    {
        public int Offset { get; set; }
        public int Length { get; set; }
    }
}