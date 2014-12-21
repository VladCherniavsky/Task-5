using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
    public class ClientContentSpecification: IContentSpecification
    {
        private readonly string _clientName;

        public ClientContentSpecification(string clientname)
        {
            _clientName = clientname;
        }

        public IEnumerable<ViewContent> SatisfiedBy(IEnumerable<ViewContent> content)
        {
            return !String.IsNullOrEmpty(_clientName) ? content.Where(x => x.ClientName == _clientName) : content;
        }
    }
}
