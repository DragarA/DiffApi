using System;
using System.ComponentModel.DataAnnotations;

namespace DiffApi.Models
{
    public class DiffRequestModel
    {
        [Required]
        [MinLength(1)]
        public string Data { get; set; }
    }
}