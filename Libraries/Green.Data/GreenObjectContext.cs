using System;
using System.Linq;
using System.Reflection;
using Green.Core;
using Green.Core.Configuration;
using Green.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Green.Data
{
    /// <summary>
    /// Object context
    /// </summary>
    public class GreenObjectContext : DbContext
    {


		#region Constructor

        public GreenObjectContext(DbContextOptions<GreenObjectContext> options) 
            :base(options)
        {
         
        }

        public GreenObjectContext():base(){
         
        }

		#endregion

		#region Utilities

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
           // optionsBuilder.UseSqlServer("");

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
			var interfaceType = typeof(IEntityTypeConfiguration<>);
			var types = Assembly.GetExecutingAssembly()
								.GetTypes();
			foreach (var type in types)
			{
				string name = type.FullName;

				foreach (var intType in type.GetInterfaces())
				{
					if (intType.IsGenericType && intType.GetGenericTypeDefinition() == interfaceType)
					{
						dynamic configurationInstance = Activator.CreateInstance(type);
						modelBuilder.ApplyConfiguration(configurationInstance);
                        break;
					}
				}

			}


            base.OnModelCreating(modelBuilder);
        }

        #endregion


    }
}