using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Anonymus";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1,2,3,4,5,6,7,8,56 };
    }
}
