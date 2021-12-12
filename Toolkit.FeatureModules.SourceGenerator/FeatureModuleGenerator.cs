using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace Toolkit.FeatureModules.SourceGenerator;

[Generator]
public class FeatureModuleGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Add the marker attribute to the compilation
        context.RegisterPostInitializationOutput(ctx => ctx.AddSource(
            "FeatureModuleAttribute.g.cs",
            SourceText.From(SourceGenerationHelper.Attribute, Encoding.UTF8)));
    }
}

public static class SourceGenerationHelper
{
    public const string Attribute = @"
        namespace Toolkit.FeatureModules;
        
        [System.AttributeUsage(System.AttributeTargets.Enum)]
        public class Toolkit.FeatureModuleAttribute : System.Attribute
        {
        }
        ";
}
