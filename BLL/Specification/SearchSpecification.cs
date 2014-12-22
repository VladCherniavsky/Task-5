using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
    public class SearchSpecification: IContentSpecification
    {
        public string ClientName { get; set; }
        public string ItemName { get; set; }
        public string ManagerName { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<ViewContent> SatisfiedBy(IEnumerable<ViewContent> content)
        {
            return new ClientContentSpecification(ClientName).SatisfiedBy(
                new DateContentSpecification(Date).SatisfiedBy(
                    new ItemContentSpecification(ItemName).SatisfiedBy(
                        new ManagerContentSpecification(ManagerName).SatisfiedBy(content))));
        }
    }
}
