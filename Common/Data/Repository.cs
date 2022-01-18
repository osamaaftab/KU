using Common.Model;
using Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Data {
    public class Repository<T> : IRepository<T>
        where T : class {
        /// <summary>
        /// EF data base context
        /// </summary>
        private readonly IDbContext context;

        /// <summary>
        /// Used to query and save instances of
        /// </summary>
        private readonly DbSet<T> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="CMSRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(IDbContext context) {
            this.context = context;

            this.dbSet = context.Set<T>();
        }

        /// <inheritdoc />
        public virtual EntityState Add(T entity) {
            return this.dbSet.Add(entity).State;
        }

        /// <inheritdoc />
        public T Get<TKey>(TKey id) {
            return this.dbSet.Find(id);
        }

        /// <inheritdoc />
        public T GetFirst() {
            return dbSet.First();
        }

        /// <inheritdoc/>
        public T Get<TKey, TProperty>(TKey id, Expression<Func<T, TProperty>> navigationPropertyPath) where TProperty : class {
            var entity = this.dbSet.Find(id);

            if (entity == null)
                return null;
            this.context.Entry(entity).Reference(navigationPropertyPath).Load();
            return entity;
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate) {

            return dbSet.Where(predicate);
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<TKey>(TKey id) {
            return await this.dbSet.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<TKey, TProperty>(TKey id, Expression<Func<T, TProperty>> navigationPropertyPath) where TProperty : class {
            var entity = await this.dbSet.FindAsync(id);
            if (entity == null) return null;
            await this.context.Entry(entity).Reference(navigationPropertyPath).LoadAsync();
            return entity;
        }

        /// <inheritdoc />
        public T Get(params object[] keyValues) {
            return this.dbSet.Find(keyValues);
        }

        /// <inheritdoc />
        public IQueryable<T> Entity() {
            return dbSet.AsQueryable();
        }

        /// <inheritdoc />
        public T Find(Expression<Func<T, bool>> predicate) {
            return dbSet
                .SingleOrDefault(predicate);
        }

        /// <inheritdoc />
        public T Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include) {
            return dbSet
                .Include(include)
                .SingleOrDefault(predicate);
        }

        /// <inheritdoc />
        public T Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include1, Expression<Func<T, object>> include2) {

            return dbSet
                .Include(include1)
                .Include(include2)
                .SingleOrDefault(predicate);
        }

        /// <inheritdoc />
        public T Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include1, Expression<Func<T, object>> include2, Expression<Func<T, object>> include3) {
            return dbSet
                .Include(include1)
                .Include(include2)
                .Include(include3)
                .SingleOrDefault(predicate);
        }


        /// <inheritdoc />
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) {
            return this.dbSet.Where(predicate);
        }

        /// <inheritdoc />
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include) {
            return this.FindBy(predicate).Include(include);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll() {
            return this.dbSet;
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(int page, int pageCount) {
            var pageSize = (page - 1) * pageCount;

            return this.dbSet.Skip(pageSize).Take(pageCount);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll<TProperty>(int page, int pageCount, Expression<Func<T, TProperty>> navigationPropertyPath) {
            var pageSize = (page - 1) * pageCount;

            return this.dbSet.Include(navigationPropertyPath).Skip(pageSize).Take(pageCount);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(Pagination pagination, Expression<Func<T, bool>> predicate) {
            var pageSize = (pagination.Page - 1) * pagination.PageCount;
            return this.dbSet.Where(predicate).Skip(pageSize).Take(pagination.PageCount);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(string include) {
            return this.dbSet.Include(include);
        }

        /// <inheritdoc />
        public IQueryable<T> FromSql(string query, params object[] parameters) {
            return this.dbSet.FromSqlRaw(query, parameters);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(string include, string include2) {
            return this.dbSet.Include(include).Include(include2);
        }

        /// <inheritdoc />
        public bool Exists(Expression<Func<T, bool>> predicate) {
            return this.dbSet.Any(predicate);
        }

        /// <inheritdoc />
        public IQueryable<T> FromSql(string sqlQuery) {
            return this.dbSet.FromSqlRaw(sqlQuery);
        }

        /// <inheritdoc />
        public EntityState Delete(T entity) {
            return dbSet.Remove(entity).State;
        }

        /// <inheritdoc />
        public virtual EntityState Update(T entity) {
            return dbSet.Update(entity).State;
        }

        public void Delete(ICollection<T> entity) {
            dbSet.RemoveRange(entity);
        }

    }
}
