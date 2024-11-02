using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.NewsArticlePage
{
    public class DeleteModel : PageModel
    {
        private readonly INewsArticleRepository _newArticleRepository;
        private readonly ITagRepository _tagRepository;

        public DeleteModel()
        {
            _newArticleRepository = new NewsArticleRepository();
            _tagRepository = new TagRepository();
        }

        [BindProperty]
        public NewsArticle newsArticle { get; set; }
        [BindProperty]
        public List<Tag> listTag { get; set; }


        public async Task OnGet(string id)
        {
            await LoadData(id);
        }
        public async Task OnPostDeleteNews(string id)
        {
            listTag = await _tagRepository.GetTagByArticleId(id);
            if (listTag.Any())
            {
                TempData["Message"] = "Please delete all tags to delete new";
                return;
            }
            else
            {
                await _newArticleRepository.DeleteNew(id);
                TempData["Message"] = "The new is detele successful";
                return;
            }
        }

        public async Task OnPostDeleteTag(string id)
        {
            await _tagRepository.DeleteAllTag(id);
            await LoadData(id);
            TempData["Message"] = "Clear tag successful";
        }

        public async Task LoadData(string newsArticleId)
        {

            newsArticle = await _newArticleRepository.GetNewsById(newsArticleId);

            if (newsArticle == null)
            {
                TempData["Error"] = "News article not found.";
                return;
            }
            listTag = await _tagRepository.GetTagByArticleId(newsArticleId);



        }
    }
}
