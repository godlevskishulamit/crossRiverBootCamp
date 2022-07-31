using System;
using System.Reflection;

namespace CoronaApp.Api.Controllers;

public static class CheckingNull
{
    public static Boolean checkNull(object obj)
    {
        PropertyInfo propinf;
        var properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            propinf = property;
            if (Nullable.GetUnderlyingType(property.PropertyType) == null)
            {
                if (property.GetValue(obj) == null)
                    return true;
            }
        }
        return false;
    }

}
