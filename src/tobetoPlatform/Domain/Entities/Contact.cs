using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Contact : Entity<int>
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
 