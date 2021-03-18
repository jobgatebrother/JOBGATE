using JOBGATE.Models.SearchListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class BlogViewModel
    {

        public IEnumerable<CPN_JobPosting> Blogs { get; set; }
        public int BlogPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Blogs.Count() / (double)BlogPerPage));
        }
        public IEnumerable<CPN_JobPosting> PaginatedBlogs()
        {
            int start = (CurrentPage - 1) * BlogPerPage;
            return Blogs.OrderBy(b => b.ID).Skip(start).Take(BlogPerPage);
            //return Blogs.Skip(start).Take(BlogPerPage).ToList();
        }
    }
}
