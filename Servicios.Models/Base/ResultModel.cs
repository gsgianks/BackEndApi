using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Models.Base
{
    public class ResultModel<T, J> : AnswerModel
    {
        public T Item { get; set; }
        public J ItemOptional { get; set; }
    }
}
