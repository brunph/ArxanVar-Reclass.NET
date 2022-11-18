using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ReClassNET.Forms;
using ReClassNET.Memory;
using ReClassNET.Nodes;
using ReClassNET.Plugins;
using ReClassNET.UI;

namespace ArxanVar
{
	public class ArxanVarExt : Plugin
	{
		private IPluginHost host;

		public override Image Icon => null;

		public override bool Initialize(IPluginHost host)
		{
			this.host = host;

			return true;
		}

		public override void Terminate()
		{
			host = null;
		}

        public override CustomNodeTypes GetCustomNodeTypes()
        {
            return new CustomNodeTypes
            {
                CodeGenerator = new ObfVarCodeGenerator(),
                Serializer = new ObfVarSerializer(),
                NodeTypes = new[] { typeof(ObfVarNode) }
            };
        }
    }
}
