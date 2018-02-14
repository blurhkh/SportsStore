using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Infrastructure
{
    [HtmlTargetElement("pagination")]
    public class PaginationTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public string FirstText { get; set; }

        public string LastText { get; set; }

        public string PreviousText { get; set; }

        public string NextText { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; }
            = new Dictionary<string, object>();

        private readonly IUrlHelperFactory _urlHelperFactory;

        public PaginationTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // 这句话的意义在于，会下面生成链接的时候，会根据路由配置的不同生成不同的链接
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            bool isFirstPage = PageModel.CurrentPage == 1;
            bool isLastPage = PageModel.CurrentPage == PageModel.TotalPages;

            // 如果设置了首页按钮
            if (!string.IsNullOrEmpty(PreviousText))
            {
                var pageItem = CreatePageItem(urlHelper, 1, FirstText, false, isFirstPage);
                output.Content.AppendHtml(pageItem);
            }

            // 如果设置了上一页按钮
            if (!string.IsNullOrEmpty(PreviousText))
            {
                var pageItem = CreatePageItem(urlHelper, PageModel.CurrentPage - 1, PreviousText, false, isFirstPage);
                output.Content.AppendHtml(pageItem);
            }

            // 输出的时候就是一个ul了
            output.TagName = "ul";
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                var pageItem = CreatePageItem(urlHelper,
                    i, i.ToString(), PageModel.CurrentPage == i);
                output.Content.AppendHtml(pageItem);
            }

            // 如果设置了下一页按钮
            if (!string.IsNullOrEmpty(NextText))
            {
                var pageItem = CreatePageItem(urlHelper, PageModel.CurrentPage + 1, NextText, false, isLastPage);
                output.Content.AppendHtml(pageItem);
            }

            // 如果设置了末页按钮
            if (!string.IsNullOrEmpty(PreviousText))
            {
                var pageItem = CreatePageItem(urlHelper, PageModel.PageSize, LastText, false, isLastPage);
                output.Content.AppendHtml(pageItem);
            }
        }

        private TagBuilder CreatePageItem(
            IUrlHelper urlHelper,
            int productPage,
            string text,
            bool active,
            bool disabled = false)
        {
            var li = new TagBuilder("li");
            li.AddCssClass("page-item");

            if (active)
            {
                li.AddCssClass("active");
            }

            if (disabled)
            {
                li.AddCssClass("disabled");
            }

            var a = new TagBuilder("a");
            a.AddCssClass("page-link");

            PageUrlValues["productPage"] = productPage;

            if (!disabled)
            {
                a.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            }

            a.InnerHtml.Append(text);
            li.InnerHtml.AppendHtml(a);

            return li;
        }
    }
}
