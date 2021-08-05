using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyIDML.Core
{
    public class TrainDataModel
    {

        [LoadColumn(0)]
        public string Text { get; set; }

        [LoadColumn(1)]
        public bool IsID { get; set; }
    }
}
