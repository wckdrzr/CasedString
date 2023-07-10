namespace WCKDRZR.CasedStringTests
{
    public class Concatenations
    {
        public CasedString TestObject { get; set; }

        public Concatenations()
        {
            TestObject = new(TestStrings.ProperCaseString, true);
        }

        [Fact]
        public void Concat()
        {
            CasedString newString = TestObject + TestStrings.LowerCaseString;
            bool match = newString == "Foo Barfoo bar";
            match.Should().BeTrue();
        }

        [Fact]
        public void Concat_CaseSensitive_NotEqual()
        {
            CasedString newString = TestObject + TestStrings.LowerCaseString;
            bool match = newString != "foo barfoo bar";
            match.Should().BeTrue();
        }

        [Fact]
        public void Concat_Object()
        {
            CasedString newString = TestObject + TestObjects.ObjectLower;
            bool match = newString == "Foo Barfoo bar";
            match.Should().BeTrue();
        }

        [Fact]
        public void Concat_NullObject()
        {
            CasedString newString = TestObject + TestObjects.ObjectNull;
            bool match = newString == "Foo Bar";
            match.Should().BeTrue();
        }

        [Fact]
        public void Concat_NullObject_Reverse()
        {
            CasedString newString = TestObjects.ObjectNull + TestObject;
            bool match = newString == "Foo Bar";
            match.Should().BeTrue();
        }
    }
}