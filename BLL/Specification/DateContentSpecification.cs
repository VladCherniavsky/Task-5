using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
    public  class DateContentSpecification:IContentSpecification
    
    {
        private readonly DateTime _dateTime;

        public DateContentSpecification(DateTime date)
        {
            _dateTime = date;
        }
        public IEnumerable<ViewContent> SatisfiedBy(IEnumerable<ViewContent> content)
        {

            if (!(_dateTime == default(DateTime)))
            {
                return content.Where(x => x.Date.ToShortDateString() == _dateTime.ToShortDateString());
            }
            return content;
        }
    }
}
