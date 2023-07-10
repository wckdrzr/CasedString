using Newtonsoft.Json;

namespace WCKDRZR.CasedStringTests
{
    public class JsonSerialisation_WithNewtonsoft
    {
        [Fact]
        public void SerialiseLower()
        {
            string testString = JsonConvert.SerializeObject(TestObjects.ObjectLower);
            testString.Should().BeEquivalentTo($"\"{TestStrings.LowerCaseString}\"");
        }

        [Fact]
        public void SerialiseProper()
        {
            string testString = JsonConvert.SerializeObject(TestObjects.ObjectProper);
            testString.Should().BeEquivalentTo($"\"{TestStrings.ProperCaseString}\"");
        }

        [Fact]
        public void SerialiseNull()
        {
            string testString = JsonConvert.SerializeObject(TestObjects.ObjectNull);
            testString.Should().BeEquivalentTo($"null");
        }

        [Fact]
        public void SerialiseNullValue()
        {
            string testString = JsonConvert.SerializeObject(TestObjects.ObjectNullValue);
            testString.Should().BeEquivalentTo($"null");
        }

        [Fact]
        public void SerialiseNullableNull()
        {
            string testString = JsonConvert.SerializeObject(TestObjects.ObjectNullableNull);
            testString.Should().BeEquivalentTo($"null");
        }

        [Fact]
        public void SerialiseNullableProper()
        {
            string testString = JsonConvert.SerializeObject(TestObjects.ObjectNullableProper);
            testString.Should().BeEquivalentTo($"\"{TestStrings.ProperCaseString}\"");
        }


        [Fact]
        public void SerialiseLower_CaseSensitive()
        {
            CasedString casedString = new(TestStrings.LowerCaseString, true);
            string testString = JsonConvert.SerializeObject(casedString);
            testString.Should().BeEquivalentTo($"{{\"Value\":\"{TestStrings.LowerCaseString}\",\"CaseSensitive\":true}}");
        }

        [Fact]
        public void SerialiseProper_CaseSensitive()
        {
            CasedString casedString = new(TestStrings.ProperCaseString, true);
            string testString = JsonConvert.SerializeObject(casedString);
            testString.Should().BeEquivalentTo($"{{\"Value\":\"{TestStrings.ProperCaseString}\",\"CaseSensitive\":true}}");
        }

        [Fact]
        public void SerialiseNullValue_CaseSensitive()
        {
            CasedString casedString = new(null, true);
            string testString = JsonConvert.SerializeObject(casedString);
            testString.Should().BeEquivalentTo($"{{\"Value\":null,\"CaseSensitive\":true}}");
        }
    }
}