using ProjectBank.Core;

namespace ProjectBank.Infrastructure
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IProjectBankContext _context;

        public CommentRepository(IProjectBankContext context)
        {
            _context = context;
        }

        public async Task<(Status, CommentDetailsDto?)> CreateAsync(CommentCreateDto comment)
        {
            if (comment.Content.Trim().Equals(""))
            {
                return (BadRequest, null);
            }
            var entity = new Comment
            {
                Content = comment.Content,
                User = await GetUserAsync(comment.UserId),
                DateAdded = DateTime.Now
            };
            var postEntity = await _context.Posts.FirstOrDefaultAsync(c => c.Id == comment.postid);
            if (postEntity == null)
            {
                return (BadRequest, null);
            }
            /*_context.Comments.Add(entity);*/
            postEntity.Comments.Add(entity);
            await _context.SaveChangesAsync();

            return (Created, new CommentDetailsDto(
                                 entity.Id,
                                 entity.Content,
                                 entity.DateAdded,
                                 entity.User.oid
                             ));
        }

        public Task<Status> UpdateAsync(int commentId, CommentUpdateDto comment)
        {
            throw new NotImplementedException();
        }

        public async Task<Option<CommentDetailsDto>> ReadAsync(int postId, int commentId){
            var c = (await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId))?.Comments.FirstOrDefault(c => c.Id == commentId);
            if (c == null) return null;
            return new CommentDetailsDto(
                c.Id,
                c.Content,
                c.DateAdded,
                c.User.oid
            );
        }

        /*public async Task<IReadOnlyCollection<CommentDto>> ReadAsync() =>
            (await _context.Comments
                           .Select(c => new CommentDto(
                               c.Id,
                               c.Content,
                               c.DateAdded,
                               c.User.oid
                            ))
                           .ToListAsync())
                           .AsReadOnly();

        public async Task<Status> UpdateAsync(int id, CommentUpdateDto comment)
        {
            var entity = await _context.Comments.FirstOrDefaultAsync(c => c.Id == comment.Id);

            if (entity == null)
            {
                return NotFound;
            }
            entity.Content = comment.Content;
            await _context.SaveChangesAsync();

            return Updated;
        }*/

        public async Task<Status> DeleteAsync(int postId, int commentId)
        {
            var postEntity = await _context.Posts.FindAsync(postId);

            if (postEntity == null)
            {
                return BadRequest;
            }

            var entity = postEntity.Comments.First(c => c.Id == commentId);
            postEntity.Comments.Remove(entity);
            await _context.SaveChangesAsync();

            return Deleted;
        }

        private async Task<User> GetUserAsync(string userId) =>
            await _context.Users.FirstAsync(u => u.oid == userId);
    }
}
