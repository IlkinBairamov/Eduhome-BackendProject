﻿using BackendProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.ViewModels
{
    public class SidebarViewModel
    {
        public List<Blog>  Blogs { get; set; }
        public List<Category>  Categories { get; set; }
        public List<Tag>  Tags { get; set; }
    }
}
