using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models.DBObjects;
using HairStyleBookingApp.Models;

namespace HairStyleBookingApp.Repository
{
    public class PostRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public PostRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public PostRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private PostModel MapDBObjectToModel(Post dbobject)
        {
            var model = new PostModel();
            if (dbobject != null)
            {
                model.IdPost = dbobject.IdPost;
                model.IdEmployee = dbobject.IdEmployee;
                model.Date = dbobject.Date;
                model.Title = dbobject.Title;
                model.Text = dbobject.Text;

            }
            return model;
        }
        private Post MapModelToDBObject(PostModel model)
        {
            var dbobject = new Post();
            if (model != null)
            {
                dbobject.IdPost = model.IdPost;
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.Date = model.Date;
                dbobject.Title = model.Title;
                dbobject.Text = model.Text;


            }
            return dbobject;
        }
        public List<PostModel> GetAllPosts()
        {
            var list = new List<PostModel>();
            foreach (var dbobject in _DBContext.Posts)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }
        public PostModel GetPostById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Posts.FirstOrDefault(x => x.IdPost == id));

        }

        public void InsertPost(PostModel model)
        {
            model.IdPost = Guid.NewGuid();
            _DBContext.Posts.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdatePost(PostModel model)
        {
            var dbobject = _DBContext.Posts.FirstOrDefault(x => x.IdPost == model.IdPost);

            if (dbobject != null)
            {
                dbobject.IdPost = model.IdPost;
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.Date = model.Date;
                dbobject.Title = model.Title;
                dbobject.Text = model.Text;

                _DBContext.SaveChanges();
            }
        }
        public void DeletePost(Guid id)
        {
            var dbobject = _DBContext.Posts.FirstOrDefault(x => x.IdPost == id);
            if (dbobject != null)
            {
                _DBContext.Posts.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
        
}
