using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Token.Interface;

namespace Token
{
    [ModelBinder(BinderType = typeof(UserClaimsModelBinder))]
    public class UserClaims
    {
        
    }

    public class UserClaimsModelBinder:IModelBinder
    {
        private readonly ITokenService _tokenService;
        public UserClaimsModelBinder(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if(bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));
            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            string value = valueProviderResult.RawValue.ToString()??"";
            throw new NotImplementedException();
        }
    }
}
