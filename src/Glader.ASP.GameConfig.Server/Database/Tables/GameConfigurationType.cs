using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// The character proportions slot type.
	/// </summary>
	[DataContract]
	[Table("gameconfig_type")]
	public class GameConfigurationType<TConfigType>
		where TConfigType : Enum
	{
		/// <summary>
		/// The primary key (enumerated type).
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[DataMember(Order = 1)]
		public TConfigType @Type { get; private set; }

		/// <summary>
		/// The visual human-readable name for the slot.
		/// </summary>
		[DataMember(Order = 2)]
		public string VisualName { get; private set; }

		/// <summary>
		/// The description of the slot.
		/// </summary>
		[DataMember(Order = 3)]
		public string Description { get; private set; }

		public GameConfigurationType(TConfigType type, string visualName, string description)
		{
			Type = type ?? throw new ArgumentNullException(nameof(type));
			VisualName = visualName;
			Description = description;
		}

		public GameConfigurationType(TConfigType type)
		{
			Type = type ?? throw new ArgumentNullException(nameof(type));
			VisualName = String.Empty;
			Description = String.Empty;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GameConfigurationType()
		{

		}
	}
}
