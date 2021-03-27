using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmainD.Models
{
    class ActionHistory
    {
        private readonly Stack<IAction> actionHistory = new Stack<IAction>();

        public IEnumerable<IAction> Actions { get { return actionHistory.ToArray(); } }

        public int Turn { get { return actionHistory.Count + 1; } }

        public void Add(IAction action)
        {
            actionHistory.Push(action);
        }

        public void Remove()
        {
            actionHistory.Pop();
        }

        internal void Clear()
        {
            actionHistory.Clear();
        }

        public void LoadFromJsonSting(string json)
        {
            var setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            actionHistory.Clear();

            foreach (var action in JsonConvert.DeserializeObject<IAction[]>(json, setting))
            {
                actionHistory.Push(action);
            }
        }

        public string GetJson()
        {
            var setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return JsonConvert.SerializeObject(Actions, setting);
        }
    }
}
