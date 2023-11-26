using System.Net;
using System.Reflection;
using DiffApi.Models;
using DiffApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiffApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class DiffController : ControllerBase
{
    private readonly IDiffDataService diffDataService;
    private readonly ICompareService compareService;

    public DiffController(IDiffDataService diffDataService, ICompareService compareService)
    {
        this.diffDataService = diffDataService;
        this.compareService = compareService;
    }

    [HttpPut("{id}/left")]
    public async Task<IActionResult> PutLeft(DiffRequestModel model, [FromRoute] int id)
    {
        await this.diffDataService.CreateOrUpdate(id, Utils.DiffSideEnum.Left, model.Data);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id}/right")]
    public async Task<IActionResult> PutRight(DiffRequestModel model, [FromRoute] int id)
    {
        await this.diffDataService.CreateOrUpdate(id, Utils.DiffSideEnum.Right, model.Data);
        return StatusCode(StatusCodes.Status201Created);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var diffDataEntity = await this.diffDataService.GetById(id);

        if (diffDataEntity == null || !diffDataEntity.IsValid())
        {
            return NotFound();
        }

        var response = this.compareService.Compare(diffDataEntity);

        return Ok(response);
    }
}