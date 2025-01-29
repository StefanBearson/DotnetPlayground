using FluentAssertions;
using PlayWithXUnit;

namespace PlayWithXUnit.tests;

public class PlayWithXUnitTests
{
    
    [Fact]
    public void ChangeNameTo_WhenNameIsErik_ThrowsException()
    {
        // Arrange
        var sut = new NameThing();
        
        // Act
        
        Action act = () => sut.ChangeNameTo("Erik", 20);
        
        // Assert
        act.Should().Throw<Exception>().WithMessage("Name cannot be Erik");
    }
    
    [Fact]
    public void ChangeNameTo_WhenNameIsEmpty_ChangesNameToJohnDoe()
    {
        // Arrange
        var sut = new NameThing();
        
        // Act
        string result = sut.ChangeNameTo("", 20);
        
        // Assert
        result.Should().Be("John Doe");
    }
    
    [Fact]
    public void ChangeNameTo_WhenNameIsNotSture_ChangesNameToNewName()
    {
        // Arrange
        var sut = new NameThing();
        
        // Act
        string result = sut.ChangeNameTo("Sture",20);
        
        // Assert
        //get private string name
        
        
        result.Should().Be("Sture");
    }
    
    [Fact]
    public void ChangeNameTo_WhenAgeIsLessThan18_ChangesNameToChild()
    {
        // Arrange
        var sut = new NameThing();
        
        // Act
        string result = sut.ChangeNameTo("Sture", 17);
        
        // Assert
        result.Should().Be("Child");
    }
    
    [Fact]
    public void CheckName_WhenNameIsKalle_ReturnsTrue()
    {
        // Arrange
        var sut = new NameThing();
        
        // Act
        var result = sut.ChangeNameTo("Kalle", 20);
        
        // Assert
        //check if result is string
        result.Should().BeOfType<string>();
    }
    
    
}