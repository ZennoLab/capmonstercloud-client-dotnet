using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Zennolab.CapMonsterCloud.Validation
{
    internal static class TaskValidator
    {
        internal static void ValidateObjectIncludingInternals(object obj)
        {
            var results = new List<ValidationResult>();

            var properties = obj.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(p => p.GetCustomAttributes(typeof(ValidationAttribute), true).Any())
                .ToList();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                var attributes = property.GetCustomAttributes(typeof(ValidationAttribute), true)
                    .Cast<ValidationAttribute>();

                foreach (var attribute in attributes)
                {
                    var context = new ValidationContext(obj)
                    {
                        MemberName = property.Name
                    };

                    var result = attribute.GetValidationResult(value, context);
                    if (result != ValidationResult.Success)
                    {
                        results.Add(result);
                    }
                }
            }

            if (results.Any())
            {
                throw new AggregateException(results.Select(r => new ValidationException(r.ErrorMessage)));
            }
        }
    }
}
