﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Glader.ASP.ServiceDiscovery
{
	public static class IMvcBuilderExtensions
	{
		/// <summary>
		/// Registers the general <see cref="HealthCheckController"/> with the MVC
		/// controllers. See controller documentation for what it does and how it works.
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static IMvcBuilder RegisterGameConfigControllers(this IMvcBuilder builder)
		{
			return builder;
		}
	}
}