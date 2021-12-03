using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using ProjectBank.Core;
using ProjectBank.Server.Model;

namespace ProjectBank.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentRepository _repository;

        public CommentController(
            ILogger<CommentController> logger,
            ICommentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IReadOnlyCollection<CommentDto>> Get()
            => await _repository.ReadAsync();

        [Authorize]
        [HttpGet("{commentId}", Name = "GetByCommentId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommentDetailsDto>> GetByCommentId(int commentId)
            => (await _repository.ReadAsync(commentId)).ToActionResult();

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(CommentDetailsDto), 201)]
        public async Task<ActionResult<CommentDetailsDto>> Post(CommentCreateDto comment)
        {
            var (status, created) = await _repository.CreateAsync(comment);
            if (status != Status.BadRequest)
            {
                return CreatedAtRoute(nameof(GetByCommentId), new { commentId = created?.Id }, created);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPut("{commentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int commentId, [FromBody] CommentUpdateDto comment)
            => (await _repository.UpdateAsync(commentId, comment)).ToActionResult();

        [Authorize]
        [HttpDelete("{commentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int commentId)
            => (await _repository.DeleteAsync(commentId)).ToActionResult();
    }
}
