using HealthJang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthJang.ViewModels
{
    public class DetailViewModel
    {
        public Board board { get; set; }

        public List<Comment> comments { get; set; }
    }
}