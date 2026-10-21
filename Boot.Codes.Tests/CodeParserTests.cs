using Xunit;

namespace Boot.Codes.Tests
{
    public class CodeParserTests
    {
        [Theory]
        [InlineData("DRAMAA", "DRAMAA")]
        [InlineData("dramaa", "DRAMAA")]
        [InlineData("  DraMaa  ", "DRAMAA")]
        [InlineData("DRAMAA # league host 1", "DRAMAA")]
        [InlineData("DRAMAA -- old comment style", "DRAMAA")]
        public void Reads_a_6_letter_code(string line, string expected)
        {
            Assert.True(CodeParser.TryParse(line, out var code));
            Assert.Equal(expected, code);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("# a comment")]
        [InlineData("  # an indented comment")]
        [InlineData("-- the old comment style")]
        public void Skips_an_empty_line_and_a_comment(string line)
        {
            Assert.Null(CodeParser.TryParse(line, out _));
        }

        [Theory]
        [InlineData("LIGA", "LIGA")]
        [InlineData("DRAMAAA", "DRAMAAA")]
        [InlineData("DRAMA1", "DRAMA1")]
        [InlineData("DRA MA", "DRA MA")]
        [InlineData("dramaą", "DRAMAĄ")]
        public void Rejects_a_line_that_is_not_6_letters_A_Z(string line, string reported)
        {
            Assert.False(CodeParser.TryParse(line, out var code));
            Assert.Equal(reported, code);
        }
    }
}
