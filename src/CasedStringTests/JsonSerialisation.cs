using System.Text.Json;

namespace WCKDRZR.CasedStringTests
{
    public class JsonSerialisation
    {
        [Fact]
        public void SerialiseLower()
        {
            string testString = JsonSerializer.Serialize(TestObjects.ObjectLower);
            testString.Should().BeEquivalentTo($"\"{TestStrings.LowerCaseString}\"");
        }

        [Fact]
        public void SerialiseProper()
        {
            string testString = JsonSerializer.Serialize(TestObjects.ObjectProper);
            testString.Should().BeEquivalentTo($"\"{TestStrings.ProperCaseString}\"");
        }

        [Fact]
        public void SerialiseNull()
        {
            string testString = JsonSerializer.Serialize(TestObjects.ObjectNull);
            testString.Should().BeEquivalentTo($"null");
        }

        [Fact]
        public void SerialiseNullValue()
        {
            string testString = JsonSerializer.Serialize(TestObjects.ObjectNullValue);
            testString.Should().BeEquivalentTo($"null");
        }

        [Fact]
        public void SerialiseNullableNull()
        {
            string testString = JsonSerializer.Serialize(TestObjects.ObjectNullableNull);
            testString.Should().BeEquivalentTo($"null");
        }

        [Fact]
        public void SerialiseNullableProper()
        {
            string testString = JsonSerializer.Serialize(TestObjects.ObjectNullableProper);
            testString.Should().BeEquivalentTo($"\"{TestStrings.ProperCaseString}\"");
        }


        [Fact]
        public void SerialiseLower_CaseSensitive()
        {
            CasedString casedString = new(TestStrings.LowerCaseString, true);
            string testString = JsonSerializer.Serialize(casedString);
            testString.Should().BeEquivalentTo($"{{\"Value\":\"{TestStrings.LowerCaseString}\",\"CaseSensitive\":true}}");
        }

        [Fact]
        public void SerialiseProper_CaseSensitive()
        {
            CasedString casedString = new(TestStrings.ProperCaseString, true);
            string testString = JsonSerializer.Serialize(casedString);
            testString.Should().BeEquivalentTo($"{{\"Value\":\"{TestStrings.ProperCaseString}\",\"CaseSensitive\":true}}");
        }

        [Fact]
        public void SerialiseNullValue_CaseSensitive()
        {
            CasedString casedString = new(null, true);
            string testString = JsonSerializer.Serialize(casedString);
            testString.Should().BeEquivalentTo($"{{\"Value\":null,\"CaseSensitive\":true}}");
        }
    }
}