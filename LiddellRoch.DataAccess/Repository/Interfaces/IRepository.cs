using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
		/// <summary>
		/// Adiciona T item ao DbSet
		/// </summary>
		/// <param name="item"></param>
		void Add(T item);

		/// <summary>
		/// Retorna T itens considerando o filtro.
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includeProperties"></param>
		/// <returns></returns>
		IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

		/// <summary>
		/// Retorna um T item considerando o filtro, ou default.
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includeProperties"></param>
		/// <param name="tracked"></param>
		/// <returns></returns>
		T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);

		/// <summary>
		/// Remove T item do DbSet
		/// </summary>
		/// <param name="item"></param>
		void Remove(T item);

		/// <summary>
		/// Remove T itens do DbSet
		/// </summary>
		/// <param name="items"></param>
		void RemoveRange(IEnumerable<T> items);
    }
}
