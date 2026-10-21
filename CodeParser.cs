using System;
using System.Linq;

namespace Boot.Codes
{
    /// <summary>
    /// Reads one line of a word list.
    /// </summary>
    public static class CodeParser
    {
        /// <summary>
        /// The comment markers. A line that starts with one is skipped. Text after one is ignored.
        /// <c>--</c> is the original Boot.Codes marker and still works.
        /// </summary>
        private static readonly string[] CommentMarkers = { "#", "--" };

        /// <summary>
        /// Gets the code on a line.
        /// <para>
        /// Only 6-letter codes A-Z. Among Us shows 6-letter codes (V2). 4-letter codes (V1) are
        /// the old format. Digits do not work: Impostor reads a code with a digit as invalid
        /// (<c>GameCodeParser.GameNameToInt</c>), and the V2 alphabet has letters only.
        /// Lower case becomes upper case.
        /// </para>
        /// </summary>
        /// <param name="line">One line of a word list.</param>
        /// <param name="code">The code in upper case, or the text that is not a valid code.</param>
        /// <returns>
        /// <c>true</c> for a valid code. <c>false</c> for an invalid code. <c>null</c> for an
        /// empty line or a comment.
        /// </returns>
        public static bool? TryParse(string line, out string code)
        {
            var text = line;
            foreach (var marker in CommentMarkers)
            {
                var index = text.IndexOf(marker, StringComparison.Ordinal);
                if (index >= 0) text = text.Substring(0, index);
            }

            code = text.Trim().ToUpperInvariant();
            if (code.Length == 0) return null;

            return code.Length == 6 && code.All(c => c >= 'A' && c <= 'Z');
        }
    }
}
