// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using System;
using System.Linq;

namespace UCI_Adult.Model
{
    [CustomMappingFactoryAttribute(nameof(LabelMapping))]
    public class LabelMapping : CustomMappingFactory<LabelMappingInput, LabelMappingOutput>
    {
        // This is the custom mapping. We now separate it into a method, so that we can use it both in training and in loading.
        public static void Mapping(LabelMappingInput input, LabelMappingOutput output)
        {
            output.Prediction = input.label.GetValues().ToArray().First() == 1;

            output.Score = input.probabilities.GetValues().ToArray();
        }
        // This factory method will be called when loading the model to get the mapping operation.
        public override Action<LabelMappingInput, LabelMappingOutput> GetMapping()
        {
            return Mapping;
        }
    }
    public class LabelMappingInput
    {
        [ColumnName("label")]
        public VBuffer<Int64> label;

        [ColumnName("probabilities")]
        public VBuffer<float> probabilities;
    }
    public class LabelMappingOutput
    {
        // ColumnName attribute is used to change the column name from
        // its default value, which is the name of the field.
        [ColumnName("PredictedLabel")]
        public Boolean Prediction { get; set; }
        public float[] Score { get; set; }
    }
}
