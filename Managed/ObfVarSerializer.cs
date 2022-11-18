using System.Collections.Generic;
using System.Xml.Linq;
using ReClassNET.DataExchange.ReClass;
using ReClassNET.Logger;
using ReClassNET.Nodes;

namespace ArxanVar
{
    public class ObfVarSerializer : ICustomNodeSerializer
    {
        private const string XmlType = "Arxan::ObfVar";

        public bool CanHandleNode(BaseNode node) => node is ObfVarNode;

        public bool CanHandleElement(XElement element) => element.Attribute(ReClassNetFile.XmlTypeAttribute)?.Value == XmlType;

        public BaseNode CreateNodeFromElement(XElement element, BaseNode parent, IEnumerable<ClassNode> classes, ILogger logger, CreateNodeFromElementHandler defaultHandler)
        {
            return new ObfVarNode();
        }

        public XElement CreateElementFromNode(BaseNode node, ILogger logger, CreateElementFromNodeHandler defaultHandler)
        {
            return new XElement(
                ReClassNetFile.XmlNodeElement,
                new XAttribute(ReClassNetFile.XmlTypeAttribute, XmlType)
            );
        }
    }
}
