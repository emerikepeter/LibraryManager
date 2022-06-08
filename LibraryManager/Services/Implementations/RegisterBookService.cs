using LibraryManager.Constance;
using LibraryManager.DataAccess.DataEntity;
using LibraryManager.DataAccess.Dtos;
using LibraryManager.DataAccess.Models;
using LibraryManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static LibraryManager.Constance.Constances;

namespace LibraryManager.Services.Implementations
{
    public class RegisterBookService : IRegisterBookService
    {
        private DataContext _dataContext;

        public RegisterBookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Constances.ResponseMessages> FormData(RegisterBookDto model)
        {
            try
            {
                var isExist = _dataContext.Tbl_RegisterBook.FirstOrDefault(x => x.Id.Equals(model.Id));
                if(isExist == null)
                {
                    RegisterBookModel registerBook = new RegisterBookModel
                    {
                        BookName = model.BookName,
                        Author = model.Author,
                        Publisher = model.Publisher,
                        PublicationYear = model.PublicationYear,
                    };
                    _dataContext.Tbl_RegisterBook.Add(registerBook);
                    var res = await _dataContext.SaveChangesAsync();
                    if (res > 0) return new Constances.ResponseMessages { IsSuccessful = true, Message = StatusMessages.Submitted };
                    else return new Constances.ResponseMessages { IsSuccessful = false, Message = StatusMessages.Declined };
                }
                else
                {
                    RegisterBookModel registerBook = new RegisterBookModel
                    {
                        Id = model.Id,
                        BookName = model.BookName,
                        Author = model.Author,
                        Publisher = model.Publisher,
                        PublicationYear = model.PublicationYear,
                    };
                    _dataContext.Tbl_RegisterBook.Update(registerBook);
                    var res = await _dataContext.SaveChangesAsync();
                    if (res > 0) return new Constances.ResponseMessages { IsSuccessful = true, Message = StatusMessages.Updated };
                    else return new Constances.ResponseMessages { IsSuccessful = false, Message = StatusMessages.Declined };
                }
            }
            catch (Exception err)
            {
                return new Constances.ResponseMessages { IsSuccessful = false, Message = $"{StatusMessages.Error} {err.Message}" };
            }
        }

        public async Task<IEnumerable<RegisterBookDto>> FetchBy(Expression<Func<RegisterBookModel, bool>> expression)
        {
            try
            {
                return (IEnumerable<RegisterBookDto>)await _dataContext.Tbl_RegisterBook.Where(expression).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Constances.ResponseMessages> Delete(string Id)
        {
            try
            {
                var isExist = _dataContext.Tbl_RegisterBook.FirstOrDefault(x => x.Id.Equals(Id));
                if (isExist != null)
                {
                    isExist.IsDeleted = true;
                    _dataContext.Tbl_RegisterBook.Update(isExist);
                    var res = await _dataContext.SaveChangesAsync();
                    if (res > 0) return new Constances.ResponseMessages { IsSuccessful = true, Message = StatusMessages.Deleted };
                    else return new Constances.ResponseMessages { IsSuccessful = false, Message = StatusMessages.Declined };
                }
                else return new Constances.ResponseMessages { IsSuccessful = false, Message = "No Record Find" };
            }
            catch (Exception err)
            {
                return new Constances.ResponseMessages { IsSuccessful = true, Message = $"{StatusMessages.Error} {err.Message}" };
            }
        }

        public async Task<Constances.ResponseMessages> SetStatus(string Id)
        {
            try
            {
                var isExist = _dataContext.Tbl_RegisterBook.FirstOrDefault(x => x.Id.Equals(Id));
                if (isExist != null)
                {
                    if(isExist.IsActive) isExist.IsActive = false;
                    else isExist.IsActive = true;

                    _dataContext.Tbl_RegisterBook.Update(isExist);
                    var res = await _dataContext.SaveChangesAsync();
                    if (res > 0) return new Constances.ResponseMessages { IsSuccessful = true, Message = StatusMessages.Deleted };
                    else return new Constances.ResponseMessages { IsSuccessful = false, Message = StatusMessages.Declined };
                }
                else return new Constances.ResponseMessages { IsSuccessful = false, Message = "No Record Find" };
            }
            catch (Exception err)
            {
                return new Constances.ResponseMessages { IsSuccessful = true, Message = $"{StatusMessages.Error} {err.Message}" };
            }
        }

        public async Task<IEnumerable<RegisterBookModel>> FetchAll()
        {
            try
            {
                return await _dataContext.Tbl_RegisterBook.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<IEnumerable<RegisterBookDto>> FetchByAuthor(string Author)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterBookModel> FetchById(string Id)
        {
            try
            {
                return await _dataContext.Tbl_RegisterBook.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(Id));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
