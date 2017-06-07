using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ignite.SharpNetSH.HTTP;

namespace Ignite.SharpNetSH.WLAN
{
    class WlanAction : IWlanAction, IAction
    {
        private String _priorText;
        private IExecutionHarness _harness;
        private Boolean _initialized;

        public string ActionName { get { return "wlan"; } }

        public WlanAction()
        {
            
        }

        internal static IWlanAction CreateAction(String priorText, IExecutionHarness harness)
        {
            var action = new WlanAction();
            action.Initialize(priorText, harness);
            return action;
        }

        
        public IShowAction Show
        {
            get
            {
                if (!_initialized)
                    throw new Exception("Actions must be initialized prior to use.");

                return ActionProxy<IShowAction>.Create("show", _priorText, _harness);
            }
        }

        public void Initialize(String priorText, IExecutionHarness harness)
        {
            _harness = harness;
            _priorText = priorText + " " + ActionName;
            _initialized = true;
        }
    }
}
