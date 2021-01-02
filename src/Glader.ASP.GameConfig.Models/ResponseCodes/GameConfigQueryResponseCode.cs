using System;
using System.Collections.Generic;
using System.Text;
using Glader.Essentials;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Response code valeus for game config queries.
	/// </summary>
	public enum GameConfigQueryResponseCode
	{
		Success = GladerEssentialsModelConstants.RESPONSE_CODE_SUCCESS_VALUE,

		//TODO: Make this a Model Constant.
		GeneralServerError = 2,

		ContentNotFound = 3,
	}
}
