using OnionArchitecture.Application.Interfaces.Repositories;
using OnionArchitecture.Application.Interfaces.Services;
using OnionArchitecture.Common.Model.RequestModel.Category;
using OnionArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Services.CategoryServices
{
    public class CatecoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CatecoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Add(CreateCategoryModel createCategoryModel)
        {
            var model = new Category
            {
                Name = createCategoryModel.Name,
            };

            return await _categoryRepository.AddAsync(model);
        }
    }
}
