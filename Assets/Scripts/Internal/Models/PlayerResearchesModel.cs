using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;

namespace Internal.Models
{
    public class PlayerResearchesModel : Model
    {
        private HashSet<IReserchable> _researched = new HashSet<IReserchable>();

        public void AddResearchedResource(IReserchable type)
        {
            _researched.Add(type);
        }

        public bool IsResearched(IReserchable type)
        {
            return _researched.Contains(type);
        }
    }
}