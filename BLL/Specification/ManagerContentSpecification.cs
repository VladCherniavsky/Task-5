using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
    public class ManagerContentSpecification:IContentSpecification
    {
        private readonly string _managerName;

        public ManagerContentSpecification(string managerName)
        {
            _managerName = managerName;
        }

        public IEnumerable<ViewContent> SatisfiedBy(IEnumerable<ViewContent> content)
        {
            return !String.IsNullOrEmpty(_managerName) ? content.Where(x => x.ManagerName == _managerName) : content;
        }
    }
}
