using LibraryManager.DataAccess.Dtos;
using LibraryManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static LibraryManager.Constance.Constances;

namespace LibraryManager.Services.Interfaces
{
    public interface IRegisterBookService
    {
        Task<ResponseMessages> FormData(RegisterBookDto model);
        Task<IEnumerable<RegisterBookDto>> FetchBy(Expression<Func<RegisterBookModel, bool>> expression);
        Task<IEnumerable<RegisterBookModel>> FetchAll();
        Task<RegisterBookModel> FetchById(string Id);
        Task<IEnumerable<RegisterBookDto>> FetchByAuthor(string Author);
        Task<ResponseMessages> Delete(string Id);
        Task<ResponseMessages> SetStatus(string Id);
    }
}
