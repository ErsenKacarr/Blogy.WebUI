﻿using Blogy.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        void TChangeToTrueByWriter(int id);
        void TChangeToFalseByWriter(int id);
    }
}
