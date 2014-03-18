using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CssDropDownMenu.Models
{
    public class DropDownMenu
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public List<SelectListItem> Items { get; set; }

        public DropDownMenu(string id)
        {
            Id = id;
            Items = new List<SelectListItem>();
        }
    }
}