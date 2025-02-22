#if XUNIT_NULLABLE
#nullable enable
#endif

using System;

namespace Xunit.Sdk
{
	/// <summary>
	/// Exception thrown when Assert.Matches fails.
	/// </summary>
#if XUNIT_VISIBILITY_INTERNAL
	internal
#else
	public
#endif
	partial class MatchesException : XunitException
	{
		MatchesException(string message) :
			base(message)
		{ }

		/// <summary>
		/// Creates a new instance of the <see cref="MatchesException"/> class to be thrown when
		/// the regular expression pattern isn't found within the value.
		/// </summary>
		/// <param name="expectedRegexPattern">The expected regular expression pattern</param>
		/// <param name="actual">The actual value</param>
		public static MatchesException ForMatchNotFound(
			string expectedRegexPattern,
#if XUNIT_NULLABLE
			string? actual) =>
#else
			string actual) =>
#endif
				new MatchesException(
					"Assert.Matches() Failure: Pattern not found in value" + Environment.NewLine +
					"Regex: " + ArgumentFormatter.Format(Assert.GuardArgumentNotNull(nameof(expectedRegexPattern), expectedRegexPattern)) + Environment.NewLine +
					"Value: " + ArgumentFormatter.Format(actual)
				);
	}
}
