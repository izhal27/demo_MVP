using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CommonServices
{
   public class ModelDataAnnotationCheck : IModelDataAnnotationCheck
   {
      public void ValidateModel<TDomainModel>(TDomainModel domainModel)
      {
         var validationResultList = new List<ValidationResult>();
         ValidationContext validationContext = new ValidationContext(domainModel);
         StringBuilder stringBuilder = new StringBuilder();

         if (!Validator.TryValidateObject(instance: domainModel, validationContext: validationContext,
                                          validationResults: validationResultList, validateAllProperties: true))
         {
            foreach (var validationResult in validationResultList)
            {
               stringBuilder.Append(validationResult.ErrorMessage)
                            .AppendLine();
            }
         }

         if (validationResultList.Count > 0)
         {
            throw new ArgumentException(stringBuilder.ToString());
         }
      }
   }
}
