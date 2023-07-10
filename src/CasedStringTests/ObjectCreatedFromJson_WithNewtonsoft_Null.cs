using Newtonsoft.Json;

namespace WCKDRZR.CasedStringTests
{
    public class ObjectCreatedFromJson_WithNewtonsoft_Null
    {
        public CasedString? TestObject { get; set; }

        public ObjectCreatedFromJson_WithNewtonsoft_Null()
        {
            string json = $"null";
            TestObject = JsonConvert.DeserializeObject<CasedString>(json);
        }

        [Fact]
        public void Direct_Equals_ProperCaseString()
        {
            bool match = TestObject == TestStrings.ProperCaseString;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_Equals_LowerCaseString()
        {
            bool match = TestObject == TestStrings.LowerCaseString;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_Equals_NullableString()
        {
            bool match = TestObject == TestStrings.NullableStringProper;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_Equals_NullString()
        {
            bool match = TestObject == TestStrings.NullString;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_Equals_Null()
        {
            bool match = TestObject == null;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_Equals_ProperCaseString_Reverse()
        {
            bool match = TestStrings.ProperCaseString == TestObject;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_Equals_LowerCaseString_Reverse()
        {
            bool match = TestStrings.LowerCaseString == TestObject;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_Equals_NullableString_Reverse()
        {
            bool match = TestStrings.NullableStringProper == TestObject;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_Equals_NullString_Reverse()
        {
            bool match = TestStrings.NullString == TestObject;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_Equals_Null_Reverse()
        {
            bool match = null == TestObject;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_Equals_ObjectProper()
        {
            bool match = TestObject == TestObjects.ObjectProper;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_Equals_ObjectLower()
        {
            bool match = TestObject == TestObjects.ObjectLower;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_Equals_ObjectNull()
        {
            bool match = TestObject == TestObjects.ObjectNull;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_Equals_ObjectNullValue()
        {
            bool match = TestObject == TestObjects.ObjectNullValue;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_Equals_ObjectNullableNull()
        {
            bool match = TestObject == TestObjects.ObjectNullableNull;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_Equals_ObjectNullableProper()
        {
            bool match = TestObject == TestObjects.ObjectNullableProper;
            match.Should().BeFalse();
        }


        [Fact]
        public void Direct_NotEqual_ProperCaseString()
        {
            bool match = TestObject != TestStrings.ProperCaseString;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_NotEqual_LowerCaseString()
        {
            bool match = TestObject != TestStrings.LowerCaseString;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_NotEqual_NullableString()
        {
            bool match = TestObject != TestStrings.NullableStringProper;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_NotEqual_NullString()
        {
            bool match = TestObject != TestStrings.NullString;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_NotEqual_Null()
        {
            bool match = TestObject != null;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_NotEqual_ProperCaseString_Reverse()
        {
            bool match = TestStrings.ProperCaseString != TestObject;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_NotEqual_LowerCaseString_Reverse()
        {
            bool match = TestStrings.LowerCaseString != TestObject;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_NotEqual_NullableString_Reverse()
        {
            bool match = TestStrings.NullableStringProper != TestObject;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_NotEqual_NullString_Reverse()
        {
            bool match = TestStrings.NullString != TestObject;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_NotEqual_Null_Reverse()
        {
            bool match = null != TestObject;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_NotEqual_ObjectProper()
        {
            bool match = TestObject != TestObjects.ObjectProper;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_NotEqual_ObjectLower()
        {
            bool match = TestObject != TestObjects.ObjectLower;
            match.Should().BeTrue();
        }

        [Fact]
        public void Direct_NotEqual_ObjectNull()
        {
            bool match = TestObject != TestObjects.ObjectNull;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_NotEqual_ObjectNullValue()
        {
            bool match = TestObject != TestObjects.ObjectNullValue;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_NotEqual_ObjectNullableNull()
        {
            bool match = TestObject != TestObjects.ObjectNullableNull;
            match.Should().BeFalse();
        }

        [Fact]
        public void Direct_NotEqual_ObjectNullableProper()
        {
            bool match = TestObject != TestObjects.ObjectNullableProper;
            match.Should().BeTrue();
        }


        [Fact]
        public void Function_Equals_ProperCaseString()
        {
            bool match = TestObject.NullableEquals(TestStrings.ProperCaseString);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_Equals_LowerCaseString()
        {
            bool match = TestObject.NullableEquals(TestStrings.LowerCaseString);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_Equals_NullableString()
        {
            bool match = TestObject.NullableEquals(TestStrings.NullableStringProper);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_Equals_NullString()
        {
            bool match = TestObject.NullableEquals(TestStrings.NullString);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_Equals_Null()
        {
            bool match = TestObject.NullableEquals(null);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_Equals_ProperCaseString_Reverse()
        {
            bool match = TestStrings.ProperCaseString.NullableEquals(TestObject);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_Equals_LowerCaseString_Reverse()
        {
            bool match = TestStrings.LowerCaseString.NullableEquals(TestObject);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_Equals_NullableString_Reverse()
        {
            bool match = TestStrings.NullableStringProper.NullableEquals(TestObject);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_Equals_NullString_Reverse()
        {
            bool match = TestStrings.NullString.NullableEquals(TestObject);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_Equals_ObjectProper()
        {
            bool match = TestObject.NullableEquals(TestObjects.ObjectProper);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_Equals_ObjectLower()
        {
            bool match = TestObject.NullableEquals(TestObjects.ObjectLower);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_Equals_ObjectNull()
        {
            bool match = TestObject.NullableEquals(TestObjects.ObjectNull);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_Equals_ObjectNullValue()
        {
            bool match = TestObject.NullableEquals(TestObjects.ObjectNullValue);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_Equals_ObjectNullableNull()
        {
            bool match = TestObject.NullableEquals(TestObjects.ObjectNullableNull);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_Equals_ObjectNullableProper()
        {
            bool match = TestObject.NullableEquals(TestObjects.ObjectNullableProper);
            match.Should().BeFalse();
        }


        [Fact]
        public void Function_NotEqual_ProperCaseString()
        {
            bool match = TestObject.NotEqual(TestStrings.ProperCaseString);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_NotEqual_LowerCaseString()
        {
            bool match = TestObject.NotEqual(TestStrings.LowerCaseString);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_NotEqual_NullableString()
        {
            bool match = TestObject.NotEqual(TestStrings.NullString);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_NotEqual_NullString()
        {
            bool match = TestObject.NotEqual(TestStrings.NullString);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_NotEqual_Null()
        {
            bool match = TestObject.NotEqual(null);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_NotEqual_ProperCaseString_Reverse()
        {
            bool match = TestStrings.ProperCaseString.NotEqual(TestObject);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_NotEqual_LowerCaseString_Reverse()
        {
            bool match = TestStrings.LowerCaseString.NotEqual(TestObject);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_NotEqual_NullableString_Reverse()
        {
            bool match = TestStrings.NullableStringProper.NotEqual(TestObject);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_NotEqual_NullString_Reverse()
        {
            bool match = TestStrings.NullString.NotEqual(TestObject);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_NotEqual_ObjectProper()
        {
            bool match = TestObject.NotEqual(TestObjects.ObjectProper);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_NotEqual_ObjectLower()
        {
            bool match = TestObject.NotEqual(TestObjects.ObjectLower);
            match.Should().BeTrue();
        }

        [Fact]
        public void Function_NotEqual_ObjectNull()
        {
            bool match = TestObject.NotEqual(TestObjects.ObjectNull);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_NotEqual_ObjectNullValue()
        {
            bool match = TestObject.NotEqual(TestObjects.ObjectNullValue);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_NotEqual_ObjectNullableNull()
        {
            bool match = TestObject.NotEqual(TestObjects.ObjectNullableNull);
            match.Should().BeFalse();
        }

        [Fact]
        public void Function_NotEqual_ObjectNullableProper()
        {
            bool match = TestObject.NotEqual(TestObjects.ObjectNullableProper);
            match.Should().BeTrue();
        }

    }
}