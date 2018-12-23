using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoggaApp.Configs
{
    public static class EntityFrameworkConfigurationExtensions
    {
        public static IConfigurationBuilder AddEFConfiguration(this IConfigurationBuilder builder,
            Action<DbContextOptionsBuilder> optionsActions) =>
            builder.Add(new EFConfigurationSource(optionsActions));
    }
}
