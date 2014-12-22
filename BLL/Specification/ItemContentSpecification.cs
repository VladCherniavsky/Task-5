using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
    public  class ItemContentSpecification: IContentSpecification
    {
        private readonly string _itemName;

        public ItemContentSpecification(string itemName)
        {
            _itemName = itemName;
        }

        public IEnumerable<ViewContent> SatisfiedBy(IEnumerable<ViewContent> content)
        {
            return !String.IsNullOrEmpty(_itemName) ? content.Where(x => x.ItemName.Contains(_itemName)) : content;
        }
    }
}
