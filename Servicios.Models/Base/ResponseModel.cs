using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Models.Base
{
    public class ResponseModel<T>: ResultBaseModel
    {
        public ResponseModel()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }
    }
}
