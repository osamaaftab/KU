﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Common.Data {
    public interface IRepository<T> {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity</returns>
        T Get<TKey>(TKey id);

        /// <summary>
        /// Gets the First Record.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <returns>Entity</returns>
        T GetFirst();

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TProperty">Child entity</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="navigationPropertyPath">Child property to include</param>
        /// <returns>Entity</returns>
        T Get<TKey, TProperty>(TKey id, Expression<Func<T, TProperty>> navigationPropertyPath) where TProperty : class;

        /// <summary>
        /// Gets the specified identifier. Asynchronous version.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Task Entity</returns>
        Task<T> GetAsync<TKey>(TKey id);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TProperty">Child entity</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="navigationPropertyPath">Child property to include</param>
        /// <returns>Entity</returns>
        Task<T> GetAsync<TKey, TProperty>(TKey id, Expression<Func<T, TProperty>> navigationPropertyPath) where TProperty : class;

        /// <summary>
        /// Gets an entity by the keys specified in <paramref name="keyValues"/>
        /// </summary>
        /// <param name="keyValues">Composite Primary Key Identifiers</param>
        /// <returns>The requested Entity</returns>
        T Get(params object[] keyValues);



        public IQueryable<T> Entity();

        /// <summary>
        /// Generic find predicate
        /// </summary>
        /// <param name="predicate">Query predicate</param>
        /// <returns>Entity</returns>
        public T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Generic find predicate
        /// </summary>
        /// <param name="predicate">Query predicate</param>
        ///         /// <param name="include1">releated entity</param>
        /// <returns>Entity</returns>
        public T Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include);

        /// <summary>
        /// Generic find predicate
        /// </summary>
        /// <param name="predicate">Query predicate</param>
        /// <param name="include1">releated entity</param>
        /// <param name="include2">releated entity</param>
        /// <returns>Entity</returns>
        public T Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include1, Expression<Func<T, object>> include2);

        /// <summary>
        /// Generic find predicate
        /// </summary>
        /// <param name="predicate">Query predicate</param>
        /// <param name="include1">releated entity</param>
        /// <param name="include2">releated entity</param>
        /// <param name="include3">releated entity</param>
        /// <returns>Entity</returns>
        T Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include1, Expression<Func<T, object>> include2, Expression<Func<T, object>> include3);

        /// <summary>
        /// Generic find by predicate
        /// </summary>
        /// <param name="predicate">Query predicate</param>
        /// <returns>Entity</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Generic find by predicate and option to include child entity
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="include">The include sub-entity.</param>
        /// <returns>Queryable</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets all. With data pagination.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <returns></returns>
        IQueryable<T> GetAll(int page, int pageCount);

        /// <summary>
        /// Gets all. With data pagination.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <param name="navigationPropertyPath">Child entity to include</param>
        /// <returns></returns>
        IQueryable<T> GetAll<TProperty>(int page, int pageCount, Expression<Func<T, TProperty>> navigationPropertyPath);

        /// <summary>
        /// Gets all. With data pagination and predicate check.
        /// </summary>
        /// <param name="pagination">The page And The page count.</param>
        /// <param name="predicate">Predicate to check</param>
        /// <returns>Whether an entities matching the <paramref name="predicate"/></returns>
        public IQueryable<T> GetAll(Pagination pagination, Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets all. With data pagination and predicate check.
        /// </summary>
        /// <param name="predicate">Predicate to check</param>
        /// <returns>Whether an entities matching the <paramref name="predicate"/></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);


        /// <summary>
        /// Gets all and offers to include a related table
        /// </summary>
        /// <param name="include">Te sub.entity to include</param>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll(string include);

        /// <summary>
        ///     <para>
        ///         Creates a LINQ query based on a raw SQL query.
        ///     </para>
        ///     <para>
        ///         If the database provider supports composing on the supplied SQL, you can compose on top of the raw SQL query using
        ///         LINQ operators - <code>context.Blogs.FromSql("SELECT * FROM dbo.Blogs").OrderBy(b =&gt; b.Name)</code>.
        ///     </para>
        ///     <para>
        ///         As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection
        ///         attack. You can include parameter place holders in the SQL query string and then supply parameter values as additional
        ///         arguments. Any parameter values you supply will automatically be converted to a DbParameter -
        ///         <code>context.Blogs.FromSql("SELECT * FROM [dbo].[SearchBlogs]({0})", userSuppliedSearchTerm)</code>.
        ///     </para>
        ///     <para>
        ///         You can also construct a DbParameter and supply it to as a parameter value. This allows you to use named
        ///         parameters in the SQL query string -
        ///         <code>context.Blogs.FromSql("SELECT * FROM [dbo].[SearchBlogs]({@searchTerm})", new SqlParameter("@searchTerm", userSuppliedSearchTerm))</code>
        ///     </para>
        /// </summary>
        /// <param name="sql"> The raw SQL query. </param>
        /// <param name="parameters"> The values to be assigned to parameters. </param>
        /// <returns>List of entities</returns>
        IQueryable<T> FromSql(string sql, params object[] parameters);

        /// <summary>
        /// Gets all and offers to include 2 related tables
        /// </summary>
        /// <param name="include">The sub.entity to include</param>
        /// <param name="include2">The second sub.entity to include</param>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll(string include, string include2);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The Entity's state</returns>
        EntityState Add(T entity);


        /// <summary>
        /// Deletes the specified <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns>The Entity's state</returns>
        EntityState Delete(T entity);

        /// <summary>
        /// Deletes the specified <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns>The Entity's state</returns>
        void Delete(ICollection<T> entity);

        /// <summary>
        /// Checks whether a entity matching the <paramref name="predicate"/> exists
        /// </summary>
        /// <param name="predicate">The predicate to filter on</param>
        /// <returns>Whether an entity matching the <paramref name="predicate"/> exists</returns>
        bool Exists(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The Entity's state</returns>
        EntityState Update(T entity);
    }

}
