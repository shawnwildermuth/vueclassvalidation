using System.Collections;
using System.Collections.Generic;

namespace VueClassValidation.Data.Entities
{
  public class Venue
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    public Address Address { get; set; }
    public ICollection<Show>  Shows { get; set; }
  }
}