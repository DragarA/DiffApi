using System;
using System.ComponentModel.DataAnnotations;
using DiffApi.Utils;

namespace DiffApi.Entities
{
    public class DiffData
    {
        [Key]
        public int Id { get; set; }
        public string? LeftValue { get; set; }
        public string? RightValue { get; set; }

        public DiffData() { }

        public DiffData(int id, DiffSideEnum side, string value)
        {
            this.Id = id;
            SetValueBySide(side, value);
        }

        public void SetValueBySide(DiffSideEnum side, string value)
        {
            if (side == DiffSideEnum.Left)
            {
                this.LeftValue = value;
            }
            else
            {
                this.RightValue = value;
            }
        }

        public Boolean IsValid()
        {
            return this.LeftValue != null && this.RightValue != null;
        }
    }
}