using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartesianTools
{
    public class RenderedMap
    {
        private readonly IEnumerable<string> _map;

        public RenderedMap(IEnumerable<string> map)
        {
            _map = map;
        }

        public override string ToString() => string.Join(Environment.NewLine, _map);

        public string[] GetArray() => _map as string[] ?? _map.ToArray();
        public List<string> GetList() => _map as List<string> ?? _map.ToList();
        public string GetString() => ToString();

        public RenderedMap Clone() => MemberwiseClone() as RenderedMap;
    }
}
