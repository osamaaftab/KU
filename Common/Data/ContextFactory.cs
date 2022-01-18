using Context;
using DBContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Common.Data {
    public class ContextFactory : IContextFactory {


        /// <summary>
        /// Initializes a new instance of the <see cref="CMSContextFactory"/> class.
        /// </summary>
        /// <param name="httpContentAccessor">The HTTP content accessor.</param>
        /// <param name="connectionOptions">The connection options.</param>
        /// <param name="dataBaseManager">The data base manager.</param>
        /// <param name="databaseType">Type of the database</param>
        /// <param name="dataSeeder">Data seeder</param>


        /// <inheritdoc />
        public IDbContext DbContext => new BankContext(ChangeDatabaseNameInConnectionString().Options);

        /// <summary>
        /// Gets tenant id from HTTP header
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        /// <exception cref="ArgumentNullException">
        /// httpContext
        /// or
        /// tenantId
        /// </exception>

        private DbContextOptionsBuilder<BankContext> ChangeDatabaseNameInConnectionString() {

            // 1. Create Connection String Builder using Default connection string
            //var connectionBuilder = databaseType.GetConnectionBuilder(connectionOptions.DefaultConnection);

            // 2. Remove old Database Name from connection string
            //connectionBuilder.Remove(DatabaseFieldKeyword);

            // 3. Obtain Database name from DataBaseManager and Add new DB name to 
            //connectionBuilder.Add(DatabaseFieldKeyword, this.dataBaseManager.GetDataBaseName(tenantId));

            // 4. Create DbContextOptionsBuilder with new Database name
            var contextOptionsBuilder = new DbContextOptionsBuilder<BankContext>();
            return contextOptionsBuilder;
        }
    }
}
