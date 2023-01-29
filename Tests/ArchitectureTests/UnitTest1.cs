using NetArchTest.Rules;

namespace ArchitectureTests;

public class UnitTest1
{
    private const string DomainNamespace = "Domain";
    private const string ApplicationNamespace = "Application";
    private const string InfrastructureNamespace = "Infrastructure";
    private const string PresentationNamespace = "Presentation";
    
    [Fact]
    public void Domain_Should_Not_Have_DependencyOnOtherProjects()
    {
        // arrange
        var assembly = typeof(ComeSocial.Domain.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace
        };

        // act 
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // assert
        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void Handlers_Should_Have_DependencyOnDomain()
    {
        // arrange
        var assembly = typeof(ComeSocial.Domain.AssemblyReference).Assembly;
        // act
        var testResult = Types.InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        // assert
        
        Assert.True(testResult.IsSuccessful);
    }
    
    [Fact]
    public void Application_Should_Not_Have_DependencyOnOtherProjects()
    {
        // arrange
        var assembly = typeof(ComeSocial.Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace
        };

        // act 
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // assert
        Assert.True(testResult.IsSuccessful);
    }
    [Fact]
    public void Infrastructure_Should_Not_Have_DependencyOnOtherProjects()
    {
        // arrange
        var assembly = typeof(ComeSocial.Infrastructure.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            PresentationNamespace
        };

        // act 
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // assert
        Assert.True(testResult.IsSuccessful);
    }

    public void Controllers_Should_Have_DependencyOnMediatR()
    {
        // arrange
        var assembly = typeof(ComeSocial.Api.AssemblyReference).Assembly;
        

        // act 
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .HaveDependencyOn("MediatR")
            .GetResult();
            

        // assert
        Assert.True(testResult.IsSuccessful);
    }
}