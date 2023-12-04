using OnionArchitecture.Common.Model.RequestModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnionArchitecture.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<int> Add(CreateCategoryModel createCategoryModel);
    }
}
