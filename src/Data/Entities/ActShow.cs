﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueClassValidation.Data.Entities
{
  public class ActShow
  {
    public int ActId { get; set; }
    public Act Act { get; set; }
    public int ShowId { get; set; }
    public Show Show { get; set; }
  }
}
