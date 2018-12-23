using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using RoggaApp.Domain.Context;
using RoggaApp.Domain;

namespace RoggaApp.Configs
{
    internal class EFConfigurationProvider : ConfigurationProvider
    {
        private Action<DbContextOptionsBuilder> _optionsAction;

        public EFConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            _optionsAction = optionsAction;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ConfigContext>();

            this._optionsAction(builder);

            using (var dbContext = new ConfigContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();

                this.Data = !dbContext.Configs.Any() ?
                    SeedDefaultValues(dbContext) : dbContext.Configs.ToDictionary(c => c.Id, c => c.Value);
            }
        }

        private IDictionary<string, string> SeedDefaultValues(ConfigContext dbContext)
        {
            var seedData = new Dictionary<string, string>
            {
                {"DefaultApiUser" ,"iB66etsbPAnHglWps7CXCCOHPGz3A1DwMEm65786" },
            };
            dbContext.Configs.AddRange(seedData.Select(cfg => new DbConfig { Id = cfg.Key, Value = cfg.Value })
                .ToArray());

            dbContext.SaveChanges();

            return seedData;
        }
    }
}