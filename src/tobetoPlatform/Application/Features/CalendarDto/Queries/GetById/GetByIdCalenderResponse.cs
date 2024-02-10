using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendar.Queries.GetById;
public class GetByIdCalenderResponse
{
    public DateTime StartDate { get; set; }
    public string SessionName { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
}
