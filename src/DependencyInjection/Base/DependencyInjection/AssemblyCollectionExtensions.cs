﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Atomiv.DependencyInjection.Common
{
    public static class AssemblyCollectionExtensions
    {
        public static IEnumerable<Type> GetTypes(this IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(e => e.GetTypes());
        }
    }
}