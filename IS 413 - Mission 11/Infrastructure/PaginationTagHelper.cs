using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission11_McGuire.Models.ViewModels;

// This will help us build custom <div> tags
namespace Mission11_McGuire.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")] // This is looking for a div with the attribute 'page-model'
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory; // Helps us build the URL we want to use

        // Constructor to make sure we have the URL Helper Factory
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }

        // Collect information for the PaginationTagHelper
        [ViewContext]
        [HtmlAttributeNotBound] // Users won't be able to view the context; it won't be bound to the HTML
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; } // We can get this from cshtml page
        public PaginationInfo PageModel { get; set; } // PageModel comes from page-model attribute in cshtml
        public bool PageClassEnabled { get; set; } = false;
        public string? PageClass { get; set; } = String.Empty;
        public string PageClassNormal { get; set; } = String.Empty;
        public string PageClassSelected { get; set; } = String.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // If we have a ViewContext and a PageModel, we can build the pagination
            if (ViewContext != null && PageModel != null)
            {
                // Create a URL Helper
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                // Build the div tag
                TagBuilder result = new TagBuilder("div");

                // Loop through the number of pages and build the <a> tags
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a"); // Build an <a> tag
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i }); // Set the href attribute to the proper action, and increment the page number

                    // If the page class is enabled, add the class to the tag
                    if (PageClassEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    // Display the tag on the HTML pagae
                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }

                // Output the result to the HTML page
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}