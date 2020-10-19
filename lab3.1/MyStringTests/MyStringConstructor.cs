using System;
using Xunit;

namespace LW5.MyString.Tests
{
    public class MyStringConstructorTests
    {
        [Fact]
        public void Constructor_NoArgs_CreatesEmptyMyString()
        {
            // Arrange & Act
            var myStr = new MyString();

            // Assert
            Assert.Equal(0, myStr.Length);
            Assert.Equal(new char[0], myStr);
        }

        [Fact]
        public void Constructor_CharArray_CreatesMyStringWithSameCharacters()
        {
            // Arrange
            var chars = new[] { 'H', 'e', 'l', 'l', 'o' };

            // Act
            var myStr = new MyString(chars);

            // Assert
            Assert.Equal(chars.Length, myStr.Length);
            Assert.Equal(chars, myStr);
            Assert.Equal("Hello", myStr);
        }

        [Fact]
        public void Constructor_CharArrayWithNullCharacterAtCenter_CreatesMyStringWithSameCharacters()
        {
            // Arrange
            var chars = new[] { 'H', 'e', 'l', 'l', 'o', '\0', 'W', 'o', 'r', 'l', 'd' };

            // Act
            var myStr = new MyString(chars);

            // Assert
            Assert.Equal(chars.Length, myStr.Length);
            Assert.Equal("Hello\0World", myStr);
        }

        [Fact]
        public void Constructor_CharArrayWithLength_CreatesMyStringWithFirstNChars()
        {
            // Arrange
            var length = 4;
            var chars = new[] { 'H', 'e', 'l', 'l', 'o' };

            // Act
            var myStr = new MyString(chars, length);

            // Assert
            Assert.Equal(length, myStr.Length);
            Assert.Equal(new[] { 'H', 'e', 'l', 'l' }, myStr);
        }

        [Fact]
        public void Constructor_CharArrayWithIncorrectLength_ThrowsException()
        {
            // Arrange
            var length = 7;
            var chars = new[] { 'H', 'e', 'l', 'l', 'o' };

            // Act && Assert
            Assert.Throws<IndexOutOfRangeException>(() => new MyString(chars, length));
        }

        [Fact]
        public void Constructor_OtherMyStringInstance_CreatesNewInstanceOfMyStringWithSameCharacters()
        {
            // Arrange & Act
            var myStr = new MyString(new[] { 'H', 'e', 'l', 'l', 'o' });
            var copyStr = new MyString(myStr);

            // Assert
            Assert.NotSame(myStr, copyStr);

            Assert.Equal(myStr.Length, copyStr.Length);
            Assert.Equal(copyStr, myStr);
        }

        [Fact]
        public void Constructor_RegularString_CreatesMyStringWithSameCharacters()
        {
            // Arrange
            var someString = "Hello";

            // Act
            var myStr = new MyString(someString);

            // Assert
            Assert.Equal(someString.Length, myStr.Length);
            Assert.Equal(new[] { 'H', 'e', 'l', 'l', 'o' }, myStr);
        }

        // *** Свойство Length было протестировано вместе с конструкторами ***
    }
}