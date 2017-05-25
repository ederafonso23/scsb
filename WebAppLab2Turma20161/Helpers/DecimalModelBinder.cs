using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppLab2Turma20161.Helpers
{
    /// <summary>
    /// Classe responsável pela conversão em tempo de execução 
    /// de strings para valores do tipo decimal, considerando para isto o 
    /// padrão de representação monetária vigente no Brasil.
    /// </summary>
    public class DecimalModelBinder : IModelBinder
    {
        /// <summary>
        /// Realiza o modelbinder
        /// </summary>
        /// <param name="controllerContext">Controller para a requisção</param>
        /// <param name="bindingContext">Contexto do Modelo no qual está vinculado</param>
        /// <returns></returns>
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                    .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                //Converte para a cultura atual do web.config para o tipo decimal
                if (!String.IsNullOrEmpty(valueResult.AttemptedValue))
                {
                    actualValue =
                        Convert.ToDecimal(
                        valueResult.AttemptedValue,
                        CultureInfo.CurrentCulture);
                }
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(
                bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
}