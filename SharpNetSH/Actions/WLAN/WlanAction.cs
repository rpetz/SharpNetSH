using System;

namespace Ignite.SharpNetSH.WLAN
{
    internal class WlanAction : IWlanAction, IAction
    {
        private bool _initialized;
        private IExecutionHarness _harness;
        private String _priorText;

        private WlanAction()
        {
            
        }

        public string ActionName { get { return "wlan"; } }

        public void Initialize(string priorText, IExecutionHarness harness)
        {
            _initialized = true;
            _priorText = priorText + " " + ActionName;
            _harness = harness;
        }

        internal static IWlanAction CreateAction(String priorText, IExecutionHarness harness)
        {
            var action = new WlanAction();
            action.Initialize(priorText, harness);
            return action;
        }

        public IAddAction Add
        {
            get
            {
                if(!_initialized)
                    throw new Exception("Actions must be initialized prior to use.");
                return ActionProxy<IAddAction>.Create("add", _priorText, _harness);
            }
        }

        public IDeleteAction Delete 
        {
            get
            {
                if (!_initialized)
                    throw new Exception("Actions must be initialized prior to use.");
                return ActionProxy<IDeleteAction>.Create("delete", _priorText, _harness);
            }
        }

        public ISetAction Set 
        {
            get
            {
                if (!_initialized)
                    throw new Exception("Actions must be initialized prior to use.");
                return ActionProxy<ISetAction>.Create("set", _priorText, _harness);
            }
        }
    }
}
