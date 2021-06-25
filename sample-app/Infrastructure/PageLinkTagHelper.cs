using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Infrastructure
{
    // Generate Link 1..2..3
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        // Tag Helpers used  IUrlHelperFactory  Object to Generate URL
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        // Object that provides access to HttpContext, Request and Response
        // Need to Set [ViewContext ] In order to gain such access
        [ViewContext]

        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; } // @Model.PagingInfo
        public string PageAction { get; set; }//page-action="Index"
        // TagHelperContext : Get the information Related execution of TagHelper 
        // TAgHelperOutput : Represents output of the tagHlper
        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            // Current ITagHelper Information  for the request associated with context
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            //  Build URLs
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                // Index/1 .. Index/2 .. Index /3 
                tag.Attributes["href"] = urlHelper.Action(PageAction,
                new { productpage = i });
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml); // Link 1..2..4
        }
    }
}
