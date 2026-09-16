using System;

namespace JetBrains.Annotations
{
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method |
	                AttributeTargets.Property | AttributeTargets.Delegate)]
	internal sealed class StringFormatMethodAttribute : Attribute
	{
		public StringFormatMethodAttribute(string formatParameterName)
			=> FormatParameterName = formatParameterName;

		public string FormatParameterName { get; }
	}
}