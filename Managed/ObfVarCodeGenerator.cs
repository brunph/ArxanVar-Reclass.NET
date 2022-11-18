using ReClassNET.CodeGenerator;
using ReClassNET.Logger;
using ReClassNET.Nodes;

namespace ArxanVar
{
    class ObfVarCodeGenerator : CustomCppCodeGenerator
    {
        public override bool CanHandle(BaseNode node)
        {
            return node is ObfVarNode;
        }

        public override BaseNode TransformNode(BaseNode node)
        {
            return node;
        }

        public override string GetTypeDefinition(BaseNode node, GetTypeDefinitionFunc defaultGetTypeDefinitionFunc, ResolveWrappedTypeFunc defaultResolveWrappedTypeFunc, ILogger logger)
        {
            return $"Obf32";
        }
    }
}
