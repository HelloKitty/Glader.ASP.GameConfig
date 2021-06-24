using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Glader.ASP.GameConfig;
using Glader.Essentials;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Glader.ASP.GameConfig
{
	public static class IMvcBuilderExtensions
	{
		/// <summary>
		/// Registers the general <see cref="HealthCheckController"/> with the MVC
		/// controllers. See controller documentation for what it does and how it works.
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IMvcBuilder RegisterGameConfigControllers<TConfigType>(this IMvcBuilder builder) 
			where TConfigType : Enum
		{
			return builder.RegisterController<GameConfigController<TConfigType>>();
		}
	}
}
