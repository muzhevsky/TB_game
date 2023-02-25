using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;

namespace Internal.Models
{
    public class PlayerResearchesModel : Model
    {
        private HashSet<IResearchableView> _researched = new HashSet<IResearchableView>();

        public void AddResearchedResource(IResearchableView type)
        {
            _researched.Add(type);
        }

        public bool IsResearched(IResearchableView type)
        {
            return _researched.Contains(type);
        }
    }
}