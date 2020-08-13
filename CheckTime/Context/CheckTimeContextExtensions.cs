using CheckTime.Context;
using CheckTime.Models;
using CheckTime.Models.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace ALLECELL.Context
{
    public static class CheckTimeContextExtensions
    {
        public static void InitDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<CheckTimeContext>().Database.Migrate();
            }
        }

        //public static void Seed(this CheckTimeContext context)
        //{
        //    IOHelper.CreateDirectoryIfNotExist(Constants.SeedPath);

        //    GenericSeed<User>(context, Constants.UsersSeedPath);
        //    context.SaveChanges();
        //}

        public static IQueryable<TEntity> FindQuery<TEntity>(this DbSet<TEntity> set, params object[] keyValues) where TEntity : class
        {
            var context = ((IInfrastructure<IServiceProvider>)set).GetService<CheckTimeContext>();

            var entityType = context.Model.FindEntityType(typeof(TEntity));
            var key = entityType.FindPrimaryKey();

            var entries = context.ChangeTracker.Entries<TEntity>();
            //Edit to find with the full entity object
            var i = 0;
            if (Convert.GetTypeCode(keyValues[0]) == TypeCode.Object)//is object
            {
                var newKeyValues = new object[key.Properties.Count];
                var entity = keyValues[0];
                i = 0;
                foreach (var property in key.Properties)
                {
                    newKeyValues[i] = entity.GetType().GetProperty(property.Name).GetValue(entity);
                    i++;
                }
                keyValues = newKeyValues;
            }

            i = 0;
            foreach (var property in key.Properties)
            {
                var keyValue = keyValues[i];
                entries = entries.Where(e => e.Property(property.Name).CurrentValue == keyValue);
                i++;
            }

            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var query = set.AsQueryable();
            i = 0;
            foreach (var property in key.Properties)
            {
                var propertyName = key.Properties[i].Name;
                Type clrType = key.Properties[i].ClrType;
                var keyValue = TypeDescriptor.GetConverter(key.Properties[i].ClrType).ConvertFromInvariantString(Convert.ToString(keyValues[i]));

                query = query.Where((Expression<Func<TEntity, bool>>)Expression.Lambda(
                            Expression.Equal(Expression.Property(parameter, propertyName), Expression.Constant(keyValue)),
                            parameter)
                        );
                i++;
            }
            return query;
        }

        private static void GenericSeed<T>(CheckTimeContext context, string path) where T : class
        {
            if (!File.Exists(path))
                return;

            if (context.Set<T>().Count() > 0)
                return;

            List<T> list = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            foreach (var item in list)
            {
                context.Add<T>(item);
            }
        }

    }
}
