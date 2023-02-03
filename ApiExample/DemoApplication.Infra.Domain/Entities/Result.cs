

namespace DemoApplication.Infra.Domain.Entities
{
    public class Result: Audit
    {
        public int Id { get; set; } 
        public int m1 { get; set; }
        public int m2 { get; set; }
        public int m3 { get; set; }

        public int StudentId { get; set; }

        public string uploadFile { get; set; }
        public virtual Student student { get; set; }

        protected Result()
        {

        }

        public Result(int mark1,int mark2,int mark3,int studId, string uploadfile)
        {
            m1 = mark1;
            m2 = mark2;
            m3 = mark3;
            StudentId = studId;
            uploadFile = uploadfile;
            CreatedOn = DateTime.UtcNow;
            IsDeleted = false;
        }

        public Result Delete()
        {
            IsDeleted = true;
            UpdatedOn = DateTime.UtcNow;

            return this;
        }
        
    }
}
